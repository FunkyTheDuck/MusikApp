using AppModels;
using AppRepository;
using MusikApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusikApp.ViewModels
{
    public class CreateUserPageViewModel
    {
        public string Name { get; set;}
        public string LastName {get; set;}
        public string UserName {get; set;}
        public string Mail {get; set;}
        public string Password {get; set;}
        public string ValidatePassword {get; set;}

        public ICommand RegisterCommand { get; set; }
        UserRepository repo { get; set; }
        SettingsPageRepository settingsRepository { get; set; }

        public CreateUserPageViewModel()
        {
            repo = new UserRepository();
            settingsRepository = new SettingsPageRepository();
            RegisterCommand = new Command(RegisterUserClicked);
        }

        public async void RegisterUserClicked()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(UserName) ||
                string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Mail) ||
                string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please fill in all fields", "ok");
                return;
            }
            //der skal laves et statement til at tjekke om der er duplicate af username
            else if(Password != ValidatePassword)
            {
                await App.Current.MainPage.DisplayAlert("Error", "make sure the password are the same", "ok");
                return;
            }
            else if(!(Password.Length >= 8 && ContainsUppercaseLetter(Password) && ContainsNumber(Password)))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Password must be 8 characters long and contain at least one uppercase letter and one number.", "ok");
                return;
            }
            User user = new User
            {
                Name = Name,
                LastName = LastName,
                UserName = UserName,
                Mail = Mail,
                Password = Password,
                IsArtist = false,
                IsPremium = false,
            };

            bool created = await repo.CreateUserAsync(user);
            if (created)
            {
                User createduser = await repo.GetUserAsync(UserName, Password);

                await settingsRepository.CreateSettingsAsync(createduser.Id);
                await SecureStorage.Default.SetAsync("userId", createduser.Id.ToString());

                await Shell.Current.GoToAsync("//ChooseGenrePage");
            }

            
        }

        private bool ContainsUppercaseLetter(string password)
        {
            return password.Any(char.IsUpper);
        }
        private bool ContainsNumber(string password)
        {
            return password.Any(char.IsDigit);
        }

    }
}
