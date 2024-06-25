using CSharpTAF.WrapperFunctions;
using NUnit.Framework;

namespace CSharpTAF.Scripts.UITDDScripts
{
    [SetUpFixture]
    public class SetUpClass
    {
        [OneTimeSetUp]
        public void oneTimeSetup()
        {
            ExtentHelper extentHelper = new ExtentHelper();
            Pojo.setExtentHelper(extentHelper);
            Pojo.getExtentHelper().InitializeReport();
        }
        [OneTimeTearDown]
        public void oneTimeTearDown()
        {
            Pojo.getExtentHelper().TearDownReport();
 
        }
    }
}
