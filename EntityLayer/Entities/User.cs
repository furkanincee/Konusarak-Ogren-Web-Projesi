using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [EmailAddress(ErrorMessage = "Geçersiz E-mail" )]
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
