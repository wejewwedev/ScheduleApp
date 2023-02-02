using Domain.Models.Common;

namespace Domain.Models.Responses
{
    public class TeachersResponse : CommonResponse
    {
        public List<Datum> Teachers { get; set; }
    }
    public class TeacherScheduleResponse : CommonResponse 
    {
        public List<ScheduleInfo> Schedule { get; set; }
    }
}
