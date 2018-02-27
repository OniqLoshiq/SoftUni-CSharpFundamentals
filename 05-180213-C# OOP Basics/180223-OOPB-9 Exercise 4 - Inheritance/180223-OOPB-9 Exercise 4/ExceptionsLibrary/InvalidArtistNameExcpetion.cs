using System;

namespace ExceptionLibrary
{
    public class InvalidArtistNameException : Exception
    {
        private const int minNameLength = 3;
        private const int maxNameLength = 20;

        public InvalidArtistNameException()
            : base(String.Format("Artist name should be between {0} and {1} symbols.", minNameLength, maxNameLength))
        {

        }
    }
}


