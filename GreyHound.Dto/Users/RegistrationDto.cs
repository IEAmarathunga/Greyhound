using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Users
{
    public class RegistrationDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? CountryId { get; set; }
        public Guid ActivationCode { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime CodeGeneratedDate { get; set; }
        public string CaptchaValue { get; set; }
    }
}
