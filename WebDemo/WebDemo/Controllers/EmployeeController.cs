using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebDemo_Common.Helper;
using WebDemo_Data.EmployeeRepository;
using WebDemo_Model.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController,Authorize]

    public class EmployeeController : ControllerBase
    {


        IEmployeeRepository _employee;
        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

       
        [HttpPost]
        public async Task<ApiPostResponse<string>> AddEditEmployee([FromForm] EmployeeModel data)
        {
            ApiPostResponse<string> response = new ApiPostResponse<string>() { Data = ""};
            if (data.Id == 0)
            {

              string result = await _employee.AddEmployee(data);
                if(result == null)
                {
                    response.Data = "Succesfully added";
                    response.Success = true;
                    response.Message = "OK";

                }
                else
                {
                    response.Data = "Error";
                }
             

            }
            else
            {
                _employee.AddEmployee(data);
                response.Success = true;
            }
            return response;
        }

        [HttpGet]
        [Route("GetEmployee")]
   

        public async Task<ApiResponse<EmployeeModel>> GetEmployee()
        
        {
            ApiResponse<EmployeeModel> response = new ApiResponse<EmployeeModel>() { Data = new List<EmployeeModel>() };
            response.Data = await _employee.GetEmployee();
            response.Success = true;
            response.Message = "OK";
            return response;


        }

    }
}
