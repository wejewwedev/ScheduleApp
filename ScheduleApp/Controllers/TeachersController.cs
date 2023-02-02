using Domain.Models.Responses;
using Infrastructure.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace ScheduleApp.Controllers
{
    public class TeachersController : BaseApiController
    {
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // GET: api/Teachers; Get all teachers by date (service)
        [HttpGet]
        public async Task<TeachersResponse> Teachers()
        {
            var response = new TeachersResponse();
            try
            {
                response = await _teacherService.GetTeachersAsync();
                if (response is null || response.Teachers.Count <= 0)
                {
                    response.IsSuccessful = false;
                    response.ErrorMessage = "Данные по преподавателям не найдены";
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
        // GET: api/Teachers/Id Get teacher by id
        [HttpGet]
        [Route("{id}")]
        public async Task<TeacherScheduleResponse> Teachers(int id)
        {
            var response = new TeacherScheduleResponse();
            try
            {
                response = await _teacherService.GetTeacherScheduleAsync(id);
                if (response is null || response.Schedule.Count <= 0)
                {
                    response.IsSuccessful = false;
                    response.ErrorMessage = "Расписание такого преподавателя не найдено";
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
