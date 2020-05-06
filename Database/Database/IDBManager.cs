using System;
using System.Collections.Generic;
using System.Text;

namespace APITEST.Database
{
    // Repository
    public interface IDBManager
    {
        void InitDBContext();
        void SaveChanges();
    }
}
