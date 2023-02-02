using Domain.Enums;
using Domain.Models.Common;
using Domain.Models.Responses;
using Infrastructure.Assistants;

namespace Infrastructure.Abstraction
{
    public interface IDSTUApiService
    {
        Task<InfoModel> GetInfoAsync(Actions action);
        Task<GroupScheduleResponse> GetInfoAsync(int id, Actions action);
    }
    public class DSTUApiService : IDSTUApiService
    {
        public async Task<InfoModel> GetInfoAsync(Actions action)
        {
            var info = new InfoModel();

            var model = await DataAssistant.GetDSTUModel(DateTime.Now, action);
            if (model is not null)
            {
                info.Data = model.Data;
            }

            return info;
        }

        public async Task<GroupScheduleResponse> GetInfoAsync(int id, Actions action)
        {
            var response = new GroupScheduleResponse();
            response.Schedule = new();

            var data = await DataAssistant.GetDataAsync(id, action);
            if (data is not null)
            {
                foreach (var item in data.Schedule)
                {
                    var scheduleInfo = new ScheduleInfo
                    {
                        Auditoria = item.Auditoria,
                        Start = item.Start,
                        End = item.End,
                        NumberOfDay = item.DayOfWeek,
                        NameOfDay = item.DayOfWeek2,
                        Group = item.Group,
                        Email = item.Email,
                        Date = item.Date,
                        Discipline = item.Discipline
                    };
                    response.Schedule.Add(scheduleInfo);
                }
            }

            return response;
        }
    }
}