using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DesktopanwendungTemperatur
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public MyDbContext _db;
        public ObservableCollection<UserModel> Users { get; set; }
        public ObservableCollection<ManufacturerModel> Manufacturer { get; set; }
        public ObservableCollection<SensorModel> Sensors { get; set; }
        public ObservableCollection<TemperatureModel> Temperatures { get; set; }
        public ObservableCollection<LogModel> Logs { get; set; }


        private UserModel _selectedUser = new();
        public UserModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                if (_selectedUser != value && value != null)
                {
                    _selectedUser = value;
                    OnPropertyChanged(nameof(SelectedUser));
                }
            }
        }

        private SensorModel _selectedSensor = new();
        public SensorModel SelectedSensor
        {
            get => _selectedSensor;
            set
            {
                if (_selectedSensor != value && value != null)
                {
                    _selectedSensor = value;
                    OnPropertyChanged(nameof(SelectedSensor));
                }
            }
        }

        private string? _manufacturerName = string.Empty;
        public string? ManufacturerName
        {
            get => _manufacturerName = Manufacturer.FirstOrDefault(p => p.Id == SelectedSensor.ManufacturerId)?.ManufacturerName;

            set
            {
                if (_manufacturerName != value && value != null)
                {
                    _manufacturerName = value;
                    OnPropertyChanged(nameof(ManufacturerName));
                }
            }
        }

        private string? _manufacturerAddress = string.Empty;
        public string? ManufacturerAddress
        {
            get => _manufacturerAddress = Manufacturer.FirstOrDefault(p => p.Id == SelectedSensor.ManufacturerId)?.Address;

            set
            {
                if (_manufacturerAddress != value && value != null)
                {
                    _manufacturerAddress = value;
                    OnPropertyChanged(nameof(ManufacturerAddress));
                }
            }
        }

        private string? _manufacturerPhone = string.Empty;
        public string? ManufacturerPhone
        {
            get => _manufacturerPhone;

            set
            {
                if (_manufacturerPhone != value && value != null)
                {
                    _manufacturerPhone = value;
                    OnPropertyChanged(nameof(ManufacturerPhone));
                }
            }
        }

        public MainWindowViewModel()
        {
            _db = new MyDbContext();


            var userList = _db.Users.ToList();
            Users = new ObservableCollection<UserModel>(userList);
            SelectedUser = Users.FirstOrDefault() ?? new UserModel();

            var manufacturerList = _db.Manufacturers.ToList();
            Manufacturer = new ObservableCollection<ManufacturerModel>(manufacturerList);

            var sensorList = _db.Sensors.ToList();
            Sensors = new ObservableCollection<SensorModel>(sensorList);

            var temperaturList = _db.Temperatures.ToList();
            Temperatures = new ObservableCollection<TemperatureModel>(temperaturList);

            var logList = _db.Logs.ToList();
            Logs = new ObservableCollection<LogModel>(logList);

            foreach (var user in Users)
            {
                System.Diagnostics.Debug.WriteLine($"User: {user.UserId}, {user.UserName}, {user.Password}, {user.PhoneNumber}");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
