using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.Paging
{
    public class PagingRequest<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } 
        public int TotalPage {  get; set; }
        public List<T> Items { get; set; }
        
    }
}
