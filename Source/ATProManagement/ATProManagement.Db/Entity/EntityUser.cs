using Microsoft.AspNetCore.Identity;


namespace ATProManagement.Db.Entity
{
    public class EntityUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
