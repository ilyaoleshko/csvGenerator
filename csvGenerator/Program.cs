using System.IO;
using System.Text;
using CsvHelper;

namespace csvGenerator
{
    internal class Program
    {
        public static void Generate(SeparatorParameters sep, EncodingParameters enc, int count)
        {
            using (TextWriter writer =
                new StreamWriter(@"TestCsv\" + enc.Title + "_" + sep.Title + "_NQ.csv", false, enc.Value))
            {
                var csv = new CsvWriter(writer);
                csv.Configuration.QuoteNoFields = true;
                for (var i = 0; i < count; i++)
                {
                    csv.WriteField(i + "default.post@gmail.com" + sep.Value + i + "Ilya" + sep.Value + i + "Oleshko");
                    csv.NextRecord();
                }
            }
        }

        public static void GenerateChangePosition(int count)
        {
            using (TextWriter writer =
                new StreamWriter(@"TestCsv\Default_parameters_Wich_header_Change_position.csv", false, Encoding.UTF8))
            {
                var csv = new CsvWriter(writer);
                csv.Configuration.QuoteNoFields = true;
                csv.WriteField("LastName,Email,FirstName");
                csv.NextRecord();
                for (var i = 0; i < count; i++)
                {
                    csv.WriteField(i + "Oleshko," + i + "default.post@gmail.com," + i + "Ilya");
                    csv.NextRecord();
                }
            }
        }

        public static void GenerateDefaultPosition(int count)
        {
            using (TextWriter writer =
                new StreamWriter(@"TestCsv\Default_parameters_Wich_header_Default_position.csv", false, Encoding.UTF8))
            {
                var csv = new CsvWriter(writer);
                csv.Configuration.QuoteNoFields = true;
                csv.WriteField("FirstName,LastName,Email");
                csv.NextRecord();
                for (var i = 0; i < count; i++)
                {
                    csv.WriteField(i + "Ilya," + i + "Oleshko," + i + "default.post@gmail.com");
                    csv.NextRecord();
                }
            }
        }

        public static void GenerateWithDelimiter(SeparatorParameters sep, EncodingParameters enc, DelimiterParameters del, int count)
        {
            using (TextWriter writer =
                new StreamWriter(@"TestCsv\" + enc.Title + "_" + sep.Title + "_" + del.Title + ".csv", false, Encoding.UTF8))
            {
                var csv = new CsvWriter(writer);
                csv.Configuration.QuoteNoFields = true;
                for (var i = 0; i < count; i++)
                {
                    csv.WriteField(i + "default.post@gmail.com" + sep.Value + del.Value + i + "Ilya" + del.Value + sep.Value + i + "Oleshko");
                    csv.NextRecord();
                }
            }
        }

        private static void Main()
        {
            const int count = 5;
            GenerateDefaultPosition(count);
            GenerateChangePosition(count);
            var i = SeparatorParameters.Separator.Count;
            while (i > 0)
            {
                i--;
                Generate(SeparatorParameters.Separator[i], EncodingParameters.Encodng[0], count);
            }

            var j = EncodingParameters.Encodng.Count;
            while (j > 0)
            {
                j--;
                Generate(SeparatorParameters.Separator[0], EncodingParameters.Encodng[j], count);
            }

            var k = DelimiterParameters.Delimiter.Count;
            while (k > 0)
            {
                k--;
                GenerateWithDelimiter(SeparatorParameters.Separator[0], EncodingParameters.Encodng[0], DelimiterParameters.Delimiter[k], count);
            }
        }
    }
}
