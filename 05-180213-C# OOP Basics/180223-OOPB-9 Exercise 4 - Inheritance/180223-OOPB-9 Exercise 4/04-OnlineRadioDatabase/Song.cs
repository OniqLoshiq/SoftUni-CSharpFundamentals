using System;
using System.Collections.Generic;
using System.Text;
using ExceptionLibrary;


class Song
{
    private string artist;
    private string songName;
    private int minutes;
    private int seconds;

    public string Artist
    {
        get { return artist; }
        private set
        {
            ValidateArtist(value);
            artist = value;
        }
    }

    public string SongName
    {
        get { return songName; }
        private set
        {
            ValidateSongName(value);
            songName = value;
        }
    }

    public int Minutes
    {
        get { return minutes; }
        private set
        {
            ValidateSongMinutes(value);
            minutes = value;
        }
    }

    public int Seconds
    {
        get { return seconds; }
        private set
        {
            ValidateSeconds(value);
            seconds = value;
        }
    }

    public Song(string artist, string songName, int minutes, int seconds)
    {
        Artist = artist;
        SongName = songName;
        Minutes = minutes;
        Seconds = seconds;
    }

    public int SongInSeconds
    {
        get
        {
            return this.Minutes * 60 + this.Seconds;
        }
    }

    private void ValidateArtist(string artist)
    {
        if (artist.Length < 3 || artist.Length > 20)
            throw new InvalidArtistNameException();
    }

    private void ValidateSongName(string songName)
    {
        if (songName.Length < 3 || songName.Length > 30)
            throw new InvalidSongNameException();
    }

    private void ValidateSongMinutes(int minutes)
    {
        if (minutes < 0 || minutes > 14)
            throw new InvalidSongMinutesException();
    }

    private void ValidateSeconds(int seconds)
    {
        if (seconds < 0 || seconds > 59)
            throw new InvalidSongSecondsException();
    }
}
