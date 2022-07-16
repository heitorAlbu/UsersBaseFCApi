using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersBaseFC.Application.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string CPF { get; set; }
        public string BirthDate { get; set; }
        public string InclusionDate { get; set; }
        public string ChangeDate { get; set; }
        public string MotherName { get; set; }
        public bool isActive { get; set; }

    }
}
