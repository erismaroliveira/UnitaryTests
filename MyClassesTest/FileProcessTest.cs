using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.bat";
        private string _GoodFileName;
        public TestContext TestContext { get; set; }

        #region Test Initialize e Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            if(TestContext.TestName == "FileNameDoesExists")
            {
                SetGoodFileName();
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Creating file: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Some Text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == "FileNameDoesExists")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting file: {_GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }

        #endregion

        [TestMethod]
        [Description("Check to see if a file does exist.")]
        [Owner("IsabellaV")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExists()
        {
            var fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing file: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);
            
            Assert.IsTrue(fromCall);
        }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];

            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [Owner("ErismarO")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistsUsingDeploymentItem()
        {
            var fp = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME}";

            TestContext.WriteLine($"Checking file: {fileName}");

            fromCall = fp.FileExists(fileName);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Timeout(3100)]
        public void SimulateTimeout()
        {
            System.Threading.Thread.Sleep(3000);
        }

        [TestMethod]
        [Description("Check to see if a file does NOT exist.")]
        [Owner("ErismarO")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExists()
        {
            var fp = new FileProcess();
            bool fromCall;
            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("ErismarO")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            var fp = new FileProcess();
            fp.FileExists("");
        }

        [TestMethod]
        [Owner("NatáliaN")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            var fp = new FileProcess();

            try
            {
                fp.FileExists("");
            }
            catch (Exception)
            {
                // The test was a success.
                return;
            }

            Assert.Fail("Fail expected");
        }
    }
}