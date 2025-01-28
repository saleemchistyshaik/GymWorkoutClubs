using System;

namespace GymBooking.DTOs
{
	public class BookingResponse
	{
		public Guid BookingId { get; set; }
		public string ClassName { get; set; }
		public TimeSpan ClassStartTime { get; set; }
		public DateTime ParticipationDate { get; set; }
		public string MemberName { get; set; }
	}
}