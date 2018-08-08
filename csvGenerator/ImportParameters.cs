using System;
using System.Collections.Generic;
using System.Text;

namespace csvGenerator
{
    internal class ImportParameters
    {
        internal string Title { get; private set; }
        internal int Id { get; private set; }

        protected ImportParameters(string title, int id)
        {
            Title = title;
            Id = id;
        }
    }

    internal class ImportParameters<T> : ImportParameters
    {
        internal T Value { get; private set; }

        protected ImportParameters(string title, T value, int id) : base(title, id)
        {
            Value = value;
        }
    }

    internal class SeparatorParameters : ImportParameters<string>
    {
        internal static List<SeparatorParameters> Separator = new List<SeparatorParameters>
        {
            new SeparatorParameters("Comma", ",", 0),
            new SeparatorParameters("Semicolon", ";", 1),
            new SeparatorParameters("Colon", ":", 2),
            new SeparatorParameters("Tab", "\t", 3),
            new SeparatorParameters("Space", " ", 4)
        };

        private SeparatorParameters(string title, string value, int id)
            : base(title, value, id)
        {
        }
    }

    internal class EncodingParameters : ImportParameters<Encoding>
    {
        internal static List<EncodingParameters> Encodng = new List<EncodingParameters>
        {
            new EncodingParameters("UTF8", Encoding.UTF8, 0),
            new EncodingParameters("ASCII", Encoding.ASCII, 1),
            new EncodingParameters("Windows1251", Encoding.GetEncoding(1251), 2),
            new EncodingParameters("CP866", Encoding.GetEncoding(866), 3),
            new EncodingParameters("KOI8R", Encoding.GetEncoding(20866), 4)
        };

        private EncodingParameters(string title, Encoding value, int id)
            : base(title, value, id)
        {
        }
    }

    internal class DelimiterParameters : ImportParameters<string>
    {
        internal static List<DelimiterParameters> Delimiter = new List<DelimiterParameters>
        {
            new DelimiterParameters("DQ", "\"", 0),
            new DelimiterParameters("SQ", "\'", 1)
        };

        private DelimiterParameters(string title, string value, int id) 
            : base(title, value, id)
        {
        }
    }
}