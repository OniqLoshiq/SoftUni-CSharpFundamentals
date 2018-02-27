using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongSecondsException : Exception
{
    private const int minSeconds = 0;
    private const int maxSeconds = 59;

    public InvalidSongSecondsException()
        : base(String.Format("Song seconds should be between {0} and {1}.", minSeconds, maxSeconds))
    {

    }
}
