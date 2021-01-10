
using Presentation.Model;
using Presentation.ViewModel.AdditionalInterfaces;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
   public class BuyDonutViewModel: BaseViewModel
    {

        public BuyDonutViewModel()
        {
            this.RefreshDonuts();
            this.RefreshCustomers();
            BuyDonutCommand = new ModelCommand(BuyDonut);
            RefreshDonutCommand = new ModelCommand(RefreshEverythink);
        }

        private void RefreshEverythink()
        {
            RefreshCustomers();
            RefreshDonuts();
        }

        private void BuyDonut()
        {
            bool ordered = false;
            if (this.currentDonut != null && this.currentCustomer != null)
               ordered= EventCRUD.BuyDonut(NewOrderID, currentDonut.donut_id, currentCustomer.customer_id, newQuantity);

            if(ordered)
            {
                actionText = "Donuts Ordered";
            }
            else
            {
                actionText = "Something went wrong upss";
            }
            MessageBoxShowDelegate(ActionText);
        }

        private void RefreshDonuts()
        {
            Task.Run(() => this.Donuts = GetDonutsModelsConverter());
            this.OnPropertyChanged("Donuts");
        }

        private IEnumerable<DonutModel> donuts;
        public IEnumerable<DonutModel> Donuts
        {
            get
            {
                return this.donuts;
            }

            set
            {
                this.donuts = value;
                this.OnPropertyChanged("Donuts");
            }
        }


        private void RefreshCustomers()
        {
            Task.Run(() => this.Customers = GetCustomersModelsConverter());
        }

        private IEnumerable<CustomerModel> customers;
        public IEnumerable<CustomerModel> Customers
        {
            get => customers;

            set
            {
                customers = value;
                OnPropertyChanged("Customers");
            }
        }

        /*Master detail - displays events for selected customer*/
        private CustomerModel currentCustomer;
        public CustomerModel CurrentCustomer
        {
            get
            {
                return currentCustomer;
            }

            set
            {
                currentCustomer = value;
                OnPropertyChanged("CurrentCustomer");
            }
        }

        private int newOrderID;
        public int NewOrderID
        {
            get
            {
                return newOrderID;
            }

            set
            {
                newOrderID = value;
                this.OnPropertyChanged("NewOrderID");
            }
        }

        private int newQuantity;
        public int NewQuantity
        {
            get
            {
                return newQuantity;
            }

            set
            {
                newQuantity = value;
                this.OnPropertyChanged("NewQuantity");
            }
        }

        private DonutModel currentDonut;
        public DonutModel CurrentDonut
        {
            get
            {
                return currentDonut;
            }
            set
            {
                currentDonut = value;
                this.OnPropertyChanged("CurrentDonut");

            }

        }

        public ModelCommand RefreshDonutCommand

        {
            get; private set;
        }
        public ModelCommand BuyDonutCommand

        {
            get; private set;
        }

        private string actionText;
        public string ActionText
        {
            get
            {
                return this.actionText;
            }
            set
            {
                this.actionText = value;
                OnPropertyChanged("ActionText");
            }
        }

        public ModelCommand DisplayPopUpCommand { get; private set; }

        public Action<string> MessageBoxShowDelegate { get; set; } = x => throw new ArgumentOutOfRangeException($"The delegate {nameof(MessageBoxShowDelegate)} must be assigned by the view layer");

        public IEnumerable<DonutModel> GetDonutsModelsConverter()
        {
            List<Dictionary<string, string>> retrived = donutCRUD.GetDonutsInfo();
            List<DonutModel> temp = new List<DonutModel>();

            foreach (Dictionary<string, string> dict in retrived)
            {
                DonutModel t = new DonutModel();
                t.Converter(dict);
                temp.Add(t);
            }
            return temp;
        }
        public IEnumerable<CustomerModel> GetCustomersModelsConverter()
        {
            List<Dictionary<string, string>> retrived = CustomerCRUD.GetCustomersInfo();
            List<CustomerModel> temp = new List<CustomerModel>();

            foreach (Dictionary<string, string> dict in retrived)
            {
                CustomerModel t = new CustomerModel();
                t.Converter(dict);
                temp.Add(t);
            }
            return temp;
        }


    }
   
}
