using Dapper;
using System.Data;
using WeightLiftingGym_CRUDApp.Models;

namespace WeightLiftingGym_CRUDApp.GymData
{
    public class EquipRepository : IEquipRepository
    {
        private readonly IDbConnection _conn;

        public EquipRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Equipment> GetAllEquipment()
        {
            return _conn.Query<Equipment>("SELECT * FROM equipment;");
        }

        public Equipment GetEquipment(int id)
        {
            return _conn.QuerySingle<Equipment>("SELECT * FROM equipment WHERE EquipmentID= @id;", new{id});
        }

        public void UpdateEquipment(Equipment equipment)
        {
            {
                _conn.Execute("UPDATE equipment SET Name = @name, Price = @price WHERE EquipmentID = @id",
                 new { name = equipment.Name, price = equipment.Price, id = equipment.EquipmentID });
            }
        }

        public void InsertEquipment(Equipment equipmentToInsert)
        {
            _conn.Execute("INSERT INTO equip,ent (NAME, PRICE, DEPARTMENTID) VALUES (@name, @price, @departmentID);",
                new { name = equipmentToInsert.Name, price = equipmentToInsert.Price, categoryID = equipmentToInsert.DepartmentID });
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _conn.Query<Department>("SELECT * FROM departments;");
        }

        public Equipment AssignDepartment()
        {
            var departmentList = GetDepartments();
            var equipment = new Equipment();
            equipment.Departments = departmentList;
            return equipment;
        }

        public void DeleteEquipment(Equipment equipment)
        {
            _conn.Execute("DELETE FROM INSTOCK WHERE EquipmentID = @id;", new { id = equipment.EquipmentID });
            _conn.Execute("DELETE FROM DEPARTMENT WHERE EquipmentID = @id;", new { id = equipment.EquipmentID });
            _conn.Execute("DELETE FROM EQUIPMENT WHERE EquipmentID = @id;", new { id = equipment.EquipmentID});
        }
    }

}
