using WeightLiftingGym_CRUDApp.Models;

namespace WeightLiftingGym_CRUDApp.GymData
{
    public interface IEquipRepository
    {
        public IEnumerable<Equipment>GetAllEquipment();
        public Equipment GetEquipment(int id);
        public void UpdateEquipment(Equipment equipment);

        public void InsertEquipment(Equipment equipmentToInsert);
        public IEnumerable<Department> GetDepartments();
        public Equipment AssignDepartment();
        public void DeleteEquipment(Equipment equipment);
    }
}
