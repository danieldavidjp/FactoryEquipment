using FactoryEquipmentDashboard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FactoryEquipmentDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis;
using System.Xml.Linq;

using Mapster;

namespace FactoryEquipmentDashboard.Pages.Equipments
{
    public class IndexModel : PageModel
    {
        private readonly IEquipmentService _equipmentService;

        public Models.Equipment View { get; private set; } = null!;

        public IndexModel(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [BindProperty]
        [Required]
        public Guid Id { get; set; }

        public Equipment SelectedEquipment { get; set; }

        [BindProperty]
        [Required]
        public EquipmentStates SelectedState { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }


        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Id = id;
            SelectedEquipment = await _equipmentService.GetEquipment(id);

            States = Enum.GetValues(typeof(EquipmentStates))
            .Cast<EquipmentStates>()
            .Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString(),
            });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var selectedEquipment = await _equipmentService.GetEquipment(Id);

            var updatedEquipment = new Equipment(selectedEquipment.Id, selectedEquipment.Name, SelectedState, selectedEquipment.CreatedAt);

            await _equipmentService.ChangeEquipmentState(Id, updatedEquipment);

            return RedirectToPage("/Equipments/Index", new { id = Id });
        }
    }
}
