using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotWithDB
{
    public class Record : EntityBase
    {
        public Record()
        {
            
        }

        public required string Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
    }
}
