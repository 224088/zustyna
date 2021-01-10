
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

    public class CustomerViewModel : BaseViewModel
    {



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

        private static CustomerModel currentCustomer;
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
                this.RefreshEvents();
            }
        }

        private IEnumerable<EventModel> events;
        public IEnumerable<EventModel> Events
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
                Task.Run(() => this.Events = GetEventsforCustomerModelsConverter(CurrentCustomer.customer_f_name, CurrentCustomer.customer_l_name));
     
        }

        /*Display book for selected event */
        private EventModel currentEvent;
        public EventModel CurrentEvent
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

        private DonutModel donut;
        public DonutModel Donut
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
                Task.Run(() => this.Donut = GetDonutModel(CurrentEvent.donut));
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

        public static CustomerModel RetriveCustomer()
        {
            return currentCustomer;
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

        public IEnumerable<EventModel> GetEventsforCustomerModelsConverter(string f_name,string l_name)
        {
            List<Dictionary<string, string>> retrived = EventCRUD.GetEventsInfoforCustomer(f_name,l_name);
            List<EventModel> temp = new List<EventModel>();

            foreach (Dictionary<string, string> dict in retrived)
            {
                EventModel t = new EventModel();
                t.Converter(dict);
                temp.Add(t);
            }
            return temp;
        }

        public DonutModel GetDonutModel(int donut_id)
        {
            DonutModel temp = new DonutModel();
            temp.Converter(donutCRUD.GetDonutInfo(donut_id));
            return temp;

        }
    }
}
