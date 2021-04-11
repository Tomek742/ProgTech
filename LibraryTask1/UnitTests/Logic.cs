using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic;

namespace UnitTests
{
    [TestClass]
    public class Logic
    {
        [TestMethod]
        public void LibraryManagerConstructor()
        {
            LibraryManager library = new LibraryManager(null);
            Assert.AreEqual(library.manager, null);

        }
        
    }
}
