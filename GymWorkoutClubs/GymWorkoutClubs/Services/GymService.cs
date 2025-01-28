using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymBooking.Models;

namespace GymBooking.Services
{
	public class GymService
	{
		private readonly List<GymClass> _classes = new();
		private readonly List<Booking> _bookings = new();

		public async Task<GymClass> CreateClass(GymClass gymClass)
		{
			if (gymClass.EndDate <= DateTime.Now)
				throw new Exception("End date must be in the future");

			if (gymClass.Capacity < 1)
				throw new Exception("Capacity must be at least 1");

			_classes.Add(gymClass);
			return await Task.FromResult(gymClass);
		}

		public async Task<Booking> CreateBooking(Booking booking)
		{
			var gymClass = _classes.FirstOrDefault(c => c.Id == booking.ClassId);
			if (gymClass == null)
				throw new Exception("Class not found");

			if (booking.ParticipationDate <= DateTime.Now)
				throw new Exception("Participation date must be in the future");

			var bookingsForClass = _bookings.Count(b =>
				b.ClassId == booking.ClassId &&
				b.ParticipationDate.Date == booking.ParticipationDate.Date);

			if (bookingsForClass >= gymClass.Capacity)
				throw new Exception("Class is full");

			_bookings.Add(booking);
			return await Task.FromResult(booking);
		}

		public async Task<List<dynamic>> SearchBookings(string memberName = null, DateTime? startDate = null, DateTime? endDate = null)
		{
			var query = _bookings.AsQueryable();

			if (!string.IsNullOrEmpty(memberName))
				query = query.Where(b => b.MemberName.Contains(memberName));

			if (startDate.HasValue)
				query = query.Where(b => b.ParticipationDate >= startDate.Value);

			if (endDate.HasValue)
				query = query.Where(b => b.ParticipationDate <= endDate.Value);

			var results = query
				.Join(_classes,
					booking => booking.ClassId,
					gymClass => gymClass.Id,
					(booking, gymClass) => new
					{
						BookingId = booking.Id,
						ClassName = gymClass.Name,
						ClassTime = gymClass.StartTime,
						Date = booking.ParticipationDate,
						Member = booking.MemberName
					})
				.ToList<dynamic>();

			return await Task.FromResult(results);
		}
	}
}