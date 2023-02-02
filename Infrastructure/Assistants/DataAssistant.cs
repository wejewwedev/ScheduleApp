using Domain.Enums;
using Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Infrastructure.Assistants
{
    public class DataAssistant
    {
        // сделать общие методы для получения данных
        public static async Task<string> GetJsonAsync(string address)
        {
            var client = new HttpClient(); // httpClientFactory.Create("base)
            var uri = new UriBuilder(address);
            var request = new HttpRequestMessage(HttpMethod.Get, uri.Uri);
            HttpResponseMessage response = client.Send(request);
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }
        /// <summary>
        /// Get Groups by date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static async Task<DSTUModel> GetDSTUModel(DateTime date, Actions action)
        {
            var model = new DSTUModel();
            try
            {
                if (action == Actions.Group)
                {
                    string address = $"https://edu.donstu.ru/api/raspGrouplist?year={date.Year - 1}-{date.Year}";
                    var json = await GetJsonAsync(address);
                    model = JsonSerializer.Deserialize<DSTUModel>(json);
                }
                if (action == Actions.Teacher)
                {
                    string address = $"https://edu.donstu.ru/api/raspTeacherlist?year={date.Year - 1}-{date.Year}";
                    var json = await GetJsonAsync(address);
                    model = JsonSerializer.Deserialize<DSTUModel>(json);
                }
                if (action == Actions.Audience)
                {
                    string address = $"https://edu.donstu.ru/api/raspAudlist?year={date.Year - 1}-{date.Year}";
                    var json = await GetJsonAsync(address);
                    model = JsonSerializer.Deserialize<DSTUModel>(json);
                }
            }
            catch
            {
                model = null;
            }

            return model;
        }
        /// <summary>
        /// Get Group by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<Data> GetDataAsync(int id, Actions action)
        {
            var data = new Data();
            try
            {
                if (action == Actions.Group)
                {
                    string address = $"https://edu.donstu.ru/api/rasp?idGroup={id}&sdate=2023-02-02"; // дата
                    var json = await GetJsonAsync(address);
                    data = JsonSerializer.Deserialize<Root>(json).Data;
                }
                if (action == Actions.Teacher)
                {
                    string address = $"https://edu.donstu.ru/api/rasp?idTeacher={id}&sdate=2023-02-02";
                    var json = await GetJsonAsync(address);
                    data = JsonSerializer.Deserialize<Root>(json).Data;
                }
                if (action == Actions.Audience)
                {
                    string address = $"https://edu.donstu.ru/api/rasp?idAudLine={id}&sdate=2023-02-02";
                    var json = await GetJsonAsync(address);
                    data = JsonSerializer.Deserialize<Root>(json).Data;
                }
            }
            catch
            {
                data = null;
            }

            return data;
        }
        ///// <summary>
        ///// Get Teachers by date
        ///// </summary>
        ///// <param name="date"></param>
        ///// <returns></returns>
        //public static async Task<TeacherInfo> GetTeachersAsync(DateTime date)
        //{
        //    var teachers = new TeacherInfo();

        //    string address = $"https://edu.donstu.ru/api/raspTeacherlist?year={date.Year - 1}-{date.Year}";
        //    var json = await GetJsonAsync(address);
        //    teachers = JsonSerializer.Deserialize<TeacherInfo>(json);

        //    return teachers;
        //}
        ///// <summary>
        /////  Get Teacher by id
        ///// </summary>
        ///// <param name="teacherId"></param>
        ///// <returns></returns>
        //public static async Task<Data> GetTeacherRaspAsync(int teacherId)
        //{
        //    var data = new Data();

        //    string address = $"https://edu.donstu.ru/api/Schedule?idTeacher={teacherId}&sdate=2023-02-02"; // дата
        //    var json = await GetJsonAsync(address);
        //    data = JsonSerializer.Deserialize<Root>(json).Data;

        //    return data;
        //}
        ///// <summary>
        ///// Get Audiences by date
        ///// </summary>
        ///// <param name="date"></param>
        ///// <returns></returns>
        //public static async Task<GroupInfo> GetAudiencesAsync(DateTime date)
        //{
        //    var audiences = new GroupInfo();

        //    string address = $"https://edu.donstu.ru/api/raspAudlist?year={date.Year - 1}-{date.Year}";
        //    var json = await GetJsonAsync(address);
        //    audiences = JsonSerializer.Deserialize<GroupInfo>(json);

        //    return audiences;
        //}
        ///// <summary>
        ///// Get Audience by id
        ///// </summary>
        ///// <param name="teacherId"></param>
        ///// <returns></returns>
        //public static async Task<Data> GetAudienceRaspAsync(int audienceId)
        //{
        //    var data = new Data();

        //    string address = $"https://edu.donstu.ru/api/Schedule?idAudLine={audienceId}&sdate=2023-02-02"; // дата
        //    var json = await GetJsonAsync(address);
        //    data = JsonSerializer.Deserialize<Root>(json).Data;

        //    return data;
        //}

    }
}
