
using ATProManagement.Db;
using System.ComponentModel.DataAnnotations;

namespace ATProManagement.Service
{
    public class ModelClient
    {
        public Guid Guid { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public DateTime TimeModify { get; set; } = DateTime.Now;
        public string? UserCreated { get; set; }
        public string? UserModified { get; set; }
        [Required(ErrorMessage = "Invalid name")]
        public string? Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string? Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select course")]
        public Guid? GuidCourse { get; set; }
        [RegularExpression(
            @"^(0|\+84)[0-9]{9}$",
            ErrorMessage = "Invalid phone number"
        )]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
        public string? CourseName { get; set; } = string.Empty;

        public EntityClient SetValueModel(Guid? guid = null)
        {

            return new EntityClient
            {
                Guid = guid ?? Guid,
                Name = Name,
                UserCreated = "Admin",
                UserModified = "Admin",
                TimeCreated = DateTime.Now,
                TimeModified = DateTime.Now,
                Email = Email,
                Phone = Phone,
                Message = Message,
                CourseName = CourseName,
                GuidCourse = GuidCourse??Guid.Empty
            };
        }

        public void Reset()
        {
            this.Guid = Guid.Empty;
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.Phone = string.Empty;
            this.Message = string.Empty;
            this.CourseName = string.Empty;
            this.GuidCourse = null;
        }
    }
}
