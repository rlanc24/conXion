using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
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
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Windows.Media.Animation;

namespace FIX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string SelectedPrinter;

        public Storyboard ExpansionStoryboard;
        public Storyboard ExpansionWStoryboard;

        public Storyboard CollapseStoryboard;
        public Storyboard CollapseWStoryboard;

        public MainWindow()
        {
            InitializeComponent();
            CheckDriveConnectionS();

                Process process = new Process();
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.Arguments = "/c net user " + Environment.UserName +" /domain"; // Note the /c command (*)
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                //* Read the output (or the error)
                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine("OP: "+output);
                UserInfo.Text = output;
                string err = process.StandardError.ReadToEnd();
                Console.WriteLine(err);
                process.WaitForExit();

                if (!"U".Equals(output.Substring(0,1)))
                {
                    Process process1 = new Process();
                    process1.StartInfo.FileName = "powershell.exe";
                    process1.StartInfo.Arguments = "/c net user " + Environment.UserName; // Note the /c command (*)
                    process1.StartInfo.UseShellExecute = false;
                    process1.StartInfo.RedirectStandardOutput = true;
                    process1.StartInfo.RedirectStandardError = true;
                    process1.StartInfo.CreateNoWindow = true;
                    process1.Start();
                    //* Read the output (or the error)
                    string output1 = process1.StandardOutput.ReadToEnd();
                    Console.WriteLine("OP1: "+output1);
                    UserInfo.Text = output1;
                    string err1 = process1.StandardError.ReadToEnd();
                    Console.WriteLine(err1);
                    process1.WaitForExit();
                }

            Process process2 = new Process();
            process2.StartInfo.FileName = "cmd.exe";
            process2.StartInfo.Arguments = "/c systeminfo";
            process2.StartInfo.UseShellExecute = false;
            process2.StartInfo.RedirectStandardOutput = true;
            process2.StartInfo.RedirectStandardError = true;
            process2.StartInfo.CreateNoWindow = true;
            process2.Start();
            //* Read the output (or the error)
            string output2 = process2.StandardOutput.ReadToEnd();
            Console.WriteLine(output2);
            SystemInfo.Text = output2;
            string err2 = process2.StandardError.ReadToEnd();
            Console.WriteLine(err2);
            process2.WaitForExit();

            if (Process.GetProcessesByName("pc-client").Length > 0)
            {
                
            }
            else
            {
                if (MessageBox.Show("PaperCut is not currently running." + Environment.NewLine + "Do you want to launch PaperCut? ", "PaperCut Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes, MessageBoxOptions.ServiceNotification) == MessageBoxResult.Yes)
                {
                    Process.Start("\\\\eqsun2109003\\Apps\\PaperCut NG\\client\\win\\pc-client.exe");
                }
                else
                {

                }
            }

            AnimationSetup();
            UpdatePrinters();

            ColapseWindowButton.Visibility = Visibility.Collapsed;

        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void UpdatePrinters()
        {

            ConnectedPrinters.Items.Clear();
            AvailablePrinters.Items.Clear();

            System.Management.ManagementScope objMS =
                new System.Management.ManagementScope(ManagementPath.DefaultPath);
            objMS.Connect();

            SelectQuery objQuery = new SelectQuery("SELECT * FROM Win32_Printer");
            ManagementObjectSearcher objMOS = new ManagementObjectSearcher(objMS, objQuery);
            System.Management.ManagementObjectCollection objMOC = objMOS.Get();

            foreach (ManagementObject Printers in objMOC)
            {

                if (Convert.ToBoolean(Printers["Network"]))
                {
                    ConnectedPrinters.Items.Add(Printers["Name"].ToString().Remove(0, 20));
                }

            }

            if (!ConnectedPrinters.Items.Contains("C05TOS"))
            {
                AvailablePrinters.Items.Add("C05TOS");
            }

            if (!ConnectedPrinters.Items.Contains("F01HPPR"))
            {
                AvailablePrinters.Items.Add("F01HPPR");
            }

            if (!ConnectedPrinters.Items.Contains("SRBTOS"))
            {
                AvailablePrinters.Items.Add("SRBTOS");
            }

            if (!ConnectedPrinters.Items.Contains("C01HPRO"))
            {
                AvailablePrinters.Items.Add("C01HPRO");
            }

            if (!ConnectedPrinters.Items.Contains("C06XEPH"))
            {
                AvailablePrinters.Items.Add("C06XEPH");
            }

            if (!ConnectedPrinters.Items.Contains("I04HPPR"))
            {
                AvailablePrinters.Items.Add("I04HPPR");
            }

            if (!ConnectedPrinters.Items.Contains("RCTOS"))
            {
                AvailablePrinters.Items.Add("RCTOS");
            }

            if (!ConnectedPrinters.Items.Contains("SRCTOS"))
            {
                AvailablePrinters.Items.Add("SRCTOS");
            }

            if (!ConnectedPrinters.Items.Contains("B05HPLJ"))
            {
                AvailablePrinters.Items.Add("B05HPLJ");
            }

            if (!ConnectedPrinters.Items.Contains("C04TOS"))
            {
                AvailablePrinters.Items.Add("C04TOS");
            }

            if (!ConnectedPrinters.Items.Contains("C08LEXM"))
            {
                AvailablePrinters.Items.Add("C08LEXM");
            }

            if (!ConnectedPrinters.Items.Contains("I06HPPR"))
            {
                AvailablePrinters.Items.Add("I06HPPR");
            }

            if (!ConnectedPrinters.Items.Contains("SRATOS"))
            {
                AvailablePrinters.Items.Add("SRATOS");
            }

            if (!ConnectedPrinters.Items.Contains("SRDTOS"))
            {
                AvailablePrinters.Items.Add("SRDTOS");
            }

        }

        private void InstalledPrinterFocus(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectedPrinter = ConnectedPrinters.SelectedItem.ToString();
                PrinterSwitch.Content = ">";
            }
            catch { }
        }

        private void AvailablePrinterFocus(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SelectedPrinter = AvailablePrinters.SelectedItem.ToString();
                PrinterSwitch.Content = "<";
            }
            catch { }
        }

        private void PrinterSwitchEngage(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!SelectedPrinter.Equals("") && PrinterSwitch.Content.Equals("<"))
                {
                    Process.Start("cmd.exe", "/C" + @"rundll32 printui.dll PrintUIEntry /in /n \\EQSUN2109003\P2109" + SelectedPrinter);
                    Thread.Sleep(5000);
                    UpdatePrinters();

                }

                if (!SelectedPrinter.Equals("") && PrinterSwitch.Content.Equals(">"))
                {
                    Process.Start("cmd.exe", "/C" + @"rundll32 printui.dll PrintUIEntry /dn /n \\EQSUN2109003\P2109" + SelectedPrinter);
                    Thread.Sleep(1000);
                    UpdatePrinters();
                }
            }
            catch { }
        }

        private void ResetSwitch(object sender, RoutedEventArgs e)
        {
            SelectedPrinter = "";
            PrinterSwitch.Content = "";
            ConnectedPrinters.SelectedIndex = -1;
            AvailablePrinters.SelectedIndex = -1;
        }

        private void CheckDriveConnection(object sender, RoutedEventArgs e)
        {
            CheckDriveConnectionS();
        }

        public void CheckDriveConnectionS()
        {
            if (Directory.Exists(@"H:"))
            {
                MapH.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
            }
            else
            {
                MapH.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
            }

            if (Directory.Exists(@"G:"))
            {
                MapG.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
            }
            else
            {
                MapG.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
            }

            if (Directory.Exists(@"I:"))
            {
                MapI.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
            }
            else
            {
                MapI.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
            }

            if (Directory.Exists(@"M:"))
            {
                MapM.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
            }
            else
            {
                MapM.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
            }

            if (Directory.Exists(@"N:"))
            {
                MapN.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
            }
            else
            {
                MapN.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
            }

            if (Directory.Exists(@"O:"))
            {
                MapO.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
            }
            else
            {
                MapO.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
            }

            if (Directory.Exists(@"P:"))
            {
                MapP.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
            }
            else
            {
                MapP.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
            }

            if (Directory.Exists(@"Q:"))
            {
                MapQ.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
            }
            else
            {
                MapQ.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
            }

            if (Directory.Exists(@"T:"))
            {
                MapT.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
            }
            else
            {
                MapT.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
            }

            if (Directory.Exists(@"U:"))
            {
                MapU.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
            }
            else
            {
                MapU.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
            }
        }

        private void ReconnectDrives(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(@"H:"))
            {
                Process.Start("cmd.exe", "/C" + @"net use H: \\eqsun2109001\" + Environment.UserName + "$");

                if (Directory.Exists(@"H:"))
                {
                    MapH.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
                }
                else
                {
                    MapH.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
                }
            }

            if (!Directory.Exists(@"G:"))
            {
                Process.Start("cmd.exe", "/C" + @"net use G: \\eqsun2109001\Data");

                if (Directory.Exists(@"G:"))
                {
                    MapG.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
                }
                else
                {
                    MapG.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
                }
            }

            if (!Directory.Exists(@"I:"))
            {
                Process.Start("cmd.exe", "/C" + @"net use I: \\eqsun2109003\Assessments");

                if (Directory.Exists(@"I:"))
                {
                    MapI.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
                }
                else
                {
                    MapI.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
                }
            }

            if (!Directory.Exists(@"M:"))
            {
                Process.Start("cmd.exe", "/C" + @"net use M: \\eqsun2109001\Menu$");

                if (Directory.Exists(@"M:"))
                {
                    MapM.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
                }
                else
                {
                    MapM.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
                }
            }

            if (!Directory.Exists(@"N:"))
            {
                Process.Start("cmd.exe", "/C" + @"net use N: \\eqsun2109001\CDApps$");

                if (Directory.Exists(@"N:"))
                {
                    MapN.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
                }
                else
                {
                    MapN.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
                }
            }

            if (!Directory.Exists(@"O:"))
            {
                Process.Start("cmd.exe", "/C" + @"net use O: \\eqsun2109003\Photos$");

                if (Directory.Exists(@"O:"))
                {
                    MapO.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
                }
                else
                {
                    MapO.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
                }
            }

            if (!Directory.Exists(@"P:"))
            {
                Process.Start("cmd.exe", "/C" + @"net use P: \\eqsun2109001\Apps");

                if (Directory.Exists(@"P:"))
                {
                    MapP.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
                }
                else
                {
                    MapP.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
                }
            }

            if (!Directory.Exists(@"Q:"))
            {
                Process.Start("cmd.exe", "/C" + @"net use Q: \\eqsun2109003\Apps");

                if (Directory.Exists(@"Q:"))
                {
                    MapQ.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
                }
                else
                {
                    MapQ.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
                }
            }

            if (!Directory.Exists(@"T:"))
            {
                Process.Start("cmd.exe", "/C" + @"net use T: \\eqsun2109003\Data\Curriculum");

                if (Directory.Exists(@"T:"))
                {
                    MapT.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
                }
                else
                {
                    MapT.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
                }
            }

            if (!Directory.Exists(@"U:"))
            {
                Process.Start("cmd.exe", "/C" + @"net use U: \\eqsun2109003\UsrHome$");

                if (Directory.Exists(@"U:"))
                {
                    MapU.Background = new SolidColorBrush(Color.FromRgb(76, 162, 64));
                }
                else
                {
                    MapU.Background = new SolidColorBrush(Color.FromRgb(162, 64, 64));
                }
            }
            Thread.Sleep(2000);
            CheckDriveConnectionS();
        }

        private void AnimationSetup()
        {
            DoubleAnimation ExpansionWDA = new DoubleAnimation();
            ExpansionWDA.From = 325;
            ExpansionWDA.To = 995;
            ExpansionWDA.Duration = new Duration(TimeSpan.FromSeconds(0.25));
            ExpansionWDA.AutoReverse = false;

            ExpansionWStoryboard = new Storyboard();
            ExpansionWStoryboard.Children.Add(ExpansionWDA);
            Storyboard.SetTargetName(ExpansionWDA, conXionWindow.Name);
            Storyboard.SetTargetProperty(ExpansionWDA, new PropertyPath(Window.WidthProperty));


            DoubleAnimation CollapseWDA = new DoubleAnimation();
            CollapseWDA.From = 995;
            CollapseWDA.To = 325;
            CollapseWDA.Duration = new Duration(TimeSpan.FromSeconds(0.25));
            CollapseWDA.AutoReverse = false;

            CollapseWStoryboard = new Storyboard();
            CollapseWStoryboard.Children.Add(CollapseWDA);
            Storyboard.SetTargetName(CollapseWDA, conXionWindow.Name);
            Storyboard.SetTargetProperty(CollapseWDA, new PropertyPath(Window.WidthProperty));
        }

        private void ExpandWindowEvent(object sender, RoutedEventArgs e)
        {
            double EDAI = conXionWindow.Left - 325;

            ExpandWindowButton.Visibility = Visibility.Collapsed;
            ColapseWindowButton.Visibility = Visibility.Visible;

            DoubleAnimation ExpansionDA = new DoubleAnimation();
            ExpansionDA.To = EDAI;
            ExpansionDA.Duration = new Duration(TimeSpan.FromSeconds(0.25));
            ExpansionDA.AutoReverse = false;

            ExpansionStoryboard = new Storyboard();
            ExpansionStoryboard.Children.Add(ExpansionDA);
            Storyboard.SetTargetName(ExpansionDA, conXionWindow.Name);
            Storyboard.SetTargetProperty(ExpansionDA, new PropertyPath(Window.LeftProperty));

            ExpansionStoryboard.Begin(this);
            ExpansionWStoryboard.Begin(this);
        }

        private void ColapseWindowEvent(object sender, RoutedEventArgs e)
        {
            double CDAI = conXionWindow.Left + 325;

            ExpandWindowButton.Visibility = Visibility.Visible;
            ColapseWindowButton.Visibility = Visibility.Collapsed;

            DoubleAnimation CollapseDA = new DoubleAnimation();
            CollapseDA.To = CDAI;
            CollapseDA.Duration = new Duration(TimeSpan.FromSeconds(0.25));
            CollapseDA.AutoReverse = false;

            CollapseStoryboard = new Storyboard();
            CollapseStoryboard.Children.Add(CollapseDA);
            Storyboard.SetTargetName(CollapseDA, conXionWindow.Name);
            Storyboard.SetTargetProperty(CollapseDA, new PropertyPath(Window.LeftProperty));

            CollapseStoryboard.Begin(this);
            CollapseWStoryboard.Begin(this);
        }
    }
}
