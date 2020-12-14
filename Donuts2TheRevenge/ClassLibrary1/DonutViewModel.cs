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
            AddDonutCommand = new ModelCommand(o=>AddDonut() );
        }

        private void RefreshDonuts()
        {
            Task.Run(() => this.Donuts =  donutCRUD.GetAllDonuts()); 
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
               // this.RefreshInfoDonut();

            }

        }

        private void RefreshInfoDonut()
        {
            throw new NotImplementedException();
        }


        public ModelCommand AddDonutCommand
        
          {
                get; private set;
        }


        public Lazy<IWindow> ChildWindow { get; set; }
        private void AddDonut()
        {
            System.Diagnostics.Debug.WriteLine("This is a log");

            IWindow _child = ChildWindow.Value;
            _child.Show();

        }

       


       
    }
}
