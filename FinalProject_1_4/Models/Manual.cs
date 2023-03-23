using System;
namespace FinalProject_1_4.Models
{
	public class Manual
	{
		public Manual()
		{
		}
        //manual schedule inputs for days of the week 
        public int MondayStart { get; set; }
        public int MondayFinnish { get; set; }
        public int TuesdayStart { get; set; }
        public int TuesdayFinnish { get; set; }
        public int WednesdayStart { get; set; }
        public int WednesdayFinnish { get; set; }
        public int ThursdayStart { get; set; }
        public int ThursdayFinnish { get; set; }
        public double FridayStart { get; set; }
        public int FridayFinnish { get; set; }
        public double SaturdayStart { get; set; }
        public int SaturdayFinnish { get; set; }
        public double SundayStart { get; set; }
        public int SundayFinnish { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
    }
}

