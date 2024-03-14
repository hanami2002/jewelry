using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.PriceDTO
{
    public class PriceResponeDTO
    {
        public int PriceId { get; set; }
        public string? Arena { get; set; }
        public double? SellPrice { get; set; }
        public double? BuyPrice { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? MaterialName { get; set; }
        public PriceResponeDTO ToDTO(Price price)
        {
            return new PriceResponeDTO
            {
                PriceId = price.PriceId,
                Arena = price.Arena,
                SellPrice = price.SellPrice,
                BuyPrice = price.BuyPrice,
                UpdateDate = price.UpdateDate,
                MaterialName = price.Material.Name
            };
        }
    }
}
