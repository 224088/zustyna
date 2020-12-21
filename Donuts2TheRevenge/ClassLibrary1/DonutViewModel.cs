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
    
    public class DonutViewModel : BaseViewModel
    {
        

        //private donutCRUD DonutService = new donutCRUD() ;
        public DonutViewModel()
        {
            this.RefreshDonuts();
            AddDonutCommand = new ModelCommand(AddDonut);
            EditDonutCommand = new ModelCommand(EditDonut);
            DeleteDonutCommand = new ModelCommand(DeleteDonuts);
            RefreshDonutCommand = new ModelCommand(RefreshDonuts);
        }

        private void RefreshDonuts()
        {
            Task.Run(() => this.Donuts =  donutCRUD.GetAllDonuts());
            this.OnPropertyChanged("Donuts");
        }

        private IEnumerable <donut> donuts;
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


        private static donut currentDonut; 
        public  donut CurrentDonut
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

       

        public ModelCommand AddDonutCommand
        
          {
                get; private set;
        }
        public ModelCommand DeleteDonutCommand

        {
            get; private set;
        }


        public Lazy<IWindow> ChildWindow { get; set; }

        public Lazy<IWindow> EditWindow { get; set; }


        private void AddDonut()
        {
          

            IWindow _child = ChildWindow.Value;
            _child.Show();

        }



        private void EditDonut()
        {

            IWindow newWindow = EditWindow.Value;
            newWindow.Show();

        }

        private void DeleteDonuts()
        {
          donutCRUD.deleteDonut(CurrentDonut.donut_id);
            RefreshDonuts();
        }


        public ModelCommand RefreshDonutCommand

        {
            get; private set;
        }


        public ModelCommand EditDonutCommand

        {
            get; private set;
        }

        public static donut RetriveDonut()
        {
            return currentDonut;
        }


    }
}
