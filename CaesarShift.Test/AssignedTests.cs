namespace CaesarShift.Test
{
    [TestClass]
    public class AssignedTests
    {
        [TestMethod]
        public void AssignedTestCase_Simple()
        {
            var caesar = new CaesarShift(-3, CharacterSet.LatinAlphabetLower);

            Assert.AreEqual(
                "xyzabcdefghijklmnopqrstuvw",
                caesar.Encode("abcdefghijklmnopqrstuvwxyz"));
        }

        [TestMethod]
        public void AssignedTestCase_Advanced()
        {
            var caesar = new CaesarShift(28, CharacterSet.LatinAlphabetLower);

            Assert.AreEqual(
                "cdefghijklmnopqrstuvwxyzab",
                caesar.Encode("abcdefghijklmnopqrstuvwxyz"));
        }
    }
}