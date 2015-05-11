using AnalyzeZillow.Core.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeZillow.Core
{
    public interface IZillowDataRepository
    {
        Task<bool> SaveSingle(Home home);
        Task<bool> SaveBatch(ICollection<Home> homes);
        ICollection<Home> GetHomes();
        Home GetSingleHome(int zId);
    }
}
