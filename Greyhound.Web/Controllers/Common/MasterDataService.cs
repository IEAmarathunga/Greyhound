using GreyHound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using GreyHound.Dto.Common;
using System.Web.Http.Description;
using System.Data.Entity;
using GreyHound.Models.Common;
using GreyHound.Models.Enums;
using System.Reflection;
using System.EnterpriseServices;
using Newtonsoft.Json.Linq;

namespace GreyHound.WebApplication.Controllers.Common
{
    public class MasterDataService : IMasterDataService
    {
        // charles commented
        private readonly GreyHoundContext _dbContext;

        public MasterDataService()
        {
            _dbContext = new GreyHoundContext();
        }

        public MasterDataService(GreyHoundContext context)
        {
            _dbContext = context;
        }

        public async Task<List<DogColorDto>> GetDogColorsAsync()
        {
            var colors = await _dbContext.DogColors.Select(c =>
                new DogColorDto()
                {
                    Id = c.DogColor_Id,
                    Name = c.DogColor_Name
                })

                .ToListAsync();
            return colors;
        }

        public async Task<List<CurrencyDto>> GetCurrenciesAsync()
        {
            var colors = await _dbContext.Currencies.Select(c =>
                new CurrencyDto()
                {
                    CurrencyId = c.Currency_Id,
                    Name = c.Currency_Name,
                    Code = c.Currency_Code,
                    Symbol = c.Currency_Symbol
                })

                .ToListAsync();
            return colors;
        }
                
        //public async Task<List<ColorCategoryDto>> GetColorCategoriessAsync()
        //{
        //    var colors = await _dbContext.DogColors.Select(c =>
        //        new ColorCategoryDto()
        //        {
        //            Id = c.DogColor_Id,
        //            Name = c.DogColor_Name
        //        })

        //        .ToListAsync();
        //    return colors;
        //}

        //public async Task<List<LandDto>> GetLandsAsync()
        //{
        //   var lands = await _dbContext.Countries.Select(l =>
        //   new LandDto()
        //   {
        //       Id = l.Country_Id,
        //       Name = l.Country_Name
        //   })           
        //   .ToListAsync();
        //    return lands;
        //}

        public async Task<List<BreedDto>> GetBreedsAsync()
        {
            var breeds = await _dbContext.Breeds.Select(b =>
           new BreedDto()
           {
               Id = b.Breed_Id,
               Name = b.Breed_Name
           }).ToListAsync();
            return breeds;
        }

        public async Task<List<AgeGroupDto>> GetAgeGroupsAsync()
        {
            var groups = await _dbContext.AgeGroups.Select(a =>
            new AgeGroupDto()
            {
                Id = a.AgeGroup_Id,
                Group = a.AgeGroup_Name
            }).ToListAsync();
            return groups;
        }

        //public List<SexDto> GetSexGroups()
        //{
        //    List<SexDto> list = new List<SexDto>();
        //    //foreach (int i in Enum.GetValues(typeof(SexEnum)))
        //    //{
        //    //    list.Add(new SexDto()
        //    //    {
        //    //        Id = i,
        //    //        Value = Enum.GetName(typeof(SexEnum), i)
        //    //    });
        //    //}
        //    return list;            
        //}


        public async Task<List<AllCountriesDto>> GetCountriesAsync()
        {
            var countries = await _dbContext.Countries.Select(c =>
            new AllCountriesDto()
            {
                Id = c.Country_Id,
                Code = c.Country_Code,
                Name = c.Country_Name
            })
            .ToListAsync();
            return countries;
        }

        public async Task<List<CountryGroupsDto>> GetCountryGroupsAsync()
        {
            var groups = await _dbContext.CountryGroups.Select(c =>
            new CountryGroupsDto()
            {
                GroupId = c.Group_Id,
                GroupName = c.Group_Name
            })
            .ToListAsync();
            return groups;
        }


        public async Task<List<AllCountriesDto>> GetCountryByIdAsync(int id)
        {
            var country = await (from c in _dbContext.Countries
                                     .Where(c => c.Country_Id == id)
                                 select new AllCountriesDto()
                                 {
                                     Id = c.Country_Id,
                                     Code = c.Country_Code,
                                     Name = c.Country_Name
                                 }).ToListAsync();
            return country;
        }

        public Task<List<MembershipTypeDto>> GetMemberTypes()
        {
            // Not developed yet.
            throw new NotImplementedException();


            //var types = await _dbContext.MembershipTypes.Select(m =>
            //new MembershipTypeDto()
            //{
            //    Id = m.Id,
            //    Description = m.Description
            //})
            //.ToListAsync();
            //return types;            
        }

        //public List<EnumTypeDto> GetMemberTypes()
        //{
        //    var list = new List<EnumTypeDto>();
        //    foreach (int i in Enum.GetValues(typeof(MemberType)))
        //    {
        //        list.Add(new EnumTypeDto()
        //        {
        //            Id = i,
        //            Value = Enum.GetName(typeof(MemberType), i)
        //        });
        //    }
        //    return list;
        //}


        public List<EnumTypeDto> GetMonths()
        {
            var list = new List<EnumTypeDto>();
            foreach (int i in Enum.GetValues(typeof(Months)))
            {
                list.Add(new EnumTypeDto()
                {
                    Id = i,
                    Value = Enum.GetName(typeof(Months), i)
                });
            }
            return list;
        }

    }
}