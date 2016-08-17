using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreyHound.Dto.Classifieds;
using GreyHound.Dto.Dogs;
using System.Data.Entity;
using GreyHound.Models;
using System.Threading.Tasks;
using GreyHound.Models.Enums;
using GreyHound.Dto.Common;
using System.Data.SqlClient;
using System.ComponentModel;
using GreyHound.Models.Classifieds;
using System.Net.Http;
using System.Net;
using System.Web.Http.Results;
using GreyHound.Dto.Users;
using System.Web.Http;


namespace GreyHound.WebApplication.Controllers.Classifieds
{
    public class ClassifiedService : IClassifiedService
    {
        private readonly GreyHoundContext _dbContext;

        public ClassifiedService()
        {
            _dbContext = new GreyHoundContext();
        }

        public ClassifiedService(GreyHoundContext context)
        {
            _dbContext = context;
        }

        public class AddCountry
        {
            public int CountryId { get; set; }
            public int AdsCount { get; set; }
        }

        public async Task<ClassifiedUserStatDto> GetClassifiedUserStatsAsync(int userId)
        {
            //get users total adds,character,image and videos counts
            var total = await (from usr in _dbContext.Users
                        .Where(u => u.User_Id == userId)
                               select new ClassifiedUserStatDto()
                               {
                                   ImageCount = usr.MemberType.MemType_ImageCount,
                                   VideoCount = usr.MemberType.MemType_VideoCount,
                                   BalanceAdsCount = usr.MemberType.MemType_AdsCount,
                                   BalanceCharCount = usr.MemberType.MemType_CharCount
                               }).SingleOrDefaultAsync();

            if (total == null)
                throw new HttpResponseException(Services.CommonServices.ResponseExcetion("Invalid User Id"));


            //get first and last day of current month
            //DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //DateTime toDate = fromDate.AddMonths(1).AddDays(-1);
            var pair = Services.CommonServices.GetFirstAndLastDayOfCurrentMonth();
            DateTime fromDate = pair.Key;
            DateTime toDate = pair.Value;

            //get balance for the current month
            var used = await (from adv in _dbContext.Advertisements
                      .Where(ad => ad.Ads_CreatedBy == userId &&
                          ad.Ads_CreatedDate >= fromDate && ad.Ads_CreatedDate <= toDate
                          )
                      .GroupBy(ad => ad.Ads_CreatedBy)
                              select
                              new ClassifiedUserStatDto()
                              {
                                  BalanceAdsCount = adv.Sum(s => s.Ads_NoOfBumps),
                                  BalanceCharCount = adv.Sum(s => s.Ads_CharCount)
                              }).SingleOrDefaultAsync();

            if (used == null)
            {
                return new ClassifiedUserStatDto
                {
                    ImageCount = total.ImageCount,
                    VideoCount = total.VideoCount,
                    BalanceAdsCount = total.BalanceAdsCount,
                    BalanceCharCount = total.BalanceCharCount
                };
            }


            int remainAds = total.BalanceAdsCount - used.BalanceAdsCount;
            int remainChar = total.BalanceCharCount - used.BalanceCharCount;

            return new ClassifiedUserStatDto
            {
                ImageCount = total.ImageCount,
                VideoCount = total.VideoCount,
                BalanceAdsCount = remainAds,
                BalanceCharCount = remainChar
            };

        }

        public async Task<ClassifiedStatsDto> GetClassifiedStatsAsync()
        {

            #region Get Ads Count

            int pupAds = 0, dogAds = 0, prvtAds = 0, busnAds = 0;

            //get pup sale ads count
            List<CountryGroupDto> pupCountryList = await GetPupSalesCountriesAsync();
            foreach(var item in pupCountryList)
            {
                pupAds += item.AdsCount;
            }

            //get dog sale ads count
            List<CountryGroupDto> dogCountryList = await GetDogSalesCountriesAsync();
            foreach (var item in dogCountryList)
            {
                dogAds += item.AdsCount;
            }

            //get private ads count
            string types = ((int)ClassifiedSection.PrivateSale).ToString() + "," + ((int)ClassifiedSection.PrivateWanted).ToString();
            List<CountryGroupDto> prvtCountryList = await GetMiscSalesCountriesAsync(types);
            foreach (var item in prvtCountryList)
            {
                prvtAds += item.AdsCount;
            }

            //get busines ads count
            types = ((int)ClassifiedSection.BusinessSection).ToString();
            List<CountryGroupDto> busnCountryList = await GetMiscSalesCountriesAsync(types);
            foreach (var item in busnCountryList)
            {
                busnAds += item.AdsCount;
            }

            #endregion

            #region Get Views Count
            #endregion

            return new ClassifiedStatsDto
            {
                OnlinePupAds = pupAds,
                OnlineDogAds = dogAds,
                OnlinePrvtAds = prvtAds,
                OnlineBsnAds = busnAds
            };
        }

        #region Pups Sales

        #region Master Data

