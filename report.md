# Playlist Report

## Give background and context

- This project involves building a playlist feature for a music application.
- The playlist allows users to add songs, remove songs, play the next song, reorder songs, and display the playlist.
- The goal of this project is to exmplore how different data structures affect perfoamnce and implmenetation.

## Talk about the implementation and performance of your playlist with an Array / List

- For this version of the playist, I used a List<Song> as the internal data structure.
- This implementation was straightforward becasue lists provide built-in support for adding and removing elements. Adding a song is efficent since it simply appends to the endof the list.
- Removing and moving songs required searching throuhg the list to find the correct song, which can take longer as the playlist grows. Moving songs up or down was done by swappingelements, which was simple but requiredcarefule handling of the current playback index.
- The PlayNext function was implemented by tracking the current position in the list, ensuring the songs are played in order and that playback stops when all songs have been played unless reset.
- In performance testting, operations were very fast for small playlists(arond 10 songs) while the largers playlists, took much more time, because the elements had to shift in the list.

## Talk about the implementation and performance of your playlist with a Linked List

For week 12, I changed my playlist so that it uses a custom linked list instead of a regular List. I made a private Node class that stores a Song and a reference to the next node in the playlist. I then updatred the playlist so it could still do the same functions as before, including adding songs, removing songs, playing the next song, resetting playback, moving songs up or down, showing the playlist, and returning the total number of songs.

This verison was a little bit more challenging because a linked list foes not let you jump direcetvly to an item by index like a regular List does. It took some learning to implements the Linked List, but I was able to figure it out with no errors or warnings!

## Talk about the implementation and performance of your playlist with a Binary Search Tree

## Which would you choose? Why? What if you had to implement other features such as Shuffle or Play Next - how would that affect your choice?