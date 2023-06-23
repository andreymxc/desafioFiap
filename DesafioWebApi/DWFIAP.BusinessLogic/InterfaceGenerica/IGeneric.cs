using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.BusinessLogic.Interfaces
{
    public interface IGeneric<T>
    {
        Task Add(T Object);

        Task Update(T Object);

        Task Delete(T Object);

        Task<T> GeById(int id);

        Task<List<T>> List();

    }
}
