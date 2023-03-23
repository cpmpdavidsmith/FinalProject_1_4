using System;
namespace FinalProject_1_4.Models
{
	public class User
	{
		public User()
		{
		}

       

        public int UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int CategoryID { get; set; }
        public double UserTotalAllowedHours { get; set; }
        public double UserScheduledHours { get; set; }
        public double UserCompletedHours { get; set; }
        public double UserAvailableScheduledHours { get; set; }
        public double UserAvailableFreeHours { get; set; }                      //hours outside of scheduled hours and total allowed hours
        public string? UserPhoneNumber { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
    }
}

