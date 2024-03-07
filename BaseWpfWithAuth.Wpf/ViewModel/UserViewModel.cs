using BaseWpfWithAuth.Core;
using BaseWpfWithAuth.DbLib.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseWpfWithAuth.Wpf.ViewModel
{
    internal class UserViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public User? SelectedUser { get; set; }

        public string? UnhashedPassword { get; set; }

        private PasswordHasher _Hasher { get; set; }

        public UserViewModel() 
        {
            _Hasher = new();
            using (ApplicationDBContext context = new())
                Users = new ObservableCollection<User>(context.Users);
        
        }

        public void AddUser()
        {
            UnhashedPassword = "Password";
            using (ApplicationDBContext context = new())
            {
                User user = new User()
                { 
                    UserName = "Nouvel Utilisateur",
                    HashedPassword = _Hasher.HashPassword(UnhashedPassword),
                    Roles = "USER" 
                };
                context.Users.Add(user);
                context.SaveChanges();
                Users.Add(user);
                SelectedUser = null;
                SelectedUser = user;
            }
        }

        public void RemoveUser()
        {
            using (ApplicationDBContext context = new())
            {
                if (SelectedUser is not null)
                {
                    context.Users.Remove(SelectedUser);
                    context.SaveChanges();
                    Users.Remove(SelectedUser);
                    SelectedUser = null;
                }
            }
        }

        public void UpdateUser()
        {
            using (ApplicationDBContext context = new())
            {
                if (SelectedUser is not null)
                {
                    if (!string.IsNullOrWhiteSpace(UnhashedPassword))
                        SelectedUser.HashedPassword = _Hasher.HashPassword(UnhashedPassword);
                    context.Users.Update(SelectedUser);
                    context.SaveChanges();
                }

            }
        }
    }
}
