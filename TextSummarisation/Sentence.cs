using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSummarisation 
{
    class Sentence //This class will store information about each sentence. Including word count, a string of the whole thing, and a list of the individual words within it.
    {
        private int wordCount = 0;
        public int WordCount { get { return wordCount; } } //Make sure this is not editable outside the sentence class.

        private string completeSentence;
        public string CompleteSentence { get { return completeSentence; } } //Make sure this is not editable outside the sentence class.

        private List<Word> listOfWords = new List<Word>();
        public List<Word> ListOfWords { get { return listOfWords; } } //Make sure this is not editable outside the sentence class.

        public double value = 0;

        public void addWord(string wordToAdd)
        {
            wordToAdd.Trim();
            listOfWords.Add(new Word(wordToAdd));
            wordCount++;
            completeSentence += (" " + wordToAdd); //Append to sentence
        }

        public void addWord(string wordToAdd, char punctuation)
        {
            wordToAdd.Trim();
            listOfWords.Add(new Word(wordToAdd));
            wordCount++;
            completeSentence += (" " + wordToAdd); //Append to sentence
            completeSentence += (punctuation.ToString()); //Append to sentence
            completeSentence.Trim(); //Trim any excess.
        }

        public void addWord(char openbracket)
        {
            completeSentence += (" " + openbracket.ToString()); // Finally, add the open bracket punctuation.
        }
    }
}
