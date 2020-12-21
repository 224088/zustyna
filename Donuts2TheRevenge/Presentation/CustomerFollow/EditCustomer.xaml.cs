using Presentation.ViewModel;
using Presentation.ViewModel.AdditionalInterfaces;
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
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Logika interakcji dla klasy EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window, IWindow
    {

        private AddEditCustomerViewModel viewModel = new AddEditCustomerViewModel();

        public EditCustomer()
        {
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = this.viewModel; };
            viewModel.MessageBoxShowDelegate = text => MessageBox.Show(text, "Button interaction", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
