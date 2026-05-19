using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATProManagement.Db
{
    public class EntityCourse : EntityBase
    {
        [MaxLength(200)]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
