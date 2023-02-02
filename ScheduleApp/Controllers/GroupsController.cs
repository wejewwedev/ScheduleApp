using Domain.Models.Responses;
using Infrastructure.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace ScheduleApp.Controllers
{
    public class GroupsController : BaseApiController
    {
        private readonly IGroupService _groupService;
        public GroupsController(IGroupService groupService) 
        { 
            _groupService = groupService; 
        }

        // GET: api/Groups; Get all groups by date (service)
        [HttpGet]
        public async Task<GroupsResponse> Groups()
        {
            var response = new GroupsResponse();

            try
            {
                response = await _groupService.GetGroupsAsync();
                if (response is null || response.Groups.Count <= 0)
                {
                    response.IsSuccessful = false;
                    response.ErrorMessage = "Данные по группам не найдены";
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
        // GET: api/Groups/Id Get group rasp by id
        [HttpGet]
        [Route("{id}")]
        public async Task<GroupScheduleResponse> Groups(int id)
        {
            var response = new GroupScheduleResponse();
            try
            {
                response = await _groupService.GetGroupScheduleAsync(id);
                if (response is null || response.Schedule.Count <= 0)
                {
                    response.IsSuccessful = false;
                    response.ErrorMessage = "Расписание такой группы не найдено";
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
