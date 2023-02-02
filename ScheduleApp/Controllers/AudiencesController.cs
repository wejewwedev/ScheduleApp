using Domain.Models.Responses;
using Infrastructure.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace ScheduleApp.Controllers
{
    public class AudiencesController : BaseApiController
    {
        private readonly IAudienceService _audienceService;
        public AudiencesController(IAudienceService audienceService)
        {
            _audienceService = audienceService;
        }

        // GET: api/Audiences; Get all audiences by date (service)
        [HttpGet]
        public async Task<AudiencesResponse> Audiences()
        {
            var response = new AudiencesResponse();

            try
            {
                response = await _audienceService.GetAudiencesAsync();
                if (response is null || response.Audiences.Count <= 0)
                {
                    response.IsSuccessful = false;
                    response.ErrorMessage = "Данные по аудиториям не найдены";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Произошла ошибка: " + ex.Message;
                response.IsSuccessful = false;
                return response;
            }

            response.IsSuccessful = true;
            return response;
        }
        // GET: api/Audiences/Id Get audience rasp by id
        [HttpGet]
        [Route("{id}")]
        public async Task<AudienceScheduleResponse> Audiences(int id)
        {
            var response = new AudienceScheduleResponse();

            try
            {
                response = await _audienceService.GetAudienceScheduleAsync(id);
                if (response is null || response.Schedule.Count <= 0)
                {
                    response.IsSuccessful = false;
                    response.ErrorMessage = "Расписание такой аудитории не найдено";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Произошла ошибка: " + ex.Message;
                response.IsSuccessful = false;
                return response;
            }

            response.IsSuccessful = true;
            return response;
        }
    }
}