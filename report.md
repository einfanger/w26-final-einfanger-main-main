# Playlist Report

## Give background and context

- This project involves building a playlist feature for a music application.
- The playlist allows users to add songs, remove songs, play the next song, reorder songs, and display the playlist.
- The goal of this project is to explore how different data structures affect performance and implementation.

## Talk about the implementation and performance of your playlist with an Array / List

- For this version of the playlist, I used a List<Song> as the internal data structure.
- This implementation was straightforward because lists provide built-in support for adding and removing elements. Adding a song is efficient since it simply appends to the end of the list.
- Removing and moving songs required searching through the list to find the correct song, which can take longer as the playlist grows. Moving songs up or down was done by swapping elements, which was simple but required careful handling of the current playback index.
- The PlayNext function was implemented by tracking the current position in the list, ensuring the songs are played in order, and that playback stops when all songs have been played unless reset.
- In performance testing, operations were very fast for small playlists (around 10 songs) while the larger playlists took much more time, because the elements had to shift in the list.

## Talk about the implementation and performance of your playlist with a Linked List

For week 12, I changed my playlist so that it uses a custom linked list instead of a regular List. I made a private Node class that stores a Song and a reference to the next node in the playlist. I then updated the playlist so it could still do the same functions as before, including adding songs, removing songs, playing the next song, resetting playback, moving songs up or down, showing the playlist, and returning the total number of songs.

This version was a little bit more challenging because a linked list does not let you jump directly to an item by index as a regular List does. It took some learning to implement the Linked List, but I was able to figure it out with no errors or warnings!

## Talk about the implementation and performance of your playlist with a Binary Search Tree

For this version of the playlist, I used a Dictionary instead of a Binary Search Tree. I chose this because it still met the goal of improving search performance while being simpler and more practical to implement. I used a List to keep the songs in playlist order and a Dictionary to support faster lookups by song title and artist. This allowed me to keep the same playlist behavior while also improving how songs could be found and managed.

Compared to the previous versions of my assignment, this one was more efficient for searching and managing songs. It still required some extra logic because a Dictionary alone does not preserve playlist order. Because of this, the List was super important for playback and reordering features. Overall, this version showed that combining data structures can be more useful than relying only on one.

## Which would you choose? Why? What if you had to implement other features such as Shuffle or Play Next - how would that affect your choice?

If I were building a real music playlist application for a software company, I would go with the dictionary version. While the regular List and Linked list versions are good and both worked, the dictionary-based version felt like it had the least amount of restrictions and had the best balance between performance and usability. It allows for faster searching while still keeping the playlist in order by using a List alongside the Dictionary. This makes it more practical for a real application where users may frequently search, remove, or manage songs.

If I had to add features such as Shuffle or Play Next, I would still want to use the Dictionary with a List. A List is naturally better for keeping track of playback, randomizing songs, and moving through the playlist one song at a time. The Dictionary helps with finding songs quickly, while the List keeps the user experience smooth. In a professional setting, I would choose the data structure that best matches how users actually interact with playlists, and this combined approach seems like the best choice for the company