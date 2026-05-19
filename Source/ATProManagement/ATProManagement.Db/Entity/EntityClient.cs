using System;
using System.Collections.Generic;
using System.Text;

namespace ATProManagement.Db
{
    public class EntityClient : EntityBase
    {
        public string? Name { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Message { get; set; } = string.Empty;
        public Guid GuidCourse { get; set; }
        public string? CourseName { get; set; } = string.Empty;
    }
}
