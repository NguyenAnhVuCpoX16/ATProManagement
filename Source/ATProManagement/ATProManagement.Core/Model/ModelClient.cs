
using ATProManagement.Db;

namespace ATProManagement.Service
{
    public class ModelClient
    {
        public Guid Guid { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public DateTime TimeModify { get; set; } = DateTime.Now;
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } = string.Empty;
        public Guid GuidCourse { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;

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
                GuidCourse = GuidCourse
            };
        }
    }
}
