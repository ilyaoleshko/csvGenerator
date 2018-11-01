using System.IO;
using System.Text;
using CsvHelper;
using System;

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

        public static void GenerateN(int bigCount)
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

        public static void GenerateContacts(int count, bool headerBool, string body, string head, string source)
        {
            using (TextWriter writer =
                new StreamWriter(@"TestCsv\" + source + "_" + count + ".csv", false, Encoding.UTF8))
            {
                var csv = new CsvWriter(writer);
                csv.Configuration.QuoteNoFields = true;
                if (headerBool)
                {
                    csv.WriteField(head);
                    csv.NextRecord();
                }
                for (var i = 0; i < count; i++)
                {
                    csv.WriteField(String.Format(body,i));
                    csv.NextRecord();
                }
            }
        }

        private static void Main()
        {
            int count = 5;
            string googleHead = "Name,Given Name,Additional Name,Family Name,Yomi Name,Given Name Yomi,Additional Name Yomi,Family Name Yomi,Name Prefix,Name Suffix,Initials,Nickname,Short Name,Maiden Name,Birthday,Gender,Location,Billing Information,Directory Server,Mileage,Occupation,Hobby,Sensitivity,Priority,Subject,Notes,Language,Photo,Group Membership,E-mail 1 - Type,E-mail 1 - Value,Phone 1 - Type,Phone 1 - Value,Address 1 - Type,Address 1 - Formatted,Address 1 - Street,Address 1 - City,Address 1 - PO Box,Address 1 - Region,Address 1 - Postal Code,Address 1 - Country,Address 1 - Extended Address,Organization 1 - Type,Organization 1 - Name,Organization 1 - Yomi Name,Organization 1 - Title,Organization 1 - Department,Organization 1 - Symbol,Organization 1 - Location,Organization 1 - Job Description";
            string outlookHead = "First Name,Middle Name,Last Name,Title,Suffix,Nickname,Given Yomi,Surname Yomi,E-mail Address,E-mail 2 Address,E-mail 3 Address,Home Phone,Home Phone 2,Business Phone,Business Phone 2,Mobile Phone,Car Phone,Other Phone,Primary Phone,Pager,Business Fax,Home Fax,Other Fax,Company Main Phone,Callback,Radio Phone,Telex,TTY/TDD Phone,IMAddress,Job Title,Department,Company,Office Location,Manager's Name,Assistant's Name,Assistant's Phone,Company Yomi,Business Street,Business City,Business State,Business Postal Code,Business Country/Region,Home Street,Home City,Home State,Home Postal Code,Home Country/Region,Other Street,Other City,Other State,Other Postal Code,Other Country/Region,Personal Web Page,Spouse,Schools,Hobby,Location,Web Page,Birthday,Anniversary,Notes";
            string thunderHead = "First Name,Last Name,Display Name,Nickname,Primary Email,Secondary Email,Screen Name,Work Phone,Home Phone,Fax Number,Pager Number,Mobile Number,Home Address,Home Address 2,Home City,Home State,Home ZipCode,Home Country,Work Address,Work Address 2,Work City,Work State,Work ZipCode,Work Country,Job Title,Department,Organization,Web Page 1,Web Page 2,Birth Year,Birth Month,Birth Day,Custom 1,Custom 2,Custom 3,Custom 4,Notes,";

            string googleBody = "{0}Test user,{0}Test,,{0}User,,,,,,,,,,,,,,,,,,,,,,,,,* myContacts,* ,{0}test@test.com,,,,,,,,,,,,,,,,,,,";
            string outlookBody = "{0}Test,,{0}User,,,,,,{0}test@test.com,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,";
            string thunderBody = "{0}Test,{0}User,{0}Test user,,{0}test@test.com,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,";

            GenerateN(1);
            GenerateN(10);
            GenerateN(100);
            GenerateN(1000);
            GenerateN(10000);
            GenerateN(100000);
            GenerateN(1000000);

            GenerateContacts(3000, true, googleBody, googleHead, "Google");
            GenerateContacts(3000, true, outlookBody, outlookHead, "Outlook");
            GenerateContacts(3000, true, thunderBody, thunderHead, "Thunderbird");

            GenerateContacts(5000, true, googleBody, googleHead, "Google");
            GenerateContacts(5000, true, outlookBody, outlookHead, "Outlook");
            GenerateContacts(5000, true, thunderBody, thunderHead, "Thunderbird");

            /*
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
