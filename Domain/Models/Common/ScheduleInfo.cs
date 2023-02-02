using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Common
{
    public class ScheduleInfo
    {
        // public int MyProperty { get; set; } - номер пары
        public string Auditoria { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int NumberOfDay { get; set; }
        public string NameOfDay { get; set; }
        public string Group { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Discipline { get; set; }

    }
}
