
using static DataLayer.IDataRepository;
using System;
using System.Collections.Generic;
using System.Text;



namespace LogicLayer
{

    public class DataService
    {

        private DataLayer.IDataRepository repository;

        public DataService(DataLayer.IDataRepository repository)
        {
            this.repository = repository;
        }


    }
}
