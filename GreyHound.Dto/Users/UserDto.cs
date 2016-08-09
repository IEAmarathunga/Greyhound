using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreyHound.Dto.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public int? MemberTypeId { get; set; }
        public int? CountryId { get; set; }
        public string State { get; set; }
        public Guid ActivationCode { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime CodeGeneratedDate { get; set; }
        public DateTime? ActivatedDate { get; set; }
    }

    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }       
    }

    public class UserInfoDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? CountryId { get; set; }
        public string Country { get; set; }
    }

    public class UserChangeDto
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }

    public class ValidateUserDto
    {
        public string Email { get; set; }        
    }

    public class ClassifiedUserStatDto
    {
        public int ImageCount { get; set; }
        public int VideoCount { get; set; }
        public int BalanceAdsCount { get; set; }
        public int BalanceCharCount { get; set; }
    }

    public class UserRolesDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
