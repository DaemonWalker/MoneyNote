using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace MoneyNote.DbModels
{
    public class RecordDto
    {
        public UserDto User { get; set; }
        public IEnumerable<TypeDto> FeeTypes { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<int> TypeIDs { get; set; }
    }
}
