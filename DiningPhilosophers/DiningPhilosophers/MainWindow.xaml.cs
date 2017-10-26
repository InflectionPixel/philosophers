//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: MainWindow.xaml.cs
//
//--------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DiningPhilosophers
{
    /// <summary>Application logic.</summary>
    public partial class MainWindow : Window
    {
        /// <summary>The number of philosophers to employ in the simulation.</summary>
        private const int NUM_PHILOSOPHERS = 5;
        /// <summary>The timescale to use for thinking and eating (any positive value; the larger, the linearly longer amount of time).</summary>
        private const int TIMESCALE = 200;
        /// <summary>The philosophers, represented as Ellipse WPF objects.</summary>
        private Ellipse[] _philosophers;
        /// <summary>A TaskFactory for running tasks on the UI.</summary>
        private TaskFactory _ui;

        /// <summary>Initializes the MainWindow.</summary>
        public MainWindow()
        {
            // Initialize the component's layout
            InitializeComponent();

            // Grab a TaskFactory for creating Tasks that run on the UI.
            _ui = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());

            // Initialize the philosophers, and then run them.
            ConfigurePhilosophers();
        }

        #region Colors
        /// <summary>A brush for rendering thinking philosophers.</summary>
        private Brush _think = Brushes.Yellow;
        /// <summary>A brush for rendering eating philosophers.</summary>
        private Brush _eat = Brushes.Green;
        /// <summary>A brush for rendering waiting philosophers.</summary>
        private Brush _wait = Brushes.Red;
        #endregion

        #region Helpers
        /// <summary>Initialize the philosophers.</summary>
        /// <param name="numPhilosophers">The number of philosophers to initialize.</param>
        private void ConfigurePhilosophers()
        {
            _philosophers = (from i in Enumerable.Range(0, NUM_PHILOSOPHERS) select new Ellipse { Height = 75, Width = 75, Fill = Brushes.Red, Stroke = Brushes.Black }).ToArray();
            foreach (var philosopher in _philosophers) circularPanel1.Children.Add(philosopher);
        }
        
        #endregion
    }
}