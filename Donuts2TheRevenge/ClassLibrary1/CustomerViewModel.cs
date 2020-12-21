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

    public class CustomerViewModel : BaseViewModel
    {


        //private donutCRUD DonutService = new donutCRUD() ;
        //private CustomerCRUD customerService;
       // private EventCRUD eventService;
        //private donutCRUD donutService;

        public CustomerViewModel()
        {
            
            AddCustomerCommand = new ModelCommand( AddCustomer);
            EditCustomerCommand = new ModelCommand(EditCustomer);
            DeleteCustomerCommand = new ModelCommand(DeleteCustomer);
            RefreshCustomerCommand = new ModelCommand(RefreshCustomers);
            RefreshCustomers();
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
        private static customer currentCustomer;
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
                this.RefreshEvents();
            }
        }

        private IEnumerable<@event> events;
        public IEnumerable<@event> Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
                OnPropertyChanged("Events");
            }
        }
        private void RefreshEvents()

        {
            if(this.CurrentCustomer != null)
                Task.Run(() => this.Events = EventCRUD.GetEventsByCustomerName(CurrentCustomer.customer_f_name, CurrentCustomer.customer_l_name));
     
        }

        /*Display book for selected event */
        private @event currentEvent;
        public @event CurrentEvent
        {
            get
            {
                return this.currentEvent;
            }
            set
            {
                this.currentEvent = value;
                OnPropertyChanged("CurrentEvent");
                this.RefreshDonut();
            }
        }

        private donut donut;
        public donut Donut
        {
            get
            {
                return this.donut;
            }
            set
            {
                this.donut = value;
                OnPropertyChanged("Donut");
            }
        }

        private void RefreshDonut()
        {
            // System.Diagnostics.Debug.WriteLine(CurrentEvent.donut);
            if (currentEvent != null)
            {
                Task.Run(() => this.Donut = donutCRUD.GetDonut(CurrentEvent.donut));
            }
            else
            {
                this.Donut = null;
            }
        }

        /*ICommand */
        // public CommandBase AddCustomer { get; private set; }

        public ModelCommand AddCustomerCommand

        {
            get; private set;
        }

        public ModelCommand EditCustomerCommand

        {
            get; private set;
        }


        public ModelCommand RefreshCustomerCommand

        {
            get; private set;
        }

        public ModelCommand DeleteCustomerCommand

        {
            get; private set;
        }  


        public Lazy<IWindow> NewWindow { get; set; }


        public Lazy<IWindow> EditWindow { get; set; }

        private void AddCustomer()
        {
            IWindow newWindow = NewWindow.Value;
            newWindow.Show();
        }

        private void EditCustomer()
        {
            IWindow editWindow = EditWindow.Value;
            editWindow.Show();
        }




        private void DeleteCustomer()
        {
            CustomerCRUD.deleteCustomer(CurrentCustomer.customer_id);
            RefreshCustomers();
        }

        public static customer RetriveCustomer()
        {
            return currentCustomer;
        }


    }
}
