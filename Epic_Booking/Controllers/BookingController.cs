using Microsoft.AspNetCore.Mvc;
using Epic_Booking.Models;
using Epic_Booking.Models.Dto;
using AutoMapper;
using MagicVilla_VillaAPI.Models;
using System.Net;
using Epic_Booking.Repository.IBookingRepostiory;

namespace Epic_Booking.Controllers
{

    [Route("bookings")]
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public BookingController(IBookingRepository bookingRepo, IMapper mapper)
        {
            _bookingRepo = bookingRepo;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAllBookings()
        {
            try
            {
                List<Booking> bookings = await _bookingRepo.GetAllAsync();

                _response.Result = bookings;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }        

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateBooking([FromBody] BookingCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                Booking booking = _mapper.Map<Booking>(createDTO);

                await _bookingRepo.CreateAsync(booking);
                _response.Result = _mapper.Map<BookingDTO>(booking);
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateBooking(int id, [FromBody] BookingUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Booking model = _mapper.Map<Booking>(updateDTO);

                await _bookingRepo.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<APIResponse>> DeleteBooking(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var booking = await _bookingRepo.GetByIdAsync(id);
                if (booking == null)
                {
                    return NotFound();
                }
                await _bookingRepo.DeleteAsync(booking);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }        
    }
}

