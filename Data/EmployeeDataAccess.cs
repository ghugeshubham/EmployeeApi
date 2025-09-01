using EmployeeApi.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace EmployeeApi.Data
{
    public class EmployeeDataAccess
    {
        private readonly string connectionString = "Server=LAPTOP-H9EO19E9\\SQLEXPRESS;Database=EmployeeDB;Trusted_Connection=True;";

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM Employees";
            using SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(new Employee
                {
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    FirstName = reader["FirstName"].ToString()!,
                    LastName = reader["LastName"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                    Department = reader["Department"].ToString()!
                });
            }
            return employees;
        }

        public Employee? GetEmployeeById(int id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT * FROM Employees WHERE EmployeeId=@Id";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Employee
                {
                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                    FirstName = reader["FirstName"].ToString()!,
                    LastName = reader["LastName"].ToString()!,
                    Email = reader["Email"].ToString()!,
                    Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                    Department = reader["Department"].ToString()!
                };
            }
            return null;
        }

        public void InsertEmployee(Employee emp)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = @"INSERT INTO Employees (FirstName, LastName, Email, Phone, Department) 
                             VALUES (@FirstName, @LastName, @Email, @Phone, @Department)";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@Phone", (object?)emp.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void UpdateEmployee(Employee emp)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = @"UPDATE Employees SET FirstName=@FirstName, LastName=@LastName, Email=@Email,
                             Phone=@Phone, Department=@Department WHERE EmployeeId=@EmployeeId";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@Email", emp.Email);
            cmd.Parameters.AddWithValue("@Phone", (object?)emp.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Department", emp.Department);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteEmployee(int id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            string query = "DELETE FROM Employees WHERE EmployeeId=@Id";
            using SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
