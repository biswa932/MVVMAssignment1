using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MVVMAssignment1.Helpers;
using MVVMAssignment1.Droid.Implementations;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLite))]
namespace MVVMAssignment1.Droid.Implementations
{
    public class AndroidSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string fileName = "parameters_db.sqlite";
            string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string full_path = Path.Combine(fileLocation, fileName);
            var conn = new SQLiteConnection(full_path);
            return conn;
        }
    }
}