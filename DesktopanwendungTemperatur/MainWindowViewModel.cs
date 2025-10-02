using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace DesktopanwendungTemperatur
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        /// Instance of the current DatabaseContext
        public MyDbContext _db;

        /// Commands for handling events such as ButtonClickEvents
        public ICommand AddUserCommand { get; }
        public ICommand CancelAddUserCommand { get; }
        public ICommand SaveAddUserCommand { get; }
        public ICommand DeleteUserCommand { get; }




        /// Objectifed instances of the databaseTables
        private ObservableCollection<UserModel>? _users;
        public ObservableCollection<UserModel>? Users
        {
            get => _users; set
            {
                if (_users != value && value != null)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }
        public ObservableCollection<ManufacturerModel> Manufacturer { get; set; }
        public ObservableCollection<SensorModel> Sensors { get; set; }
        public ObservableCollection<TemperatureModel> Temperatures { get; set; }
        public ObservableCollection<LogModel> Logs { get; set; }


        /// helper fields for handling different appstates
        private bool _enableUserGrid = true;
        public bool EnableUserGrid
        {
            get => _enableUserGrid;
            set
            {
                if (_enableUserGrid != value)
                {
                    _enableUserGrid = value;
                    EnableAddButtons = !value;
                    OnPropertyChanged(nameof(EnableUserGrid));
                }
            }
        }

        private bool _enableAddButtons = false;
        public bool EnableAddButtons
        {
            get => _enableAddButtons;
            set
            {
                if (_enableAddButtons != value)
                {
                    _enableAddButtons = value;
                    OnPropertyChanged(nameof(EnableAddButtons));
                }
            }
        }

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
                    ManufacturerName = Manufacturer.FirstOrDefault(p => p.Id == SelectedSensor.ManufacturerId)?.ManufacturerName;
                    ManufacturerAddress = Manufacturer.FirstOrDefault(p => p.Id == SelectedSensor.ManufacturerId)?.Address;
                    ManufacturerPhone = Manufacturer.FirstOrDefault(p => p.Id == SelectedSensor.ManufacturerId)?.PhoneNumber;
                    OnPropertyChanged(nameof(SelectedSensor));
                }
            }
        }

        private string? _manufacturerName = string.Empty;
        public string? ManufacturerName
        {
            get => _manufacturerName;

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
            get => _manufacturerAddress;

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

        /// Methods
        public void AddUser()
        {
            SelectedUser = new UserModel { LogInName = "", Password = "", PhoneNumber = "", UserName = "" };
            EnableUserGrid = false;
        }

        public void SaveAddUser()
        {
            _db.Users.Add(SelectedUser);
            _db.SaveChanges();
            EnableUserGrid = true;
            InitUserSource();
        }


        public void CancelAddUser()
        {
            SelectedUser = Users!.FirstOrDefault() ?? new UserModel();
            EnableUserGrid = true;
        }

        public void DeleteUser()
        {
            if (SelectedUser != null)
            {
                _db.Users.Remove(SelectedUser);
                _db.SaveChanges();
                InitUserSource();
            }
        }

        private void InitUserSource()
        {
            var userList = _db.Users.ToList();
            Users = new ObservableCollection<UserModel>(userList);
            SelectedUser = Users.FirstOrDefault() ?? new UserModel();
        }

        public MainWindowViewModel()
        {
            _db = new MyDbContext();

            AddUserCommand = new RelayCommand(AddUser, () => true);
            CancelAddUserCommand = new RelayCommand(CancelAddUser, () => true);
            SaveAddUserCommand = new RelayCommand(SaveAddUser, () => true);
            DeleteUserCommand = new RelayCommand(DeleteUser, () => true);

            InitUserSource();

            var manufacturerList = _db.Manufacturers.ToList();
            Manufacturer = new ObservableCollection<ManufacturerModel>(manufacturerList);

            var sensorList = _db.Sensors.ToList();
            Sensors = new ObservableCollection<SensorModel>(sensorList);

            var temperaturList = _db.Temperatures.ToList();
            Temperatures = new ObservableCollection<TemperatureModel>(temperaturList);

            var logList = _db.Logs.ToList();
            Logs = new ObservableCollection<LogModel>(logList);

            if (Users != null)
            {
                foreach (var user in Users)
                {
                    System.Diagnostics.Debug.WriteLine($"User: {user.UserId}, {user.UserName}, {user.Password}, {user.PhoneNumber}");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
