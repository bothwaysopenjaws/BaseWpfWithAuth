using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using BaseWpfWithAuth.DbLib.Model;

namespace BaseWpfWithAuth.Wpf.Converters;

class RoleToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Visibility visibility = Visibility.Collapsed;
        bool isRoleValid = false;
        try
        {
            isRoleValid = ((User)value).Roles?.Contains((string)parameter) ?? false;
        }
        catch (Exception ex)
        {
            throw new Exception("Erreur de conversion de l'utilisateur, ou rôle inexistant", ex);
        }

        if (isRoleValid && value != null && value != DependencyProperty.UnsetValue)
            visibility = Visibility.Visible;

        return visibility;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
