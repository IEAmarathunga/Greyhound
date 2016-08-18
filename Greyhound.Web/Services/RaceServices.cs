using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreyHound.Dto.Tracks;
using GreyHound.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using GreyHound.Dto.Race;
using GreyHound.Models.Enums;

namespace GreyHound.Web.Services
{
    public class RaceServices
    {

        #region BY DOGS
                
        #region GET TOTAL POINTS EARNED BY SELECTED DOG/DOGS

        public static IQueryable<PointsDto> GetTotalPoints(IQueryable<PointsDto> dogList, GreyHoundContext context)
        {
            var points = from rg in context.RaceResults                        
                         join dl in dogList on rg.result_DogId equals dl.DogId into result
                         group rg by rg.result_DogId into grouped
                         select new PointsDto
                         {
                             DogId = grouped.Key,
                             Points = grouped.Sum(c=>c.result_Points)
                         };

#if DEBUG
            var list3 = points.ToList();
#endif

            return points;
        }

        #endregion

        #endregion

        #region OTHER

        #region GET BEST TRACK RECORDS

        public async Task<TrackRecordDto> BestTrackRecord(int trackId)
        {
            try
            {
                ////assumes that one track has fixed length
                ////half implemented....to be filtered by time
                //var query = (from r in _dbContext.RaceResults                             
                //             .Where(r => r.Race.TrackId == trackId)
                //             select new TrackRecordDto()
                //             {
                //                  OwnerId = r.DogId,
                //                  OwnerName = r.Dog.Name,
                //                  RecordDate = r.Race.Date,
                //                  RecordTime = r.Time
                //             });

                //TrackRecordDto result = await query.FirstOrDefaultAsync();                
                //return result;
                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<TrackRecordDto> BestTrackRecord(DateTime dFrom, DateTime dTo)
        {
            try
            {
                //var query = (from r in _dbContext.RaceResults
                //             .Where(r => r.Race.Date >= dFrom && r.Race.Date <= dTo)
                //             select new TrackRecordDto()
                //             {
                //                 OwnerId = r.DogId,
                //                 OwnerName = r.Dog.Name,
                //                 RecordDate = r.Race.Date,
                //                 RecordTime = r.Time
                //             });

                //TrackRecordDto result = await query.FirstOrDefaultAsync();
                //return result;

                return null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region RACE COMPARISON.....DWT AND DT 
        
        public async static Task<decimal?> GetDWTRecords(int TrackId, DateTime RaceDate,DateTime FinishTime, GreyHoundContext context)
        {
            //get date range (quater) for this race date           
            int quarterNumber = (RaceDate.Month - 1) / 3 + 1;
            DateTime fromDate = GetFirstDateOfQuarter(RaceDate, quarterNumber);
            DateTime toDate = GetLastDateOfQuarter(RaceDate, quarterNumber);

            //get average wining time on this track on that quater of the year
            var rc = await (from rr in context.RaceResults                     
                     where rr.result_FinishedOrderId == (int)RaceFinishOrder.winner && rr.Race.Race_TrackId == TrackId &&
                     rr.Race.Race_DateTime >= fromDate && rr.Race.Race_DateTime <= toDate
                     group rr by rr.Race.Race_TrackId into grouped
                     select new
                     {
                         TrackId = grouped.Key,
                         AverageWinTime = grouped.Average(c => c.result_Time.Value.Second * 1000 + c.result_Time.Value.Millisecond)
                     }).SingleOrDefaultAsync();

            decimal? dwt=null,dogTime;
            dogTime = FinishTime.Second*1000 + FinishTime.Millisecond;

            if(rc!=null)
            {
                dwt = dogTime - Convert.ToDecimal(rc.AverageWinTime);
            }

            return dwt;
        }

        public async static Task<decimal?> GetDTRecords(int TrackId, DateTime RaceDate, DateTime FinishTime, GreyHoundContext context)
        {
            //get date range (quater) for this race date           
            int quarterNumber = (RaceDate.Month - 1) / 3 + 1;
            DateTime fromDate = GetFirstDateOfQuarter(RaceDate, quarterNumber);
            DateTime toDate = GetLastDateOfQuarter(RaceDate, quarterNumber);

            //get average finish time on this track on that quater of the year
            var rc = await (from rr in context.RaceResults
                            where rr.Race.Race_TrackId == TrackId &&
                            rr.Race.Race_DateTime >= fromDate && rr.Race.Race_DateTime <= toDate
                            group rr by rr.Race.Race_TrackId into grouped
                            select new
                            {
                                TrackId = grouped.Key,
                                AverageWinTime = grouped.Average(c => c.result_Time.Value.Second * 1000 + c.result_Time.Value.Millisecond)
                            }).SingleOrDefaultAsync();

            decimal? dt = null, dogTime;
            dogTime = FinishTime.Second * 1000 + FinishTime.Millisecond;

            if (rc != null)
            {
                dt = dogTime - Convert.ToDecimal(rc.AverageWinTime);
            }

            return dt;
        }


        public static DateTime GetFirstDateOfQuarter(DateTime date, int quarterNumber)
        {
            return new DateTime(date.Year, (quarterNumber - 1) * 3 + 1, 1);
        }

        public static DateTime GetLastDateOfQuarter(DateTime date, int quarterNumber)
        {
            DateTime FirstDay = new DateTime(date.Year, (quarterNumber - 1) * 3 + 1, 1);
            return FirstDay.AddMonths(3).AddDays(-1);
        }
       
        #endregion

        #endregion

        #region BY RACE

        #region GET WINNER DETAILS FOR GIVEN RACE/RACES

        public static IQueryable<RaceWinnerDto> GetRaceWinnerDetails(IQueryable<RaceWinnerDto> raceList, GreyHoundContext context)
        {
            var raceWinner = from rc in raceList
                             join rr in context.RaceResults.Where(c=> c.result_FinishedOrderId == (int)RaceFinishOrder.winner) 
                             on rc.RaceId equals rr.result_RaceId into result                             
                             from rs in result.DefaultIfEmpty()                             
                             select new RaceWinnerDto
                             {
                                 RaceId = rc.RaceId,
                                 WinnerId = rs.result_DogId == null ? 0 : rs.result_DogId,
                                 WinnerName = rs.Dog.Dog_Name == null ? "" : rs.Dog.Dog_Name,
                                 WinTime = rs.result_Time
                             };

            //var raceWinner = from rr in context.RaceResults
            //                 join rc in raceList on rr.result_RaceId equals rc.RaceId into result
            //                 where (rr.result_FinishedOrderId == (int)RaceFinishOrder.winner)
            //                 from rs in result.DefaultIfEmpty()
            //                 select new RaceWinnerDto
            //                 {
            //                     RaceId = rr.result_RaceId,
            //                     WinnerId = rr.result_DogId == null ? 0 : rr.result_DogId,
            //                     WinnerName = rr.Dog.Dog_Name == null ? "" : rr.Dog.Dog_Name,
            //                     WinTime = rr.result_Time
            //                 };


#if DEBUG
            var list = raceWinner.ToList();
#endif

            return raceWinner;
        }

        #endregion

        #region GET NUMBER OF RUNNERS FOR GIVEN RACE/RACES

        public static IQueryable<NumberOfRunnersDto> GetNoOfRunnersForRace(IQueryable<NumberOfRunnersDto> raceList, GreyHoundContext context)
        {
            var countRunners = from rc in raceList
                               join rr in context.RaceResults on rc.RaceId equals rr.result_RaceId into result
                               select new NumberOfRunnersDto
                               {
                                   RaceId = rc.RaceId,
                                   Runners = result.Where(d => d.result_RaceId == rc.RaceId).Count()
                               };
            
            return countRunners;
        }
        
        #endregion

        #region GET MAJOR RACES FOR SELECTED DOGS

        public static IQueryable<OffspringRaceStatDto> GetTopOffspringRaceStats(IQueryable<OffspringRaceStatDto> dogList, GreyHoundContext context)
        {

            var TopRaces = from rr in context.RaceResults
                        where rr.Race.RaceGrade.Grade_IsMajor == true || rr.Race.RaceGrade.Grade_IsFeature==true
                        join dl in dogList on rr.result_DogId equals dl.DogId into grouped
                        group grouped by rr.result_DogId into result
                        select new 
                        {
                            DogId = result.Key,
                            TopRaces = result.Count()
                        };

#if DEBUG
            var list1 = TopRaces.ToList();
#endif

            var places = from grouped in
                         (
                         from rr in context.RaceResults
                         where rr.Race.RaceGrade.Grade_IsMajor == true || rr.Race.RaceGrade.Grade_IsFeature == true
                         join dl in dogList on rr.result_DogId equals dl.DogId                   
                         select new { dl.DogId,rr.result_FinishedOrderId }
                         )
                         group grouped by new { grouped.DogId } into result
                         select new 
                         {
                             DogId = result.Key.DogId,
                             First = result.Count(c => c.result_FinishedOrderId == (int)RaceFinishOrder.winner),
                             Second = result.Count(c => c.result_FinishedOrderId == (int)RaceFinishOrder.second),    
                         };
#if DEBUG
            var list2 = places.ToList();
#endif

            var races = from tr in TopRaces
                        join pl in places on tr.DogId equals pl.DogId
                        select new OffspringRaceStatDto
                        {
                            DogId = tr.DogId,
                            TopRaces = tr.TopRaces,
                            First = pl.First,
                            Second = pl.Second,
                        };

#if DEBUG
            var list3 = races.ToList();
#endif
            return races;

        }        

        #endregion 

        #endregion
    }
}