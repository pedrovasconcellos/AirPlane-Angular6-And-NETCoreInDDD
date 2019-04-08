using AirPlaneDDD.Application.Interfaces;
using AirPlaneDDD.Domain.Interfaces.AirPlanes;
using AirPlaneDDD.WebAPI.Models;
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

        private readonly IAppAirPlane _IAppAirPlane;

        public AirPlaneController(IAppAirPlane iAppAirPlane)
        {
            this._IAppAirPlane = iAppAirPlane;
        }

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
            List<AirPlaneDDD.Domain.Entities.AirPlane> airPlanes = this._IAppAirPlane.List(code, model, numberOfPassengers, creationDate);

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

            var airPlane = this._IAppAirPlane.GetEntity(identifier);

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

            var entity = new AirPlaneDDD.Domain.Entities.AirPlane() {
                Code = airPlane.Code,
                NumberOfPassengers = airPlane.NumberOfPassengers,
                ModelId = airPlane.Model.Id
            };

            var result = this._IAppAirPlane.AddEntity(entity);

            if (result.Errors.Count > 0) return await Task.FromResult<ActionResult>(this.UnprocessableEntity(result.Errors.First()));
            else return await Task.FromResult<ActionResult>(this.Created(result.Response.Id.ToString(), result.Response));
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
                return await Task.FromResult<ActionResult>(this.BadRequest(new ErrorModel(1, "AirPlane", "AirPlane invalid!").ToList()));

            var entity = new AirPlaneDDD.Domain.Entities.AirPlane()
            {
                Code = airPlane.Code,
                NumberOfPassengers = airPlane.NumberOfPassengers,
                ModelId = airPlane.Model.Id
            };

            var result = this._IAppAirPlane.Update(identifier, entity);
            if (result.Errors.Count > 0) return await Task.FromResult<ActionResult>(this.UnprocessableEntity(result.Errors.First()));
            else return await Task.FromResult<ActionResult>(this.Ok(result.Response));
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
            List<AirPlaneModel> AirPlaneRepository = new List<AirPlaneModel>();//n tava

            Guid identifier = Guid.Empty;
            if (!Guid.TryParse(id, out identifier))
                return await Task.FromResult<ActionResult>(this.BadRequest(new ErrorModel(1, "Id", "Invalid ID!").ToList()));

            var selectedAirPlane = this._IAppAirPlane.Delete(identifier);
            if (selectedAirPlane == null) return await Task.FromResult<ActionResult>(this.NotFound());

            if (selectedAirPlane <= 0) return await Task.FromResult<ActionResult>(this.UnprocessableEntity());
            else return await Task.FromResult<ActionResult>(this.Ok("The AirPlane was successfully removed."));
        }
    }
}