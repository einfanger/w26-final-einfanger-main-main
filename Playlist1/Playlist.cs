using System;
using System.Collections.Generic;

public class Playlist : IPlaylist
{
    private readonly List<Song> _songs = new List<Song>();
    private int _nextIndex = 0;

    public void AddSong(Song song)
    {
        if (song == null)
        {
            throw new ArgumentNullException(nameof(song));
        }

        _songs.Add(song);
    }

    public bool RemoveSong(Song song)
    {
        int index = FindSongIndex(song);
        if (index == -1)
        {
            return false;
        }

        _songs.RemoveAt(index);

        if (index < _nextIndex)
        {
            _nextIndex--;
        }

        if (_nextIndex < 0)
        {
            _nextIndex = 0;
        }

        if (_nextIndex > _songs.Count)
        {
            _nextIndex = _songs.Count;
        }

        return true;
    }

    public Song? PlayNext()
    {
        if (_nextIndex >= _songs.Count)
        {
            return null;
        }

        Song nextSong = _songs[_nextIndex];
        _nextIndex++;
        return nextSong;
    }

    public void Reset()
    {
        _nextIndex = 0;
    }

public bool MoveSongUp(Song song)
{
    int index = FindSongIndex(song);

    if (index <= 0)
    {
        return false;
    }

    Song temp = _songs[index];
    _songs[index] = _songs[index - 1];
    _songs[index - 1] = temp;

    // Only adjust if some songs have already been played
    if (_nextIndex > 0)
    {
        if (_nextIndex == index + 1)
        {
            _nextIndex--;
        }
        else if (_nextIndex == index)
        {
            _nextIndex++;
        }
    }

    return true;
}

public bool MoveSongDown(Song song)
{
    int index = FindSongIndex(song);

    if (index == -1 || index >= _songs.Count - 1)
    {
        return false;
    }

    Song temp = _songs[index];
    _songs[index] = _songs[index + 1];
    _songs[index + 1] = temp;

    if (_nextIndex > 0)
    {
        if (_nextIndex == index + 1)
        {
            _nextIndex--;
        }
        else if (_nextIndex == index)
        {
            _nextIndex++;
        }
    }

    return true;
}

    public void ShowPlaylist()
    {
        if (_songs.Count == 0)
        {
            Console.WriteLine("Playlist is empty.");
            return;
        }

        for (int i = 0; i < _songs.Count; i++)
        {
            Song song = _songs[i];
            Console.WriteLine($"{i + 1}. {song.Title} by {song.Artist} ({song.Length} sec)");
        }
    }

    public int Length()
    {
        return _songs.Count;
    }

    private int FindSongIndex(Song song)
    {
        for (int i = 0; i < _songs.Count; i++)
        {
            if (SongsMatch(_songs[i], song))
            {
                return i;
            }
        }

        return -1;
    }

    private bool SongsMatch(Song playlistSong, Song searchSong)
    {
        bool titleMatches = string.IsNullOrWhiteSpace(searchSong.Title) ||
                            playlistSong.Title.Equals(searchSong.Title, StringComparison.OrdinalIgnoreCase);

        bool artistMatches = string.IsNullOrWhiteSpace(searchSong.Artist) ||
                             playlistSong.Artist.Equals(searchSong.Artist, StringComparison.OrdinalIgnoreCase);

        return titleMatches && artistMatches;
    }

    private void AdjustNextIndexAfterMoveUp(int index)
    {
        if (_nextIndex == index)
        {
            _nextIndex--;
        }
        else if (_nextIndex == index - 1)
        {
            _nextIndex++;
        }
    }

    private void AdjustNextIndexAfterMoveDown(int index)
    {
        if (_nextIndex == index)
        {
            _nextIndex++;
        }
        else if (_nextIndex == index + 1)
        {
            _nextIndex--;
        }
    }
}