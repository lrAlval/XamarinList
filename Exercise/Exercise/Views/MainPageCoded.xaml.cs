using Exercise.Models;
using Exercise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Exercise.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageCoded : ContentPage
    {
        private UserViewModel viewModel
        {
            get { return BindingContext as UserViewModel; }
            set { BindingContext = value; }
        }

        public MainPageCoded()
        {
            InitializeComponent();

            BindingContext = new UserViewModel(new PageService());

            this.Content = viewModel.GetListView();
        }

        protected override void OnAppearing()
        {
            viewModel.GetAllCommand.Execute(null);
            base.OnAppearing();
        }
    }
}