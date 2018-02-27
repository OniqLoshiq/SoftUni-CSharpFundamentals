using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongNameException : Exception
{
    private const int minNameLength = 3;
    private const int maxNameLength = 30;

    public InvalidSongNameException()
        : base(String.Format("Song name should be between {0} and {1} symbols.", minNameLength, maxNameLength))
    {

    }
}
