using System;
using System.ComponentModel.DataAnnotations;

namespace GymBooking.DTOs
{
	public class CreateGymClassRequest
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		[Required]
		public TimeSpan StartTime { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int DurationMinutes { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Capacity { get; set; }
	}
}