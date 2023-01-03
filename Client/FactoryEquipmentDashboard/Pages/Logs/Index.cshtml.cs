using FactoryEquipmentDashboard.Models;
using FactoryEquipmentDashboard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactoryEquipmentDashboard.Pages.Logs
{
    public class LogsModel : PageModel
    {

        private readonly IStatusLogService _statusLogService;
        
        public LogsModel(IStatusLogService statusLogService)
        {
            _statusLogService = statusLogService;
        }

        public IEnumerable<StatusLog> EquipmentsLogs { get; set; } = null!;
        public async Task<IActionResult> OnGet()
        {
            EquipmentsLogs = await _statusLogService.GetLogs();

            return Page();
        }
    }
}
