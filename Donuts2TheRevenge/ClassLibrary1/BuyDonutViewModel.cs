using Data;
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
               ordered= EventCRUD.BuyDonut(NewOrderID, currentDonut, currentCustomer, newQuantity);

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
            Task.Run(() => this.Donuts = donutCRUD.GetAllDonuts());
            this.OnPropertyChanged("Donuts");
        }

        private IEnumerable<donut> donuts;
        public IEnumerable<donut> Donuts
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
            Task.Run(() => this.Customers = CustomerCRUD.GetAllCustomers());
        }

        private IEnumerable<customer> customers;
        public IEnumerable<customer> Customers
        {
            get => customers;

            set
            {
                customers = value;
                OnPropertyChanged("Customers");
            }
        }

        /*Master detail - displays events for selected customer*/
        private customer currentCustomer;
        public customer CurrentCustomer
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

        private donut currentDonut;
        public donut CurrentDonut
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
    }
}
