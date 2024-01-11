using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace MVPPattern.View
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Window, IMainView
    {
        public event RoutedEventHandler? OnLoaded;
        public event RoutedEventHandler? OnSave;
        public event RoutedEventHandler? OnDelete;
        public event RoutedEventHandler? OnCancel;
        public event Action<object>? OnListItemSelected;

        public MainView()
        {
            InitializeComponent();

            Loaded += (s, e) => OnLoaded?.Invoke(s, e);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidDelete())
                return;

            OnDelete?.Invoke(sender, e);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            OnCancel?.Invoke(sender, e);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidSave())
                return;

            OnSave?.Invoke(sender, e);
        }

        private void ListViewItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            OnListItemSelected?.Invoke(element.DataContext);
        }

        private bool IsValidSave()
        {
            if (Id <= 0)
                return false;

            if (string.IsNullOrWhiteSpace(Name))
                return false;

            if (string.IsNullOrWhiteSpace(Sex))
                return false;

            if (Age <= 0)
                return false;

            return true;
        }

        private bool IsValidDelete()
        {
            if (Id <= 0)
                return false;
            return true;
        }

        public int Id
        {
            get
            {
                int.TryParse(tbID.Text, out int value);
                return value;
            }
            set
            {
                tbID.Text = value == 0 ? "" : value.ToString();
            }
        }

        public new string Name { get => tbName.Text.Trim(); set => tbName.Text = value; }

        public string Sex { get => cbSex.Text; set => cbSex.Text = value; }

        public int Age
        {
            get
            {
                int.TryParse(tbAge.Text, out int value);
                return value;
            }
            set
            {
                tbAge.Text = value == 0 ? "" : value.ToString();
            }
        }
        public IEnumerable ItemSource { get => lstView.ItemsSource; set => lstView.ItemsSource = value; }
    }
}
