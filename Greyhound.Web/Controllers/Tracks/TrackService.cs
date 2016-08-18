using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreyHound.Dto.Tracks;
using System.Threading.Tasks;
using GreyHound.Models;
using System.Data.Entity;
using GreyHound.Dto.Race;
using GreyHound.Models.Enums;
using GreyHound.Models.Tracks;
using System.ComponentModel;

namespace GreyHound.Web.Controllers.Tracks
{
    public class TrackService : ITrackService
    {
        private readonly GreyHoundContext _dbContext;

        public TrackService()
        {
            _dbContext = new GreyHoundContext();
        }

        public TrackService(GreyHoundContext context)
        {
            _dbContext = context;
        }

        #region ADMIN BODIES

        public async Task<List<AdminBodyDto>> GetAdminBodiesAsync()
        {
            try
            {
                var adminBody = await (from a in _dbContext.AdminBodies                                
                                       select new AdminBodyDto()
                                             {
                                                 Id = a.AdminBody_Id,
                                                 Name = a.AdminBody_Name,
                                                 CountryId = a.AdminBody_CountryId,
                                                 Country = a.Country.Country_Name,
                                                 Description = a.AdminBody_Description,
                                                 Address = a.AdminBody_Address,
                                                 Contact = a.AdminBody_Contact,
                                                 Url = a.AdminBody_Url
                                             }).ToListAsync();

                return adminBody;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<AdminBodyDto>> AdminBodiesByCountryAsync(int id)
        {
            try
            {
                var adminBody = await (from a in _dbContext.AdminBodies.Where(a => a.AdminBody_CountryId == id)                                
                                       select new AdminBodyDto()
                                       {
                                           Id = a.AdminBody_Id,
                                           Name = a.AdminBody_Name,
                                           CountryId = a.AdminBody_CountryId,
                                           Country = a.Country.Country_Name,
                                           Description = a.AdminBody_Description,
                                           Address = a.AdminBody_Address,
                                           Contact = a.AdminBody_Contact,
                                           Url = a.AdminBody_Url
                                       }).ToListAsync();

                return adminBody;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region STADIUMS

        #region BASICS

        public async Task<List<StadiumDto>> GetAllStadiumsAsync()
        {
            try
            {
                var stadium = await (from s in _dbContext.Stadiums                                    
                                     select new StadiumDto()
                                     {
                                         Id = s.Stadium_Id,
                                         CountryId = s.Stadium_CountryId,
                                         Country = s.Country.Country_Name,
                                         CountryCode = s.Country.Country_Code,
                                         Name = s.Stadium_Name,
                                         DisplayName = s.Stadium_DisplayName,
                                         Address = s.Stadiumy_Address,
                                         Url = s.Stadium_Url,
                                         Phone = s.Stadium_Phone,
                                         //DaysOpen = s.,
                                         Latitude = s.Stadium_Latitude,
                                         Longitude = s.Stadium_Longitude
                                     }).ToListAsync();

                return stadium;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<StadiumDto> GetStadiumByIdAsync(int id)
        {
            try
            {                
                var stadium = await( from s in _dbContext.Stadiums
                                    .Where(s => s.Stadium_Id == id)
                                     select new StadiumDto()
                                     {
                                         Id = s.Stadium_Id,
                                         Code = s.Stadium_Code,
                                         CountryId = s.Stadium_CountryId,
                                         Country = s.Country.Country_Name,
                                         CountryCode = s.Country.Country_Code,
                                         Name = s.Stadium_Name,
                                         DisplayName = s.Stadium_DisplayName,
                                         Address = s.Stadiumy_Address,
                                         Url = s.Stadium_Url,
                                         Phone = s.Stadium_Phone,                                        
                                         Latitude = s.Stadium_Latitude,
                                         Longitude = s.Stadium_Longitude
                                     }).SingleOrDefaultAsync();                
                  

                //get stadium open days
                List<StadiumOpenDays> oDays = await( from d in _dbContext.StadiumOpenDays
                                                     where d.OpenDay_StadiumId == id
                                                     select new StadiumOpenDays
                                                     {
                                                         Id = d.OpenDay_Value
                                                     }).ToListAsync();

                var type = typeof(OpenDays);
                string name;

                foreach(var item in oDays)
                {
                    name = Enum.GetName(typeof(OpenDays),item.Id);
                    item.Value = ((DescriptionAttribute)type.GetMember(name)[0].GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description;
                }

                stadium.DaysOpen = oDays;

                return stadium;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<StadiumsByCountryDto>> StadiumsByCountryAsync(int id)
        {
            var stadium = await (from s in _dbContext.Stadiums
                                .Where(s => s.Stadium_CountryId == id)                                
                                 select new StadiumsByCountryDto()
                                 {
                                     StadiumId = s.Stadium_Id,
                                     StadiumName = s.Stadium_Name
                                 }).ToListAsync();

            return stadium;
        }

        public async Task<List<StadiumImagesDto>> GetStadiumImagesAsync(int stadiumId)
        {
            var images = await (from i in _dbContext.Images
                                where i.Image_TransactionId == stadiumId && i.Image_TypeId == (int)ImageTypes.Stadium
                                select new StadiumImagesDto
                                {
                                    Id = i.Image_Id,
                                    Name = i.Image_Name,
                                    Url = i.Image_Url
                                }).ToListAsync();

            return images;
        }

        public async Task<List<TrackDistancesDto>> GelStadiumDistancesAsync(int stadiumId)
        {
            var distances = await (from tr in _dbContext.Track
                             where tr.Trk_StadiumId == stadiumId
                             select new TrackDistancesDto
                             {
                                 Id = tr.Trk_DistanceId,
                                 Value = tr.TrackDistance.TrDis_LengthInMeter
                             }).ToListAsync();

            return distances;            
        }

        public async Task<List<TrackDistancesDto>> GetDistanceByTracksAsync(int stadiumId)
        {
            var distances = await(from tr in _dbContext.Track
                                  where tr.Trk_StadiumId == stadiumId
                                  select new TrackDistancesDto
                                  {
                                      Id = tr.Trk_Id,
                                      Value = tr.TrackDistance.TrDis_LengthInMeter
                                  }).ToListAsync();

            return distances;   
        }

        #endregion

        #region STATS

        public async Task<List<int>> GetRaceYearsAsync(int stadiumId)
        {
            List<int> years = await (from rc in _dbContext.Races
                               where (rc.Track.Trk_StadiumId == stadiumId)
                               group rc by rc.Race_DateTime.Value.Year into grouped
                               select grouped.Key).ToListAsync();

            return years;
        }

        public async Task<List<StadiumDistancesDto>> GetTrackDistancesAsync(int stadiumId)
        {
            var dist = await(from tr in _dbContext.Track
                       where tr.Trk_StadiumId == stadiumId
                       select new StadiumDistancesDto
                       {
                           Id = tr.Trk_DistanceId,
                           Value = tr.TrackDistance.TrDis_LengthInMeter
                       }).ToListAsync();;

            return dist;
        }

        public async Task<List<TrackRecordsDto>> GetTrackRecordsAsync(int stadiumId)
        {
            //get races held in this stadium
            var races = from rc in _dbContext.Races
                        where rc.Track.Trk_StadiumId == stadiumId
                        select new
                        {
                            RaceId = rc.Race_Id
                        };

            //get winners for those races
            var winners = from rc in races
                          select new RaceWinnerDto
                          {
                              RaceId = rc.RaceId,
                              WinnerId = 0,
                              WinnerName = "",
                              WinTime = null
                          };
            winners = Services.RaceServices.GetRaceWinnerDetails(winners, _dbContext);

            //link all and get final result
            var records = await(from rc in _dbContext.Races
                          join wn in winners on rc.Race_Id equals wn.RaceId
                          join dg in _dbContext.Dogs on wn.WinnerId equals dg.Dog_Id
                          select new TrackRecordsDto
                          {
                              RaceId = rc.Race_Id,
                              RaceDate = rc.Race_DateTime,
                              Distance = rc.Track.TrackDistance.TrDis_LengthInMeter,
                              RaceType = rc.RaceType.RaceType_Name,
                              WinnerId = wn.WinnerId,
                              WinnerName = wn.WinnerName + " [" + dg.BirthLand.Country_Code + "/" + dg.StandingLand.Country_Code + " " + dg.Dog_DateOfBirth.Value.Year +"]",
                              WinnerTime = wn.WinTime
                          }).ToListAsync();

            return records;
        }

        public async Task<List<FastTimesDto>> GetFastTimesAsync(int stadiumId, int year, int distanceId)
        {
            //get races held in this stadium year and distance wise
            var races = from rc in _dbContext.Races
                        where rc.Track.Trk_StadiumId == stadiumId &&
                              rc.Race_DateTime.Value.Year == year &&
                              rc.Track.Trk_DistanceId == distanceId
                        select new
                        {
                            RaceId = rc.Race_Id
                        };

            //get winners for those races
            var winners = from rc in races
                          select new RaceWinnerDto
                          {
                              RaceId = rc.RaceId,
                              WinnerId = 0,
                              WinnerName = "",
                              WinTime = null
                          };
            winners = Services.RaceServices.GetRaceWinnerDetails(winners, _dbContext);

            //get winners points for those races
            var points = from rr in _dbContext.RaceResults
                         join wn in winners on new { x1=rr.result_RaceId, x2=rr.result_DogId } equals new { x1=wn.RaceId, x2=wn.WinnerId }
                         select new
                         {
                             RaceId = rr.result_RaceId,
                             DogId = wn.WinnerId,
                             Point = rr.result_Points
                         };
                         

            //link all and get result
            var fastest = await(from rc in _dbContext.Races
                                join wn in winners on rc.Race_Id equals wn.RaceId
                                join dg in _dbContext.Dogs on wn.WinnerId equals dg.Dog_Id
                                join pn in points on new { x1 = wn.RaceId, x2 = wn.WinnerId } equals new { x1 = pn.RaceId, x2 = pn.DogId }
                                select new FastTimesDto
                                {
                                    RaceId = rc.Race_Id,
                                    RaceDate = rc.Race_DateTime,                                   
                                    WinnerId = wn.WinnerId,
                                    WinnerName = wn.WinnerName + " [" + dg.BirthLand.Country_Code + "/" + dg.StandingLand.Country_Code + " " + dg.Dog_DateOfBirth.Value.Year + "]",
                                    WinnerTime = wn.WinTime,
                                    Gender = (Gender)dg.Dog_Gender,
                                    Sire = dg.Sire.Dog_Name,
                                    Dam = dg.Dam.Dog_Name,
                                    Points = pn.Point
                                }).ToListAsync();



            return fastest;
        }

        public async Task<List<TrapStatsDto>> GetTrapStatsAsync(int stadiumId, int year, int? distanceId)
        {
            //count all race held in this trck for given year and tracks
            var query = from rr in _dbContext.RaceResults
                        where rr.Race.Track.Trk_StadiumId == stadiumId && rr.Race.Race_DateTime.Value.Year == year                                                      
                        select new
                        {
                            RaceId = rr.result_RaceId,
                            DistanceId = rr.Race.Track.Trk_DistanceId,
                            FinOrder = rr.result_FinishedOrderId,
                            Trap = rr.result_Trap
                        };
            
            if(distanceId.HasValue)
                query = query.Where(r => r.DistanceId == distanceId);
                       

            var lst = query.ToList();

            //get trap wise winner count
            var trapCounts = await(from qr in query
                             group qr by qr.FinOrder into grouped
                                   select new TrapStatsDto
                                   {
                                       FinOrder = grouped.Key,
                                       RaceCount = grouped.Count(),
                                       T1 = grouped.Where(c => c.Trap == 1).Count().ToString(),
                                       T2 = grouped.Where(c => c.Trap == 2).Count().ToString(),
                                       T3 = grouped.Where(c => c.Trap == 3).Count().ToString(),
                                       T4 = grouped.Where(c => c.Trap == 4).Count().ToString(),
                                       T5 = grouped.Where(c => c.Trap == 5).Count().ToString(),
                                       T6 = grouped.Where(c => c.Trap == 6).Count().ToString(),
                                       T7 = grouped.Where(c => c.Trap == 7).Count().ToString(),
                                       T8 = grouped.Where(c => c.Trap == 8).Count().ToString(),
                                       T9 = grouped.Where(c => c.Trap == 9).Count().ToString(),
                                   }).ToListAsync();

            return trapCounts;
        }

        public async Task<List<DistanceWiseRacesDto>> GetYearAndDistanceWiseStatAsync(int stadiumId)
        {
            //var races = await(from rc in _dbContext.RaceResults
            //                  where rc.Race.Track.Trk_StadiumId == stadiumId
            //                  group rc by new { rc.Race.Track.Trk_DistanceId, rc.Race.Race_DateTime.Value.Year } into grouped

            //                  orderby grouped.Key.Year
            //                  select new DistanceWiseRacesDto
            //                  {
            //                      Year = grouped.Key.Year,
            //                      Distance = grouped.Where(c => c.Race.Track.Trk_DistanceId == grouped.Key.Trk_DistanceId).Select(c => c.Race.Track.TrackDistance.TrDis_LengthInMeter).FirstOrDefault().ToString(),
            //                      RaceCount = grouped.Where(c => c.Race.Track.Trk_DistanceId == grouped.Key.Trk_DistanceId).Count()                                  
            //                  }).ToListAsync();

            var races = await(from rc in _dbContext.Races
                        where rc.Track.Trk_StadiumId == stadiumId
                        group rc by new { rc.Track.Trk_DistanceId, rc.Race_DateTime.Value.Year } into grouped
                        select new DistanceWiseRacesDto
                        {
                            Year = grouped.Key.Year,
                            Distance = grouped.Where(c => c.Track.Trk_DistanceId == grouped.Key.Trk_DistanceId).Select(c => c.Track.TrackDistance.TrDis_LengthInMeter).FirstOrDefault().ToString(),
                            RaceCount = grouped.Count()
                        }).ToListAsync();

            return races;
        }

        public async Task<List<AvgAndBestTimeDto>> GetAvgAndBestAsync(int stadiumId, int? year, int? quarter, int? distanceId)
        {
            //get race list
            var raceList = from rc in _dbContext.Races
                           where rc.Track.Trk_StadiumId == stadiumId
                           select new
                           {
                               RaceId = rc.Race_Id,
                               Year = rc.Race_DateTime.Value.Year,
                               Quarter = (rc.Race_DateTime.Value.Month - 1) / 3 + 1,
                               DistanceId = rc.Track.Trk_DistanceId
                           };

            if (year.HasValue)
                raceList = raceList.Where(r => r.Year == year);

            if (quarter.HasValue)
                raceList = raceList.Where(r => r.Quarter == quarter);

            if(distanceId.HasValue)
                raceList = raceList.Where(r => r.DistanceId == distanceId);

            var v = raceList.ToList();

            var times1 = (from rr in _dbContext.RaceResults
                          join rl in raceList on rr.result_RaceId equals rl.RaceId into result
                          from rs in result
                          group rs by new { rr.Race.Track.Trk_DistanceId } into grouped
                          orderby grouped.Key.Trk_DistanceId
                          select new
                          {
                              distance = grouped.Key,
                              count = grouped.Count()
                          }).ToList();
                        //select rs).ToList();

            //runners 
            var times = await(from rr in _dbContext.RaceResults
                        join rl in raceList on rr.result_RaceId equals rl.RaceId
                        group rr by new { rl.Year,rl.Quarter,rr.Race.Track.Trk_DistanceId, } into grouped
                        orderby grouped.Key.Trk_DistanceId
                        select new AvgAndBestTimeDto
                        {
                            Year = year.HasValue ? grouped.Key.Year : grouped.Select(r => r.Race.Race_DateTime.HasValue ? r.Race.Race_DateTime.Value.Year : 0).FirstOrDefault(),
                            Quarter = quarter.HasValue ? grouped.Key.Quarter : grouped.Select(r => r.Race.Race_DateTime.HasValue ? ((r.Race.Race_DateTime.Value.Month - 1) / 3) + 1 : 0).FirstOrDefault(),
                            Distance = distanceId.HasValue ? grouped.Key.Trk_DistanceId : grouped.Select(r => r.Race.Race_TrackId.HasValue ? r.Race.Track.TrackDistance.TrDis_LengthInMeter : 0).FirstOrDefault(),
                            DifRunners = grouped.Select(r => r.result_DogId).Distinct().Count(),
                            AvgTime = grouped.Average(r => r.result_Time.HasValue ? ((r.result_Time.Value.Second * 1000) + r.result_Time.Value.Millisecond ) : 0),
                            AvgWinTime = grouped.Where(r => r.result_FinishedOrderId == (int)RaceFinishOrder.winner).Average(r => r.result_Time.HasValue ? ((r.result_Time.Value.Second * 1000) + r.result_Time.Value.Millisecond ) : 0),
                            BestTime = grouped.OrderBy(r => r.result_Time).FirstOrDefault().result_Time.Value,
                            BestRunnerId = grouped.OrderBy(r=>r.result_Time).FirstOrDefault().result_DogId,
                            BestRunnerName = grouped.OrderBy(r => r.result_Time).FirstOrDefault().Dog.Dog_Name,
                            BestRaceId = grouped.OrderBy(r => r.result_Time).FirstOrDefault().result_RaceId,
                            BestRaceDate = grouped.OrderBy(r => r.result_Time).FirstOrDefault().Race.Race_DateTime                            
                        }).ToListAsync();

            return times;
        }

        #endregion

        #endregion

        #region TRACKS

        public async Task<List<TrackCountryDto>> GetAllTrackCountriesAsync()
        {
            var trackCountries = from st in _dbContext.Stadiums
                            group st by st.Stadium_CountryId into grouped
                            select new
                            {
                                ContryId = grouped.Key
                            };

            var countryList = await(from cn in _dbContext.Countries
                              join tc in trackCountries on cn.Country_Id equals tc.ContryId
                              select new TrackCountryDto
                              {
                                 Id = cn.Country_Id,
                                 Code = cn.Country_Code,
                                 Name = cn.Country_Name,
                                 Description = cn.Country_TrackDetails
                              }).ToListAsync();

               return countryList;
        }

        public async Task<List<TrackCountryDto>> GetTrackByCountryIdAsync(int countryId)
        {
            var trackCountries = from st in _dbContext.Stadiums
                                 where st.Stadium_CountryId == countryId
                                 group st by st.Stadium_CountryId into grouped
                                 select new
                                 {
                                     ContryId = grouped.Key
                                 };

            var countryList = await(from cn in _dbContext.Countries
                                    join tc in trackCountries on cn.Country_Id equals tc.ContryId
                                    select new TrackCountryDto
                                    {
                                        Id = cn.Country_Id,
                                        Code = cn.Country_Code,
                                        Name = cn.Country_Name,
                                        Description = cn.Country_TrackDetails
                                    }).ToListAsync();

            return countryList;
        }

        public async Task<List<TrackDto>> TracksByStadiumAsync(int id)
        {
            var track = await (from t in _dbContext.Stadiums.Where(t => t.Stadium_Id == id)                              
                               select new TrackDto()
                               {
                                   StadiumId = t.Stadium_Id,
                                   Stadium = t.Stadium_Name//,
                                   //Distance = t.Distance,
                                   //QualifyingTime = t.QualifyingTime,
                                   //Hurdles = t.Hurdles,

                               }).ToListAsync();

            return track;
        }

        public async Task<List<TrackFormsDto>> TrackFormsByStadiumIdAsync(int stadiumId)
        {
            var forms = await (from tf in _dbContext.TrackForms
                               where tf.Track.Trk_StadiumId == stadiumId
                               select new TrackFormsDto
                               {
                                   FormId = tf.TForm_Id,
                                   TrackId = tf.TForm_TrackId,
                                   DateFrom = tf.TForm_DateFrom,
                                   DateTo = tf.TForm_DateTo,
                                   Time = tf.TForm_Time
                               }).ToListAsync();

            return forms;
        }

        #endregion

        #region POST TRACKS

        public async Task<bool> PostTrackFormsAsync(List<SaveTrackFormsDto> dto)
        {
            bool? insertSuccess = null, updateSuccess = null;

            //if track id is null insert.......else update
            foreach (var item in dto)
            {
                if (item.TFormId.HasValue)
                {
                    #region insert
                    insertSuccess = false;
                    var FormEntity = new TrackForm
                    {
                        TForm_TrackId = item.TrackId,
                        TForm_DateFrom = item.DateFrom,
                        TForm_DateTo = item.DateTo,
                        TForm_Time = item.Time
                    };

                    _dbContext.TrackForms.Add(FormEntity);
                    await _dbContext.SaveChangesAsync();

                    if (FormEntity.TForm_Id != null && FormEntity.TForm_Id > 0)
                        insertSuccess = true;

                    #endregion
                }
                else
                {
                    #region update

                    updateSuccess = false;

                    //get track forms 
                    var form = _dbContext.TrackForms.Where(a => a.TForm_Id == item.TFormId).FirstOrDefault<TrackForm>();

                    form.TForm_TrackId = item.TrackId;
                    form.TForm_DateFrom = item.DateFrom;
                    form.TForm_DateTo = item.DateTo;

                    _dbContext.Entry(form).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    if (form.TForm_Id > 0)
                        updateSuccess = true;

                    #endregion
                }

                if (insertSuccess.HasValue && insertSuccess.Value == true || updateSuccess.HasValue && updateSuccess.Value == true)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteTrackFormsAsync(DeleteTrackFormDto dto)
        {            
            //get track forms 
            var form = _dbContext.TrackForms.Where(a => a.TForm_Id == dto.TrackFormId).FirstOrDefault<TrackForm>();

            form.TForm_IsDeleted = true;
            form.TForm_DeletedDate = DateTime.Now;
            form.TForm_DeleteComment = dto.Comment;
            form.TForm_DeletedBy = dto.DeletedBy;

            _dbContext.Entry(form).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            if (form.TForm_Id > 0)
                return true;

            return false;
        }

        #endregion

    }
}