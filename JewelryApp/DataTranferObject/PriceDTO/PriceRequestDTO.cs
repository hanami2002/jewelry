using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.PriceDTO
{
    public class PriceRequestDTO
    {
        public int PriceId { get; set; }
        public string? Arena { get; set; }
        public double? SellPrice { get; set; }
        public double? BuyPrice { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? MaterialId { get; set; }

        public Price ToEntity()
        {
            return new Price { 
                PriceId = this.PriceId,
                Arena = this.Arena,
                SellPrice = this.SellPrice,
                BuyPrice = this.BuyPrice,
                UpdateDate=this.UpdateDate,
                MaterialId = this.MaterialId
            };
        }
    }
}
