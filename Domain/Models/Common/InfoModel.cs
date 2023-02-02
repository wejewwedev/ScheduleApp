using Domain.Models.Responses;

namespace Domain.Models.Common
{
    public class InfoModel : CommonResponse
    {
        public List<ScheduleInfo> Schedule { get; set; }
        public List<Datum> Data { get; set; }
    }
}
