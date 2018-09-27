using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MVVMAssignment1.Helpers
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
