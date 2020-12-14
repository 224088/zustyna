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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Logika interakcji dla klasy Customer.xaml
    /// </summary>
    public partial class Customer : UserControl
    {
        private CustomerViewModel CustomerViewModel = new CustomerViewModel();
        public Customer()
        {
            InitializeComponent();
            this.Loaded += (s, e) => { this.DataContext = this.CustomerViewModel; };
            //CustomerViewModel.ChildWindow = new Lazy<IWindow>(() => new AddCustomer());
        }
    }
}
