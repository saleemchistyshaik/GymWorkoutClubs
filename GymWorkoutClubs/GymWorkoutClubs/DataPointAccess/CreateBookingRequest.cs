using System;
using System.ComponentModel.DataAnnotations;

namespace GymBooking.DTOs
{
	public class CreateBookingRequest
	{
		[Required]
		public string MemberName { get; set; }

		[Required]
		public Guid ClassId { get; set; }

		[Required]
		public DateTime ParticipationDate { get; set; }
	}
}