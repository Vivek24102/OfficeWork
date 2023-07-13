using LoginForm_Common.Helper;
using LoginForm_Model.ViewModel;
using LoginForrm_Data.EmployeeRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace LoginForm.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _data;

        public EmployeeController(IEmployeeRepository data)
        {
            _data = data;
        }
        [Route("Employeeshow")]
        [HttpGet]
        public async Task<IActionResult> ShowEmployee()
        {
            ApiResponse<IList<Employee>> response = new ApiResponse<IList<Employee>>();
            var result = await _data.EmployeeDetails();
            if (result != null)
            {

                return Ok(result);


            }
            else
            {
                return BadRequest(response);
            }
        }
        [Route("pagination")]
        [HttpPost]
        public async Task<IActionResult> pagination(PaginationViewModel employee)
        {
            ApiResponse<IList<Employee>> response = new ApiResponse<IList<Employee>>();
            var result = await _data.paginator(employee);
            if (result != null)
            {

                return Ok(result);


            }
            else
            {
                return BadRequest(response);
            }
        }
        [Route("AddEditEmployee")]
        [HttpGet]

        public async Task<IActionResult> AddEditEmployee(int ID)
        {
            ApiPostResponse<string> response = new ApiPostResponse<String>() { Data = "" };
            var result = await _data.EmployeeByID(ID);
            if (result != null)
            {
                response.Success = true;
                response.Message = "Success";
             
                return Ok(result);
            }
            else
            {
                response.Message = "error";
                response.Success = false;
                return BadRequest(response);
            }

        }

        [Route("AddEditEmployee")]
        [HttpPost]

        public async Task<IActionResult> AddEditEmployee(Employee employee)
        {
            ApiPostResponse<string> response = new ApiPostResponse<String>() { Data = "" };
            if (employee.Id == 0)
            {
                var data = await _data.AddeditEmployee(employee);
                if(data != null)
                {
                    response.Data = "Success";
                    return Ok(response);

                }
                else

                {
                    response.Data = "Error";
                    return BadRequest(response);
                }

            }
            else
            {
                var data = await _data.AddeditEmployee(employee);
                if (data != null)
                {
                    response.Data = "Success";
                    return Ok(response);

                }
                else
                {
                    response.Data = "Error";
                    return BadRequest(response);
                }

            }

        }
        [Route("DeleteEmployee")]
        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            ApiPostResponse<string> response = new ApiPostResponse<String>() { Data = "" };
            var data = await _data.DeleteEmployee(id);
            if(data != null)
            {
                response.Data = "Success";
                response.Success = true;
                return Ok(response);
            }
            else
            {
                response.Data = "Error";
                response.Success = false;
                return BadRequest(response);
            }


        }
    }
}
