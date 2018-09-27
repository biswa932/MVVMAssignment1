using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MVVMAssignment1.Models;
using Xamarin.Forms;

namespace MVVMAssignment1.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteConnection sqliteConnection;
       
        
        public DatabaseHelper()
        {
            sqliteConnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteConnection.CreateTable<Parameter>();
            Parameter param = new Parameter();//initializing Parameter A
            param.Id=1;
            param.Name = "Parameter1";
            param.Value = "5";
            Parameter param2 = new Parameter();//initializing Parameter B
            param2.Id = 2;
            param2.Name = "Parameter2";
            param2.Value = "5";
            if (sqliteConnection.Table<Parameter>().ToList().Count == 0)//setting default vaue for Parameter A and B
            {
                sqliteConnection.Insert(param);
                sqliteConnection.Insert(param2);
            }
        }

        // Get All Parameter data      
        public List<Parameter> GetAllParameterData()
        {
            return sqliteConnection.Table<Parameter>().ToList();
        }

        //Get Specific Parameter data  
        public Parameter GetParameterData(int id)
        {
            return sqliteConnection.Table<Parameter>().FirstOrDefault(t => t.Id == id);
        }
        
        // Update Parameter Data  
        public void UpdateParameter(Parameter parameter)
        {
            sqliteConnection.Update(parameter);
        }
    }
}
