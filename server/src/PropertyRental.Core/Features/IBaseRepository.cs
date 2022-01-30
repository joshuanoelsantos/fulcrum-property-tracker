using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Core
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetById(string bidId);
        Task<List<T>> GetByIds(List<string> ids);
    }
}
