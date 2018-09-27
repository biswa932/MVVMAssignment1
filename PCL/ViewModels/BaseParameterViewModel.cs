using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using MVVMAssignment1.Helpers;
using MVVMAssignment1.Models;
using MVVMAssignment1.Services;

namespace MVVMAssignment1.ViewModels
{
    public class BaseParameterViewModel:INotifyPropertyChanged
    {
        public Parameter _parameter;
        public INavigation _navigation;
        public IParameterRepository _parameterRepository;
        public string Name
        {
            get { return _parameter.Name; }
            set
            {
                _parameter.Name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public string Value
        {
            get { return _parameter.Value; }
            set
            {
                _parameter.Value = value;
                NotifyPropertyChanged("Value");
            }
        }
        List<Parameter> _parameterList;
        public List<Parameter> ParameterList
        {
            get
            {
                return _parameterList;
            }
            set
            {
                _parameterList = value;
                NotifyPropertyChanged("ParameterList");
            }
        }
        #region InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
