using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace MoneyNote.DomainModel
{
    public class RecordModel
    {
        [Description("费用类型")]
        public IEnumerable<string> TypeNames { get; set; }
        
        [Description("时间")]
        public DateTime Date { get; set; }
        
        [Description("金额")]
        public double Amount { get; set; }

        [Description("备注")]
        public string Remark { get; set; }

    }
}
