using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTranferObject.OtherRespone
{
    public class ApiRespone<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; }
    }
}
