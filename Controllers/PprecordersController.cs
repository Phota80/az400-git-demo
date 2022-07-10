using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerPlantSampleApi.Models;
using PowerPlantSampleApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PowerPlantSampleApi.Controllers
{    
    [Produces("application/json")]
    [Route("api/[controller]")] 
    [ApiController]
    public class PprecordersController : ControllerBase
    {
        private readonly IPowerPlantRecorderRepository _powerplantRep;
        public PprecordersController(IPowerPlantRecorderRepository powerplantRepository)
        {
            _powerplantRep = powerplantRepository;
        }
        // GET: api/<PprecordersController>
        [HttpGet]
        public async Task<List<MeasurementInfo>> GetInstrumentMeasurements()
        {
            return await _powerplantRep.GetInstrumentMeasurements();
        }

        // GET api/<PprecordersController>/5
        [HttpGet("{id}")]
        public async Task<MeasurementInfo> Get(int id)
        {
            return await _powerplantRep.GetInstrumentMeasurementById(id);
        }

        // POST api/<PprecordersController>
        [AllowAnonymous]
        [HttpPost]
        public void Post([FromBody]MeasurementInfo measurementRequest)
        {
            _powerplantRep.InsertInstumentMeasument(measurementRequest);
        }

        // PUT api/<PprecordersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PprecordersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
