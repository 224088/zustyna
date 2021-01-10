
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
            Task.Run(() =>  this.Donuts = GetDonutsModelsConverter());
            this.OnPropertyChanged("Donuts");
        }

        private IEnumerable <DonutModel> donuts;
        public IEnumerable<DonutModel> Donuts
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


        private static DonutModel currentDonut; 
        public  DonutModel CurrentDonut
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

        public static DonutModel RetriveDonut()
        {
            return currentDonut;
        }

        public IEnumerable<DonutModel> GetDonutsModelsConverter()
        {
            List <Dictionary<string, string>> retrived = donutCRUD.GetDonutsInfo();
            List<DonutModel> temp = new List<DonutModel>();

            foreach(Dictionary<string,string> dict in retrived)
            {
                DonutModel t = new DonutModel();
                t.Converter(dict);
                temp.Add(t);
            }
            return temp;
        }


    }
}
