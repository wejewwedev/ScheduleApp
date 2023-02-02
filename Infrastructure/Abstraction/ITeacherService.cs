using Domain.Enums;
using Domain.Models.Common;
using Domain.Models.Responses;
using Infrastructure.Assistants;

namespace Infrastructure.Abstraction
{
    public interface ITeacherService
    {
        Task<TeachersResponse> GetTeachersAsync();
        Task<TeacherScheduleResponse> GetTeacherScheduleAsync(int id);
    }

    public class TeacherService : ITeacherService
    {
        private readonly DSTUApiService _service;
        public TeacherService(DSTUApiService service)
        {
            _service = service;
        }

        public async Task<TeachersResponse> GetTeachersAsync()
        {
            var response = new TeachersResponse();

            var teachers = _service.GetInfoAsync(Actions.Teacher).Result.Data;
            if (teachers is null)
            {
                response.ErrorMessage = "Данные по преподавателям не найдены";
                return response;
            }
            response.Teachers = teachers;
            return response;
        }

        public async Task<TeacherScheduleResponse> GetTeacherScheduleAsync(int id)
        {
            var response = new TeacherScheduleResponse();

            var schedule = _service.GetInfoAsync(id, Actions.Teacher);
            if (schedule is null)
            {
                response.ErrorMessage = "Расписание преподавателя не найдено";
                return response;
            }
            response.Schedule = schedule.Result.Schedule;
            return response;
        }
    }
}
