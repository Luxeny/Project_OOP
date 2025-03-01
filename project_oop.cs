using System;
using System.Collections.Generic;
using static System.Console;

// Базовый класс для документа
class Document
{
  public List<string> Info { get; set; }

  public Document(List<string> info)
  {
    Info = info;
  }

  public virtual void DisplayInfo()
  {
    WriteLine($"Документ: {Info[0]}, Автор: {Info[1]}, Ключевые слова: {Info[2]}, Тематика: {Info[3]}, Путь: {Info[4]}");
  }
}

// Дочерние классы для каждого типа документов
class WordDocument : Document
{
  public int PageCount { get; set; }

  public WordDocument(List<string> info, int pageCount)
    : base(info)
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

  public PdfDocument(List<string> info, bool hasDigitalSignature)
    : base(info)
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

  public ExcelDocument(List<string> info, int sheetCount)
    : base(info)
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

  public TextDocument(List<string> info, string encoding)
    : base(info)
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

  public HtmlDocument(List<string> info, bool hasCss)
    : base(info)
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

    manager.AddDocument(new WordDocument(new List<string>{"Отчет о продажах", "Иван Петров", "финансы, отчет", "Бизнес-аналитика", "C:/docs/sales_report.docx"}, 25));
    manager.AddDocument(new PdfDocument(new List<string>{"Договор аренды", "ООО 'Аренда Плюс'", "юридический, аренда", "Юридические документы", "C:/docs/rent_agreement.pdf"}, true));
    manager.AddDocument(new ExcelDocument(new List<string>{"Бюджет компании", "Анна Смирнова", "финансы, бюджет", "Финансовый анализ", "C:/docs/company_budget.xlsx"}, 5));
    manager.AddDocument(new TextDocument(new List<string>{"Список дел", "Дмитрий Орлов", "задачи, организация", "Персональный менеджмент", "C:/docs/todo_list.txt"}, "UTF-8"));
    manager.AddDocument(new HtmlDocument(new List<string>{"Главная страница сайта", "Алексей Иванов", "веб-разработка, сайт", "Разработка", "C:/docs/index.html"}, true));

    manager.ShowDocuments();
  }
}
