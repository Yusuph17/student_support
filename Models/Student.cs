namespace StudentSupportApp.Models
{
    public class Student
    {
        public int Id { get; set; } // Primary key
        public string FullName { get; set; } // Student's full name
        public string Email { get; set; } // Student's email
        public string Course { get; set; } // Course the student is enrolled in
        public string AcademicYear { get; set; } // Academic year of the student
    }
}
