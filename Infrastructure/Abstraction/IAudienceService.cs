using Domain.Enums;
using Domain.Models.Responses;
using Infrastructure.Assistants;

namespace Infrastructure.Abstraction
{
    public interface IAudienceService
    {
        Task<AudiencesResponse> GetAudiencesAsync();
        Task<AudienceScheduleResponse> GetAudienceScheduleAsync(int id);
    }

    public class AudienceService : IAudienceService
    {
        private readonly DSTUApiService _service;
        public AudienceService(DSTUApiService service)
        {
            _service = service;
        }

        public async Task<AudiencesResponse> GetAudiencesAsync()
        {
            var response = new AudiencesResponse();

            var audiences = _service.GetInfoAsync(Actions.Audience).Result.Data;
            if (audiences is null)
            {
                response.ErrorMessage = "Данные по аудиториям не найдены";
                return response;
            }
            response.Audiences = audiences;
            return response;
        }

        public async Task<AudienceScheduleResponse> GetAudienceScheduleAsync(int id)
        {
            var response = new AudienceScheduleResponse();

            var schedule = _service.GetInfoAsync(id, Actions.Audience);
            if (schedule is null)
            {
                response.ErrorMessage = "Расписание аудитории не найдено";
                return response;
            }
            response.Schedule = schedule.Result.Schedule;
            return response;
        }
    }
}
