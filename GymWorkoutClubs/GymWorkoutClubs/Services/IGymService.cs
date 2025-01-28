using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymBooking.Models;
using GymBooking.DTOs;

namespace GymBooking.Services
{
	public interface IGymService
	{
		Task<GymClass> CreateClassAsync(CreateGymClassRequest request);
		Task<Booking> CreateBookingAsync(CreateBookingRequest request);
		Task<IEnumerable<BookingResponse>> SearchBookingsAsync(BookingSearchRequest request);
	}
}