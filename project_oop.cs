using System;
using System.Collections.Generic;
using static System.Console;

class Program
{
    class Document
    {
        public string Name, Author, Keywords, Topic, FilePath;
        public Document(string name, string author, string keywords, string topic, string filePath)
        {
            Name = name;
            Author = author;
            Keywords = keywords;
            Topic = topic;
            FilePath = filePath;
        }
        public void GetInfo()
        {
            WriteLine($"{Name}, {Author}, {Keywords}, {Topic}, {FilePath}");
        }
    }

    static void Main()
    {
        List<Document> docs = new List<Document>
        {
            new Document("Документ1", "Автор1", "ключ1", "Тема1", "C:/docs/doc1.docx"),
            new Document("Документ2", "Автор2", "ключ2", "Тема2", "C:/docs/doc2.pdf"),
            new Document("Документ3", "Автор3", "ключ3", "Тема3", "C:/docs/doc3.xlsx"),
            new Document("Документ4", "Автор4", "ключ4", "Тема4", "C:/docs/doc4.txt"),
            new Document("Документ5", "Автор5", "ключ5", "Тема5", "C:/docs/doc5.html")
        };

        foreach (var doc in docs)
            doc.GetInfo();
    }
}
