using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ObjectDetector
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        private const int MINIMUM_SPLASH_TIME = 120;

        public const int SC_MINIMIZE = 6;

        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);

        public SplashScreen()
        {
            InitializeComponent();
            this.Topmost = true;
            
            prgssbrLoadingBar.Maximum = MINIMUM_SPLASH_TIME;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync();
            OpenWithStartInfo();
        }

        void OpenWithStartInfo()
        {
            /*
            ProcessStartInfo startInfo = new ProcessStartInfo("C:\\ObjectDetection\\ObjectDetection.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;

            Process.Start(startInfo);
            */
            {
                Process p = new Process();

                p.StartInfo.FileName = "C:\\ObjectDetection\\ObjectDetection.exe";
                p.Start();
                Thread.Sleep(10000);
                bool isMinimized = false;
                while (!isMinimized)
                {
                    int hWnd;
                    Process[] processRunning = Process.GetProcesses();
                    foreach (Process pr in processRunning)
                    {
                        if (pr.ProcessName == "ObjectDetection")
                        {
                            hWnd = pr.MainWindowHandle.ToInt32();
                            ShowWindow(hWnd, SC_MINIMIZE);
                            isMinimized = true;
                        }
                        //lstProcess.Items.Add(pr.ProcessName);
                    }
                }
            }
            {
                Process p = new Process();

                p.StartInfo.FileName = "C:\\Program Files\\Nox\\bin\\Nox.exe";
                p.Start();
                Thread.Sleep(20000);
                bool isMinimized = false;
                while (!isMinimized)
                {
                    int hWnd;
                    Process[] processRunning = Process.GetProcesses();
                    foreach (Process pr in processRunning)
                    {
                        if (pr.ProcessName == "Nox")
                        {
                            hWnd = pr.MainWindowHandle.ToInt32();
                            ShowWindow(hWnd, SC_MINIMIZE);
                            isMinimized = true;
                        }
                        //lstProcess.Items.Add(pr.ProcessName);
                    }
                }
            }
        }

        //RUN BG STUFF HERE.NO GUI HERE PLEASE
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= MINIMUM_SPLASH_TIME; i++)
            {
                Thread.Sleep(1000);
                backgroundWorker1.ReportProgress(i);
            }

        }

        //THIS UPDATES GUI.OUR PROGRESSBAR
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prgssbrLoadingBar.Value = e.ProgressPercentage;
            //percentageLabel.Text = e.ProgressPercentage.ToString() + " %";
        }

        //WHEN JOB IS DONE THIS IS CALLED.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //ShowWindow(p.MainWindowHandle, SC_MINIMIZE);
            
            MainWindow mw = new MainWindow();
            mw.Show();

            this.Close();
        }
    }
}
