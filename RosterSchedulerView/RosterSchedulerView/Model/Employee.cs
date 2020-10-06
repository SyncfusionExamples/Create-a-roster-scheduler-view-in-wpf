using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RosterSchedulerView
{
    public class Employee
    {
        /// <summary>
        /// Gets or sets the resource name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource id.
        /// </summary>
        public object ID { get; set; }

        /// <summary>
        /// Gets or sets the resource background brush.
        /// </summary>
        public Brush BackgroundBrush { get; set; }

        /// <summary>
        /// Gets or sets the foreground brush.
        /// </summary>
        public Brush ForegroundBrush { get; set; }

        /// <summary>
        /// Gets or sets the resource image.
        /// </summary>
        public string ImageSource { get; set; }
    }
}
