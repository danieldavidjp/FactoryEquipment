using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FactoryEquipmentsAPI.Models;
using FactoryEquipmentsAPI.Services;

namespace FactoryEquipmentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentServices _equipmentServices;

        public EquipmentsController(FactoryEquipmentContext context, IEquipmentServices equipmentServices)
        {
            _equipmentServices = equipmentServices;
        }

        // GET: api/Equipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipment()
        {
            return Ok(await _equipmentServices.ListEquipment());
        }

        // GET: api/Equipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipment>> GetEquipment(Guid id)
        {
            return await _equipmentServices.GetEquipment(id);
        }

        // PUT: api/Equipments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipment(Guid id, Equipment equipment)
        {
            await _equipmentServices.UpdateEquipment(id, equipment);

            return NoContent();
        }

        // POST: api/Equipments
        [HttpPost]
        public async Task<ActionResult<Equipment>> PostEquipment(Equipment equipment)
        {

            await _equipmentServices.CreateEquipment(equipment);

            return CreatedAtAction("GetEquipment", new { id = equipment.Id }, equipment);
        }
    }
}
