using System;
using System.Collections.Generic;
using System.Text;
using MVVMAssignment1.Models;
namespace MVVMAssignment1.Services
{
    public interface IParameterRepository
    {
        List<Parameter> GetAllParameterData();

        //Get Specific Parameter data  
        Parameter GetParameterData(int id);
       

        // Update Parameter Data  
        void UpdateParameter(Parameter parameter);
        
    }
}
