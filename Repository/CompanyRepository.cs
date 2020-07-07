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
    public class CompanyRepository : IRepository<Company>
    {
        private readonly ProcedureHelper procedureHelper = new ProcedureHelper();
        private readonly IConfiguration configuration;

        public CompanyRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<Company> GetAll()
        {
            List<Company> companies = new List<Company>();

            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                SqlDataReader reader = procedureHelper.CallReader("spGetCompanies", connect);

                while (reader.Read())
                {
                    var company = new Company()
                    {
                        CompanyId = Convert.ToInt32(reader["CompanyId"]),
                        Name = reader["Name"].ToString(),
                        Size = reader["Size"].ToString(),
                        Form = reader["Form"].ToString()
                    };
                    companies.Add(company);
                }
                return (companies);
            }
        }

        public Company GetById(int id)
        {
            Company company = new Company();

            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                SqlDataReader reader = procedureHelper.CallReader("spGetCompanyById", connect, "@CompanyId", id);

                while (reader.Read())
                {
                    company.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                    company.Name = reader["Name"].ToString();
                    company.Size = reader["Size"].ToString();
                    company.Form = reader["Form"].ToString();
                }
                return (company);
            }
        }

        public void Create(Company company)
        {
            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                var cmd = new SqlCommand("spAddNewCompany", connect);
                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", company.Name);
                cmd.Parameters.AddWithValue("@Size", company.Size);
                cmd.Parameters.AddWithValue("@Form", company.Form);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Company company)
        {
            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                var cmd = new SqlCommand("spUpdateCompany", connect);
                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", company.CompanyId);
                cmd.Parameters.AddWithValue("@Name", company.Name);
                cmd.Parameters.AddWithValue("@Size", company.Size);
                cmd.Parameters.AddWithValue("@Form", company.Form);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Company company)
        {
            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                var cmd = new SqlCommand("spDeleteCompany", connect);
                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyId", company.CompanyId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
