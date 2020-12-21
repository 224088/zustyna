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
    public class AddEditCustomerViewModel : BaseViewModel
    {
            //private donutCRUD DonutService = new donutCRUD();

            public AddEditCustomerViewModel()
            {
                AddCustomerCommand = new ModelCommand(AddCustomer);
                EditCustomerCommand = new ModelCommand(EditCustomer);
                currentCustomer = CustomerViewModel.RetriveCustomer();
                newCustomer = new customer();
            
        }

            public ModelCommand AddCustomerCommand

            {
                get; private set;
            }
            public ModelCommand EditCustomerCommand

            {
                get; private set;
            }

            public void AddCustomer()
            {

                bool added = CustomerCRUD.addCustomer(newCustomer.customer_id, newCustomer.customer_f_name, newCustomer.customer_l_name);
                if (added)
                {

                    actionText = "Customer Added";
                }
                else
                {
                    actionText = "Customer with such ID already exists in the database";
                }
                MessageBoxShowDelegate(ActionText);

            }

            public void EditCustomer()
            {

                bool editedN = CustomerCRUD.updateName(currentCustomer.customer_id, currentCustomer.customer_f_name);
            bool editedF = CustomerCRUD.updateLastName(currentCustomer.customer_id, currentCustomer.customer_l_name);

                if (editedN && editedF)
                {
                    actionText = "Customer Edited";
                }
                else
                {
                    actionText = "Oh nooo something went wrong";
                }
                MessageBoxShowDelegate(ActionText);

            }

            private customer currentCustomer;
            public customer CurrentCustomer
            {
                get
                {
              
                return this.currentCustomer;
                }
                set
                {
                    this.currentCustomer = value;
                    this.OnPropertyChanged("CurrentCustomer");

                }

            }

            private customer newCustomer;
            public customer NewCustomer
            {
                get
                {
                    return this.newCustomer;
                }
                set
                {
                    this.newCustomer = value;
                    this.OnPropertyChanged("NewCustomer");

                }

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

