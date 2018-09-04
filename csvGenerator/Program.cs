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
                new StreamWriter(@"TestCsv\" + enc.Title + "_" + sep.Title + ".csv", false, enc.Value))
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

        public static void Generate100(int bigCount)
        {
            using (TextWriter writer =
                new StreamWriter(@"TestCsv\"+bigCount+".csv", false, Encoding.UTF8))
            {
                var csv = new CsvWriter(writer);
                csv.Configuration.QuoteNoFields = true;
                for (var i = 0; i < bigCount; i++)
                {
                    csv.WriteField(i + "default.post@gmail.com,"+ i + "Ilya,"+ i + "Oleshko");
                    csv.NextRecord();
                }
            }
        }

        public static void GenerateChangePosition(int count, bool headerBool)
        {
            using (TextWriter writer =
                new StreamWriter(@"TestCsv\Default_parameters_" + CheckHeader(headerBool) + "_Change_position.csv", false, Encoding.UTF8))
            {
                var csv = new CsvWriter(writer);
                csv.Configuration.QuoteNoFields = true;
                if (headerBool)
                {
                    csv.WriteField("LastName,Email,FirstName");
                    csv.NextRecord();
                }
                for (var i = 0; i < count; i++)
                {
                    csv.WriteField(i + "Oleshko," + i + "default.post@gmail.com," + i + "Ilya");
                    csv.NextRecord();
                }
            }
        }

        public static void GenerateDefaultPosition(int count, bool headerBool)
        {
            using (TextWriter writer =
                new StreamWriter(@"TestCsv\Default_parameters_" + CheckHeader(headerBool) + "_Default_position.csv", false, Encoding.UTF8))
            {
                var csv = new CsvWriter(writer);
                csv.Configuration.QuoteNoFields = true;
                if (headerBool)
                {
                    csv.WriteField("Email,FirstName,LastName");
                    csv.NextRecord();
                }
                for (var i = 0; i < count; i++)
                {
                    csv.WriteField(i + "default.post@gmail.com," + i + "Ilya," + i + "Oleshko");
                    csv.NextRecord();
                }
            }
        }

        public static string CheckHeader(bool headerBool)
        {
        if (headerBool)
            {
                return "With_header";
            }
            else
            {
                return "Without_header";
            }
        }

        private static void Main()
        {
            const int count = 5;

            Generate100(1000);
            Generate100(10000);
            Generate100(100000);
            Generate100(1000000);

            /*
            GenerateDefaultPosition(count, true);
            GenerateChangePosition(count, true);
            GenerateDefaultPosition(count, false);
            GenerateChangePosition(count, false);
            
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
            */
        }
    }
}
