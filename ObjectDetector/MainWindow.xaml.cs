using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;               // For prcesss related information
using System.Runtime.InteropServices;   // For DLL importing

namespace ObjectDetector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_NORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_MAXIMIZE = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_SHOW = 5;
        private const int SW_MINIMIZE = 6;
        private const int SW_SHOWMINNOACTIVE = 7;
        private const int SW_SHOWNA = 8;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;
        private const int SW_FORCEMINIMIZE = 11;
        private const int SW_MAX = 11;

        [DllImport("User32")]
        private static extern int ShowWindow(int hwnd, int nCmdShow);

        bool isObjectDetectionShowed = false;
        bool isNoxShowed = false;
        bool isMapShowed = false;

        map mp = new map();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isObjectDetectionShowed)
            {
                int hWnd;
                Process[] processRunning = Process.GetProcesses();
                foreach (Process pr in processRunning)
                {
                    if (pr.ProcessName == "ObjectDetection")
                    {
                        hWnd = pr.MainWindowHandle.ToInt32();
                        ShowWindow(hWnd, SW_MINIMIZE);
                    }
                    //lstProcess.Items.Add(pr.ProcessName);
                }
            }
            else
            {
                int hWnd;
                Process[] processRunning = Process.GetProcesses();
                foreach (Process pr in processRunning)
                {
                    if (pr.ProcessName == "ObjectDetection")
                    {
                        hWnd = pr.MainWindowHandle.ToInt32();
                        ShowWindow(hWnd, SW_MAXIMIZE);
                    }
                    //lstProcess.Items.Add(pr.ProcessName);
                }
            }
            isObjectDetectionShowed = !isObjectDetectionShowed;
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (isNoxShowed)
            {
                int hWnd;
                Process[] processRunning = Process.GetProcesses();
                foreach (Process pr in processRunning)
                {
                    if (pr.ProcessName == "Nox")
                    {
                        hWnd = pr.MainWindowHandle.ToInt32();
                        ShowWindow(hWnd, SW_MINIMIZE);
                    }
                    //lstProcess.Items.Add(pr.ProcessName);
                }
            }
            else
            {
                int hWnd;
                Process[] processRunning = Process.GetProcesses();
                foreach (Process pr in processRunning)
                {
                    if (pr.ProcessName == "Nox")
                    {
                        hWnd = pr.MainWindowHandle.ToInt32();
                        ShowWindow(hWnd, SW_MAXIMIZE);
                    }
                    //lstProcess.Items.Add(pr.ProcessName);
                }
            }
            isNoxShowed = !isNoxShowed;
        }

        private void Image_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            if (isMapShowed)
            {
                mp.Show();
            }
            else
            {
                mp.Hide();
            }
            isMapShowed = !isMapShowed;
        }
    }
}
