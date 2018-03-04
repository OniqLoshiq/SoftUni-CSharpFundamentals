using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Smartphone : IBrowsable, ICallable
{
    private const string numberPattern = @"[^\d]";

    public string Browse(string url)
    {
        ValidateUrl(url);
        return $"Browsing: {url}!";
    }

    public string Calling(string number)
    {
        ValidateNumber(number);
            return $"Calling... {number}";
    }

    private void ValidateUrl(string url)
    {
        if (url.Any(char.IsDigit))
            throw new ArgumentException("Invalid URL!");
    }

    private void ValidateNumber(string number)
    {
        if (Regex.IsMatch(number,numberPattern))
            throw new ArgumentException("Invalid number!");
    }
}
