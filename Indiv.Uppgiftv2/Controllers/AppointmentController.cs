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

namespace Indiv.Uppgiftv2.Controllers
{

    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointment<Appointment> _appointment;
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "appointments.json");
        public AppointmentController(IAppointment<Appointment> appointment)
        {
            _appointment = appointment;

        }

        [HttpGet("week", Name = "GetAppointmentByWeek")]
        public async Task<ActionResult<Appointment>> GetAppointmentByWeek()
        {
            try
            {
                var appoinments = await _appointment.GetAllAppointmentsThisWeek();
                return Ok(appoinments);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve appointment from database.");

            }
        }
        [HttpGet("month", Name = "GetAppointmentByMonth")]
        public async Task<ActionResult<Appointment>> GetAppointmentByMonth()
        {
            try
            {
                var appoinments = await _appointment.GetAllAppointmentsThisMonth();
                return Ok(appoinments);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve appointment from database.");

            }
        }
        [HttpGet("{id:int}", Name = "GetSingleAppointment")]
        public async Task<ActionResult<Appointment>> GetSingleAppointment(int id)
        {
            try
            {
                var result = await _appointment.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve appointment from database.");

            }
        }
        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateNewAppointment(Appointment newAppointment)
        {
            try
            {
                if (newAppointment == null)
                {
                    return BadRequest();
                }
                var createdAppointment = await _appointment.Add(newAppointment);
                return CreatedAtAction(nameof(GetSingleAppointment),
                    new
                    {
                        id = createdAppointment.AppointmentID
                    }, createdAppointment);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve appointment from database.");

            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        {
            try
            {
                var appointmentToDelete = await _appointment.GetSingle(id);
                if (appointmentToDelete == null)
                {
                    return NotFound($"Appointment with id {id} doesn't exist in database.");

                }
                return await _appointment.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve appointment from database.");

            }
        }
        [HttpPut("{id:int}", Name = "UpdateAppointment")]
        public async Task<ActionResult<Appointment>> UpdateAppointment(int id, Appointment appointment)
        {
            try
            {
                if (id != appointment.AppointmentID)
                {
                    return BadRequest($"Appointment ID {id} not found.");
                }
                var appointmentToUpdate = await _appointment.GetSingle(id);
                if (appointmentToUpdate == null)
                {
                    return NotFound($"Appointment with ID {id} not found.");
                }

                // Store original appointment JSON before updating
                var originalJson = JsonSerializer.Serialize(appointmentToUpdate);

                // Update appointment details
                appointmentToUpdate.Date = appointment.Date;
                appointmentToUpdate.StartTime = appointment.StartTime;
                appointmentToUpdate.EndTime = appointment.StartTime.AddHours(1); // Ensure EndTime is set correctly

                // Save changes to database
                await _appointment.SaveChangesAsync();

                // Save appointments to file and log changes
                await SaveAppointmentsToFile(appointmentToUpdate, originalJson);

                return Ok(appointmentToUpdate);
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
                    Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                new DateTimeConverter()
            },
                    ReferenceHandler = ReferenceHandler.Preserve // Handle object cycles
                };

                var json = JsonSerializer.Serialize(appointments, options);

                // Write the JSON to the file, overwriting the existing content
                await System.IO.File.WriteAllTextAsync(_filePath, json);

                // Create an object to represent the change
                var change = new
                {
                    AppointmentID = updatedAppointment.AppointmentID,
                    ChangeType = "Update",
                    Timestamp = DateTime.UtcNow,
                    PreviousValue = originalJson,
                    NewValue = JsonSerializer.Serialize(updatedAppointment)
                };

                // Serialize the change object
                var changeJson = JsonSerializer.Serialize(change);

                // Append the change to the file
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
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (DateTime.TryParseExact(reader.GetString(), "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datetime))
                {
                    return datetime;
                }
            }
            throw new JsonException("Failed to parse datetime.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss"));
        }
    }
}
