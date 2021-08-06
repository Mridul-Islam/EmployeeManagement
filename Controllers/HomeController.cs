using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers{
    public class HomeController:Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        
        public HomeController(IEmployeeRepository employeeRepository){
            _employeeRepository = employeeRepository;
        }

        
        public ViewResult Index(){
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }


        [HttpGet]
        public ViewResult Create(){
            return View();
        }


        [HttpPost]
        public IActionResult Create(Employee employee){
            if(ModelState.IsValid){
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("details", new{id = newEmployee.Id});
            }
            return View();
        }


        public ViewResult Details(int id){
            HomeDetailsVeiwModel homeDetailsViewModel = new HomeDetailsVeiwModel(){
                employee = _employeeRepository.GetEmployee(id),
                pageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }





    }
}