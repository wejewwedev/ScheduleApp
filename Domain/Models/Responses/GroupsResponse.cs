using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Responses
{
    public class GroupsResponse : CommonResponse
    {
        public List<Datum> Groups { get; set; }
    }
    public class GroupScheduleResponse : CommonResponse
    {
        public List<ScheduleInfo> Schedule { get; set; }
    }
}
