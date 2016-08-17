using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GreyHound.Dto.Classifieds;
using GreyHound.Models;
using GreyHound.Models.Enums;
using GreyHound.Dto.Common;
using System.Data.Entity;
using System.Net.Http;
using System.Net;

namespace GreyHound.WebApplication.Services
{
    public class CommonServices
    {
        private readonly GreyHoundContext _dbContext;

        public CommonServices()
        {
            _dbContext = new GreyHoundContext();
        }

        public CommonServices(GreyHoundContext context)
        {
            _dbContext = context;
        }
                
        public async Task<List<ImageDto>> GetImagesAsync(int TypeId, int TransactionId)
        {
            try
            {
                var images = await (from c in _dbContext.Images
                                    .Where(i => i.Image_TypeId == TypeId && i.Image_TransactionId == TransactionId)                                     
                                    select new ImageDto()
                                     {
                                         Id = c.Image_Id,
                                         TypeId = c.Image_TypeId,
                                         TransactionId = c.Image_TransactionId,
                                         Name = c.Image_Name,
                                         Url = c.Image_Url
                                     }).ToListAsync();

                return images;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int GetClassifiedExpireDays()
        {
            return 28;
        }

        public static KeyValuePair<DateTime, DateTime> GetFirstAndLastDayOfCurrentMonth()
        {
            DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime toDate = fromDate.AddMonths(1).AddDays(-1);

            return new KeyValuePair<DateTime, DateTime>(fromDate, toDate);
        }

        public static HttpResponseMessage ResponseExcetion(string errorMsg)
        {
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(string.Format(errorMsg))
            };

            return resp;
        }

    }
}