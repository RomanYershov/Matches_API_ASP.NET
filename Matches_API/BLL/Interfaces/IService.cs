using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matches_API.BLL.Models;
using Matches_API.DAL.Models;

namespace Matches_API.BLL.Interfaces
{
    public interface IService<T1, T2> where T1 : Entity where  T2 : ModelBase
    {
        IEnumerable<T2> Get();
        IEnumerable<T2> Get(Func<T1, Boolean> predicate);
        T2 FindById(int id);
        T1 Create(T2 item);
        T2 Delete(T2 item);
        T2 Delete(int id);

    }
}
