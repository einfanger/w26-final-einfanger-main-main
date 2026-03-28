using System;

public class Playlist : IPlaylist
{
    private class Node
    {
        public Song Data;
        public Node? Next;

        public Node(Song song)
        {
            Data = song;
            Next = null;
        }
    }

    private Node? _head;
    private Node? _tail;
    private int _length;
    private int _nextIndex;

    public Playlist()
    {
        _head = null;
        _tail = null;
        _length = 0;
        _nextIndex = 0;
    }

    public void AddSong(Song song)
    {
        if (song == null)
        {
            throw new ArgumentNullException(nameof(song));
        }

        Node newNode = new Node(song);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail!.Next = newNode;
            _tail = newNode;
        }

        _length++;
    }

    public bool RemoveSong(Song song)
    {
        Node? current = _head;
        Node? previous = null;
        int index = 0;

        while (current != null)
        {
            if (SongsMatch(current.Data, song))
            {
                if (previous == null)
                {
                    _head = current.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }

                if (current == _tail)
                {
                    _tail = previous;
                }

                _length--;

                if (index < _nextIndex)
                {
                    _nextIndex--;
                }

                if (_nextIndex < 0)
                {
                    _nextIndex = 0;
                }

                if (_nextIndex > _length)
                {
                    _nextIndex = _length;
                }

                if (_length == 0)
                {
                    _head = null;
                    _tail = null;
                    _nextIndex = 0;
                }

                return true;
            }

            previous = current;
            current = current.Next;
            index++;
        }

        return false;
    }

    public Song? PlayNext()
    {
        if (_nextIndex >= _length)
        {
            return null;
        }

        Node? current = GetNodeAt(_nextIndex);
        if (current == null)
        {
            return null;
        }

        _nextIndex++;
        return current.Data;
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

        Node? current = GetNodeAt(index);
        Node? previous = GetNodeAt(index - 1);

        if (current == null || previous == null)
        {
            return false;
        }

        Song temp = current.Data;
        current.Data = previous.Data;
        previous.Data = temp;

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

        if (index == -1 || index >= _length - 1)
        {
            return false;
        }

        Node? current = GetNodeAt(index);
        Node? next = GetNodeAt(index + 1);

        if (current == null || next == null)
        {
            return false;
        }

        Song temp = current.Data;
        current.Data = next.Data;
        next.Data = temp;

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
        if (_head == null)
        {
            Console.WriteLine("Playlist is empty.");
            return;
        }

        Node? current = _head;
        int position = 1;

        while (current != null)
        {
            Song song = current.Data;
            Console.WriteLine($"{position}. {song.Title} by {song.Artist} ({song.Length} sec)");
            current = current.Next;
            position++;
        }
    }

    public int Length()
    {
        return _length;
    }

    private Node? GetNodeAt(int index)
    {
        if (index < 0 || index >= _length)
        {
            return null;
        }

        Node? current = _head;
        int currentIndex = 0;

        while (current != null && currentIndex < index)
        {
            current = current.Next;
            currentIndex++;
        }

        return current;
    }

    private int FindSongIndex(Song song)
    {
        Node? current = _head;
        int index = 0;

        while (current != null)
        {
            if (SongsMatch(current.Data, song))
            {
                return index;
            }

            current = current.Next;
            index++;
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
}