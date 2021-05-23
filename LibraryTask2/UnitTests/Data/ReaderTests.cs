using Data.API;
using Data.DataFiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Data
{
    [TestClass]
    public class ReaderTests
    {
        public IDataManager manager;

        [TestInitialize]
        public void Initialize()
        {
            manager = new DataManager();
        }

        [TestMethod]
        public void AddReaderToDatabaseTest()
        {
            Assert.IsTrue(manager.AddReader(1, "Norman Parke"));
            Assert.AreEqual(manager.GetReader(1).Name, "Norman Parke");
            Assert.AreEqual(manager.GetReader(1).ReaderID, 1);

            Assert.IsTrue(manager.DeleteReader(manager.GetReader(1).ReaderID));
        }

        [TestMethod]
        public void UpdateReaderTest()
        {
            Assert.IsTrue(manager.AddReader(1, "Don Kasjo"));
            Assert.IsTrue(manager.UpdateReader(manager.GetReader(1).ReaderID, "Michal Baron"));

            Assert.AreEqual(manager.GetReader(1).Name, "Michal Baron");
            Assert.AreEqual(manager.GetReader(1).ReaderID, 1);

            Assert.IsTrue(manager.DeleteReader(manager.GetReader(1).ReaderID));
        }

        [TestMethod]
        public void AddSameReaderTest()
        {
            Assert.IsTrue(manager.AddReader(1, "Gabriel Arab"));
            Assert.IsFalse(manager.AddReader(1, "Gabriel Arab"));

            Assert.IsTrue(manager.DeleteReader(manager.GetReader(1).ReaderID));
        }
    }
}
