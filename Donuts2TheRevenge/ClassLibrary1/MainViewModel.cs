using Data;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private donutCRUD DonutService = new donutCRUD() ;
        public MainViewModel()
        {
            this.RefreshDonuts();


        }

        private void RefreshDonuts()
        {
            Task.Run(() => this.Donuts =  DonutService.GetAllDonuts()); 
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
    }
}
