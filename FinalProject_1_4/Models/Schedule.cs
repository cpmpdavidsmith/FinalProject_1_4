using System;
using System.Collections.Generic;

namespace FinalProject_1_4.Models
{
	public class Schedule
	{
		public Schedule()
		{
		}
        //manual schedule inputs for days of the week
        public int Day { get; set; }
        public int UserID { get; set; }
        public int Monday { get; set; }
        //public int MondayFinnish { get; set; }
        public int Tuesday { get; set; }
        //public int TuesdayFinnish { get; set; }
        public int Wednesday { get; set; }
        //public int WednesdayFinnish { get; set; }
        public int Thursday { get; set; }
        //public int ThursdayFinnish { get; set; }
        public double Friday { get; set; }
        //public int FridayFinnish { get; set; }
        public double Saturday { get; set; }
        //public int SaturdayFinnish { get; set; }
        public double Sunday { get; set; }
        //public int SundayFinnish { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
    }
}

