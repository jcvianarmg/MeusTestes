using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses;
using System;
using System.Configuration;
using System.IO;

namespace MyClassesTest
{
    [TestClass]
    public class FileProcessTeste
    {

        private const string BAD_FILE_NAME = @"C:\BadFileName.bat";
        private string _GoodFileName;

        public TestContext TestContext { get; set; }

        #region Test Initialize e Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            SetGoodFilename();
            if (TestContext.TestName.StartsWith("FileNameDoesExists") & (!string.IsNullOrEmpty(_GoodFileName)))
            {
                   TestContext.WriteLine($"Creating File: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Some Text");
             }
        }
       
        [TestCleanup]
        public void TestCleanup()
        {
            if ( TestContext.TestName.StartsWith("FileNameDoesExists") & (!string.IsNullOrEmpty(_GoodFileName)) )
            {
                TestContext.WriteLine($"Deleting File: {_GoodFileName}");
                    File.Delete(_GoodFileName);
            }
        }
        #endregion

        [TestMethod]
        [Description("Verificar se o arquivo existe.")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesExists()
        {   FileProcess fp = new FileProcess();
            bool fromCall; 
            TestContext.WriteLine($"Testing File: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);
            Assert.IsTrue(fromCall);
        }
        [TestMethod]
        [Owner("Jcviana")]
        [DataSource("System.Data.SqlClient",
            @"Data Source=DESKTOP-PB1TQU7\SQLEXPRESS;Initial Catalog=TesteUnitario;Integrated Security=True", 
            "FileProcessTest",
            DataAccessMethod.Sequential)]
        public void FileExistsTestFromDB()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool expectedValue;
            bool causesException;
            bool fromCall;

            fileName = TestContext.DataRow["Filename"].ToString();
            expectedValue = Convert.ToBoolean(TestContext.DataRow["ExpectedValue"]);
            causesException = Convert.ToBoolean(TestContext.DataRow["CausesException"]);

            try
            {
                fromCall = fp.FileExists(fileName);
                Assert.AreEqual(expectedValue, fromCall, $"File: {fileName} has failed. METHOD: FileExistsTestFromDB");

            }
            catch (Exception)
            {

                Assert.IsTrue(causesException);
            }
        }

        [TestMethod]
        public void FileNameDoesExistsSimpleMessage()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing File: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);
     
            Assert.IsTrue(fromCall, "File Does  Exist.");
        }
        [TestMethod]
        public void FileNameDoesExistsMessageFormatting()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing File: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);

            Assert.IsTrue(fromCall, "File '{0}' Does NOT Exist.", _GoodFileName);
        }

        public void SetGoodFilename()
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
        [Owner("josé Claudio")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistsUsingDepoymentItem()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            string filename = $@"{TestContext.DeploymentDirectory}/{FILE_NAME}";

            TestContext.WriteLine($"Checking File: {filename}");

            fromCall = fp.FileExists(filename);

            Assert.IsTrue(fromCall);
        }

        [TestMethod]
        [Description("Verificar se o arquivo não existe.")]
        [Owner("josé Claudio")]
        [Priority(0)]
        [TestCategory("NoException")]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);
            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Owner("josé Claudio N")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {

            FileProcess fp = new FileProcess();
            fp.FileExists("");
        }

        [TestMethod]
        [Owner("josé claudio 3")]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullExceptionUsingTryCatch()
        {
            FileProcess fp = new FileProcess();
            try
            {
                fp.FileExists("");
            }
            catch (ArgumentException)
            {
                return;
            }
            Assert.Fail("fail exepected");
        }
    }
}
