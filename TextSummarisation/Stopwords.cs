using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextSummarisation
{
    class Stopwords //This class takes in and holds a list of all the stop words ready for comparison.
    {
       // int counter = 0;

        public List<Word> stopwords = new List<Word>(); //Create a list of stopwords to compare input file to.

        public Stopwords() 
        {
            string word;
            StreamReader file = new StreamReader(Directory.GetCurrentDirectory() + @"\stopwords.txt");
            while ((word = file.ReadLine()) != null)
            {
                stopwords.Add(new Word(word));
                //counter++;
            }
            file.Close();
            //Console.WriteLine(counter + " stopwords recorded");
        }
    }
}
