using HomeCloudWindows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeCloudWindowsTest
{
    [TestClass]
    public class InMemoryConfigTest
    {
        [TestMethod]
        public void TestReg()
        {
            const int PORT = 1111;
            const string SYNC_FOLDER = @"c:\Sync";
            const string PASSWORD = "password";

            InMemoryConfig.Instance._port = PORT;
            InMemoryConfig.Instance._syncFolder = SYNC_FOLDER;
            InMemoryConfig.Instance._password = PASSWORD;

            InMemoryConfig.Instance.SaveRegKey();

            InMemoryConfig.Instance._port = 0;
            InMemoryConfig.Instance._syncFolder = string.Empty;
            InMemoryConfig.Instance._password = string.Empty;

            InMemoryConfig.Instance.LoadRegKey();

            Assert.AreEqual(InMemoryConfig.Instance._port, PORT);
            Assert.AreEqual(InMemoryConfig.Instance._syncFolder, SYNC_FOLDER);
            Assert.AreEqual(InMemoryConfig.Instance._password, PASSWORD);

            InMemoryConfig.Instance.DeleteRegKey();
        }
    }
}
