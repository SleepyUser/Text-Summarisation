using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSummarisation
{
    class Word
    {
        public string word;
        public int frequency; //number of times it appears in text.

        public Word(string w)
        {
            w.ToLower();
            word = w;
        }
    }
}
