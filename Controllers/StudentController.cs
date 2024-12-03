using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using StudentSupportApp.Models;

namespace StudentSupportApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly string _connectionString = "Server=localhost;Database=StudentSupportDB;Uid=root;Pwd=;";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/register")]
        public IActionResult Register(Student student)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Students (FullName, Email, Course, AcademicYear) VALUES (@FullName, @Email, @Course, @AcademicYear)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", student.FullName);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@Course", student.Course);
                    cmd.Parameters.AddWithValue("@AcademicYear", student.AcademicYear);
                    cmd.ExecuteNonQuery();
                }
            }
            return Redirect("/login.html");
        }

        [HttpPost("/login")]
        public IActionResult Login(string email)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Students WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return Redirect("/dashboard.html");
                    }
                    else
                    {
                        return Redirect("/login.html?error=1");
                    }
                }
            }
        }
    }
}
