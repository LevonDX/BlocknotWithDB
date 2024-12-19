using BlocknotWithDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotWithDB
{
    public class BlocknotRepository : IBlocknotRepo
    {
        BlocknotDbContext blocknotDbContext;
        public BlocknotRepository(Blocknot blocknot)
        {
            blocknotDbContext = new BlocknotDbContext(blocknot);
             
        }

        public Blocknot GetBlocknot()
        {
            return blocknotDbContext.Blocknot;
        }

        public Record? GetRecordByNameAsync(string name)
        {
            Record? record = blocknotDbContext.Blocknot[name];

            return record;
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
