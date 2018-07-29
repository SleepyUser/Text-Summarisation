# Text-Summarisation

Text Summarisation program created for university

**Explanation**

This program will take a text document and output a summarised version of the same document. It will split the document into words and sentences, then tally the frequency of the words within the document. Stopwords such as "and" and "of" won't be counted for the tally. 
Once each word has a frequency value, the sentences will be given a score which will be the sum of the frequencies of each word in the sentence, divided by the number of words in the sentence to avoid overly long sentences being the highest rated. This value is the "relevance" of the sentence to the document, as in theory the most frequently mentioned words would be those that are relevant to the subject of the document.
The sentences are then added to an output document, until the number of words in the output document hit a certain threshold, at which point the file is complete.

**Instructions**

Download the built version, and add a .txt file containing the document to be summarised to the same directory before running the executable.

**Notes**

-This program can handle basic punctuation fairly well, but more complex documents may become muddled.

-This program won't output a perfect summarisation as it can't understand the context of the document, further alterations could be made to fix this.
