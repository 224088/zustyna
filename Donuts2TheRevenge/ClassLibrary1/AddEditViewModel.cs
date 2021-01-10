
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
    public class AddEditViewModel : BaseViewModel
    {
        //private donutCRUD DonutService = new donutCRUD();

        public AddEditViewModel()
        {
            AddDonutCommand = new ModelCommand(AddDonut);
            EditDonutCommand = new ModelCommand(EditDonut);
            currentDonut = DonutViewModel.RetriveDonut();
            NewDonut = new DonutModel();
                //new donut();
        }

        public ModelCommand AddDonutCommand

        {
            get; private set;
        }
        public ModelCommand EditDonutCommand

        {
            get; private set;
        }

        public void AddDonut()
        {
           
            bool added = donutCRUD.addDonut(newDonut.donut_id,newDonut.quantity,newDonut.donut_name,newDonut.filling,newDonut.price);
            if (added) { 
            
                actionText = "Donut Added";
            }
            else
            {
                actionText = "Donut with such ID already exists in the database";
            }
            MessageBoxShowDelegate(ActionText);

        }

        public void EditDonut()
        {

            bool editedN = donutCRUD.updateName(currentDonut.donut_id, currentDonut.donut_name);
            bool editedF = donutCRUD.updateFilling(currentDonut.donut_id, currentDonut.filling);
            bool editedP = donutCRUD.updatePrice(currentDonut.donut_id, currentDonut.price);
            bool editedQ = donutCRUD.updateQuantity(currentDonut.donut_id, currentDonut.quantity);

            if (editedN && editedF && editedP && editedQ)
            {
                actionText = "Donut Edited";
            }
            else
            {
                actionText = "Donut with such ID already exists in the database";
            }
            MessageBoxShowDelegate(ActionText);

        }

        private DonutModel currentDonut;
        public DonutModel CurrentDonut
        {
            get
            {
                return this.currentDonut;
            }
            set
            {
                this.currentDonut = value;
                this.OnPropertyChanged("CurrentDonut");
               
            }

        }

        private DonutModel newDonut;
        public DonutModel NewDonut
        {
            get
            {
                return this.newDonut;
            }
            set
            {
                this.newDonut = value;
                this.OnPropertyChanged("NewDonut");

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
