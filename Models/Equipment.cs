namespace WeightLiftingGym_CRUDApp.Models
{
    public class Equipment
    {
        public int EquipmentID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Department { get; set; }
        public int DepartmentID { get; set; }
        public string InStock { get; set; }
        public IEnumerable<Department>Departments { get; set; }

    }
}
    

