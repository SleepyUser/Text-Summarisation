using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextSummarisation
{
    class Document //This class will be essentially a copy of the document. Uneditable, and split into sentences and words.
    {
        private int wordCounter = 0;
        public int WordCounter { get { return this.wordCounter; } }
        string word; //The Current word.

        private List<Word> words = new List<Word>();         //Create a list of words present in the document.
       // public List<string> Words {get{return this.words;}}      //Make sure the only time this can be edited is from inside the document.

        private List<Sentence> sentences = new List<Sentence>(); //Keep a record of all sentences in input file, in the order they appear.
        public List<Sentence> Sentences{get {return this.sentences;} } //Make sure the only time this can be edited is from inside the document.

        public Document(string path) //Accesses the document and breaks it down into sentences etc.
        {
            Console.WriteLine(@path);
            Console.ReadLine();
            char prev;
            char.TryParse("a", out prev);
            char current; //The Current character being accessed.
            StreamReader file = new StreamReader(@path);
            sentences.Add(new Sentence());
            do
            {
                
                current = (char)file.Read();
                //Console.WriteLine(current);
                if (Char.IsWhiteSpace(current))
                {
                    if (word != "") //Checks for a new sentence beginning, and skips the space if it at the beginning of a new word.
                    {
                        words.Add(new Word(word));
                        sentences.Last<Sentence>().addWord(word);
                        wordCounter++;
                        word = "";
                    }
                }
                //else if (current.ToString() == "(" || current.ToString() == ")" || current.ToString() == "\"")//If open bracket, add without adding to a word.
                //{
                //    sentences.Last<Sentence>().addWord(word, current);
                //}
                else if (current.ToString() == "!" || current.ToString() == "?") //Check for sentences ending.
                {
                    words.Add(new Word(word));
                    sentences.Last<Sentence>().addWord(word, current);
                    sentences.Add(new Sentence());
                    //Console.WriteLine(word);
                    word = "";

                }
                else if ((current.ToString() == ".") && char.IsWhiteSpace((char)file.Peek()))// && (word.Trim() != "Mr") && !char.IsUpper(prev)) //Checks the full stop is at the end of a sentence, and not part of an abbreviation like U.S.A
                {
                    words.Add(new Word(word));
                    sentences.Last<Sentence>().addWord(word, current);
                    sentences.Add(new Sentence());
                    //Console.WriteLine(word);
                    word = "";
                }
                else if (Char.IsLetterOrDigit(current) || Char.IsPunctuation(current)) //Anything else that could be in a sentence is added to the word.
                {
                    word += current.ToString();
                }
                
                prev = current;
            } while (!file.EndOfStream);
            file.Close();
            Console.WriteLine();
            Console.WriteLine(sentences.Count() + "sentences recorded");
            Console.WriteLine(words.Count() + " words recorded");
        }

        public List<Word> RemoveStopwordsFromDoc() //Returns a list of all words in the document, with stopwords removed.
        {
            Stopwords stop = new Stopwords();
            List<Word> docWords = new List<Word>(words); //Create a new list, deep copy. So we can erase all stopwords from one of the lists.
            Console.WriteLine(docWords.Count + "Before.");
            for (int i = 0; i<stop.stopwords.Count(); i++)
            {
                docWords.RemoveAll(item => item.word.ToLower() == stop.stopwords[i].word.ToLower());
            }
            Console.WriteLine(docWords.Count + "After");
            return docWords;
        }
    }
}
