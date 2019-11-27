using Microsoft.EntityFrameworkCore;
using StrategyGame.Bll.DTOs;
using StrategyGame.Bll.Interfaces;
using StrategyGame.Dal;
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
                    Message = "something",
                    RoundOfNewDevelopment = roundOfnewDevelopment
                };
                responseDevelopents.Add(devResponse);
            }
            return new DevelopmentsResponseDTO
            {
                Developments = responseDevelopents
            };
        }
    }
}
