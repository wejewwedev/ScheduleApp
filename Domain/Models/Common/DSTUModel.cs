using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models.Common
{
    public class DSTUModel
    {
        [JsonPropertyName("data")]
        public List<Datum> Data { get; set; }
        [JsonPropertyName("state")]
        public int State { get; set; }
        [JsonPropertyName("msg")]
        public string Msg { get; set; }
    }
    public class Teacher
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("kaf")]
        public string Kaf { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("idFromRasp")]
        public bool IdFromRasp { get; set; }
    }
    public class Datum
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("kurs")]
        public int Kurs { get; set; }
        [JsonPropertyName("facul")]
        public string Facul { get; set; }
        [JsonPropertyName("yearName")]
        public string YearName { get; set; }
        [JsonPropertyName("facultyID")]
        public int FacultyID { get; set; }
    }

    public class Aud
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("isCyclicalSchedule")]
        public bool IsCyclicalSchedule { get; set; }

        [JsonPropertyName("rasp")]
        public List<Schedule> Schedule { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }
    }

    public class Group
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("groupID")]
        public int GroupID { get; set; }
    }

    public class Info
    {
        [JsonPropertyName("group")]
        public Group Group { get; set; }

        [JsonPropertyName("prepod")]
        public Prepod Prepod { get; set; }

        [JsonPropertyName("aud")]
        public Aud Aud { get; set; }

        [JsonPropertyName("year")]
        public string Year { get; set; }

        [JsonPropertyName("curWeekNumber")]
        public int CurWeekNumber { get; set; }

        [JsonPropertyName("curNumNed")]
        public int CurNumNed { get; set; }

        [JsonPropertyName("selectedNumNed")]
        public int SelectedNumNed { get; set; }

        [JsonPropertyName("curSem")]
        public int CurSem { get; set; }

        [JsonPropertyName("typesWeek")]
        public List<TypesWeek> TypesWeek { get; set; }

        [JsonPropertyName("fixedInCache")]
        public bool FixedInCache { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("lastDate")]
        public DateTime LastDate { get; set; }

        [JsonPropertyName("dateUploadingRasp")]
        public DateTime DateUploadingRasp { get; set; }
    }

    public class Prepod
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Schedule
    {
        [JsonPropertyName("код")]
        public int Code { get; set; }

        [JsonPropertyName("дата")]
        public DateTime Date { get; set; }

        [JsonPropertyName("начало")]
        public string Start { get; set; }

        [JsonPropertyName("датаНачала")]
        public DateTime DateStart { get; set; }

        [JsonPropertyName("датаОкончания")]
        public DateTime DateEnd { get; set; }

        [JsonPropertyName("конец")]
        public string End { get; set; }

        [JsonPropertyName("деньНедели")]
        public int DayOfWeek { get; set; }

        [JsonPropertyName("день_недели")]
        public string DayOfWeek2 { get; set; }

        [JsonPropertyName("почта")]
        public string Email { get; set; }

        [JsonPropertyName("день")]
        public string Day { get; set; }

        [JsonPropertyName("код_Семестра")]
        public int TermCode { get; set; }

        [JsonPropertyName("типНедели")]
        public int TypeOfWeek { get; set; }

        [JsonPropertyName("номерПодгруппы")]
        public int NumberOfSubgroup { get; set; }

        [JsonPropertyName("дисциплина")]
        public string Discipline { get; set; }

        [JsonPropertyName("преподаватель")]
        public string Teacher { get; set; }

        [JsonPropertyName("должность")]
        public string Post { get; set; }

        [JsonPropertyName("аудитория")]
        public string Auditoria { get; set; }

        [JsonPropertyName("учебныйГод")]
        public string AcademicYear { get; set; }

        [JsonPropertyName("группа")]
        public string Group { get; set; }

        [JsonPropertyName("custom1")]
        public string Custom1 { get; set; }

        [JsonPropertyName("часы")]
        public string Hours { get; set; }

        [JsonPropertyName("неделяНачала")]
        public int WeekStart { get; set; }

        [JsonPropertyName("неделяОкончания")]
        public int WeekEnd { get; set; }

        [JsonPropertyName("замена")]
        public bool Swap { get; set; }

        [JsonPropertyName("кодПреподавателя")]
        public int TeacherCode { get; set; }

        [JsonPropertyName("кодГруппы")]
        public int GroupCode { get; set; }

        [JsonPropertyName("фиоПреподавателя")]
        public object FullNameTeacher { get; set; }

        [JsonPropertyName("кодПользователя")]
        public object UserCode { get; set; }

        [JsonPropertyName("элементЦиклРасписания")]
        public bool Element { get; set; }

        [JsonPropertyName("тема")]
        public string Topic { get; set; }

        [JsonPropertyName("номерЗанятия")]
        public int NumberOfClass { get; set; }

        [JsonPropertyName("ссылка")]
        public object Link { get; set; }

        [JsonPropertyName("созданиеВебинара")]
        public bool Webinar { get; set; }

        [JsonPropertyName("кодВебинара")]
        public object WebinarCode { get; set; }

        [JsonPropertyName("вебинарЗапущен")]
        public bool WebinarIsStart { get; set; }

        [JsonPropertyName("кодыСтрок")]
        public List<int> StringsCode { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }

        [JsonPropertyName("state")]
        public int State { get; set; }

        [JsonPropertyName("msg")]
        public string Msg { get; set; }
    }

    public class TypesWeek
    {
        [JsonPropertyName("typeWeekID")]
        public int TypeWeekID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }
    }
}
