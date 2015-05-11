using AnalyzeZillow.Core.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeZillow.Core
{
    public class ZillowDataRepository : IZillowDataRepository
    {
        public ZillowDataContext dbContext { get; set; }

        public ZillowDataRepository()
        {
            dbContext = new ZillowDataContext();
        }

        public async Task<bool> SaveSingle(Home home)
        {
            try
            {
                dbContext.Homes.Add(home);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                dbContext.Homes.Remove(home);
                return false;
            }
        }

        public async Task<bool> SaveBatch(ICollection<Home> homes)
        {
            foreach(Home home in homes)
            {
                dbContext.Homes.Add(home);
            }
            try
            {
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        ICollection<SQL.Home> IZillowDataRepository.GetHomes()
        {
            throw new NotImplementedException();
        }

        SQL.Home IZillowDataRepository.GetSingleHome(int zId)
        {
            throw new NotImplementedException();
        }
    }
}
