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

namespace GoingViral.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();

            // setup the buttons within the canvas
            EnumControls(MapCanvas);
        }

        public void EnumControls(Visual myControl)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(myControl); i++)
            {
                // Retrieve child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(myControl, i);

                if (childVisual is Button)
                {
                    ((Button)childVisual).MouseEnter += HUD.Button_MouseMove;
                }

                // Enumerate children of the child visual object.
                EnumControls(childVisual);
            }
        }

        public void Update(bool pause)
        {
            HUD.Update();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(TheGrid); ++i)
            {
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(TheGrid, i);
                if (childVisual is Button)
                {
                    UpdateButtonImage(childVisual as Button);
                }
            }

            if (pause)
            {
                PauseButton.Content = "Unpause";
            }
            else
            {
                PauseButton.Content = "Pause";
            }
            //Update the window with values from the engine.
        }

        private void UpdateButtonImage(Button button)
        {
            Location loc = MapInfo.GetLocationByName(button.Name.Substring(0, button.Name.IndexOf("Button")));

            if (loc != null && loc.Population <= 0)
            {
                var buttonTemplate = button.FindResource("PopulationCenterButton") as DataTemplate;
                var imageControl = buttonTemplate.LoadContent() as Image;

                BitmapImage skullImage = new BitmapImage();
                skullImage.BeginInit();
                skullImage.UriSource = new Uri(@"Images\skull_and_crossbones.jpg", UriKind.Relative);
                skullImage.EndInit();

                imageControl.Source = skullImage;
            }
        }

        public Map MapInfo
        {
            get;
            set;
        }

        private void GameSpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
