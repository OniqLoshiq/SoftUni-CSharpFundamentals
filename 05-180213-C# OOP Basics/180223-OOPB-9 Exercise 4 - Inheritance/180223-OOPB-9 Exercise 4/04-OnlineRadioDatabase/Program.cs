using System;
using System.Collections.Generic;
using System.Linq;
using ExceptionLibrary;

class Program
{
    static void Main(string[] args)
    {
        List<Song> songs = new List<Song>();

        GetSongs(songs);
        PrintPlaylist(songs);
    }

    private static void PrintPlaylist(List<Song> songs)
    {
        string playlistLength = GetPlaylistLength(songs);

        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {playlistLength}");
    }

    private static string GetPlaylistLength(List<Song> songs)
    {
        int lengthInSeconds = songs.Sum(x => x.SongInSeconds);
        TimeSpan t = TimeSpan.FromSeconds(lengthInSeconds);

        return string.Format($"{t.Hours}h {t.Minutes}m {t.Seconds}s");
    }

    private static void GetSongs(List<Song> songs)
    {
        int nSongs = int.Parse(Console.ReadLine());

        for (int i = 0; i < nSongs; i++)
        {
            try
            {
                string[] songData = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string artist = songData[0];
                string songName = songData[1];
                int[] lengthData = new int[2];

                try
                {
                    lengthData = songData[2].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                }
                catch
                {
                    throw new InvalidSongLengthException();
                }

                Song newSong = new Song(artist, songName, lengthData[0], lengthData[1]);

                songs.Add(newSong);

                Console.WriteLine("Song added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
