using Exercise.Data;
using Exercise.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Exercise.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; private set; } = new ObservableCollection<User>();
        public ICommand GetAllCommand { get; private set; }
        public ICommand SelectedUserCommand { get; private set; }



        private  IPageService _pageService;

        public UserViewModel(IPageService pageService)
        {
            _pageService = pageService;
            GetAllCommand = new Command(async () => await GetUsers());
            SelectedUserCommand = new Command<User>(async (user) => await OnUserSelect(user));
        }

        public ListView GetListView()
        {
            return new ListView
            {
                ItemsSource = Users,
                ItemTemplate = new DataTemplate(typeof(CustomCell))
            };
        }

        public async Task OnUserSelect(User user)
        {
            await _pageService.DisplayAlert("Welcome", user.FirstName , "ok");
        }

        public async Task GetUsers()
        {
            var service = new UserService();
            var users = await service.GetUsers();
            users.ForEach(u => Users.Add(u));
        }
    }
}
