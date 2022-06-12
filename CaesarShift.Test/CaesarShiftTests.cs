namespace CaesarShift.Test
{
    [TestClass]
    public class CaesarShiftTests
    {
        [TestMethod]
        public void Default_Constructor_AllowUnknownChars_LatinAlphabet()
        {
            var caesar = new CaesarShift(1);

            Assert.AreEqual(caesar.ShiftDistance, 1);
            Assert.IsTrue(caesar.AllowUnknownCharacters);
            Assert.AreEqual(caesar.Cipher, CharacterSet.LatinAlphabet);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroShift_Constructor_Exception()
        {
            new CaesarShift(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroShift_Set_Exception()
        {
            var caesar = new CaesarShift(1);

            caesar.ShiftDistance = 0;
        }

        [TestMethod]
        public void Encode_PositiveShift()
        {
            var caesar = new CaesarShift(1);

            Assert.AreEqual("b", caesar.Encode("a"));
        }

        [TestMethod]
        public void Encode_NegativeShift()
        {
            var caesar = new CaesarShift(-1);

            Assert.AreEqual("Z", caesar.Encode("a"));
        }

        [TestMethod]
        public void Encode_LongPositiveShift()
        {
            var caesar = new CaesarShift(53);

            Assert.AreEqual("b", caesar.Encode("a"));
        }

        [TestMethod]
        public void Encode_LongNegativeShift()
        {
            var caesar = new CaesarShift(-53);

            Assert.AreEqual("Z", caesar.Encode("a"));
        }

        [TestMethod]
        public void Decode_PositiveShift()
        {
            var caesar = new CaesarShift(1);

            Assert.AreEqual("a", caesar.Decode("b"));
        }

        [TestMethod]
        public void Decode_NegativeShift()
        {
            var caesar = new CaesarShift(-1);

            Assert.AreEqual("a", caesar.Decode("Z"));
        }

        [TestMethod]
        public void Decode_LongPositiveShift()
        {
            var caesar = new CaesarShift(53);

            Assert.AreEqual("a", caesar.Decode("b"));
        }

        [TestMethod]
        public void Decode_LongNegativeShift()
        {
            var caesar = new CaesarShift(-53);

            Assert.AreEqual("a", caesar.Decode("Z"));
        }

        [TestMethod]
        public void Encode_AllowUnknownChar_IgnoresUnkownChar()
        {
            var caesar = new CaesarShift(1)
            {
                AllowUnknownCharacters = true
            };

            Assert.AreEqual("b b", caesar.Encode("a a"));
        }

        [TestMethod]
        public void Decode_AllowUnknownChar_IgnoresUnkownChar()
        {
            var caesar = new CaesarShift(1)
            {
                AllowUnknownCharacters = true
            };

            Assert.AreEqual("a a", caesar.Decode("b b"));
        }

        [TestMethod]
        public void Encode_DisallowUnknownChar_OnlyKnownChars()
        {
            var caesar = new CaesarShift(1)
            {
                AllowUnknownCharacters = false
            };

            Assert.AreEqual("bb", caesar.Encode("aa"));
        }

        [TestMethod]
        [ExpectedException(typeof(UnknownCharacterException))]
        public void Encode_DisallowUnknownChar_UnknownChar_Exception()
        {
            var caesar = new CaesarShift(1)
            {
                AllowUnknownCharacters = false
            };

            Assert.AreEqual("b b", caesar.Encode("a a"));
        }

        [TestMethod]
        public void Decode_DisallowUnknownChar_OnlyKnownChars()
        {
            var caesar = new CaesarShift(1)
            {
                AllowUnknownCharacters = false
            };

            Assert.AreEqual("aa", caesar.Decode("bb"));
        }

        [TestMethod]
        [ExpectedException(typeof(UnknownCharacterException))]
        public void Decode_DisallowUnknownChar_UnknownChar_Exception()
        {
            var caesar = new CaesarShift(1)
            {
                AllowUnknownCharacters = false
            };

            Assert.AreEqual("a a", caesar.Decode("b b"));
        }

        [TestMethod]
        public void Encode_LatinAlphabet_IgnoresNumbers()
        {
            var caesar = new CaesarShift(1);

            Assert.AreEqual("Ovncfs 90", caesar.Encode("Number 90"));
        }

        [TestMethod]
        public void Decode_LatinAlphabet_IgnoresNumbers()
        {
            var caesar = new CaesarShift(1);

            Assert.AreEqual("Number 90", caesar.Decode("Ovncfs 90"));
        }

        [TestMethod]
        public void Encode_Alphanumeric_EncodesNumbers()
        {
            var caesar = new CaesarShift(1, CharacterSet.AlphaNumeric);

            Assert.AreEqual("Ovncfs a1", caesar.Encode("Number 90"));
        }

        [TestMethod]
        public void Decode_Alphanumeric_DecodesNumbers()
        {
            var caesar = new CaesarShift(1, CharacterSet.AlphaNumeric);

            Assert.AreEqual("Number 90", caesar.Decode("Ovncfs a1"));
        }

        [TestMethod]
        public void EncodePangram()
        {
            var caesar = new CaesarShift(99, CharacterSet.Extended);

            Assert.AreEqual(
                "EduymgodfvsArdjsBdnyqtwdszivdxlidpeDCdhsk>",
                caesar.Encode("A quick brown fox jumps over the lazy dog."));
        }

        [TestMethod]
        public void DecodePangram()
        {
            var caesar = new CaesarShift(99, CharacterSet.Extended);

            Assert.AreEqual(
                "A quick brown fox jumps over the lazy dog.",
                caesar.Decode("EduymgodfvsArdjsBdnyqtwdszivdxlidpeDCdhsk>"));
        }
    }
}
