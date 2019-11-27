using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.Errors;
using StrategyGame.Bll.Interfaces;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.Bll.Services
{
    public class DevelopmentsService : IDevelopmentsService
    {
        private readonly AppDbContext _context;
        private readonly IUserAccessor _IUserAccessor;

        public DevelopmentsService(AppDbContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _IUserAccessor = userAccessor;
        }

        public async Task<DevelopmentsResponseDTO> GetAllDevelopment()
        {
            var allDevelopment = await _context.Developments.ToListAsync();
            var userId = await _IUserAccessor.GetCurrentUserId();
            var userDevelopmentGroups = await _context.DevelopmentGroups.Where(dg => dg.UserId == userId).ToListAsync();
            var responseDevelopents = new List<DevelopmentDTO>();
            foreach (var development in allDevelopment)
            {
                var userDevelopmentGroup = userDevelopmentGroups.Where(udg => udg.DevelopmentId == development.DevelopmentId).FirstOrDefault();
                var roundOfnewDevelopment = 0;
                if (userDevelopmentGroup != null)
                {
                    roundOfnewDevelopment = await _context.NewDevelopments.Where(nd => nd.DevelopmentGroupId == userDevelopmentGroup.DevelopmentGroupId).Select(nd => nd.Round).FirstOrDefaultAsync();
                }
                var devResponse = new DevelopmentDTO
                {
                    DevelopmentId = development.DevelopmentId,
                    DevelopmentName = development.DevelopmentName,
                    ImageUrl = development.ImageUrl,
                    Own = userDevelopmentGroups.Any(dg => dg.DevelopmentId == development.DevelopmentId),
                    Message = generateDevelopmentMessage(development),
                    RoundOfNewDevelopment = roundOfnewDevelopment
                };
                responseDevelopents.Add(devResponse);
            }
            return new DevelopmentsResponseDTO
            {
                Developments = responseDevelopents
            };
        }

        public async Task<bool> AddNewDevelopment(int developmentId)
        {
            var userId = await _IUserAccessor.GetCurrentUserId();
            var user = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            var userExistingDevelopmentGroups = await _context.DevelopmentGroups.Where(u => u.UserId == userId).ToListAsync();
            var newDevelopments = await _context.NewDevelopments.ToListAsync();
            var existInProgressDevelopment = newDevelopments.Where(nd => userExistingDevelopmentGroups.Any(uedg => uedg.DevelopmentGroupId == nd.DevelopmentGroupId && nd.Round < 15)).ToList();
            if (existInProgressDevelopment.Count() > 0)
            {
                throw new RestException(HttpStatusCode.Conflict, new { Message = "You have got new development in progress" });
            }
            var userDevelopmentGroup = await _context.DevelopmentGroups.Where(dg => dg.DevelopmentId == developmentId && dg.UserId == userId).FirstOrDefaultAsync();
            if (userDevelopmentGroup != null)
            {
                throw new RestException(HttpStatusCode.Conflict, new { Message = "You have got the target development" });
            }
            else
            {
                var development = await _context.Developments.Where(d => d.DevelopmentId == developmentId).FirstOrDefaultAsync();
                if (development == null)
                {
                    throw new RestException(HttpStatusCode.BadRequest, new { message = "unknown developmentId" });
                }
                var newDevelopmentGroup = new DevelopmentGroup
                {
                    Development = development,
                    User = user
                };
                _context.DevelopmentGroups.Add(newDevelopmentGroup);
                await _context.SaveChangesAsync();
                var newDevelopment = new NewDevelopment
                {
                    DevelopmentGroup = await _context.DevelopmentGroups.Where(dg => dg.DevelopmentId == developmentId && dg.UserId == userId).FirstOrDefaultAsync()
                };
                _context.NewDevelopments.Add(newDevelopment);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        private string generateDevelopmentMessage(Development development)
        {
            if (development.AddCorall.HasValue)
            {
                return $"növeli a korall termesztést {Math.Round(development.AddCorall.Value * 100 - 100 , 0)}%-al";
            }
            else if (development.AddTax.HasValue)
            {
                return $"növeli a beszedett adót {Math.Round(development.AddTax.Value * 100 - 100,0)}%-al";
            }
            else if (development.AddAttack.HasValue && development.AddDefense.HasValue)
            {
                if (development.AddAttack == development.AddDefense)
                {
                    return $"növeli a védelmi és támadóerőt {Math.Round(development.AddAttack.Value * 100 - 100,0)}%-al";
                }
                else
                {
                    return $"növeli a védelmierőt {Math.Round(development.AddDefense.Value * 100 - 100,0)}%-al és támadóerőt {Math.Round(development.AddAttack.Value * 100 - 100,0)}%-al";
                }
               
            }
            else if (development.AddAttack.HasValue)
            {
                return $"növeli a támadóerőt {Math.Round(development.AddAttack.Value * 100 - 100, 0)}%-al";
            }
            else if (development.AddDefense.HasValue)
            {
                return $"növeli a védelmierőt {Math.Round(development.AddDefense.Value * 100 - 100, 0)}%-al";
            }
            else
            {
                return "Hát ez nem igazán csinál semmit";
            }
        }
    }
}
