using Adodemo_Model.Model;
using Adodemo_Repositry.Repositry;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adodemo_Repositry.Services
{
    public class EmployeeServices : IEmployee
    {
        public string Constr { get; set; }
        public IConfiguration _configuration;
        public SqlConnection con;
        public EmployeeServices(IConfiguration configuration)
        {
            _configuration = configuration;
            Constr = _configuration.GetConnectionString("Demodb");
        }

        public  List<Employee> GetEmployees()
        {
            try

            {
                List<Employee> employees = new List<Employee>();
                using (SqlConnection con  = new SqlConnection(Constr))
                {
                    SqlCommand cmd = new SqlCommand("spGetEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        Employee emp = new Employee();
                        emp.Id = Convert.ToInt32(rdr["ID"]);
                        emp.Firstname = rdr["Firstname"].ToString();
                        emp.MiddleName = rdr["MiddleName"].ToString() ;
                        emp.Lastname = rdr["Lastname"].ToString();
                        emp.Dob = Convert.ToDateTime( rdr["Dob"]);
                        emp.Gender = rdr["Gender"].ToString();
                        emp.EmailAddress = rdr["EmailAddress"].ToString();
                        emp.mobileno = rdr["mobileno"].ToString();
                        emp.Experiance = rdr["Experiance"].ToString();
                        emp.qulification = rdr["qulification"].ToString();
                        emp.createdBy = rdr["createdBy"].ToString();
                        emp.createdDate = Convert.ToDateTime(rdr["createddate"]);
                        

                        employees.Add(emp);

                    }
                    con.Close();
                }
                return employees;

            }catch (Exception e)
            {
                throw e;
            }
        }

        public void AddEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                SqlCommand cmd = new SqlCommand("Sp_Add", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Firstname", emp.Firstname);
                cmd.Parameters.AddWithValue("@MiddleName", emp.MiddleName);
                cmd.Parameters.AddWithValue("@Lastname", emp.Lastname);
                cmd.Parameters.AddWithValue("@Dob", emp.Dob);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@mobileno", emp.mobileno);
                cmd.Parameters.AddWithValue("@EmailAddress", emp.EmailAddress);
                cmd.Parameters.AddWithValue("@qulification", emp.qulification);
                cmd.Parameters.AddWithValue("@Experiance", emp.Experiance);
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public void EditEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                SqlCommand cmd = new SqlCommand("Sp_Add", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Firstname", emp.Firstname);
                cmd.Parameters.AddWithValue("@MiddleName", emp.MiddleName);
                cmd.Parameters.AddWithValue("@Lastname", emp.Lastname);
                cmd.Parameters.AddWithValue("@Dob", emp.Dob);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@mobileno", emp.mobileno);
                cmd.Parameters.AddWithValue("@EmailAddress", emp.EmailAddress);
                cmd.Parameters.AddWithValue("@qulification", emp.qulification);
                cmd.Parameters.AddWithValue("@Experiance", emp.Experiance);
               
              
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        public Employee GetEmployeebyid(int id)
        {
            using (SqlConnection con = new SqlConnection(Constr))
            {
                Employee emp = new Employee();
                string sqlquery = "SELECT * FROM Employee WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    
                    emp.Id = Convert.ToInt32(rdr["ID"]);
                    emp.Firstname = rdr["Firstname"].ToString();
                    emp.MiddleName = rdr["MiddleName"].ToString();
                    emp.Lastname = rdr["Lastname"].ToString();
                    emp.Dob = Convert.ToDateTime(rdr["Dob"]).Date;
                    emp.Gender = rdr["Gender"].ToString();
                    emp.EmailAddress = rdr["EmailAddress"].ToString();
                    emp.mobileno = rdr["mobileno"].ToString();
                    emp.Experiance = rdr["Experiance"].ToString();
                    emp.qulification = rdr["qulification"].ToString();
                   

                }
                con.Close();
                return emp;
            }
        }

        public void delete(int id)
        {
           
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
             
        }
    }
}
