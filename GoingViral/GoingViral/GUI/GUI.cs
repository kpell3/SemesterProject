using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace GoingViral.GUI
{
    /// <summary>
    /// This class keeps track of all of the window objects, making sure that
    /// they are handled properly, and can be accessed through here so only
    /// one instance is created.
    /// </summary>
    public class GUI
    {
        public GameWindow mGameWindow = new GameWindow();
        public ModifyVirusWindow mModifyVirusWindow = new ModifyVirusWindow();
        public Engine TheEngine;

        GameMode mGameMode;

        public GUI(Engine theengine)
        {
            mGameWindow.ModifyVirusButton.Click += ModifyVirusButton_Click;
            mGameWindow.PauseButton.Click += PauseButton_Click;
            mGameWindow.Closing += Exit;
            mGameWindow.GameSpeedSlider.ValueChanged += GameSpeedSlider_ValueChanged;
            mModifyVirusWindow.Closing += HideModifyVirusWindow;

            TheEngine = theengine;
        }

        void GameSpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TheEngine.SleepDuration = Convert.ToInt32((sender as Slider).Value);
        }

        void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            TheEngine.PauseSimulation = !TheEngine.PauseSimulation;
            if (TheEngine.PauseSimulation)
            {
                mGameWindow.PauseButton.Content = "Unpause";
            }
            else
            {
                mGameWindow.PauseButton.Content = "Pause";
            }
        }

        private void HideModifyVirusWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            mModifyVirusWindow.Hide();
        }

        void Exit(object sender, CancelEventArgs e)
        {
            try
            {
                TheEngine.ContinueSimulation = false;
                mModifyVirusWindow.Closing -= HideModifyVirusWindow;
                mModifyVirusWindow.Close();
            }
            catch (Exception)
            {
                //well, we tried to close it.
            }
        }

        public void Update()
        {
            if (mGameWindow.Visibility == Visibility.Visible)
            {
                //This has to be invoked so that it can be done in realtime without
                //throwing threading exceptions
                mGameWindow.Dispatcher.Invoke(new UpdateDelegate(mGameWindow.Update), TheEngine.PauseSimulation);
                //mGameWindow.Update( );
            }
        }

        void ModifyVirusButton_Click(object sender, RoutedEventArgs e)
        {
            mModifyVirusWindow.Show();
            TheEngine.PauseSimulation = true;
            mModifyVirusWindow.Update();
        }

        private delegate void UpdateDelegate(bool pause);

    }
}
