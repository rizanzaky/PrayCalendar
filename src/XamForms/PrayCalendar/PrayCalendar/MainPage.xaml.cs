using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrayCalendar
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public List<List<int?>> Weeks { get; set; } = new List<List<int?>> {
            new List<int?> { null, 1, 2, 3, 4, 5, 6 },
            new List<int?> { 7, 8, 9, 10, 11, 12, 13 },
            new List<int?> { 14, 15, 16, 17, 18, 19, 20 },
            new List<int?> { 21, 22, 23, 24, 25, 26, 27 },
            new List<int?> { 28, 29, 30, 31, null, null, null }
        };
    }
}
