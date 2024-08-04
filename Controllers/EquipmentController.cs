using Microsoft.AspNetCore.Mvc;
using WeightLiftingGym_CRUDApp.GymData;
using WeightLiftingGym_CRUDApp.Models;

namespace WeightLiftingGym_CRUDApp.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipRepository _repository;

        public EquipmentController(IEquipRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var equipment = _repository.GetAllEquipment();
            return View(equipment);

        }
       
        public IActionResult ViewEquipment(int id)
        {
            var equipment = _repository.GetEquipment(id);
            return View(equipment);
        }

        public IActionResult UpdateEquipment(int id)
        {
            var equipment = _repository.GetEquipment(id);
            if (equipment == null)
            {
                return View("Item(s)NotFound");
            }
            return View(equipment);
        }

        public IActionResult UpdadteEquipmentToDatabase(Equipment equipment )
        {
            _repository.UpdateEquipment(equipment);

            return RedirectToAction("ViewEquipment", new { id = equipment.EquipmentID });
        }

        public IActionResult InsertEquipment()
        {
            var equipment = _repository.AssignDepartment();
            return View(equipment);
        }

        public IActionResult InsertEquipmentToDatabase(Equipment equipmentToInsert)
        {
            _repository.InsertEquipment(equipmentToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEquipment(Equipment equipment)
        {
            _repository.DeleteEquipment(equipment);
            return RedirectToAction("Index");
        }

    }
}
