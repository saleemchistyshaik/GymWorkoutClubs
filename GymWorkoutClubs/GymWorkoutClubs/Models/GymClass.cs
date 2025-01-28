using System;

namespace GymBooking.Models
{
	public class GymClass
	{
		public Guid Id { get; set; } = Guid.NewGuid(); // used in the code to uniquely identify classes and bookings
		public string Name { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public TimeSpan StartTime { get; set; }
		public int DurationMinutes { get; set; }
		public int Capacity { get; set; }
	}
}