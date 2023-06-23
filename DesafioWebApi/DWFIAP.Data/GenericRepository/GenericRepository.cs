using DWFIAP.BusinessLogic.Interfaces;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Data.GenericRepository
{
    public class GenericRepository<T> : IGeneric<T>, IDisposable where T : class
    {

        public async Task Add(T Object)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(T Object)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> List()
        {
            throw new NotImplementedException();
        }

        public async Task Update(T Object)
        {
            throw new NotImplementedException();
        }

        #region Disposed
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }
        #endregion
    }
}
