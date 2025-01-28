using System;

namespace GymBooking.DTOs
{
	public class BookingSearchRequest
	{
		public string? MemberName { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
	}
}