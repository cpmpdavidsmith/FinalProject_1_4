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
            _conn.Execute("DELETE FROM Schedule WHERE Day = @Day;", new { day = Schedule.Day });
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
            _conn.Execute("INSERT INTO USER (FIRSTNAME, LASTNAME, USERPHONENUMBER, CATEGORYID," +
                "USERTOTALALLOWEDHOURS, USERSCHEDULEDHOURS, USERCOMPLETEDHOURS," +
                "USERAVAILABLESCHEDULEDHOURS, USERAVAILABLEFREEHOURS) VALUES(@firstname, @lastname, @userphonenumber, @categoryid," +
                "@usertotalallowedhours, @userscheduledhours," +
                "@usercompletedhours, @useravailablescheduledhours," +
                "@useravailablefreehours);",
            new
            {
                firstname = userToInsert.FirstName,
                lastname = userToInsert.LastName,
                userphonenumber = userToInsert.UserPhoneNumber,
                categoryid = userToInsert.CategoryID,
                usertotalallowedhours = userToInsert.UserTotalAllowedHours,
                userscheduledhours = userToInsert.UserScheduledHours,
                usercompletedhours = userToInsert.UserCompletedHours,
                useravailablescheduledhours = userToInsert.UserAvailableScheduledHours,
                useravailablefreehours = userToInsert.UserAvailableFreeHours
            });
        }

        public void UpdateUser(User user)
        {
            _conn.Execute("UPDATE user SET FirstName = @firstname, LastName = @lastname," +
                "UserPhoneNumber = @userphonenumber," +
                "UserTotalAllowedHours = @usertotalallowedhours, " +
                "UserScheduledHours = @userscheduledhours, UserCompletedHours = " +
                "@usercompletedhours, UserAvailableScheduledHours = @useravailablescheduledhours," +
                "UserAvailableFreeHours = @useravailablefreehours WHERE UserID = @userid",
                new
                {
                    firstname = user.FirstName,
                    lastname = user.LastName,
                    userphonenumber = user.UserPhoneNumber,
                    usertotalallowedhours = user.UserTotalAllowedHours,
                    userscheduledhours = user.UserScheduledHours,
                    usercompletedhours = user.UserCompletedHours,
                    useravailablescheduledhours = user.UserAvailableScheduledHours,
                    useravailablefreehours = user.UserAvailableFreeHours,
                    userid = user.UserID
                });
        }
    }
}

