using System.ComponentModel.DataAnnotations;

namespace Blazor.Starter.Server.Models
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool HasDriversLicense { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
    }
}
