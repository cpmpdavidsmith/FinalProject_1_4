using System;
using System.Collections.Generic;

namespace FinalProject_1_4.Models
{
	public interface IScheduleRepository
	{
        public IEnumerable<Schedule> GetAllSchedule();
        public Schedule GetSchedule(int userid);
        public void UpdateSchedule(Schedule schedule);

        public void InsertSchedule(Schedule scheduleToInsert);
        public IEnumerable<Category> GetCategories();

        public Schedule AssignCategory();
        public void DeleteSchedule(Schedule schedule);
    }
}

