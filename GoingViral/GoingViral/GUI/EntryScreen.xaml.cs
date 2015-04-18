using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoingViral.GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class EntryScreen : Window
	{
		public EntryScreen()
		{
			InitializeComponent();
			NewSandboxGame.Visibility = Visibility.Hidden;
			NewRegularGame.Visibility = Visibility.Hidden;
			opt.Visibility = Visibility.Hidden;
			cn.Visibility = Visibility.Hidden;
		}

		private void Grid_Loaded_1(object sender, RoutedEventArgs e)
		{
			var fadeInAnimation = new DoubleAnimation(1d, TimeSpan.FromSeconds(5));

			if( image.Source != null )
			{
				var fadeOutAnimation = new DoubleAnimation(0d, TimeSpan.FromSeconds(5));
				fadeOutAnimation.Completed += fadeOutAnimation_Completed;
				//fadeOutAnimation.Completed += (o, e) =>
				{
					//image.Source = source;
					image.BeginAnimation(Image.OpacityProperty, fadeInAnimation);
				};

				image.BeginAnimation(Image.OpacityProperty, fadeOutAnimation);
			}
			else
			{
				image.Opacity = 0d;
				//image.Source = source;
				image.BeginAnimation(Image.OpacityProperty, fadeInAnimation);
			}
		}

		void fadeOutAnimation_Completed(object sender, EventArgs e)
		{
			background.Visibility = Visibility.Visible;
			background.Height = this.Height;
			background.Width = this.Width;
			NewSandboxGame.Visibility = Visibility.Visible;
			NewRegularGame.Visibility = Visibility.Visible;
			opt.Visibility = Visibility.Visible;
			cn.Visibility = Visibility.Visible;
		}

		private void NewSandboxGame_Click(object sender, RoutedEventArgs e)
		{

		}

		private void NewRegularGame_Click(object sender, RoutedEventArgs e)
		{

		}

		private void opt_Click(object sender, RoutedEventArgs e)
		{

		}

	}
}
