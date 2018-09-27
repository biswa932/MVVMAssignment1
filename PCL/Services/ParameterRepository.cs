using System;
using System.Collections.Generic;
using System.Text;
using MVVMAssignment1.Models;
using MVVMAssignment1.Helpers;

namespace MVVMAssignment1.Services
{
    public class ParameterRepository : IParameterRepository
    {
        DatabaseHelper _databaseHelper;
        
        public ParameterRepository()
        {
            _databaseHelper = new DatabaseHelper();            
        }

        public List<Parameter> GetAllParameterData()
        {
           return _databaseHelper.GetAllParameterData();
        }

        public Parameter GetParameterData(int id)
        {
            return _databaseHelper.GetParameterData(id);
        }

        public void UpdateParameter(Parameter parameter)
        {
            _databaseHelper.UpdateParameter(parameter);
        }
    }
}
