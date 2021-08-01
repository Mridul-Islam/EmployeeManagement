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


        public ViewResult Details(int? id){
            HomeDetailsVeiwModel homeDetailsViewModel = new HomeDetailsVeiwModel(){
                employee = _employeeRepository.GetEmployee(id??3),
                pageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }






    }
}