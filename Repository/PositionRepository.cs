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
    public class PositionRepository : IRepository<Position>
    {
        private readonly ProcedureHelper procedureHelper = new ProcedureHelper();
        private readonly IConfiguration configuration;

        public PositionRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<Position> GetAll()
        {
            List<Position> positions = new List<Position>();

            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                SqlDataReader reader = procedureHelper.CallReader("spGetPositions", connect);

                while (reader.Read())
                {
                    var position = new Position()
                    {
                        PositionId = Convert.ToInt32(reader["PositionId"]),
                        Name = reader["Name"].ToString()
                    };
                    positions.Add(position);
                }

                return (positions);
            }
        }

        public Position GetById(int id)
        {
            Position position = new Position();

            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                SqlDataReader reader = procedureHelper.CallReader("spGetPositionById", connect, "@PositionId", id);

                while (reader.Read())
                {
                    position.PositionId = Convert.ToInt32(reader["PositionId"]);
                    position.Name = reader["Name"].ToString();
                }

                return (position);
            }
        }

        public void Create(Position position)
        {
            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                var cmd = new SqlCommand("spAddNewPosition", connect);

                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", position.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Position position)
        {
            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                var cmd = new SqlCommand("spUpdatePosition", connect);

                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PositionId", position.PositionId);
                cmd.Parameters.AddWithValue("@Name", position.Name);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(Position position)
        {
            using (SqlConnection connect = new SqlConnection(configuration.GetConnectionString("RSOEContext")))
            {
                var cmd = new SqlCommand("spDeletePosition", connect);

                connect.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PositionId", position.PositionId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
