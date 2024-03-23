using DataTranferObject.Paging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PagingRepository
{
    public class PagingRepository
    {
        private readonly JewelryContext _context;

        public PagingRepository(JewelryContext context)
        {
            _context = context;
        }

   
    }
}