        public async Task<List<KennelInfoDto>> GetKennelsByCountryGroupIdAsync(int countryGroupId)
        {
            //Services.CommonServices cs = new Services.CommonServices();
            //int expireDays = cs.GetClassifiedExpireDays();

            //DateTime dateTo = DateTime.Now;
            //DateTime dateFrom = dateTo.AddDays(-1 * expireDays);

            DateTime dateFrom = GetClassifiedExpireDate();

            var kennels = await (from l in _dbContext.LitterSales
                                .Where(ls => ls.LitSale_KennelId == countryGroupId &&
                                (ls.Add.Ads_LastModifiedDate >= dateFrom && ls.Add.Ads_LastModifiedDate <= DateTime.Now)
                                )
                                 select new KennelInfoDto()
                                 {
                                     KennelId = l.Kennel.Ken_Id,
                                     KennelName = l.Kennel.Ken_Name,
                                 }).Distinct().ToListAsync();

            return kennels;
        }

        public List<SireDto> GetSiresAsync()
        {
            List<SireDto> list = new List<SireDto>();

            SireDto dto = new SireDto();
            dto.SireId = 1;
            dto.SireName = "Ace Hi Rumble";
            list.Add(dto);
            SireDto dto2 = new SireDto();
            dto2.SireId = 2;
            dto2.SireName = "Droopys Jet";
            list.Add(dto2);

            return list;
        }

        #endregion

