﻿using System;
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
			WestUSButton.MouseEnter += HUD.Button_MouseMove;
			EastUSButton.MouseEnter += HUD.Button_MouseMove;
			SouthCanadaButton.MouseEnter += HUD.Button_MouseMove;
			NorthCanadaAndAlaskaButton.MouseEnter += HUD.Button_MouseMove;
			MexicoAndCentralAmericaButton.MouseEnter += HUD.Button_MouseMove;
			NorthEastUSAndEastCanadaButton.MouseEnter += HUD.Button_MouseMove;
			NorthWestSouthAmericaButton.MouseEnter += HUD.Button_MouseMove;
			EastSouthAmericaButton.MouseEnter += HUD.Button_MouseMove;
			SouthSouthAmericaButton.MouseEnter += HUD.Button_MouseMove;
			WestAfricaButton.MouseEnter += HUD.Button_MouseMove;
			EastAfricaButton.MouseEnter += HUD.Button_MouseMove;
			NorthAfricaButton.MouseEnter += HUD.Button_MouseMove;
			SouthAfricaButton.MouseEnter += HUD.Button_MouseMove;
			WestEuropeButton.MouseEnter += HUD.Button_MouseMove;
			NorthEuropeButton.MouseEnter += HUD.Button_MouseMove;
			EastEuropeButton.MouseEnter += HUD.Button_MouseMove;
			SouthEuropeButton.MouseEnter += HUD.Button_MouseMove;
			GreenlandButton.MouseEnter += HUD.Button_MouseMove;
			WestRussiaButton.MouseEnter += HUD.Button_MouseMove;
			NorthRussiaButton.MouseEnter += HUD.Button_MouseMove;
			SouthRussiaButton.MouseEnter += HUD.Button_MouseMove;
			EastRussiaButton.MouseEnter += HUD.Button_MouseMove;
			SouthMiddleEastButton.MouseEnter += HUD.Button_MouseMove;
			NorthEastChinaButton.MouseEnter += HUD.Button_MouseMove;
			SouthChinaButton.MouseEnter += HUD.Button_MouseMove;
			NorthWestChinaButton.MouseEnter += HUD.Button_MouseMove;
			IndiaButton.MouseEnter += HUD.Button_MouseMove;
			NorthMiddleEastButton.MouseEnter += HUD.Button_MouseMove;
			JapanButton.MouseEnter += HUD.Button_MouseMove;
			WestIndonesiaButton.MouseEnter += HUD.Button_MouseMove;
			EastIndonesiaButton.MouseEnter += HUD.Button_MouseMove;
			AustraliaButton.MouseEnter += HUD.Button_MouseMove;
			NewZealandButton.MouseEnter += HUD.Button_MouseMove;
		}

		public void Update( bool pause )
		{
			HUD.Update();
			for( int i = 0; i < VisualTreeHelper.GetChildrenCount( TheGrid ); ++i )
			{
				Visual childVisual = (Visual)VisualTreeHelper.GetChild( TheGrid, i );
				if( childVisual is Button )
				{
					UpdateButtonImage( childVisual as Button );
				}
			}
			if( pause )
			{
				PauseButton.Content = "Unpause";
			}
			else
			{
				PauseButton.Content = "Pause";
			}
			//Update the window with values from the engine.
		}

		private void UpdateButtonImage( Button button )
		{
			Location loc = MapInfo.GetLocationByName( button.Name.Substring( 0, button.Name.IndexOf( "Button" ) ) );
			//TODO: Tom, please finish this out.
			//Change the button image
			//the population of the location should be loc.Population
		}

		public Map MapInfo
		{
			get;
			set;
		}

		private void GameSpeedSlider_ValueChanged( object sender, RoutedPropertyChangedEventArgs<double> e )
		{
			
		}
	}
}
