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

    public Document(string name, string author, string keywords, string topic, string filePath)
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
            WriteLine("--------------------------------");
        }
    }
}

// Основной класс приложения
class Program
{
    static void Main()
    {
        DocumentManager manager = DocumentManager.GetInstance();

        manager.AddDocument(new WordDocument("Отчет о продажах", "Иван Петров", "финансы, отчет", "Бизнес-аналитика", "C:/docs/sales_report.docx", 25));
        manager.AddDocument(new PdfDocument("Договор аренды", "ООО 'Аренда Плюс'", "юридический, аренда", "Юридические документы", "C:/docs/rent_agreement.pdf", true));
        manager.AddDocument(new ExcelDocument("Бюджет компании", "Анна Смирнова", "финансы, бюджет", "Финансовый анализ", "C:/docs/company_budget.xlsx", 5));
        manager.AddDocument(new TextDocument("Список дел", "Дмитрий Орлов", "задачи, организация", "Персональный менеджмент", "C:/docs/todo_list.txt", "UTF-8"));
        manager.AddDocument(new HtmlDocument("Главная страница сайта", "Алексей Иванов", "веб-разработка, сайт", "Разработка", "C:/docs/index.html", true));

        manager.ShowDocuments();
    }
}
