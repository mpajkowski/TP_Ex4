using Microsoft.VisualStudio.TestTools.UnitTesting;
using app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appTests.Model;
using app.Model;

namespace app.ViewModel.Tests
{
    public class DummyDialogService : IDialogService
    {
        public void Show(string text)
        {
            Console.WriteLine(text);
        }
    }

    [TestClass()]
    public class MainViewModelTests
    {
        [TestMethod()]
        public void TestDeleteClientAndDog()
        {
            DataHandlerMock dataHandlerMock = new DataHandlerMock();
            MainViewModel mvm = new MainViewModel();
            mvm.InjectDialogService(new DummyDialogService());
            mvm.InjectDataHandler(dataHandlerMock);
            mvm.PopulateClientData();
            mvm.PopulateDogData();

            mvm.CurrentClient = mvm.Clients.Last();
            mvm.DeleteCurrentClient();

            mvm.CurrentDog = mvm.Dogs.Last();
            mvm.DeleteCurrentDog();

            Assert.AreEqual(1, dataHandlerMock.DeleteClientHits);
            Assert.AreEqual(1, dataHandlerMock.DeleteDogHits);
        }

        [TestMethod()]
        public void TestCannotDeleteReferencedClient()
        {
            DataHandlerMock dataHandlerMock = new DataHandlerMock();
            MainViewModel mvm = new MainViewModel();
            mvm.InjectDialogService(new DummyDialogService());
            mvm.InjectDataHandler(dataHandlerMock);
            mvm.PopulateClientData();
            mvm.PopulateDogData();

            mvm.CurrentClient = mvm.Clients.First();
            mvm.DeleteCurrentClient();

            Assert.AreEqual(0, dataHandlerMock.DeleteClientHits);
        }

        [TestMethod()]
        public void TestUpdateExpectedCalls()
        {
            DataHandlerMock dataHandlerMock = new DataHandlerMock();
            MainViewModel mvm = new MainViewModel();
            mvm.InjectDialogService(new DummyDialogService());
            mvm.InjectDataHandler(dataHandlerMock);
            mvm.PopulateClientData();
            mvm.PopulateDogData();

            mvm.CurrentClient = mvm.Clients.First();
            mvm.UpdateCurrentClient();

            mvm.CurrentDog = mvm.Dogs.Last();
            mvm.UpdateCurrentDog();

            Assert.AreEqual(1, dataHandlerMock.UpdateDogDataHits);
            Assert.AreEqual(1, dataHandlerMock.UpdateClientDataHits);
        }
    }
}