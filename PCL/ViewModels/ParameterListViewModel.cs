using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMAssignment1.Models;
using MVVMAssignment1.Helpers;
using MVVMAssignment1.Services;
using Xamarin.Forms;
using MVVMAssignment1.Views;

namespace MVVMAssignment1.ViewModels
{
    public class ParameterListViewModel : BaseParameterViewModel
    {
        public ICommand EditParameterCommand { get; private set; }
        public ParameterListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _parameterRepository = new ParameterRepository();
            EditParameterCommand = new Command(async () => await EditParameter());
            FetchParameters();

        }
        async Task EditParameter()
        {

            await _navigation.PushAsync(new DetailsPage());

        }
        void FetchParameters()
        {
            ParameterList = _parameterRepository.GetAllParameterData();
        }        

    }
}
