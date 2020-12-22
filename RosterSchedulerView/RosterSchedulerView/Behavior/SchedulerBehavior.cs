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
            this.AssociatedObject.Loaded += OnSchedulerLoaded;

            this.AssociatedObject.TimelineViewSettings.ViewHeaderDateFormat = "dd";
            this.AssociatedObject.TimelineViewSettings.VisibleResourceCount = 5;
            this.AssociatedObject.TimelineViewSettings.ResourceHeaderSize = 120;
        }

        private void OnSchedulerLoaded(object sender, RoutedEventArgs e)
        {
            var appointmentHeight = (this.AssociatedObject.ActualHeight - this.AssociatedObject.HeaderHeight - this.AssociatedObject.TimelineViewSettings.ViewHeaderHeight) / this.AssociatedObject.TimelineViewSettings.VisibleResourceCount;
            this.AssociatedObject.TimelineViewSettings.TimelineAppointmentHeight = appointmentHeight;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Loaded -= OnSchedulerLoaded;
        }
    }
}
