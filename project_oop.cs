using System;
using System.Collections.Generic;
using static System.Console;

// Базовый класс для документа
class Document
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Keywords { get; set; }
    public string Topic { get; set; }
    public string FilePath { get; set; }

    protected Document(string name, string author, string keywords, string topic, string filePath)
    {
        Name = name;
        Author = author;
        Keywords = keywords;
        Topic = topic;
        FilePath = filePath;
    }

    public virtual void DisplayInfo()
    {
        WriteLine($"Документ: {Name}, Автор: {Author}, Ключевые слова: {Keywords}, Тематика: {Topic}, Путь: {FilePath}");
    }
}

// Дочерние классы для каждого типа документов
class WordDocument : Document
{
    public int PageCount { get; set; }

    public WordDocument(string name, string author, string keywords, string topic, string filePath, int pageCount)
        : base(name, author, keywords, topic, filePath)
    {
        PageCount = pageCount;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        WriteLine($"Количество страниц: {PageCount}");
    }
}

class PdfDocument : Document
{
    public bool HasDigitalSignature { get; set; }

    public PdfDocument(string name, string author, string keywords, string topic, string filePath, bool hasDigitalSignature)
        : base(name, author, keywords, topic, filePath)
    {
        HasDigitalSignature = hasDigitalSignature;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        WriteLine($"Цифровая подпись: {(HasDigitalSignature ? "Есть" : "Нет")}");
    }
}

class ExcelDocument : Document
{
    public int SheetCount { get; set; }

    public ExcelDocument(string name, string author, string keywords, string topic, string filePath, int sheetCount)
        : base(name, author, keywords, topic, filePath)
    {
        SheetCount = sheetCount;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        WriteLine($"Количество листов: {SheetCount}");
    }
}

class TextDocument : Document
{
    public string Encoding { get; set; }

    public TextDocument(string name, string author, string keywords, string topic, string filePath, string encoding)
        : base(name, author, keywords, topic, filePath)
    {
        Encoding = encoding;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        WriteLine($"Кодировка: {Encoding}");
    }
}

class HtmlDocument : Document
{
    public bool HasCss { get; set; }

    public HtmlDocument(string name, string author, string keywords, string topic, string filePath, bool hasCss)
        : base(name, author, keywords, topic, filePath)
    {
        HasCss = hasCss;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        WriteLine($"Стили CSS: {(HasCss ? "Подключены" : "Отсутствуют")}");
    }
}

// Singleton для управления меню
class DocumentManager
{
    private static DocumentManager s_instance;
    private readonly List<Document> _documents = new List<Document>();

    private DocumentManager() { }

    public static DocumentManager GetInstance()
    {
        if (s_instance == null)
            s_instance = new DocumentManager();
        return s_instance;
    }

    public void AddDocument(Document doc)
    {
        _documents.Add(doc);
    }

    public void ShowDocuments()
    {
        foreach (var doc in _documents)
        {
            doc.DisplayInfo();
        }
    }
}

// Основной класс приложения
class Program
{
    static void Main()
    {
        DocumentManager manager = DocumentManager.GetInstance();

        manager.AddDocument(new WordDocument("Документ1", "Автор1", "ключ1", "Тема1", "C:/docs/doc1.docx", 500));
        manager.AddDocument(new PDFDocument("Документ2", "Автор2", "ключ2", "Тема2", "C:/docs/doc2.pdf", true));
        manager.AddDocument(new ExcelDocument("Документ3", "Автор3", "ключ3", "Тема3", "C:/docs/doc3.xlsx", 3));
        manager.AddDocument(new TextDocument("Документ4", "Автор4", "ключ4", "Тема4", "C:/docs/doc4.txt", 100));
        manager.AddDocument(new HTMLDocument("Документ5", "Автор5", "ключ5", "Тема5", "C:/docs/doc5.html", "HTML5"));

        manager.ShowDocuments();
    }
}
