using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotWithDB
{
    internal interface IBlocknotRepo
    {
        Task SaveChangesAsync();

        Blocknot GetBlocknot();

        Record? GetRecordByNameAsync(string name);
    }
}
