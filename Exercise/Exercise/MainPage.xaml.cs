﻿using Exercise.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Exercise
{
	public partial class MainPage : ContentPage
	{
        private UserViewModel viewModel
        {
            get { return BindingContext as UserViewModel; }
            set { BindingContext = value; }
        }

        public MainPage()
		{
			InitializeComponent();

            BindingContext = new UserViewModel(new PageService());
        }

        protected override void OnAppearing()
        {
            viewModel.GetAllCommand.Execute(null);
            base.OnAppearing();
        }

        public void OnUserSelected(object sender,SelectedItemChangedEventArgs e)
        {
            viewModel.SelectedUserCommand.Execute(e.SelectedItem);
        }
    }
}
