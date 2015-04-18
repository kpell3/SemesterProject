using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using GoingViralEngine;

namespace GoingViral.Controls
{
    /// <summary>
    /// Interaction logic for MapInformationControl.xaml
    /// </summary>
    public partial class MapInformationControl : UserControl
    {
        /// <summary>
        /// Buffer area near mouse pointer in which a location may be recognized
        /// </summary>
        private const int PIXEL_SIZE_BUFFER = 5;

        private System.Windows.Media.ImageSource _mapImage;
        private Map _mapInfo;

        /// <summary>
        /// An image of the world map.
        /// </summary>
        public System.Windows.Media.ImageSource MapImage
        {
            get { return _mapImage; }
            set
            {
                _mapImage = value;
                imgMap.Source = _mapImage;
            }
        }

        /// <summary>
        /// The map data, contains location information
        /// </summary>
        public Map MapInfo
        {
            get { return _mapInfo; }
            set
            {
                _mapInfo = value;
            }
        }

        public MapInformationControl()
        {
            InitializeComponent();
        }

        private void imgMap_MouseMove(object sender, MouseEventArgs e)
        {
            string locationInfo = string.Empty;
            Point pointerLocation = e.GetPosition(imgMap);//Get position of mouse pointer relative to the image control

            if (_mapInfo != null)//Only process if map object is not null
            {
                List<Location> locations = _mapInfo.theMap;
                //foundlocation uses lambas to see if there are any regions under our pointer or within the buffer 
                var foundLocation = locations.Where(l => Math.Abs(pointerLocation.X - l.Coordinates.Item1) <= PIXEL_SIZE_BUFFER && Math.Abs(pointerLocation.Y - l.Coordinates.Item2) <= PIXEL_SIZE_BUFFER);

                if (foundLocation.Any())//only process if a location is found
                {
                    Location location = foundLocation.First();

                    string quarentineStatus = location.IsUnderQuarentine ? "Quarentined" : "Not Quarentined";

                    locationInfo = string.Format("Name: {0}\nPopulation: {1}\nNumber Infected: {2}\n{3}", location.Name, location.Population, quarentineStatus);
                }

                txtRegionInfo.Text = locationInfo;
            }
        }
    }
}
