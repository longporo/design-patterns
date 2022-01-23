using System;

namespace structural_adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Adapter is a structural design pattern, which allows incompatible objects to collaborate
            Console.WriteLine("Hello World!");
        }
    }

    // The client interface is only able to play wav audio while the old player can only play mp3 audio
    interface WavPlayer
    {
        void PlayWavAudio(Object wav);
    }

    // The adaptee
    class Mp3Player
    {
        public void PlayMp3Audio(Object mp3)
        {
            // code to play mp3 audio
        }
    }

    // The adapter
    class Adapter : WavPlayer
    {
        private Mp3Player OldPlayer;

        public Adapter(Mp3Player oldPlayer)
        {
            OldPlayer = oldPlayer;
        }

        public void PlayWavAudio(Object wav)
        {
            // code to convert wav audio in mp3 format,
            Object mp3 = wav;
            // the client is now possible to play wav audio with Mp3Player 
            OldPlayer.PlayMp3Audio(mp3);
        }
    }
    
}