using Domain.Models.Common;

namespace Domain.Models.Responses
{
    public class AudiencesResponse : CommonResponse
    {
        public List<Datum> Audiences { get; set; }
    }
    public class AudienceScheduleResponse : CommonResponse 
    {
        public List<ScheduleInfo> Schedule { get; set; }
    }
}
