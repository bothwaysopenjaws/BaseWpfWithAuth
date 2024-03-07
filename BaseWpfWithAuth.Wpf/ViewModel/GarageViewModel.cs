using BaseWpfWithAuth.Core;
using BaseWpfWithAuth.DbLib.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace BaseWpfWithAuth.Wpf.ViewModel;

internal class GarageViewModel : ObservableObject
{
    private ObservableCollection<Garage> _Garages;

    private Garage? _SelectedGarage;

    private Car? _SelectedCar;

    public ObservableCollection<Garage> Garages 
    { 
        get => _Garages; 
        set => SetProperty(nameof(Garage), ref _Garages, value); 
    }

    public Garage? SelectedGarage 
    { 
        get => _SelectedGarage; 
        set => SetProperty(nameof(SelectedGarage), ref _SelectedGarage, value); 
    }

    public Car? SelectedCar 
    { 
        get => _SelectedCar; 
        set => SetProperty(nameof(SelectedCar), ref _SelectedCar, value); 
    }

    public GarageViewModel()
    {
        using (ApplicationDBContext db = new())
            Garages = new ObservableCollection<Garage>(db.Garages.Include(g => g.Cars));
    }

    public void AddGarage()
    {
        using (ApplicationDBContext db = new())
        {
            Garage garage = new()
            {
                Name = "Nouveau Garage" 
            };
            db.Garages.Add(garage);
            db.SaveChanges();
            Garages.Add(garage);
        }
    }

    public void AddCar()
    {
        if (SelectedGarage is not null)
        {
            using (ApplicationDBContext db = new())
            {
                Car car = new()
                {
                    Name = "Nouvelle Voiture",
                    GarageId = SelectedGarage.Id
                };
                db.Cars.Add(car);
                db.SaveChanges();
                SelectedGarage.Cars.Add(car);
            }
        }
    }

    public void RemoveGarage()
    {
        if (SelectedGarage is not null)
        {
            using (ApplicationDBContext db = new())
            {
                db.Garages.Remove(SelectedGarage);
                db.SaveChanges();
                Garages.Remove(SelectedGarage);
            }
        }
    }
    

    public void RemoveCar()
    {
        if (SelectedCar is not null)
        {
            using (ApplicationDBContext db = new())
            {
                db.Cars.Remove(SelectedCar);
                db.SaveChanges();
                SelectedGarage?.Cars.Remove(SelectedCar);
            }
        }
    }

    public void UpdateGarage()
    {
        if (SelectedGarage is not null)
        {
            using (ApplicationDBContext db = new())
            {
                db.Garages.Update(SelectedGarage);
                db.SaveChanges();
            }
        }
    }

    public void UpdateCar()
    {
        if (SelectedCar is not null)
        {
            using (var db = new ApplicationDBContext())
            {
                db.Cars.Update(SelectedCar);
                db.SaveChanges();
            }
        }
    }
}
