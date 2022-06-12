using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarShift
{
    public partial class CharacterSet
    {
        private readonly char[] characters;

        public int Length => characters.Length;

        private CharacterSet(params char[] chars)
        {
            if (chars.Distinct().Count() != chars.Length)
                throw new ArgumentException($"All chars in a {nameof(CharacterSet)} must be unique.");
            characters = chars;
        }

        public bool IsKnown(char c)
        {
            return characters.Contains(c);
        }

        public int IndexOf(char c)
        {
            if (IsKnown(c))
                return Array.IndexOf(characters, c);
            else
                throw new UnknownCharacterException($"Character '{c}' was not found in this {nameof(CharacterSet)}");
        }

        public char CharacterAt(int index)
        {
            if (index < 0 || index >= characters.Length)
                throw new ArgumentOutOfRangeException(nameof(index), $"Index '{index}' was out of range of this {nameof(CharacterSet)}");

            return characters[index];
        }
    }
}
