using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.Interfaces;
using StrategyGame.Dal;
using StrategyGame.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public DevelopmentsResponseDTO getAllDevelopment()
        {
            var allDevelopment = _context.Developments.ToList();
            var userId = _IUserAccessor.GetCurrentUserId();
            var userDevelopmentGroups = _context.DevelopmentGroups.Where(dg => dg.UserId == userId).ToList();
            var responseDevelopents = new List<DevelopmentDTO>();
            foreach (var development in allDevelopment)
            {
                var userDevelopmentGroup = userDevelopmentGroups.Where(udg => udg.DevelopmentId == development.DevelopmentId).FirstOrDefault();
                var roundOfnewDevelopment = 0;
                if (userDevelopmentGroup != null)
                {
                    roundOfnewDevelopment = _context.NewDevelopments.Where(nd => nd.DevelopmentGroupId == userDevelopmentGroup.DevelopmentGroupId).Select(nd => nd.Round).FirstOrDefault();
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
