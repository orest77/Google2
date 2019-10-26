using NUnit.Framework;
using TheBestProject.Pages.Main;
using TheBestProject.Tools;

namespace TheBestProject.Tests
{
    public class GoogleTest : TestRunner
    {
        [TestCase("Java", "Java | Oracle")]
        public void SearchTest(string searchText, string expectedResult)
        {
            //Arrange
            MainPage mainPage = new MainPage();
            //Act
            string actualResult = mainPage.SetSearchBoxAndClickButton(searchText).GetTitleTextLink(expectedResult);
            //Assert
            Assert.AreEqual(expectedResult, actualResult, "Test Fail");
        }
    }
}
