using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data.API;
using Data.DataFiles;
using Service.API;
using Service.DataFiles;

namespace UnitTests.Service
{
    [TestClass]
    public class ReaderTests
    {
        public IDataManager manager;
        public IReaderService service;

        [TestInitialize]
        public void Initialize()
        {
            manager = new DataManager();
            service = new ReaderService(manager);
        }

        [TestMethod]
        public void AddReaderToDatabaseTest()
        {
            Assert.IsTrue(service.AddReader(1, "Mariusz Pudzianowski"));
            Assert.AreEqual(service.GetReader(1).Name, "Mariusz Pudzianowski");
            Assert.AreEqual(service.GetReader(1).ReaderID, 1);

            Assert.IsTrue(service.DeleteReader(service.GetReader(1).ReaderID));
        }

        [TestMethod]
        public void UpdateReaderTest()
        {
            Assert.IsTrue(service.AddReader(1, "Jarosław Psikutas"));
            Assert.IsTrue(service.UpdateReader(service.GetReader(1).ReaderID, "Jarosław Psikuta"));

            Assert.AreEqual(service.GetReader(1).Name, "Jarosław Psikuta");
            Assert.AreEqual(service.GetReader(1).ReaderID, 1);

            Assert.IsTrue(service.DeleteReader(service.GetReader(1).ReaderID));
        }

        [TestMethod]
        public void AddSameReaderTest()
        {
            Assert.IsTrue(service.AddReader(1, "Marcin Majkut"));
            Assert.IsFalse(service.AddReader(1, "Marcin Majkut"));

            Assert.IsTrue(service.DeleteReader(service.GetReader(1).ReaderID));
        }
    }
}
