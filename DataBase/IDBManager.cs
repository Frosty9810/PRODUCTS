using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    // Repository
    public interface IDBManager
    {
        void InitDBContext();
        void SaveChanges();
    }
}
