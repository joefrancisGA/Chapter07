using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EGMS.Common
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
