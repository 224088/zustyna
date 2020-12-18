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
    public class AddEditViewModel : BaseViewModel
    {
        //private donutCRUD DonutService = new donutCRUD();

        public AddEditViewModel()
        {
            AddDonutCommand = new ModelCommand(o => AddDonut());
            currentDonut = new donut();
        }

        public ModelCommand AddDonutCommand

        {
            get; private set;
        }

        public void AddDonut()
        {
           
            bool added = donutCRUD.addDonut(currentDonut.donut_id,currentDonut.quantity,currentDonut.donut_name,currentDonut.filling,currentDonut.price);
            if (added)
            {
                actionText = "Reader Added";
            }
            else
            {
                actionText = "Reader already exists in the database";
            }
            MessageBoxShowDelegate(ActionText);

        }

        private donut currentDonut;
        public donut CurrentDonut
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
