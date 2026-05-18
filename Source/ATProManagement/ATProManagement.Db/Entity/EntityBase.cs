using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATProManagement.Db
{
    public class EntityBase
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public DateTime TimeModified { get; set; } = DateTime.Now;

        public string UserCreated { get; set; }
        public string UserModified { get; set; }
    }
}
