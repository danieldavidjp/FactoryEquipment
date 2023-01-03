using FactoryEquipmentDashboard.Models;
using FactoryEquipmentDashboard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FactoryEquipmentDashboard.Pages.Equipments
{
    public class StatesLogModel : PageModel
    {
        private readonly IStatusLogService _statusLogService;

        public StatesLogModel(IStatusLogService statusLogService)
        {
            _statusLogService = statusLogService;
        }

        public IEnumerable<StatusLog> EquipmentLogs { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            EquipmentLogs = await _statusLogService.GetLogsByEquipments(id);

            return Page();
        }
    }
}
