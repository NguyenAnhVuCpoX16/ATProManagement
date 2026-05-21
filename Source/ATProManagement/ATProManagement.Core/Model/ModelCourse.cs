
using ATProManagement.Db;

namespace ATProManagement.Service
{
    public class ModelCourse
    {
        public Guid Guid { get; set; }
        public DateTime? TimeCreated { get; set; } = DateTime.Now;
        public DateTime? TimeModified { get; set; } = DateTime.Now;

        public string? UserCreated { get; set; }
        public string? UserModified { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public EntityCourse SetValueModel(Guid? guid = null)
        {   

            return new EntityCourse
            {
                Guid = guid ?? Guid,
                Name = Name,
                UserCreated = UserCreated ?? "Admin",
                UserModified = UserModified ?? "Admin",
                TimeCreated = TimeCreated ?? DateTime.Now,
                TimeModified = TimeModified ?? DateTime.Now,
                Description = Description ?? string.Empty,
            };
        }
    }
}
