using Microsoft.Extensions.Configuration;
using RSOE.Models;
using RSOE.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RSOE.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly ProcedureHelper procedureHelper = new ProcedureHelper();
        private readonly IConfiguration configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                SqlDataReader reader = procedureHelper.CallReader("spGetEmployees", connect);

                while (reader.Read())
                {
                    var employee = new Employee()
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        EmploymentDate = Convert.ToDateTime(reader["EmploymentDate"]),
                        PositionId = Convert.ToInt32(reader["PositionId"]),
                        CompanyId = Convert.ToInt32(reader["CompanyId"])
                    };

                    employees.Add(employee);
                }

                return (employees);
            }
        }

        public Employee GetById(int id)
        {
            Employee employee = new Employee();

            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                SqlDataReader reader = procedureHelper.CallReader("spGetEmployeeById", connect, "@EmployeeId", id);

                while (reader.Read())
                {
                    employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    employee.FirstName = reader["FirstName"].ToString();
                    employee.LastName = reader["LastName"].ToString();
                    employee.EmploymentDate = Convert.ToDateTime(reader["EmploymentDate"]);
                    employee.PositionId = Convert.ToInt32(reader["PositionId"]);
                    employee.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                }

                return (employee);
            }
        }

        public void Create(Employee employee)
        {
            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                var cmd = new SqlCommand("spAddNewEmployee", connect);
                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@EmploymentDate", employee.EmploymentDate);
                cmd.Parameters.AddWithValue("@PositionId", employee.PositionId);
                cmd.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Employee employee)
        {
            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                var cmd = new SqlCommand("spUpdateEmployee", connect);
                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                cmd.Parameters.AddWithValue("@EmploymentDate", employee.EmploymentDate);
                cmd.Parameters.AddWithValue("@PositionId", employee.PositionId);
                cmd.Parameters.AddWithValue("@CompanyId", employee.CompanyId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Employee employee)
        {
            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                var cmd = new SqlCommand("spDeleteEmployee", connect);
                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
