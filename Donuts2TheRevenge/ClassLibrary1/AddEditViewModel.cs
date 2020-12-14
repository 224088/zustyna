using Data;
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
        private donutCRUD DonutService = new donutCRUD();

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
           
            System.Diagnostics.Debug.WriteLine(CurrentDonut.donut_name);
            System.Diagnostics.Debug.WriteLine(CurrentDonut.filling);


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
    }
    }
