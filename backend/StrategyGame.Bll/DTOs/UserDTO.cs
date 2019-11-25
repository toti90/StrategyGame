﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrategyGame.Bll.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserResponseDTO
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
