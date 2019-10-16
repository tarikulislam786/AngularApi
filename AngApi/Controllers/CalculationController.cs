using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngApi.BLL;
using AngApi.DAL.Model;
using AngApi.DAL.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICalculation blCalculation;
        private readonly IUser blUser;

        public CalculationController(IMapper mapper, ICalculation calculation, IUser user)
        {
            this.mapper = mapper;
            this.blCalculation = calculation;
            this.blUser = user;
            
        }

        // GET: api/Calculation
        [HttpGet]
        public System.Object Get()
        {
            var calculations = blCalculation.GetCalculations();
            return calculations;
           // return mapper.Map<IEnumerable<Calculation>, IEnumerable<CalculationViewModel>>(calculations);
        }



        // GET: api/Calculation/5
        [HttpGet("{id}")]
        public CalculationViewModel Get(int id)
        {
            var _calculation = blCalculation.GetCalculation(id);
            return mapper.Map<Calculation, CalculationViewModel>(_calculation);
        }

        // POST: api/Calculation
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CalculationViewModel calculation)
        {
            var _calculation = blCalculation.UpsertCalculation(calculation);
            return CreatedAtAction("Get", new { id = calculation.Id }, calculation);
        }



        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var calculation = blCalculation.GetCalculation(id);
            var userCalculationId = calculation.UserId;
            if (calculation == null)
            {
                return NotFound();
            }
            blCalculation.DeleteCalculation(calculation.Id); // delete calculation
            blUser.DeleteUser(userCalculationId); // delete user
            return Ok(calculation);
        }
    }
}