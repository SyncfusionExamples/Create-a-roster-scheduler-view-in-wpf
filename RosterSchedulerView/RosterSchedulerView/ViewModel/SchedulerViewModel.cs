using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RosterSchedulerView
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// current day meetings 
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// list of meeting
        /// </summary>
        private ScheduleAppointmentCollection events;

        /// <summary>
        /// color collection
        /// </summary>
        private List<Brush> colorCollection;

        /// <summary>
        /// name collection
        /// </summary>
        internal List<string> nameCollection;

        /// <summary>
        /// resources
        /// </summary>
        private ObservableCollection<object> employees;

        public SchedulerViewModel()
        {
            this.events = new ScheduleAppointmentCollection();
            this.employees = new ObservableCollection<object>();
            this.InitializeDataForBookings();
            this.InitializeResources();
            this.BookingAppointments();
        }

        /// <summary>
        /// Property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #region ListOfMeeting

        /// <summary>
        /// Gets or sets list of meeting
        /// </summary>
        public ScheduleAppointmentCollection Events
        {
            get
            {
                return this.events;
            }

            set
            {
                this.events = value;
                this.RaiseOnPropertyChanged("Events");
            }
        }
        #endregion

        public ObservableCollection<object> Employees
        {
            get
            {
                return employees;
            }

            set
            {
                employees = value;
                this.RaiseOnPropertyChanged("Employees");
            }
        }

        private void InitializeResources()
        {
            Random random = new Random();
            for (int i = 0; i < 9; i++)
            {
                Employees.Add(new Employee()
                {
                    Name = nameCollection[i],
                    BackgroundBrush = this.colorCollection[random.Next(8)],
                    ID = "560" + i.ToString(),
                    ImageSource = "/Assets/People_Circle" + i.ToString() + ".png"
                });
            }
        }

        #region BookingAppointments

        /// <summary>
        /// Method for booking appointments.
        /// </summary>
        private void BookingAppointments()
        {
            Random random = new Random();

            DateTime date;
            DateTime dateFrom = DateTime.Now.AddYears(-1).AddDays(-20);
            DateTime dateTo = DateTime.Now.AddYears(1).AddDays(20);

            foreach (var resource in Employees)
            {
                for (date = dateFrom; date < dateTo; date = date.AddDays(1))
                {
                    ScheduleAppointment workDetails = new ScheduleAppointment();
                    workDetails.StartTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
                    workDetails.EndTime = workDetails.StartTime.AddHours(1);
                    workDetails.Subject = this.currentDayMeetings[random.Next(6)];
                    workDetails.AppointmentBackground = workDetails.Subject == "Work" ? new SolidColorBrush(Colors.Green) : (workDetails.Subject == "Off" ? new SolidColorBrush(Colors.Gray) : new SolidColorBrush(Colors.Red));
                    workDetails.IsAllDay = true;
                    workDetails.ResourceIdCollection = new ObservableCollection<object>
                        {
                            (resource as Employee).ID
                        };

                    this.Events.Add(workDetails);
                }
            }
        }

        #endregion BookingAppointments

        #region InitializeDataForBookings

        /// <summary>
        /// Method for initialize data bookings.
        /// </summary>
        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("Work");
            this.currentDayMeetings.Add("Leave");
            this.currentDayMeetings.Add("Off");
            this.currentDayMeetings.Add("Work");
            this.currentDayMeetings.Add("Work");
            this.currentDayMeetings.Add("Work");

            this.nameCollection = new List<string>();
            this.nameCollection.Add("Sophia");
            this.nameCollection.Add("Kinsley Elena");
            this.nameCollection.Add("Adeline Ruby");
            this.nameCollection.Add("Kinsley Ruby");
            this.nameCollection.Add("Emilia");
            this.nameCollection.Add("Daniel");
            this.nameCollection.Add("Adeline Elena");
            this.nameCollection.Add("Emilia William");
            this.nameCollection.Add("James William");
            this.nameCollection.Add("Zoey Addison");
            this.nameCollection.Add("Danial William");
            this.nameCollection.Add("Stephen Addison");
            this.nameCollection.Add("Stephen");
            this.nameCollection.Add("Danial Addison");
            this.nameCollection.Add("Brooklyn");

            this.colorCollection = new List<Brush>();
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1BA1E2")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA2C139")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD80073")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF339933")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE671B8")));
            this.colorCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00ABA9")));
        }

        #endregion InitializeDataForBookings

        #region Property Changed Event

        /// <summary>
        /// Invoke method when property changed
        /// </summary>
        /// <param name="propertyName">property name</param>
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

}
