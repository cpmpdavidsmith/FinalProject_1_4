using System;
using System.Collections.Generic;
using System.Data;
using Dapper;


namespace FinalProject_1_4.Models
{
	public class ScheduleRepository : IScheduleRepository
	{
        private readonly IDbConnection _conn;

        public ScheduleRepository(IDbConnection conn)
		{
            _conn = conn;
        }

        public Schedule AssignCategory()
        {
            var categoryList = GetCategories();
            var schedule = new Schedule();
            schedule.Categories = categoryList;
            return schedule;
        }

        public void DeleteSchedule(Schedule Schedule)
        {
            _conn.Execute("DELETE FROM Schedule WHERE Day = @Day;", new { day = Schedule.Day });//might have to add more properties to this method 
        }

        public IEnumerable<Schedule> GetAllSchedule()
        {
            const string Sql = "SELECT * FROM SCHEDULE;";
            return _conn.Query<Schedule>(Sql);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM CATEGORIES;");
        }

        public Schedule GetSchedule(int Day)
        {
            return _conn.QuerySingle<Schedule>("SELECT * FROM SCHEDULE WHERE DAY = @Day",
                new { Day = Day });
        }

        public void InsertSchedule(Schedule scheduleToInsert)//continue
        {
            _conn.Execute("INSERT INTO SCHEDULE (DAY, USERID, MONDAY, TUESDAY, WEDNESDAY, THURSDAY," +
                "FRIDAY, SATURDAY, SUNDAY) VALUES(@day, @userid @monday, @tuesday, @wednesday, @thursday," +
                "@friday, @saturday, @sunday);",             
            new
            {
                day = scheduleToInsert.Day,
                monday = scheduleToInsert.Monday,
                tuesday = scheduleToInsert.Tuesday,
                wednesday = scheduleToInsert.Wednesday,
                thursday = scheduleToInsert.Thursday,
                friday = scheduleToInsert.Friday,
                saturday = scheduleToInsert.Saturday,
                sunday = scheduleToInsert.Sunday,
            });
        }

        public void UpdateSchedule(Schedule schedule)
        {
            _conn.Execute("UPDATE schedule SET Day = @day, UserID = @userid Monday = @monday, Tuesday = @tuesday," +
                "Wdenesday = @wednesday, Thursday = @thursday, Friday = @friday, Saturday = @saturday," +
                "Sunday = @sunday WHERE UserID = @userid", 
                new
                {
                    day = schedule.Day,
                    userid = schedule.UserID,
                    monday = schedule.Monday,
                    tuesday = schedule.Tuesday,
                    wednesday = schedule.Wednesday,
                    thursday = schedule.Thursday,
                    friday = schedule.Friday,
                    saturday = schedule.Saturday,
                    Sunday = schedule.Sunday
                });
        }
    }
}

