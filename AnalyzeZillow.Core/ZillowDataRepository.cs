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
        /// <summary>
        /// Notice that this is NOT IZillowDataRepository.SaveSingle,
        /// Doing so would force a private member here.
        /// </summary>
        /// <param name="home"></param>
        /// <returns></returns>
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
                //if something goes wrong, we can't save the changes,
                //but chances are it is still in the context.
                //next time we attempt a save, it will still be there
                //causing another exception.
                //we must remove the bad home (probably a key duplicate)
                //otherwise our program will constantly be failing with a growing 
                //in memory list of homes to add
                dbContext.Homes.Remove(home);
                return false;
            }
        }

        public async Task<bool> SaveBatch(ICollection<Home> homes)
        {
            foreach(Home home in homes)
            {
                //Add a bunch of homes here
                dbContext.Homes.Add(home);
            }
            try
            {
                //save all of them as a batch
                //this is a HUGE performance gain.
                //I've seen upwards of multiples of minutes 
                //performance increase for larger inserts
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
