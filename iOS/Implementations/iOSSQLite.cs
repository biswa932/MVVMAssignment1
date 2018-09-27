using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MVVMAssignment1.iOS.Implementations;
using MVVMAssignment1.Helpers;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(iOSSQLite))]
namespace MVVMAssignment1.iOS.Implementations
{
    public class iOSSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string fileName = "parameters_db.sqlite";
            string fileLocation = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library");
            string full_path = Path.Combine(fileLocation, fileName);
            var conn = new SQLiteConnection(full_path);
            return conn;
        }
    }
}