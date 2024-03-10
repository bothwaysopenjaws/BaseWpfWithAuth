using BaseWpfWithAuth.Core;
using BaseWpfWithAuth.DbLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseWpfWithAuth.Wpf.ViewModel;

internal class MainWindowViewModel : ObservableObject
{
	private User? _LoggedUser;

	public User? LoggedUser
	{
		get { return _LoggedUser; }
		set { SetProperty(nameof(LoggedUser), ref _LoggedUser, value); }
	}

    public MainWindowViewModel()
    {
		LoggedUser = ((App)App.Current).LoggedUser;
    }

	public void Logout() => ((App)App.Current).Logout();
}
