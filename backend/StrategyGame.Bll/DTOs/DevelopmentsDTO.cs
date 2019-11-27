using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame.Bll.DTOs
{
    public class DevelopmentsResponseDTO
    {
        public ICollection<DevelopmentDTO> Developments { get; set; }
    }

    public class DevelopmentDTO
    {
        public int DevelopmentId { get; set; }
        public string DevelopmentName { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
        public int RoundOfNewDevelopment { get; set; }
        public bool Own { get; set; }
    }

    public class addNewDevelopmentRequestDTO
    {
        public int developmentId { get; set; }
    }
}
