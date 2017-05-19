using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Probs.Wpf
{
    class ColourStack
    {
        readonly string[] _colours;
        int _next;

        //  #5cb85c Green
        //  #5bc0de Blue (mid)
        //  #f0ad4e Yellow
        //  #aaaaaa Grey
        //  #d9534f Red

        // #C6DAFC  Blue (light)
        // #4285F4  Blue (dark)

        public ColourStack()
        {
            _next = 0;
            _colours = new string[]
            {
                "#5cb85c", "#5bc0de", "#f0ad4e", "#d9534f", "#C65AFC", "#4265F4", "#aaaaaa"
            };
        }

        public Brush GetNextBrush()
        {
            var b = _colours[_next];
            _next++;
            TypeConverter tc = new ColorConverter();
            Color color = (Color)tc.ConvertFromString(b);

            return new SolidColorBrush(color);
        }
    }
}
