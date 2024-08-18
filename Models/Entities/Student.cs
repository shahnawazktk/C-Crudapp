namespace CrudApp.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }  // Primary key
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // Add additional properties as needed
    }
}
