using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongLengthException : Exception
{
    public InvalidSongLengthException()
        : base(String.Format("Invalid song length."))
    {

    }
}
