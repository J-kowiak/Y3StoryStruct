using FinalPrototype.Data;
using FinalPrototype.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalPrototype.Controllers
{
    public class SiteStructureController : Controller
    {
        private readonly SiteStructuresDbContext context;

        public SiteStructureController(SiteStructuresDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var siteStructure = context.siteStructures.ToList();
            List<SiteStructureViewModel> structureList = new List<SiteStructureViewModel>();
            if (siteStructure != null)
            {

                foreach (var structure in siteStructure)
                {
                    var SiteStructureViewModel = new SiteStructureViewModel()
                    {
                        Id = structure.Id,
                        Name = structure.Name,
                        by = structure.by,
                        Acts = structure.Acts,
                        Description = structure.Description,

                    };
                    structureList.Add(SiteStructureViewModel);
                }
                return View(structureList);
            }
            return View(structureList);
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            try
            {
                var userStructure = context.siteStructures.SingleOrDefault(x => x.Id == Id);
                if (userStructure != null)
                {
                    var structure = new SiteStructureViewModel()
                    {
                        Id = userStructure.Id,
                        Name = userStructure.Name,
                        by = userStructure.by,
                        Acts = userStructure.Acts,
                        Description = userStructure.Description,
                    };
                    return View(userStructure);
                }
                else
                {
                    TempData["errorMessage"] = $"Structure details not available with the ID: {Id}";
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }

}
