using System.Text;

namespace CaesarShift
{
    public class CaesarShift
    {
        private int shiftDistanceValue;

        public CharacterSet Cipher { get; set; } = CharacterSet.LatinAlphabet;
        public bool AllowUnknownCharacters { get; set; } = true;
        public int ShiftDistance
        { 
            get => shiftDistanceValue; 
            set
            {
                if (value == 0)
                    throw new ArgumentException($"{nameof(CaesarShift)} cannot have 0 as {nameof(ShiftDistance)} value.");
                shiftDistanceValue = value; 
            }
        }

        public CaesarShift(int shiftDistance)
        {
            ShiftDistance = shiftDistance;
        }

        public CaesarShift(int shiftDistance, CharacterSet cipher)
        {
            ShiftDistance = shiftDistance;
            Cipher = cipher;
        }

        public string Encode(string input)
        {
            return InterpretString(input, ShiftCharacter);
        }

        public string Decode(string input)
        {
            return InterpretString(input, UnshiftCharacter);
        }

        private char ShiftCharacter(char input)
        {
            return InterpretChar(input, ShiftIndex);
        }

        private char UnshiftCharacter(char input)
        {
            return InterpretChar(input, UnshiftIndex);
        }

        private int ShiftIndex(int index)
        {
            return InterpretIndex(index, (i, j) => i + j);
        }

        private int UnshiftIndex(int index)
        {
            return InterpretIndex(index, (i, j) => i - j);
        }

        private string InterpretString(string input, Func<char, char> interpreter)
        {
            return input
                .Select(interpreter)
                .Aggregate(
                    new StringBuilder(input.Length),
                    (builder, c) => builder.Append(c))
                .ToString();
        }

        private char InterpretChar(char input, Func<int, int> interpreter)
        {
            if (Cipher.IsKnown(input))
                return InterpretKnownChar(input, interpreter);
            else
                return InterpretUnknownChar(input);
        }

        private char InterpretKnownChar(char input, Func<int, int> interpreter)
        {
            var index = Cipher.IndexOf(input);

            var interpretedIndex = interpreter(index);

            return Cipher.CharacterAt(interpretedIndex);
        }

        private char InterpretUnknownChar(char input)
        {
            if (AllowUnknownCharacters)
                return input;
            else
                throw new UnknownCharacterException($"Cannot interpret character '{input}' as it is unknown in the cipher.");
        }

        private int InterpretIndex(int index, Func<int, int, int> interpreter)
        {
            var result = interpreter(index, ShiftDistance) % Cipher.Length;

            if (result < 0)
                result += Cipher.Length;

            return result;
        }
    }
}