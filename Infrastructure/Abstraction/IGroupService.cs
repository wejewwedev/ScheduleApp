using Domain.Enums;
using Domain.Models.Common;
using Domain.Models.Responses;
using Infrastructure.Assistants;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Abstraction
{
    public interface IGroupService
    {
        Task<GroupsResponse> GetGroupsAsync();
        Task<GroupScheduleResponse> GetGroupScheduleAsync(int id);
    }

    public class GroupService : IGroupService
    {
        private readonly DSTUApiService _service;
        public GroupService(DSTUApiService service)
        {
            _service = service;
        }

        public async Task<GroupsResponse> GetGroupsAsync()
        {
            var response = new GroupsResponse();

            var groups = _service.GetInfoAsync(Actions.Group).Result.Data;
            if (groups is null)
            {
                response.ErrorMessage = "Данные по группам не найдены";
                return response;
            }
            response.Groups = groups;
            return response;
        }

        public async Task<GroupScheduleResponse> GetGroupScheduleAsync(int id)
        {
            var response = new GroupScheduleResponse();

            var schedule = _service.GetInfoAsync(id, Actions.Group);
            if (schedule is null)
            {
                response.ErrorMessage = "Расписание такой группы не найдено";
                return response;
            }
            response.Schedule = schedule.Result.Schedule;
            return response;
        }
    }
}