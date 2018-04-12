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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            WpfApp1._aspnet_StudentAttendance_20180308103350DataSet _aspnet_StudentAttendance_20180308103350DataSet = ((WpfApp1._aspnet_StudentAttendance_20180308103350DataSet)(this.FindResource("_aspnet_StudentAttendance_20180308103350DataSet")));
            // Load data into the table Students. You can modify this code as needed.
            WpfApp1._aspnet_StudentAttendance_20180308103350DataSetTableAdapters.StudentsTableAdapter _aspnet_StudentAttendance_20180308103350DataSetStudentsTableAdapter = new WpfApp1._aspnet_StudentAttendance_20180308103350DataSetTableAdapters.StudentsTableAdapter();
            _aspnet_StudentAttendance_20180308103350DataSetStudentsTableAdapter.Fill(_aspnet_StudentAttendance_20180308103350DataSet.Students);
            System.Windows.Data.CollectionViewSource studentsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("studentsViewSource")));
            studentsViewSource.View.MoveCurrentToFirst();
            // Load data into the table Lecturers. You can modify this code as needed.
            WpfApp1._aspnet_StudentAttendance_20180308103350DataSetTableAdapters.LecturersTableAdapter _aspnet_StudentAttendance_20180308103350DataSetLecturersTableAdapter = new WpfApp1._aspnet_StudentAttendance_20180308103350DataSetTableAdapters.LecturersTableAdapter();
            _aspnet_StudentAttendance_20180308103350DataSetLecturersTableAdapter.Fill(_aspnet_StudentAttendance_20180308103350DataSet.Lecturers);
            System.Windows.Data.CollectionViewSource lecturersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("lecturersViewSource")));
            lecturersViewSource.View.MoveCurrentToFirst();
        }
    }
}
