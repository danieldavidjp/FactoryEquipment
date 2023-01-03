using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FactoryEquipmentDashboard.Models;
using FactoryEquipmentDashboard.Services;
using Microsoft.Build.Framework;

namespace FactoryEquipmentDashboard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEquipmentService _equipmentService;
        public IndexModel(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService ?? throw new ArgumentNullException(nameof(equipmentService));
        }

        [BindProperty]
        [Required]
        public string Name { get; set; } = null!;

        public IEnumerable<Models.Equipment> View { get; private set; }
        public async Task<IActionResult> OnGet()
        {
            View = await _equipmentService.ListEquipments();
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _equipmentService.CreateEquipment(Name);

            return RedirectToPage("./Index");
        }
    }
}
