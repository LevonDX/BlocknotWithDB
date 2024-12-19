using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotWithDB
{
    internal class BlocknotRepoEF : IBlocknotRepo
    {
        public BlocknotRepoEF(Blocknot blocknot)
        {
            
        }
        public Blocknot GetBlocknot()
        {
            throw new NotImplementedException();
        }

        public Record? GetRecordByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
