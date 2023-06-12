using StringExtention;

namespace StringExtentionTest
{
    [TestClass]
    public class StringTest
    {
        #region Method 1: Palindrome, Complexity 1 & 3
        [DataTestMethod]
        [DataRow("racecar")]
        [DataRow("Racecar")]
        [DataRow("Hannah")]
        [DataRow("han nah")]
        public void PalindromeTrue(string s)
        {
            Assert.IsTrue(s.IsPalindrome());
        }

        [DataTestMethod]
        [DataRow("boris")]
        [DataRow("doris")]
        public void PalindromeFalse(string s)
        {
            Assert.IsFalse(s.IsPalindrome());
        }


        [DataTestMethod]
        [DataRow("RacecaR")]
        [DataRow("Han naH")]
        public void PassCaseSensativePalindrome(string s)
        {
            //"true" switch turns on case sensativity
            Assert.IsTrue(s.IsPalindrome(true));
        }

        [DataTestMethod]
        [DataRow("Racecar")]
        [DataRow("Hannah")]
        public void FailCaseSensativePalindrome(string s)
        {
            //"true" switch turns on case sensativity
            Assert.IsFalse(s.IsPalindrome(true));
        }
        #endregion

        #region Method 2a: Reverse complexity:1
        [TestMethod]
        public void ReverseCaseInsensitiveTrue()
        {
            string s = "Rocky";
            Assert.AreEqual("ykcoR", s.Reverse());
        }

        [TestMethod]
        public void ReverseCaseInsensitiveFalse()
        {
            string s = "Rocky";
            Assert.AreNotEqual("Bullwinkle", s.Reverse());
        }
        #endregion

        #region Method 2b: Reverse w/overload, complexity:6
        [TestMethod]
        public void ReverseCaseSensativeTrue()
        {
            string s = "Bullwinkle";
            Assert.AreEqual("Elkniwllub", s.Reverse(true));
        }

        [TestMethod]
        public void ReverseCaseSensativeFalse()
        {
            string s = "Bullwinkle";
            Assert.AreNotEqual("elkniwlluB", s.Reverse(true));
        }
        #endregion

        #region Method 3: SearchPattern, Complexity 1 & 3
        #endregion

        #region Method 4: Remove Duplicates, Complexity: 3
        [TestMethod]
        public void RemoveDupSucess()
        {
            string s = "Hobgoblins";
            Assert.IsTrue(s.RemoveDuplicates() == "Hobglins");
        }

        [TestMethod]
        public void RemoveDupFail()
        {
            string s = "Hobgoblins";
            Assert.IsFalse(s.RemoveDuplicates() == s);
        }
        #endregion

        #region Method 5: Min/Max, Complexity: 11

        [TestMethod]
        public void MinMax()
        {
            string s = "boo";
            Assert.IsTrue(s.MinMax() == 0);
            //Assert.AreEqual(s.MinMax(), "b,1 o,2");
        }

        [TestMethod]
        public void MaxOccurance()
        {
            string s = "Hobgoblins";
            Assert.IsTrue(s.MinMax(SillyString.MinMaxType.MAX_OCCURANCE) == 2);
        }

        [TestMethod]
        public void MinOccurance()
        {
            string s = "Hobgoblins";
            Assert.IsTrue(s.MinMax(SillyString.MinMaxType.MIN_OCCURANCE) == 1);
        }

        [TestMethod]
        public void MinVowels()
        {
            string s = "Hobgoblins";
            Assert.IsTrue(s.MinMax(SillyString.MinMaxType.MIN_OCCURANCE_VOWELS) == 1);
        }
        [TestMethod]
        public void MaxVowels() {
            string s = "Hobgoblins";
            Assert.IsTrue(s.MinMax(SillyString.MinMaxType.MAX_OCCURANCE_VOWELS) == 2);
        }


        #endregion
    }
}
