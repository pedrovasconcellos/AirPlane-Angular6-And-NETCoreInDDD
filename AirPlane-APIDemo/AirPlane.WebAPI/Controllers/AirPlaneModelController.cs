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
    public class AirPlaneModelController : ControllerBase
    {
        //https://localhost:5001/v1/AirPlaneModelController?code=5
        /// <summary>
        /// Get AirPlaneModel
        /// </summary> 
        /// <response code="200">Ok</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IList<AirPlaneModelModel>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IList<AirPlaneModelModel>>> GetAirPlaneModel(string name)
        {
            IEnumerable<AirPlaneModelModel> airPlanesModel = AirPlaneRepository.AirPlanModels;

            if (!string.IsNullOrEmpty(name))
                airPlanesModel = airPlanesModel.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            Request.HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "X-Total-Count");
            Request.HttpContext.Response.Headers.Add("X-Total-Count", airPlanesModel?.Count().ToString());

            return await Task.FromResult<ActionResult>(this.Ok(airPlanesModel));
        }

        /// <summary>
        /// Get AirPlaneModel
        /// </summary> 
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AirPlaneModelModel), 200)]
        [ProducesResponseType(typeof(ErrorModel), 400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<AirPlaneModelModel>> GetAirPlaneModels(string id)
        {
            Guid identifier = Guid.Empty;
            if (!Guid.TryParse(id, out identifier))
                return await Task.FromResult<ActionResult>(this.BadRequest(new ErrorModel(1, "Id", "Invalid ID!").ToList()));

            var airPlane = this.SelectAirPlane(identifier);

            if (airPlane == null) return await Task.FromResult<ActionResult>(this.NotFound());
            else return await Task.FromResult<ActionResult>(this.Ok(airPlane)); ;
        }

        private AirPlaneModel SelectAirPlane(Guid identifier)
        {
            return AirPlaneRepository.AirPlanes.FirstOrDefault(x => x.Id == identifier);
        }
    }
}
