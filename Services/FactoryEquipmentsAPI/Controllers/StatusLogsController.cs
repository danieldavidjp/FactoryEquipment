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
    public class StatusLogsController : ControllerBase
    {
        private readonly IStatusLogServices _statusLogServices;

        public StatusLogsController( IStatusLogServices statusLogServices)
        {
            _statusLogServices = statusLogServices;
        }

        // GET: api/StatusLogs
        [HttpGet]
        public async Task<IEnumerable<StatusLog>> GetStatusLogs()
        {
            return await _statusLogServices.GetStatusLogs();
        }

        // GET: api/StatusLogs/5
        [HttpGet("{equipmentId}")]
        public async Task<IEnumerable<StatusLog>> GetStatusLogByEquipment(Guid equipmentId)
        {
            return await _statusLogServices.GetStatusLogsByEquipment(equipmentId);
        }

        // POST: api/StatusLogs
        [HttpPost]
        public async Task<ActionResult<StatusLog>> PostStatusLog(StatusLog statusLog)
        {
            

            return CreatedAtAction("GetStatusLog", new { id = statusLog.Id }, statusLog);
        }
    }
}
