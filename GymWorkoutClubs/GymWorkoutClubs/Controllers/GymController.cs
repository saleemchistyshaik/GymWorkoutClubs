using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymBooking.Models;
using GymBooking.Services;

namespace GymBooking.Controllers
{
	[ApiController]
	[Route("api/gym")]
	public class GymController : ControllerBase
	{
		private readonly GymService _service;

		public GymController(GymService service)
		{
			_service = service;
		}

		[HttpPost("classes")]
		public async Task<IActionResult> CreateClass([FromBody] GymClass gymClass)
		{
			try
			{
				var result = await _service.CreateClass(gymClass);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("bookings")]
		public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
		{
			try
			{
				var result = await _service.CreateBooking(booking);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("bookings")]
		public async Task<IActionResult> SearchBookings(
			[FromQuery] string memberName,
			[FromQuery] DateTime? startDate,
			[FromQuery] DateTime? endDate)
		{
			var results = await _service.SearchBookings(memberName, startDate, endDate);
			return Ok(results);
		}
	}
}