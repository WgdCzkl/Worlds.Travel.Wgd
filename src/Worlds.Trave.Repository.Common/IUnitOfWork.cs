using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worlds.Trave.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
    }
}
