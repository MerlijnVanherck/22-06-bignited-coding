using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarShift
{
    public partial class CharacterSet
    {
        public static readonly CharacterSet LatinAlphabet = new("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray());
        public static readonly CharacterSet LatinAlphabetLower = new("abcdefghijklmnopqrstuvwxyz".ToArray());
        public static readonly CharacterSet LatinAlphabetUpper = new("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray());
        public static readonly CharacterSet AlphaNumeric = new("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToArray());
        public static readonly CharacterSet Extended = new("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789,.;:<>?!~/|\\'\"[]{}()+-*=_&^%$#@€ ".ToArray());
    }
}
