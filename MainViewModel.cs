using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DemoApp
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            MyControls.Add("textbox1", Visibility.Visible );
        }

        public Dictionary<string, Visibility> MyControls { get; set; } = new Dictionary<string, Visibility>();

        private string? vehicleNumber;
        public string? VehicleNumber
        {
            get { return vehicleNumber; }
            set
            {
                if (vehicleNumber != value)
                {
                    vehicleNumber = value;
                    NotifyPropertyChanged(nameof(VehicleNumber));
                }
            }
        }

        private string? vehicleColor;
        public string? VehicleColor
        {
            get { return vehicleColor; }
            set
            {
                vehicleColor = value;
                NotifyPropertyChanged(nameof(VehicleColor));
            }
        }

        private int? vehicleMake;
        public int? VehicleMake
        {
            get { return vehicleMake; }
            set
            {
                vehicleMake = value;
                NotifyPropertyChanged(nameof(VehicleMake));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<ControlModel> _controls = new ObservableCollection<ControlModel>();

        private ObservableCollection<VehicleDetailsModel> myVar = new ObservableCollection<VehicleDetailsModel>();
        public ObservableCollection<VehicleDetailsModel> VehicleDetailsCollection
        {
            get { return myVar; }
            set { myVar = value; }
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ICommand _addCommand;
        public ICommand AddCommand => _addCommand ?? new RelayCommand(_ => AddVehicleDetails());
        public void AddVehicleDetails()
        {
            VehicleDetailsCollection.Add(new VehicleDetailsModel
            {
                VehicleColor = VehicleColor,
                VehicleMake = VehicleMake,
                VehicleNumber = VehicleNumber
            });
        }

        ICommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand ?? new RelayCommand(_ => DeleteCommandVehicleDetails());
        public void DeleteCommandVehicleDetails()
        {
            var deleteEntry = VehicleDetailsCollection.Where(x => x.VehicleNumber == VehicleNumber).FirstOrDefault();
            if (deleteEntry != null)
            {
                VehicleDetailsCollection.Remove(deleteEntry);
            }
        }

        ICommand _updateCommand;
        public ICommand UpdateCommand => _updateCommand ?? new RelayCommand(_ => UpdateVehicleDetails());
        public void UpdateVehicleDetails()
        {
            var deleteEntry = VehicleDetailsCollection.Where(x => x.VehicleNumber == VehicleNumber).FirstOrDefault();
            if (deleteEntry != null)
            {
                VehicleDetailsCollection.Remove(deleteEntry);
            }
            AddVehicleDetails();
        }
    }
    public class VehicleDetailsModel
    {
        public string? VehicleNumber { get; set; }
        public string? VehicleColor { get; set; }
        public int? VehicleMake { get; set; }

    }
    public class ControlModel
    {
        public string ControlName { get; set; }
        public Visibility Visibility { get; set; }
    }
}
