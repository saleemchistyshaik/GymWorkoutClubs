using System;

namespace GymBooking.Models
{
	public class Booking
	{
		public Guid Id { get; set; } = Guid.NewGuid(); // used in the code to uniquely identify classes and bookings
		public string MemberName { get; set; }
		public Guid ClassId { get; set; }
		public DateTime ParticipationDate { get; set; }
	}
}