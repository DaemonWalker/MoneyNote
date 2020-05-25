using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyNote.DbModels
{
    public class UserDto
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Tel { get; set; }
        public string EMail { get; set; }
    }
}
