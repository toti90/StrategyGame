using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTO
{
    public class UserLoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class UserLoginResponseDTO
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }

    public class UserRegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string confirmPassword { get; set; }
        [Required]
        public string CountryName { get; set; }
    }

    public class UserRegisterResponseDTO: UserLoginResponseDTO
    {
    }
}
