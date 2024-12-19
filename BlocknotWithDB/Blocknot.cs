using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotWithDB
{
    public class Blocknot : IEnumerable<Record>
    {
        private readonly List<Record> _records = new List<Record>();

        public void Add(Record record)
        {
            if (_records.Contains(record))
                throw new InvalidOperationException("Record already exists");

            _records.Add(record);
        }

        public void Remove(Record record)
        {
            if (!_records.Contains(record))
                throw new InvalidOperationException("Record does not exist");

            _records.Remove(record);
        }

        public IEnumerator<Record> GetEnumerator() // implicit implementation
        {
            foreach (Record item in _records)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() // explicit implementation
        {
            return GetEnumerator();
        }

        public Record this[int index]
        {
            get => _records[index];
        }

        public  Record? this[string name]
        {
            get
            {
                return _records.FirstOrDefault(r=>r.Name == name);
            }
        }
    }
}