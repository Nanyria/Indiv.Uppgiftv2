using System.IO;
using Indiv.Uppgiftv2.Services;
using IndUppClassModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Globalization;
using Indiv.Uppgiftv2.Methods;
using IndProjModels;
using AutoMapper;

namespace Indiv.Uppgiftv2.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointment<Appointment> _appointment;
        private IMapper _mapper;
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "appointments.json");
        public AppointmentController(IAppointment<Appointment> appointment, IMapper mapper)
        {
            _appointment = appointment;
            _mapper = mapper;

        }

        [HttpGet("week", Name = "GetAppointmentByWeek")]
        public async Task<ActionResult<AppointmentDTO>> GetAppointmentByWeek()
        {
            try
            {
                var appoinments = await _appointment.GetAllAppointmentsThisWeek();
                var appointmentDTO = appoinments.Select(p => _mapper.Map<AppointmentDTO>(p)).ToList();
                return Ok(appointmentDTO);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve appointment from database.");

            }
        }
        [HttpGet("month", Name = "GetAppointmentByMonth")]
        public async Task<ActionResult<AppointmentDTO>> GetAppointmentByMonth()
        {
            try
            {
                var appoinments = await _appointment.GetAllAppointmentsThisMonth();
                var appointmentDTO = appoinments.Select(p => _mapper.Map<AppointmentDTO>(p)).ToList();
                return Ok(appointmentDTO);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve appointment from database.");

            }
        }
        [HttpGet("{id:int}", Name = "GetSingleAppointment")]
        public async Task<ActionResult<AppointmentDTO>> GetSingleAppointment(int id)
        {
            try
            {
                var appointment = await _appointment.GetSingle(id);
                if (appointment == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<AppointmentDTO>(appointment));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve appointment from database.");

            }
        }
        [HttpPost]
        public async Task<ActionResult<AppointmentDTO>> CreateNewAppointment(AppointmentDTO newAppointmentDTO)
        {
            try
            {
                if (newAppointmentDTO == null)
                {
                    return BadRequest();
                }
                var newAppointment = _mapper.Map<Appointment>(newAppointmentDTO);
                var createdAppointment = await _appointment.Add(newAppointment);
                var createdAppointmentDTO = _mapper.Map<AppointmentDTO>(createdAppointment);
                return CreatedAtAction(nameof(GetSingleAppointment),
                    new
                    {
                        id = createdAppointmentDTO.AppointmentID
                    }, createdAppointmentDTO);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve appointment from database.");

            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AppointmentDTO>> DeleteAppointment(int id)
        {
            try
            {
                var appointmentToDelete = await _appointment.GetSingle(id);
                if (appointmentToDelete == null)
                {
                    return NotFound($"Appointment with id {id} doesn't exist in database.");

                }
                var deletedAppointment = await _appointment.Delete(id);
                return Ok(_mapper.Map<AppointmentDTO>(deletedAppointment));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve appointment from database.");

            }
        }
        [HttpPut("{id:int}", Name = "UpdateAppointment")]
        public async Task<ActionResult<AppointmentDTO>> UpdateAppointment(int id, AppointmentDTO appointmentDTO)
        {
            try
            {
                if (id != appointmentDTO.AppointmentID)
                {
                    return BadRequest($"Appointment ID {id} not found.");
                }
                var appointmentToUpdate = await _appointment.GetSingle(id);
                if (appointmentToUpdate == null)
                {
                    return NotFound($"Appointment with ID {id} not found.");
                }

                // Store original appointment JSON before updating
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters = { new JsonStringEnumConverter() },
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };
                var originalJson = JsonSerializer.Serialize(appointmentToUpdate, options);
                //Mapping
                _mapper.Map(appointmentDTO, appointmentToUpdate);
                // Update appointment details
                appointmentToUpdate.Date = appointmentDTO.Date;
                appointmentToUpdate.StartTime = appointmentDTO.StartTime;
                appointmentToUpdate.EndTime = appointmentDTO.StartTime.AddHours(1); // Ensure EndTime is set correctly

                // Save changes to database
                await _appointment.SaveChangesAsync();

                // Save appointments to file and log changes
                await SaveAppointmentsToFile(appointmentToUpdate, originalJson);

                return Ok(_mapper.Map<AppointmentDTO>(appointmentToUpdate));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");

            }
        }
        private async Task SaveAppointmentsToFile(Appointment updatedAppointment, string originalJson)
        {
            try
            {
                // Check if the directory exists
                string directoryPath = Path.GetDirectoryName(_filePath);
                if (!Directory.Exists(directoryPath))
                {

                    Directory.CreateDirectory(directoryPath); // Create the directory if it doesn't exist
                }

                var appointments = await _appointment.GetAllAppointmentsThisMonth();

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
                };
                ;
                var change = new
                {
                    AppointmentID = updatedAppointment.AppointmentID,
                    ChangeType = "Update",
                    Timestamp = DateTime.UtcNow.ToString("o"),
                    PreviousValue = originalJson,
                    NewValue = JsonSerializer.Serialize(updatedAppointment, options)
                };

                var changeJson = JsonSerializer.Serialize(change, options);

                await System.IO.File.AppendAllTextAsync(_filePath, changeJson + Environment.NewLine);
            }

            catch (Exception ex)
            {
                // Handle exceptions appropriately (logging, etc.)
                Console.WriteLine($"Failed to save appointment change to file. Error: {ex.Message}");
                throw new Exception("Failed to save appointment change to file.", ex);
            }
        }

    }
    //public class DateTimeConverter : JsonConverter<DateTime>
    //{
    //    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    //    {
    //        if (reader.TokenType == JsonTokenType.String)
    //        {
    //            if (DateTime.TryParseExact(reader.GetString(), "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime))
    //            {
    //                return datetime;
    //            }
    //        }
    //        throw new JsonException("Failed to parse datetime.");
    //    }

    //    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    //    {
    //        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss"));
    //    }
    //}
}
