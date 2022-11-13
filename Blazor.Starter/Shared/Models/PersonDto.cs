using System.Text;

namespace Blazor.Starter.Server.Models
{
    public class PersonDto
    {
        public Guid? PersonId { get; set; }
        required public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        required public string LastName { get; set; }

        public int Age { get; set; }
        public bool HasDriversLicense { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

        public PersonDto()
        {
            if(PersonId is null) PersonId = Guid.NewGuid();
        }

        public string ToFullName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FirstName);

            if (MiddleName is not null)
            {
                sb.Append(" ");
                sb.Append(MiddleName);
            }

            sb.Append(" ");
            sb.Append(LastName);

            return sb.ToString();
        }
    }
}
