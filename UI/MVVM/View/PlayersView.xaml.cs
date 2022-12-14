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

namespace UI.MVVM.View
{
    /// <summary>
    /// Interaction logic for PlayersView.xaml
    /// </summary>
    public partial class PlayersView : UserControl
    {
        public PlayersView()
        {
            InitializeComponent();
        }
        private void BtnOpenAddModal(object sender, RoutedEventArgs e)
        {
            AddPlayer modal = new AddPlayer();
            modal.Owner = Application.Current.MainWindow;
            modal.DataContext = this.DataContext;
            modal.ShowDialog();
        }
    }


}