        public async Task<List<CountryGroupDto>> GetPupSalesCountriesAsync()
        {
            try
            {
                //Services.CommonServices cs = new Services.CommonServices();
                //int expireDays = cs.GetClassifiedExpireDays();

                //DateTime dateTo = DateTime.Now;
                //DateTime dateFrom = dateTo.AddDays(-1 * expireDays);
                //var FromDate = new SqlParameter("dateFrom", dateFrom);
                //var ToDate = new SqlParameter("dateTo", dateTo);

                //List<CountryGroupDto> countryList = await _dbContext.Database.SqlQuery<CountryGroupDto>("Classifieds_SP_Get_LitterSaleCountries @DateFrom,@DateTo", FromDate, ToDate).ToListAsync();
                //return countryList;
                DateTime dateFrom = GetClassifiedExpireDate();

                IQueryable<AddCountry> addCountries = (from adv in _dbContext.Advertisements
                                                       join ls in _dbContext.LitterSales on adv.Ads_Id equals ls.LitSale_AddId
                                                       where adv.Ads_IsDeleted == false &&
                                                       adv.Ads_LastModifiedDate >= dateFrom &&
                                                       adv.Ads_LastModifiedDate <= DateTime.Now
                                                       group adv by adv.Ads_CountryId into grouped
                                                       select new AddCountry
                                                       {
                                                          CountryId = grouped.Key,
                                                           AdsCount = grouped.Count()
                                                       });
                #if DEBUG
                    var list = addCountries.ToList();
                #endif

                return await QueryMethod(addCountries);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<CountryDto>> GetPupSalesCountryGroupsAsync(int groupId)
        {
            try
            {
                //Services.CommonServices cs = new Services.CommonServices();
                //int expireDays = cs.GetClassifiedExpireDays();

                //DateTime dateTo = DateTime.Now;
                //DateTime dateFrom = dateTo.AddDays(-1 * expireDays);
                //var FromDate = new SqlParameter("dateFrom", dateFrom);
                //var ToDate = new SqlParameter("dateTo", dateTo);
                //var GroupId = new SqlParameter("groupId", groupId);

                //List<CountryDto> countryList = await _dbContext.Database.SqlQuery<CountryDto>("Classifieds_SP_Get_LitterSaleCountriesById @DateFrom,@DateTo,@GroupId", FromDate, ToDate, GroupId).ToListAsync();
                //return countryList;

                //get country wise adds count
                DateTime dateFrom = GetClassifiedExpireDate();

                IQueryable<AddCountry> addCoutns = from adv in _dbContext.Advertisements
                                                   join ls in _dbContext.LitterSales on adv.Ads_Id equals ls.LitSale_AddId
                                                   where adv.Ads_IsDeleted == false &&
                                                   adv.Ads_LastModifiedDate >= dateFrom &&
                                                   adv.Ads_LastModifiedDate <= DateTime.Now
                                                   group adv by adv.Ads_CountryId into grouped
                                                   select new AddCountry
                                                   {
                                                        CountryId = grouped.FirstOrDefault().Ads_CountryId,
                                                        AdsCount = grouped.Count()
                                                   };

                return await QueryMethodCountryWise(addCoutns, groupId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<PupsSaleDto>> GetLitterAdsAsync(SearchPupSalesDto dto)
        {
            try
            {
                Services.CommonServices cs = new Services.CommonServices();
                int expireDays = cs.GetClassifiedExpireDays();

                DateTime dateTo = DateTime.Now;
                DateTime dateFrom = dateTo.AddDays(-1 * expireDays);

                //Services.CommonServices cs = new Services.CommonServices();
                var query = (from ls in _dbContext.LitterSales
                          .Where(c => c.Add.Ads_CountryId == dto.CountryId &&
                          (c.Add.Ads_LastModifiedDate >= dateFrom && c.Add.Ads_LastModifiedDate <= dateTo)
                          && c.Add.Ads_IsDeleted == false)

                             select new PupsSaleDto()
                             {
                                 AddId = ls.LitSale_AddId,
                                 LittlerSaleId = ls.LitSale_Id,
                                 DamId = ls.LitSale_DamId,
                                 DamName = ls.Dam.Dog_Name,
                                 SireId = ls.LitSale_SireId,
                                 SireName = ls.Sire.Dog_Name,
                                 DateOfBirth = ls.LitSale_DateOfBirth,
                                 Price = ls.LitSale_Price,
                                 Comment = ls.Add.Ads_Description,
                                 AddCountryId = ls.Add.Ads_CountryId,
                                 AddCountryName = ls.Add.Country.Country_Name,
                                 ContactName = ls.Add.Ads_ContactName,
                                 Address = ls.Add.Ads_Address,
                                 Phone = ls.Add.Ads_Contact,
                                 Email = ls.Add.Ads_Email,
                                 KennelId = ls.Kennel.Ken_Id,
                                 KennelName = ls.Kennel.Ken_Name,
                                 PostedUserId = ls.Add.CreatedUser.User_Id,
                                 PostedBy = ls.Add.CreatedUser.User_FirstName + " " + ls.Add.CreatedUser.User_LastName,
                                 PostedDate = ls.Add.Ads_CreatedDate,
                                 RePostedDate = ls.Add.Ads_LastModifiedDate
                             });

                if (dto.KennelId.HasValue)
                    query = query.Where(c => c.KennelId == dto.KennelId);

                //for the moment this is commented
                //if (dto.SireId.HasValue)
                //    query = query.Where(c => c.SireId == dto.SireId);

                var ads = await query.ToListAsync();

                List<ImageDto> rslt;
                foreach (var item in ads)
                {
                    rslt = await cs.GetImagesAsync((int)ImageTypes.LitterSale, item.LittlerSaleId);
                    item.ImageUrls = rslt;

                    //check for deletable ads
                    if (item.PostedUserId == dto.UserId)
                        item.Deletable = true;
                    else
                        item.Deletable = false;
                }

                return ads;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region Dog Sales

        #region Master Data

        public async Task<List<DogSaleTypesDto>> GetDogSaleTypesAsync()
        {
            var types = await _dbContext.DogSaleType.Select(d =>
                new DogSaleTypesDto()
                {
                    SaleTypeId = d.SaleType_Id,
                    SaleTypeName = d.SaleType_Name,
                    HasPrice = d.SaleType_HasPrice
                }).ToListAsync();
            return types;
        }

        public async Task<List<DogSalePricesDto>> GetPricesAsync()
        {
            var prices = await _dbContext.ClassifiedPrices.Select(c =>
                new DogSalePricesDto()
                {
                    PriceId = c.Price_Id,
                    DisplayValue = c.Price_DisplayValue,
                    ValueFrom = c.Price_FromValue,
                    ValueTo = c.Price_ToValue
                }).ToListAsync();
            return prices;
        }

        #endregion

        public async Task<List<CountryGroupDto>> GetDogSalesCountriesAsync()
        {
            try
            {
                //Services.CommonServices cs = new Services.CommonServices();
                //int expireDays = cs.GetClassifiedExpireDays();

                //DateTime dateTo = DateTime.Now;
                //DateTime dateFrom = dateTo.AddDays(-1 * expireDays);
                //var FromDate = new SqlParameter("dateFrom", dateFrom);
                //var ToDate = new SqlParameter("dateTo", dateTo);

                //List<CountryGroupDto> countryList = await _dbContext.Database.SqlQuery<CountryGroupDto>("Classifieds_SP_Get_DogSaleCountries @DateFrom,@DateTo", FromDate, ToDate).ToListAsync();
                //return countryList;
                DateTime dateFrom = GetClassifiedExpireDate();

                IQueryable<AddCountry> addCountries = (from adv in _dbContext.Advertisements
                                                       join ds in _dbContext.DogsSales on adv.Ads_Id equals ds.DogSale_AddId
                                                       where adv.Ads_IsDeleted == false &&
                                                       adv.Ads_LastModifiedDate >= dateFrom &&
                                                       adv.Ads_LastModifiedDate <= DateTime.Now
                                                       group adv by adv.Ads_CountryId into grouped
                                                       select new AddCountry
                                                       {
                                                           CountryId = grouped.FirstOrDefault().Ads_CountryId,
                                                           AdsCount = grouped.Count()
                                                       });

                return await QueryMethod(addCountries);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<CountryDto>> GetDogSalesCountryGroupsAsync(int groupId)
        {
            try
            {
                //Services.CommonServices cs = new Services.CommonServices();
                //int expireDays = cs.GetClassifiedExpireDays();

                //DateTime dateTo = DateTime.Now;
                //DateTime dateFrom = dateTo.AddDays(-1 * expireDays);
                //var FromDate = new SqlParameter("dateFrom", dateFrom);
                //var ToDate = new SqlParameter("dateTo", dateTo);
                //var GroupId = new SqlParameter("groupId", groupId);

                //List<CountryDto> countryList = await _dbContext.Database.SqlQuery<CountryDto>("Classifieds_SP_Get_DogSaleCountriesById @DateFrom,@DateTo,@GroupId", FromDate, ToDate, GroupId).ToListAsync();
                //return countryList;
                
                //get country wise adds count
                DateTime dateFrom = GetClassifiedExpireDate();

                IQueryable<AddCountry> addCoutns = from adv in _dbContext.Advertisements
                                                   join ds in _dbContext.DogsSales on adv.Ads_Id equals ds.DogSale_AddId
                                                   where adv.Ads_IsDeleted == false &&
                                                   adv.Ads_LastModifiedDate >= dateFrom &&
                                                   adv.Ads_LastModifiedDate <= DateTime.Now
                                                   group adv by adv.Ads_CountryId into grouped
                                                   select new AddCountry
                                                   {
                                                       CountryId = grouped.FirstOrDefault().Ads_CountryId,
                                                       AdsCount = grouped.Count()
                                                   };

                return await QueryMethodCountryWise(addCoutns, groupId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<DogSaleDto>> GetDogAdsAsync(SearchDogSaleDto dto)
        {
            try
            {
                Services.CommonServices cs = new Services.CommonServices();
                int expireDays = cs.GetClassifiedExpireDays();

                DateTime dateTo = DateTime.Now;
                DateTime dateFrom = dateTo.AddDays(-1 * expireDays);


                var query = (from ds in _dbContext.DogsSales
                          .Where(c => c.Add.Ads_CountryId == dto.CountryId &&
                          (c.Add.Ads_LastModifiedDate >= dateFrom && c.Add.Ads_LastModifiedDate <= dateTo)
                          && c.Add.Ads_IsDeleted == false)

                             select new DogSaleDto()
                             {
                                 AddId = ds.DogSale_AddId,
                                 DogSaleId = ds.DogSale_Id,
                                 SireId = ds.Dog.Dog_SireId,
                                 SireName = ds.Dog.Sire.Dog_Name,
                                 ColorId = ds.Dog.Dog_ColorId,
                                 Color = ds.Dog.DogColor.DogColor_Name,
                                 DamId = ds.Dog.Dog_DamId,
                                 DamName = ds.Dog.Dam.Dog_Name,
                                 DOB = ds.Dog.Dog_DateOfBirth,
                                 Gender = (Gender)ds.Dog.Dog_Gender,
                                 CurrencyId = ds.DogSale_CurrencyId,
                                 Currency = ds.Currency.Currency_Name,
                                 Price = ds.DogSale_Price,
                                 Comment = ds.Add.Ads_Description,
                                 AddCountryId = ds.Add.Ads_CountryId,
                                 AddCountryName = ds.Add.Country.Country_Name,
                                 Contact = ds.Add.Ads_ContactName,
                                 Address = ds.Add.Ads_Address,
                                 Phone = ds.Add.Ads_Contact,
                                 Email = ds.Add.Ads_Email,
                                 PostedUserId = ds.Add.CreatedUser.User_Id,
                                 PostedBy = ds.Add.CreatedUser.User_FirstName + " " + ds.Add.CreatedUser.User_LastName,
                                 PostedDate = ds.Add.Ads_CreatedDate
                             });

                if (dto.Gender.HasValue)
                    query = query.Where(c => c.Gender == (Gender)dto.Gender);

                //for the moment this is commented
                //if (dto.SireId.HasValue)
                //    query = query.Where(c => c.SireId == dto.SireId);

                if (dto.PriceId.HasValue)
                {
                    //get price range                    
                    var result = await (from p in _dbContext.ClassifiedPrices where p.Price_Id == dto.PriceId select new { p.Price_FromValue, p.Price_ToValue }).ToListAsync();
                    int? fromVal = null, toVal = null;
                    foreach (var item in result)
                    {
                        fromVal = Convert.ToInt32(item.Price_FromValue);
                        toVal = Convert.ToInt32(item.Price_ToValue);
                    }

                    if (fromVal.HasValue && toVal.HasValue)
                    {
                        query = query.Where(p => p.Price >= fromVal && p.Price <= toVal);
                    }
                }

                var ads = await query.ToListAsync();

                List<ImageDto> rslt;
                foreach (var item in ads)
                {
                    rslt = await cs.GetImagesAsync((int)ImageTypes.DogSale, item.DogSaleId);
                    item.ImageUrls = rslt;

                    //check for deletable ads
                    if (item.PostedUserId == dto.UserId)
                        item.Deletable = true;
                    else
                        item.Deletable = false;
                }

                return ads;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region Private Sales

        public async Task<List<SectionAddsCountDto>> GetSectionAdsCountAsync(int groupId)
        {
            try
            {
                Services.CommonServices cs = new Services.CommonServices();
                int expireDays = cs.GetClassifiedExpireDays();

                DateTime dateTo = DateTime.Now;
                DateTime dateFrom = dateTo.AddDays(-1 * expireDays);
                var FromDate = new SqlParameter("dateFrom", dateFrom);
                var ToDate = new SqlParameter("dateTo", dateTo);
                var GroupId = new SqlParameter("groupId", groupId);

                //GET PRIVATE-WANTED ADDS COUNT
                var pWanted = await (_dbContext.MiscellaneousSales
                               .Where(a => a.MiscSale_SaleTypeId == (int)ClassifiedSection.PrivateWanted &&
                               a.Add.Country.Country_GroupId == groupId &&
                               a.Add.Ads_LastModifiedDate >= dateFrom && a.Add.Ads_LastModifiedDate <= dateTo
                               && a.Add.Ads_IsDeleted == false)

                               .GroupBy(p => new { p.MiscSale_Id })
                               .Select(g => new { adsCount = g.Count() })).ToListAsync();

                ////GET PRIVATE-FOR SALE ADDS COUNT
                var pSale = await (_dbContext.MiscellaneousSales
                               .Where(a => a.MiscSale_SaleTypeId == (int)ClassifiedSection.PrivateSale &&
                               a.Add.Country.Country_GroupId == groupId &&
                               a.Add.Ads_LastModifiedDate >= dateFrom && a.Add.Ads_LastModifiedDate <= dateTo
                               && a.Add.Ads_IsDeleted == false)
                               .GroupBy(p => new { p.MiscSale_Id })
                               .Select(g => new { adsCount = g.Count() })).ToListAsync();

                ////SET ALL ADDS-COUNT
                int wantedAds = 0, saleAds = 0, totAds = 0;
                foreach (var item in pWanted)
                {
                    wantedAds = Convert.ToInt32(item.adsCount);
                    totAds = Convert.ToInt32(item.adsCount);
                }

                foreach (var item in pSale)
                {
                    saleAds = Convert.ToInt32(item.adsCount);
                    totAds += Convert.ToInt32(item.adsCount);
                }

                var type = typeof(ClassifiedSection);

                SectionAddsCountDto dto = new SectionAddsCountDto();
                dto.SectionId = null;
                dto.SectionName = "ALL";
                dto.AdsCount = totAds;

                SectionAddsCountDto dto1 = new SectionAddsCountDto();
                dto1.SectionId = (int)ClassifiedSection.PrivateSale;
                dto1.SectionName = ((DescriptionAttribute)type.GetMember(ClassifiedSection.PrivateSale.ToString())[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description;
                dto1.AdsCount = saleAds;

                SectionAddsCountDto dto2 = new SectionAddsCountDto();
                dto2.SectionId = (int)ClassifiedSection.PrivateWanted;
                dto2.SectionName = ((DescriptionAttribute)type.GetMember(ClassifiedSection.PrivateWanted.ToString())[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description;
                dto2.AdsCount = wantedAds;

                List<SectionAddsCountDto> list = new List<SectionAddsCountDto>();
                SectionAddsCountDto[] dtos = new SectionAddsCountDto[] { dto, dto1, dto2 };
                list.AddRange(dtos);

                return list;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region Private and Business Sales

        public async Task<List<MiscAddTypesDto>> GetMiscAdsTypes()
        {
            List<MiscAddTypesDto> list = new List<MiscAddTypesDto>();
            var type = typeof(ClassifiedSection);

            foreach (ClassifiedSection items in Enum.GetValues(typeof(ClassifiedSection)))
            {
                MiscAddTypesDto dto = new MiscAddTypesDto();
                var memInfo = type.GetMember(items.ToString());
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)attributes[0]).Description;

                dto.AddTypeId = (int)items;
                dto.AddTypeName = description.ToString();
                list.Add(dto);
            }

            return list;
        }

        public async Task<List<CountryGroupDto>> GetMiscSalesCountriesAsync(string types)
        {
            try
            {
                //Services.CommonServices cs = new Services.CommonServices();
                //int expireDays = cs.GetClassifiedExpireDays();

                //DateTime dateTo = DateTime.Now;
                //DateTime dateFrom = dateTo.AddDays(-1 * expireDays);

                //var FromDate = new SqlParameter("dateFrom", dateFrom);
                //var ToDate = new SqlParameter("dateTo", dateTo);
                //var TypeId = new SqlParameter("TypeId", types);

                //List<CountryGroupDto> countryList = await _dbContext.Database.SqlQuery<CountryGroupDto>("Classifieds_SP_Get_MiscSaleCountries @DateFrom,@DateTo,@TypeId", FromDate, ToDate, TypeId).ToListAsync();
                DateTime dateFrom = GetClassifiedExpireDate();

                IQueryable<AddCountry> addCountries = (from adv in _dbContext.Advertisements
                                                       join msl in _dbContext.MiscellaneousSales on adv.Ads_Id equals msl.MiscSale_AddId
                                                       where adv.Ads_IsDeleted == false &&
                                                       adv.Ads_LastModifiedDate >= dateFrom &&
                                                       adv.Ads_LastModifiedDate <= DateTime.Now
                                                       group adv by adv.Ads_CountryId into grouped
                                                       select new AddCountry
                                                       {
                                                           CountryId = grouped.FirstOrDefault().Ads_CountryId,
                                                           AdsCount = grouped.Count()
                                                       });
                #if DEBUG
                var list = addCountries.ToList();
                #endif

                return await QueryMethod(addCountries);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<CountryDto>> GetMiscSalesCountryGroupsAsync(int groupId, string SectionId)
        {
            try
            {
                //Services.CommonServices cs = new Services.CommonServices();
                //int expireDays = cs.GetClassifiedExpireDays();

                //DateTime dateTo = DateTime.Now;
                //DateTime dateFrom = dateTo.AddDays(-1 * expireDays);
                //var FromDate = new SqlParameter("dateFrom", dateFrom);
                //var ToDate = new SqlParameter("dateTo", dateTo);
                //var GroupId = new SqlParameter("groupId", groupId);
                //var TypeId = new SqlParameter("typeId", SectionId);
                //List<CountryDto> countryList = await _dbContext.Database.SqlQuery<CountryDto>("Classifieds_SP_Get_MiscSaleCountriesById @DateFrom,@DateTo,@GroupId,@TypeId", FromDate, ToDate, GroupId, TypeId).ToListAsync();
                //return countryList;

                //get country wise adds count
                DateTime dateFrom = GetClassifiedExpireDate();

                IQueryable<AddCountry> addCoutns = from adv in _dbContext.Advertisements
                                                   join ms in _dbContext.MiscellaneousSales on adv.Ads_Id equals ms.MiscSale_AddId
                                                   where adv.Ads_IsDeleted == false &&
                                                   adv.Ads_LastModifiedDate >= dateFrom &&
                                                   adv.Ads_LastModifiedDate <= DateTime.Now
                                                   group adv by adv.Ads_CountryId into grouped
                                                   select new AddCountry
                                                   {
                                                       CountryId = grouped.FirstOrDefault().Ads_CountryId,
                                                       AdsCount = grouped.Count()
                                                   };

                return await QueryMethodCountryWise(addCoutns, groupId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<MiscAdsDto>> GetMiscellaneousAdsAsync(SearchMiscAdsDto dto)
        {
            try
            {
                Services.CommonServices cs = new Services.CommonServices();
                int expireDays = cs.GetClassifiedExpireDays();

                DateTime dateTo = DateTime.Now;
                DateTime dateFrom = dateTo.AddDays(-1 * expireDays);


                var query = (from ms in _dbContext.MiscellaneousSales
                          .Where(c => c.Add.Country.Country_GroupId == dto.CountryGroupId &&
                          (c.Add.Ads_LastModifiedDate >= dateFrom && c.Add.Ads_LastModifiedDate <= dateTo)
                          && c.Add.Ads_IsDeleted == false)
                             select new MiscAdsDto()
                             {
                                 AddId = ms.MiscSale_AddId,
                                 MiscAddId = ms.MiscSale_Id,
                                 SaleTypeId = ms.MiscSale_SaleTypeId,
                                 Title = ms.MiscSale_Title,
                                 Description = ms.Add.Ads_Description,
                                 AddCountryId = ms.Add.Ads_CountryId,
                                 AddCountryName = ms.Add.Country.Country_Name,
                                 Contact = ms.Add.Ads_ContactName,
                                 Address = ms.Add.Ads_Address,
                                 Phone = ms.Add.Ads_Contact,
                                 Email = ms.Add.Ads_Email,
                                 PostedUserId = ms.Add.CreatedUser.User_Id,
                                 PostedBy = ms.Add.CreatedUser.User_FirstName + " " + ms.Add.CreatedUser.User_LastName,
                                 PostedDate = ms.Add.Ads_CreatedDate
                             });
                //section id null means return all private ads(private wanted and private sale adds)
                if (dto.SectionId.HasValue)
                    query = query.Where(c => c.SaleTypeId == dto.SectionId);
                else
                    query = query.Where(c => c.SaleTypeId == (int)ClassifiedSection.PrivateSale || c.SaleTypeId == (int)ClassifiedSection.PrivateWanted);


                var ads = await query.ToListAsync();

                List<ImageDto> rslt;
                foreach (var item in ads)
                {
                    rslt = await cs.GetImagesAsync((int)ImageTypes.MiscSale, item.MiscAddId);
                    item.ImageUrls = rslt;

                    //check for deletable ads
                    if (item.PostedUserId == dto.UserId)
                        item.Deletable = true;
                    else
                        item.Deletable = false;
                }

                return ads;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region Save Ads

        public async Task<int?> PostAdvertisementAsync(SaveAddDto dto)
        {
            var entity = new Advertisement
            {

                Ads_Description = dto.Description,
                Ads_ContactName = dto.ContactName,
                Ads_CountryId = dto.CountryId,
                Ads_PostCode = dto.PostCode,
                Ads_City = dto.City,
                Ads_Contact = dto.Phone,
                Ads_Email = dto.Email,
                Ads_Address = dto.Address,
                Ads_NoOfBumps = 1,
                Ads_CharCount = Convert.ToInt16(dto.Description.Length),
                Ads_IsVerified = false,
                Ads_VerifiedDate = null,
                Ads_CreatedBy = dto.UserId,
                Ads_CreatedDate = DateTime.Now,
                Ads_ModifiedBy = dto.UserId,
                Ads_LastModifiedDate = DateTime.Now
            };
            _dbContext.Advertisements.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Ads_Id;
        }

        //save litter add
        public async Task<int?> PostLitterAdsAsync(SaveAddDto addDto, SavePupSaleDto dto)
        {
            int? AddId = await PostAdvertisementAsync(addDto);
            if (AddId.HasValue)
            {
                var LitterEntity = new LitterSale
                {
                    LitSale_AddId = Convert.ToInt32(AddId),
                    LitSale_SireId = dto.SireId,
                    LitSale_DamId = dto.DamId,
                    LitSale_CurrencyId = dto.CurrencyId,
                    LitSale_Price = dto.Price,
                    LitSale_DateOfBirth = dto.DateOfBirth,
                    LitSale_KennelId = dto.KennelId
                };
                _dbContext.LitterSales.Add(LitterEntity);
                await _dbContext.SaveChangesAsync();
                return LitterEntity.LitSale_Id;
            }

            return null;
        }

        //save dog add
        public async Task<int?> PostDogAdsAsync(SaveAddDto addDto, SaveDogSaleDto dto)
        {
            int? AddId = await PostAdvertisementAsync(addDto);
            if (AddId.HasValue)
            {
                var DogEntity = new DogsSale
                {
                    DogSale_AddId = Convert.ToInt32(AddId),
                    DogSale_DogId = dto.DogId,
                    DogSale_SaleTypeId = dto.SaleTypeId,
                    DogSale_CurrencyId = dto.CurrencyId,
                    DogSale_Price = dto.Price
                };
                _dbContext.DogsSales.Add(DogEntity);
                await _dbContext.SaveChangesAsync();
                return DogEntity.DogSale_Id;
            }

            return null;
        }

        //save misc add
        public async Task<int?> PostMiscAdsAsync(SaveAddDto addDto, SaveMiscAdDto dto)
        {
            int? AddId = await PostAdvertisementAsync(addDto);
            if (AddId.HasValue)
            {
                var MiscEntity = new MiscellaneousSale
                {
                    MiscSale_AddId = Convert.ToInt32(AddId),
                    MiscSale_SaleTypeId = dto.SaleTypeId,
                    MiscSale_Title = dto.Title
                };
                _dbContext.MiscellaneousSales.Add(MiscEntity);
                await _dbContext.SaveChangesAsync();
                return MiscEntity.MiscSale_Id;
            }

            return null;
        }
        #endregion

        #region Update Ads

        public async Task<int?> UpdateAdvertisementAsync(UpdateAddDto dto)
        {
            //get advert 
            var addv = _dbContext.Advertisements.Where(a => a.Ads_Id == dto.AddId).FirstOrDefault<Advertisement>();

            if (addv == null)
                return null;

            addv.Ads_Description = dto.Description;
            addv.Ads_ContactName = dto.ContactName;
            addv.Ads_CountryId = dto.CountryId;
            addv.Ads_PostCode = dto.PostCode;
            addv.Ads_City = dto.City;
            addv.Ads_Contact = dto.ContactName;
            addv.Ads_Email = dto.Email;
            addv.Ads_Address = dto.Address;
            addv.Ads_NoOfBumps = addv.Ads_NoOfBumps + 1;
            addv.Ads_CharCount = Convert.ToInt16(addv.Ads_CharCount) + Convert.ToInt16(dto.Description.Length);
            addv.Ads_IsVerified = false;
            addv.Ads_VerifiedDate = null;
            addv.Ads_ModifiedBy = dto.UserId;
            addv.Ads_LastModifiedDate = DateTime.Now;

            //mark entry as modifed
            _dbContext.Entry(addv).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return addv.Ads_Id;
        }

        //update litter add
        public async Task<int?> UpdateLitterAdsAsync(UpdateAddDto addDto, UpdatePupSaleDto dto)
        {
            int? AddId = await UpdateAdvertisementAsync(addDto);
            if (AddId.HasValue)
            {
                //get litter add                 
                var LitAd = _dbContext.LitterSales
                    .Where(l => l.LitSale_Id == dto.SaleId && l.LitSale_AddId == AddId)
                    .FirstOrDefault<LitterSale>();

                if (LitAd == null)
                    return null;

                LitAd.LitSale_SireId = dto.SireId;
                LitAd.LitSale_DamId = dto.DamId;
                LitAd.LitSale_CurrencyId = dto.CurrencyId;
                LitAd.LitSale_Price = dto.Price;
                LitAd.LitSale_DateOfBirth = dto.DateOfBirth;
                LitAd.LitSale_KennelId = dto.KennelId;

                //mark entry as modifed
                _dbContext.Entry(LitAd).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return LitAd.LitSale_Id;
            }

            return null;
        }

        //update dog add
        public async Task<int?> UpdateDogAdsAsync(UpdateAddDto addDto, UpdateDogSaleDto dto)
        {
            int? AddId = await UpdateAdvertisementAsync(addDto);
            if (AddId.HasValue)
            {
                //get dog add                 
                var DogAd = _dbContext.DogsSales
                    .Where(d => d.DogSale_Id == dto.SaleId && d.DogSale_AddId == AddId)
                    .FirstOrDefault<DogsSale>();

                DogAd.DogSale_DogId = dto.DogId;
                DogAd.DogSale_SaleTypeId = dto.SaleTypeId;
                DogAd.DogSale_CurrencyId = dto.CurrencyId;
                DogAd.DogSale_Price = dto.Price;

                //mark entry as modifed
                _dbContext.Entry(DogAd).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return DogAd.DogSale_Id;
            }

            return null;
        }

        //update misc add
        public async Task<int?> UpdateMiscAdsAsync(UpdateAddDto addDto, UpdateMiscAdDto dto)
        {
            int? AddId = await UpdateAdvertisementAsync(addDto);
            if (AddId.HasValue)
            {
                //get misc add                 
                var MiscAd = _dbContext.MiscellaneousSales
                    .Where(m => m.MiscSale_Id == dto.MiscSaleId && m.MiscSale_AddId == AddId)
                    .FirstOrDefault<MiscellaneousSale>();


                MiscAd.MiscSale_SaleTypeId = dto.SaleTypeId;
                MiscAd.MiscSale_Title = dto.Title;

                //mark entry as modifed
                _dbContext.Entry(MiscAd).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return MiscAd.MiscSale_Id;
            }

            return null;
        }
        #endregion

        #region Delete Ads

        public async Task<int?> DeleteAdAsync(DeleteAddDto dto)
        {
            //get advert 
            var addv = _dbContext.Advertisements.Where(a => a.Ads_Id == dto.AddId).FirstOrDefault<Advertisement>();

            if (addv == null)
                return null;

            addv.Ads_IsDeleted = true;
            addv.Ads_DeletedBy = dto.UserId;
            addv.Ads_DeleteComment = dto.Comment;
            addv.Ads_DeletedDate = DateTime.Now;

            //mark entry as modifed
            _dbContext.Entry(addv).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return addv.Ads_Id;
        }

        #endregion

        #region Services

        public async Task<List<CountryGroupDto>> QueryMethod(IQueryable<AddCountry> adv) 
        {
            var addCountries = from advCount in adv                            
                            join cn in _dbContext.Countries
                               on advCount.CountryId equals cn.Country_Id
                               select new
                               {
                                   groupId = cn.Country_GroupId,
                                   adsCount = advCount.AdsCount,
                               }into result                              
                               group result by result.groupId into grouped
                          select new
                          {
                              GroupId = grouped.Key,
                                   Count = grouped.Sum(r=> r.adsCount)
                          } into grpCount
                          join cgp in _dbContext.CountryGroups on grpCount.GroupId equals cgp.Group_Id
                          select new
                          {
                              GroupId = grpCount.GroupId,
                              GroupName = cgp.Group_Name,
                              AdsCount = grpCount.Count
                          };

            #if DEBUG
                var list1 = addCountries.ToList();
            #endif


                var allCountries = from cg in _dbContext.CountryGroups
                                   where !(from ad in addCountries
                                          select ad.GroupId    
                                          ).Contains(cg.Group_Id)
                                   select new { GroupId = cg.Group_Id, GroupName = cg.Group_Name, AdsCount = 0 };

            #if DEBUG
                var list2 = allCountries.ToList();
            #endif


                var Addcounts = addCountries.Union(allCountries);

            #if DEBUG
                var list3 = Addcounts.ToList();
            #endif

                var CountryCount = from cn in _dbContext.Countries
                                   join cg in _dbContext.CountryGroups on cn.Country_GroupId equals cg.Group_Id into result
                                   from rs in result.DefaultIfEmpty()
                                   group rs by rs.Group_Id into grouped
                                   select new
                                   {
                                       GroupId = grouped.FirstOrDefault().Group_Id,
                                       Name = grouped.FirstOrDefault().Group_Name,
                                       CountryCount = grouped.Count()
                                   };

            #if DEBUG
                var list4 = CountryCount.ToList();
            #endif

                var finalResult = await (from ac in Addcounts
                            join cc in CountryCount on ac.GroupId equals cc.GroupId into fr
                            from final in fr.DefaultIfEmpty()
                                  select new CountryGroupDto
                                  {
                                     GroupId = ac.GroupId,
                                     GroupName = ac.GroupName,
                                     AdsCount = ac.AdsCount,
                                     CountryCount = final.CountryCount
                                  }).ToListAsync();

                return finalResult;
        }

        public async Task<List<CountryDto>> QueryMethodCountryWise(IQueryable<AddCountry> addCounts, int groupId)
        {
            var countries = await(from cn in _dbContext.Countries
                                  join ac in addCounts on cn.Country_Id equals ac.CountryId into result
                            where cn.Country_GroupId == groupId 
                            from rs in result.DefaultIfEmpty()
                            select new CountryDto
                            {
                                CountryId = cn.Country_Id,
                                CountryName = cn.Country_Name,
                                AdsCount = rs.AdsCount == null ? 0 : rs.AdsCount
                            }).ToListAsync();

            return countries;
        }

        public DateTime GetClassifiedExpireDate()
        {
            Services.CommonServices cs = new Services.CommonServices();
            int expireDays = cs.GetClassifiedExpireDays();

            return DateTime.Now.AddDays(-1 * expireDays);
        }

        #endregion

    }
}