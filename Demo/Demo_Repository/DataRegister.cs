using Demo_Data.Employee_Repository;
using Demo_Data.Login_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Data
{
   public class DataRegister
   {
        public static Dictionary<Type, Type> GetTypes()
        {
            var serviceDictionary = new Dictionary<Type, Type>()
            {
                { typeof(IEmployeeRepository), typeof(EmployeeRepository)},
                {typeof(ILoginRepository), typeof(LoginRepository)}

            };

            return serviceDictionary;
        }
   }
}
