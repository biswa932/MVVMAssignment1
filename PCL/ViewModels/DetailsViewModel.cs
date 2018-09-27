using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using MVVMAssignment1.Helpers;
using MVVMAssignment1.Models;
using MVVMAssignment1.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMAssignment1.Validation;

namespace MVVMAssignment1.ViewModels
{
    public class DetailsViewModel:INotifyPropertyChanged
    {
        public Parameter _parameterA;
        public Parameter _parameterB;
        public INavigation _navigation;
        public IParameterRepository _parameterRepository;
        public Validator _validator;
        public string NameA
        {
            get { return _parameterA.Name; }
            set
            {
                _parameterA.Name = value;
                NotifyPropertyChanged("NameA");
            }
        }
        public string ValueA
        {
            get { return _parameterA.Value; }
            set
            {
                _parameterA.Value = value;
                NotifyPropertyChanged("ValueA");
            }
        }
        public string NameB
        {
            get { return _parameterB.Name; }
            set
            {
                _parameterB.Name = value;
                NotifyPropertyChanged("NameB");
            }
        }
        public string ValueB
        {
            get { return _parameterB.Value; }
            set
            {
                _parameterB.Value = value;
                NotifyPropertyChanged("ValueB");
            }
        }
        public ICommand UpdateParameterCommand { get; private set; }

        public DetailsViewModel(INavigation nav)
        {
            _navigation = nav;
            _parameterA = new Parameter();
            _parameterA.Id = 1;
            _parameterB = new Parameter();
            _parameterB.Id = 2;
            _parameterRepository = new ParameterRepository();

            UpdateParameterCommand = new Command(async () => await UpdateParameter());

            FetchParameterDetails();
        }

        void FetchParameterDetails()
        {
            _parameterA = _parameterRepository.GetParameterData(_parameterA.Id);
            _parameterB = _parameterRepository.GetParameterData(_parameterB.Id);
        }

        async Task UpdateParameter()
        {
            _validator = new Validator(_parameterA.Value, _parameterB.Value);
            if(_validator.IsValidated())
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Parameter Details", "Program Parameter Details", "OK", "Cancel");
                if (isUserAccept)
                {
                    _parameterRepository.UpdateParameter(_parameterA);
                    _parameterRepository.UpdateParameter(_parameterB);
                    await _navigation.PopAsync();
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error Occured", "Invalid Details Entered", "OK");
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
