using DataTranferObject.DetailDTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DetailRepository
{
    public interface IDetailRepository
    {
        public IEnumerable<DetailResponeDTO> GetAllDetails();
        public DetailResponeDTO GetDetailById(int detailId);
        public DetailResponeDTO GetDetailByOidAndPid(int oid,int pid);
        public IEnumerable<DetailResponeDTO> GetAllDetailByOrderID(int detailId);
        public void CreateDetail(DetailRequestDTO detail);
        public void UpdateDetail(DetailRequestDTO detail);
        public void DeleteDetail(int id);
        List<DetailResponeDTO> GetDetailByOrderId(int id);
    }
}
