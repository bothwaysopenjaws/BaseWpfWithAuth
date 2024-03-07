using BaseWpfWithAuth.DbLib.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseWpfWithAuth.Wpf.ViewModel;

internal class LoginViewModel
{
    public string? UserName { get; set; }

    public string? Password { get; set; }

    private PasswordHasher _Hasher { get; set; }

    public LoginViewModel()
    {
        _Hasher = new();
    }

    public void Login()
    {
        User? user = null;
        PasswordVerificationResult result = PasswordVerificationResult.Failed;
        using (ApplicationDBContext context = new())
            user = context.Users
                .FirstOrDefault(userTemp => userTemp.UserName.Equals(UserName));

        if (user is not null)
        {
            result = _Hasher.VerifyHashedPassword(user.HashedPassword, Password);
            if (result == PasswordVerificationResult.Success)
                ((App)App.Current).Login(user);
        }
    }
}
