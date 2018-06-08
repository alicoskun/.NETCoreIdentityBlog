using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreIdentity.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(12, 5, 2018)]
        public void Alias (int day, int month, int year)
        {
            string filename = "unittest";
            string url = "https://alicoskun.github.io";
            string actualPath = System.IO.Path.Combine(url, $"{filename}{year:0000}{month:00}{day:00}.txt");

            string expectedPath = "https://alicoskun.github.io\\unittest20180512.txt";

            Assert.AreEqual(actualPath, expectedPath);
        }
    }
}
