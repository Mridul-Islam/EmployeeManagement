using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository:IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id=1, Name="Mridul Islam", Department="CSE", Email="md.mridulislam12345@gmail.com"},
                new Employee() {Id=2, Name="Aziz", Department="EEE", Email="Aziz57@gmail.com"},
                new Employee() {Id=3, Name="Shamim", Department="BBA", Email="shamim43@gmail.com"}
            };
        }
        public Employee GetEmployee(int Id){
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
        public IEnumerable<Employee> GetAllEmployee(){
            return _employeeList;
        }
    }
}