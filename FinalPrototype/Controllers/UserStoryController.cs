using FinalPrototype.Data;
using FinalPrototype.Models;
using FinalPrototype.Models.DBEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalPrototype.Controllers
{
    public class UserStoryController : Controller
    {
        
        private readonly StructureDbContext context;

        public UserStoryController(StructureDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var structures = context.userStructures.ToList();
            List<UserStructureViewModel> structureList = new List<UserStructureViewModel>();

            if (structures != null)
            {
               
                foreach (var structure in structures)
                {
                    var UserStructureViewModel = new UserStructureViewModel()
                    {
                        Id = structure.Id,
                        Name = structure.Name,
                        by = structure.by,
                        Acts= structure.Acts,
                        Description= structure.Description,

                    };
                    structureList.Add(UserStructureViewModel);
                }
                return View(structureList);
            }
            return View(structureList);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserStructureViewModel userStructure)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userStructures = new UserStructure()
                    {
                        Name = userStructure.Name,
                        by = userStructure.by,
                        Acts = userStructure.Acts,
                        Description = userStructure.Description,
                    };

                    context.userStructures.Add(userStructures);
                    context.SaveChanges();
                    TempData["successMessage"] = "Structure Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is not valid.";
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var userStructure = context.userStructures.SingleOrDefault(x => x.Id == Id);
                if (userStructure != null)
                {
                    var structure = new UserStructureViewModel()
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
        [HttpPost]
        public  IActionResult Edit(UserStructureViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userStructures = new UserStructure()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        by = model.by,
                        Acts = model.Acts,
                        Description = model.Description,
                    };

                    context.userStructures.Update(userStructures);
                    context.SaveChanges();
                    TempData["successMessage"] = "Structure Updated Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is not valid.";
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
                throw;
            }

        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var userStructure = context.userStructures.SingleOrDefault(x => x.Id == Id);
                if (userStructure != null)
                {
                    var structure = new UserStructureViewModel()
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

        [HttpPost]
        public IActionResult Delete(UserStructureViewModel model)
        {
            var userStructure = context.userStructures.SingleOrDefault(x => x.Id == model.Id);

            try
            {
                if (userStructure != null)
                {
                    context.userStructures.Remove(userStructure);
                    context.SaveChanges();
                    TempData["successMessage"] = "Structure Deleted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Structure details not available with the ID: {model.Id}";
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
