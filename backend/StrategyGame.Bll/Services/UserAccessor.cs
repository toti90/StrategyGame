using Microsoft.AspNetCore.Http;
using StrategyGame.Bll.Errors;
using StrategyGame.Bll.Interfaces;
using StrategyGame.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace StrategyGame.Bll.Services
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _appDbContext;
        public UserAccessor(IHttpContextAccessor httpContextAccessor, AppDbContext appDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _appDbContext = appDbContext;
        }
        public string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = _appDbContext.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return userId;
            } else
            {
                throw new RestException(HttpStatusCode.Unauthorized, new { message = "Not registered user" });
            }

            
        }
    }
}
