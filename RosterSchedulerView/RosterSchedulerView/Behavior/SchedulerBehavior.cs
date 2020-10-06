using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace RosterSchedulerView
{
    public class SchedulerBehavior : Behavior<SfScheduler>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.ViewChanged += OnSchedulerViewChanged;
            this.AssociatedObject.Loaded += OnSchedulerLoaded;

            this.AssociatedObject.TimelineViewSettings.ViewHeaderDateFormat = "dd";
            this.AssociatedObject.TimelineViewSettings.TimeRulerSize = 0;
            this.AssociatedObject.TimelineViewSettings.TimeInterval = new TimeSpan(24, 0, 0);
            this.AssociatedObject.TimelineViewSettings.VisibleResourceCount = 5;
            this.AssociatedObject.TimelineViewSettings.ResourceHeaderSize = 120;
            this.AssociatedObject.TimelineViewSettings.DaysCount = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            this.AssociatedObject.DisplayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void OnSchedulerLoaded(object sender, RoutedEventArgs e)
        {
            var appointmentHeight = (this.AssociatedObject.ActualHeight - this.AssociatedObject.HeaderHeight - this.AssociatedObject.TimelineViewSettings.ViewHeaderHeight) / this.AssociatedObject.TimelineViewSettings.VisibleResourceCount;
            this.AssociatedObject.TimelineViewSettings.TimelineAppointmentHeight = appointmentHeight;
        }

        private void OnSchedulerViewChanged(object sender, ViewChangedEventArgs e)
        {
            var date = e.NewValue.ActualStartDate.AddDays(this.AssociatedObject.TimelineViewSettings.DaysCount  / 2);
            this.AssociatedObject.TimelineViewSettings.DaysCount = DateTime.DaysInMonth(date.Year, date.Month);
            this.AssociatedObject.DisplayDate = new DateTime(date.Year, date.Month, 1);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.ViewChanged -= OnSchedulerViewChanged;
            this.AssociatedObject.Loaded -= OnSchedulerLoaded;
        }
    }
}
