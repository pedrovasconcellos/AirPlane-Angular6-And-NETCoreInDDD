using AirPlane.WebAPI.Help;
using AirPlane.WebAPI.Models;
using AirPlane.WebAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirPlane.WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class AirPlaneController : ControllerBase
    {
        //https://localhost:5001/v1/AirPlanes??code=5
        /// <summary>
        /// Get AirPlane
        /// </summary> 
        /// <response code="200">Ok</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IList<AirPlaneModel>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IList<AirPlaneModel>>> GetAirPlane(string code, string model, short? numberOfPassengers, DateTime? creationDate)
        {
            IEnumerable<AirPlaneModel> airPlanes = AirPlaneRepository.AirPlanes;

            if (!string.IsNullOrEmpty(code))
                airPlanes = airPlanes.Where(x => x.Code.Contains(code, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(model))
                airPlanes = airPlanes.Where(x => x.Model.Name.Contains(model, StringComparison.OrdinalIgnoreCase));

            if (numberOfPassengers != null && numberOfPassengers >= 0)
                airPlanes = airPlanes.Where(x => x.NumberOfPassengers == numberOfPassengers);

            if (creationDate != null)
                airPlanes = airPlanes.Where(x => x.CreationDate == creationDate);

            Request.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "X-Total-Count");
            Request.HttpContext.Response.Headers.Add("X-Total-Count", airPlanes?.Count().ToString());

            return await Task.FromResult<ActionResult>(this.Ok(airPlanes));
        }

        /// <summary>
        /// Get AirPlane
        /// </summary> 
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AirPlaneModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AirPlaneModel>> GetAirPlanes(string id)
        {
            Guid identifier = Guid.Empty;
            if (!Guid.TryParse(id, out identifier))
                return await Task.FromResult<ActionResult>(this.BadRequest(new ErrorModel(1, "Id", "Invalid ID!").ToList()));

            var airPlane = this.SelectAirPlane(identifier);

            if (airPlane == null) return await Task.FromResult<ActionResult>(this.NotFound());
            else return await Task.FromResult<ActionResult>(this.Ok(airPlane)); ;
        }

        /// <summary>
        /// Create AirPlane
        /// </summary> 
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AirPlaneModel), 201)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(string), 422)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AirPlaneModel>> CreateAirPlane([FromBody] AirPlaneAddModel airPlane)
        {
            if (airPlane == null)
                return await Task.FromResult<ActionResult>(this.BadRequest(new ErrorModel(1, "AirPlane", "The AirPlane can not be null!").ToList()));

            if (airPlane.NumberOfPassengers > 300)
                return await Task.FromResult<ActionResult>(this.UnprocessableEntity("Air Plane number of passengers is invalid!"));

            if(AirPlaneRepository.AirPlanes.Count() > 30)
                return await Task.FromResult<ActionResult>(this.UnprocessableEntity("It is not possible to add more Air Planes, please delete the available Air Planes!"));

            if(!AirPlaneRepository.AirPlanes.Any(x => x.Model.Id == airPlane.Model.Id))
                return await Task.FromResult<ActionResult>(this.UnprocessableEntity("There is no such model airplane registered in the system!"));

            var result = this.InsertAirPlane(airPlane);

            if (result == null) return await Task.FromResult<ActionResult>(this.UnprocessableEntity("This AirPlane has already been registered!"));
            else return await Task.FromResult<ActionResult>(this.Created(result.Id.ToString(), result));
        }

        /// <summary>
        /// Update AirPlane
        /// </summary> 
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AirPlaneModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 422)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AirPlaneModel>> UpdateAirPlane(string id, [FromBody] AirPlaneAlterModel airPlane)
        {
            Guid identifier = Guid.Empty;
            if (!Guid.TryParse(id, out identifier))
                return await Task.FromResult<ActionResult>(this.BadRequest(new ErrorModel(1, "Id", "Invalid ID!").ToList()));

            if (airPlane == null)
                return await Task.FromResult<ActionResult>(this.BadRequest(new ErrorModel(1, "Id", "The AirPlane can not be null!").ToList()));

            if (!AirPlaneRepository.AirPlanes.Any(x => x.Model.Id == airPlane.Model.Id))
                return await Task.FromResult<ActionResult>(this.UnprocessableEntity("There is no such model airplane registered in the system!"));

            var selectedAirPlane = this.SelectAirPlane(identifier);
            if (selectedAirPlane == null) return await Task.FromResult<ActionResult>(this.NotFound());
            else this.AlterAirPlane(selectedAirPlane, airPlane);

            selectedAirPlane = this.SelectAirPlane(identifier);

            return await Task.FromResult<ActionResult>(this.Ok(selectedAirPlane));
        }

        /// <summary>
        /// Remove AirPlane
        /// </summary> 
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="422">Unprocessable Entity</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<string>> RemoveAirPlane(string id)
        {
            Guid identifier = Guid.Empty;
            if (!Guid.TryParse(id, out identifier))
                return await Task.FromResult<ActionResult>(this.BadRequest(new ErrorModel(1, "Id", "Invalid ID!").ToList()));

            var selectedAirPlane = this.SelectAirPlane(identifier);
            if (selectedAirPlane == null) return await Task.FromResult<ActionResult>(this.NotFound());

            var removed = AirPlaneRepository.AirPlanes.Remove(selectedAirPlane);
            if (removed == false) return await Task.FromResult<ActionResult>(this.UnprocessableEntity());
            else return await Task.FromResult<ActionResult>(this.Ok("The AirPlane was successfully removed."));
        }


        private void AlterAirPlane(AirPlaneModel selectedAirPlane, AirPlaneAlterModel airPlane)
        {
            selectedAirPlane.Model.Id = airPlane.Model.Id;
            selectedAirPlane.Code = airPlane.Code;
        }

        private AirPlaneModel SelectAirPlane(Guid identifier)
        {
            return AirPlaneRepository.AirPlanes.FirstOrDefault(x => x.Id == identifier);
        }

        private AirPlaneModel InsertAirPlane(AirPlaneAddModel airPlane)
        {
            if (AirPlaneRepository.AirPlanes.Any(x => x.Code.Equals(airPlane.Code, StringComparison.OrdinalIgnoreCase)))
                return null;

            var entity = new AirPlaneModel(airPlane);
            AirPlaneRepository.AirPlanes.Add(entity);
            return entity;
        }
    }
}
