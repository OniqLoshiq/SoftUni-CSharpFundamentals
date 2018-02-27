using System;
using System.Collections.Generic;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;
    
    public string Author
    {
        get { return author; }
        set
        {
            if (value.Contains(" ") && Char.IsDigit(value[value.IndexOf(' ') + 1]))
                throw new ArgumentException("Author not valid!");
            author = value;
        }
    }

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
                throw new ArgumentException("Title not valid!");
            title = value;
        }
    }

    public decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Price not valid!");
            price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {Title}")
            .AppendLine($"Author: {Author}")
            .AppendLine($"Price: {Price:f2}");
        return sb.ToString().TrimEnd();
    }
}
