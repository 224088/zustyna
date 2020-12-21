using System;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModel;

namespace PresentationTest
{
    [TestClass]
    public class CustomerModelTest
    {
        [TestMethod]
        public void CreatorTestMethodListView()
        {
            CustomerViewModel vm = new CustomerViewModel();
            Assert.IsNull(vm.Customers);
            Assert.IsNull(vm.Events);
            Assert.IsNull(vm.CurrentEvent);
            Assert.IsNull(vm.CurrentCustomer);
            Assert.IsNotNull(vm.AddCustomerCommand);
            Assert.IsNotNull(vm.EditCustomerCommand);
            Assert.IsNotNull(vm.RefreshCustomerCommand);
            Assert.IsNotNull(vm.DeleteCustomerCommand);

            Assert.IsTrue(vm.AddCustomerCommand.CanExecute(null));
            Assert.IsTrue(vm.EditCustomerCommand.CanExecute(null));
            Assert.IsTrue(vm.RefreshCustomerCommand.CanExecute(null));
            Assert.IsTrue(vm.DeleteCustomerCommand.CanExecute(null));
        }

        [TestMethod]
        public void CreatorTestMethodAddEditView()
        {
            AddEditCustomerViewModel vm = new AddEditCustomerViewModel();
            Assert.IsNull(vm.CurrentCustomer);
            Assert.IsTrue(String.IsNullOrEmpty(vm.ActionText));
            Assert.IsNotNull(vm.MessageBoxShowDelegate);

            Assert.IsNotNull(vm.AddCustomerCommand);
            Assert.IsNotNull(vm.EditCustomerCommand);

            Assert.IsTrue(vm.AddCustomerCommand.CanExecute(null));
            Assert.IsTrue(vm.EditCustomerCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddReaderPopUpWasShownTest()
        {
            CustomerViewModel vm = new CustomerViewModel();

            vm.CurrentCustomer= new Data.customer();

            vm.CurrentCustomer.customer_id = 0;
            vm.CurrentCustomer.customer_f_name = "Test";
            vm.CurrentCustomer.customer_l_name = "Test";

            AddEditCustomerViewModel evm = new AddEditCustomerViewModel();

            int _boxShowCount = 0;
            evm.MessageBoxShowDelegate = (messageBoxText) =>
            {
                _boxShowCount++;
                Assert.AreEqual("Customer Added", messageBoxText);
            };

            evm.ActionText = "Customer Added";
         

            Assert.IsTrue(vm.AddCustomerCommand.CanExecute(null));
            Assert.IsTrue(vm.RefreshCustomerCommand.CanExecute(null));
            Assert.IsTrue(vm.DeleteCustomerCommand.CanExecute(null));

            evm.AddCustomerCommand.Execute(null);
            Assert.AreEqual(1, _boxShowCount);

            vm.RefreshCustomerCommand.Execute(null);

            Thread.Sleep(3000);
            Assert.IsTrue(vm.Customers.Count() > 4);

            vm.CurrentCustomer = vm.Customers.FirstOrDefault();
            Assert.IsNotNull(vm.CurrentCustomer);

            vm.DeleteCustomerCommand.Execute(null);
        }



        [TestMethod]
        public void RefreshCustomers()
        {
            CustomerViewModel vm = new CustomerViewModel();

            //view loads readers after 3s
            Thread.Sleep(3000);
            Assert.IsTrue(vm.Customers.Count() > 0);
        }


        [TestMethod]
        public void RefreshEventsCurrentCustomer()
        {
            CustomerViewModel vm = new CustomerViewModel();

            Thread.Sleep(3000);

            var eventRefreshEventRaised = false;
            vm.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Events")
                {
                    eventRefreshEventRaised = true;
                }
            };

            vm.CurrentCustomer = vm.Customers.Skip(1).First();
            Assert.IsNotNull(vm.CurrentCustomer);

            Thread.Sleep(3000);
            Assert.IsTrue(eventRefreshEventRaised);
        }
    }
}
