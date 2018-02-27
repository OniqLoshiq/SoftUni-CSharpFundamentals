using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongMinutesException : Exception
{
    private const int minMinutes = 0;
    private const int maxMinutes = 14;

    public InvalidSongMinutesException()
        : base(String.Format("Song minutes should be between {0} and {1}.", minMinutes, maxMinutes))
    {

    }
}
