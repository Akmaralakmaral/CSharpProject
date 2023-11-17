using AutoMapper;
using BLL.Services;
using BLL.Services.Interfaces;
using Domain.Models.DTO;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeServices employeeServices, IMapper mapper)
        {
            _employeeServices = employeeServices;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            // Получаем список всех сотрудников из сервиса
            var employees = _employeeServices.GetAllEmployees();

            // Маппим сотрудников в ViewModel
            var employeeViewModels = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            // Возвращаем представление с списком сотрудников
            return View(employeeViewModels);
        }

        public IActionResult Details(int id)
        {
            // Получаем информацию о сотруднике по идентификатору из сервиса
            var employee = _employeeServices.GetEmployeeById(id);

            // Маппим сотрудника в ViewModel
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);

            // Возвращаем представление с деталями сотрудника
            return View(employeeViewModel);
        }

        public IActionResult Create()
        {
            // Возвращаем представление для создания сотрудника
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            // Проверяем, прошла ли валидация модели
            if (ModelState.IsValid)
            {
                // Маппим ViewModel в DTO
                var employeeDTO = _mapper.Map<EmployeeDTO>(employeeViewModel);

                // Вызываем сервис для создания сотрудника
                _employeeServices.CreateEmployee(employeeDTO);

                // Перенаправляем на список сотрудников
                return RedirectToAction(nameof(Index));
            }

            // Если валидация не удалась, возвращаем представление с ошибками
            return View(employeeViewModel);
        }

        public IActionResult Edit(int id)
        {
            // Получаем информацию о сотруднике по идентификатору из сервиса
            var employee = _employeeServices.GetEmployeeById(id);

            // Маппим сотрудника в ViewModel
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);

            // Возвращаем представление для редактирования сотрудника
            return View(employeeViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeViewModel employeeViewModel)
        {
            // Проверяем, прошла ли валидация модели и соответствует ли идентификатор
            if (id != employeeViewModel.EmployeeId || !ModelState.IsValid)
            {
                // Если условия не выполнились, возвращаем 404 Not Found
                return NotFound();
            }

            // Маппим ViewModel в DTO
            var employeeDTO = _mapper.Map<EmployeeDTO>(employeeViewModel);

            // Вызываем сервис для обновления сотрудника
            _employeeServices.UpdateEmployee(employeeDTO);

            // Перенаправляем на список сотрудников
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            // Получаем информацию о сотруднике по идентификатору из сервиса
            var employee = _employeeServices.GetEmployeeById(id);

            // Маппим сотрудника в ViewModel
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(employee);

            // Возвращаем представление для подтверждения удаления сотрудника
            return View(employeeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Вызываем сервис для удаления сотрудника
            _employeeServices.DeleteEmployee(id);

            // Перенаправляем на список сотрудников
            return RedirectToAction(nameof(Index));
        }
    }
}
