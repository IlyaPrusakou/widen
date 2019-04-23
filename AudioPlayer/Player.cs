using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Audioplayer
{
    public class CompareHelper : IComparer<string> // realize custom sorting
    {
        public int Compare(string x, string y) // realize custom sorting
        {
            if (Convert.ToInt32(x[x.Length - 1]) < Convert.ToInt32(y[y.Length - 1])) // realize custom sorting
            {
                return -1;// realize custom sorting
            }
            else if (Convert.ToInt32(x[x.Length - 1]) > Convert.ToInt32(y[y.Length - 1]))// realize custom sorting
            {
                return 1;// realize custom sorting
            }
            else// realize custom sorting
            {
                return 0;// realize custom sorting
            }
        }
    }
    class Player
    {
        
        private int volume;
        public const int minVolume = 0;
        public const int maxVolume = 100;
        public bool isLock;
        private bool playing;
        public List<Song> songs; //replace [] to list
        public Random rnd = new Random();
        public CompareHelper Comp = new CompareHelper(); // realize custom sorting

        //B5-Player4/10. Properties.
        public bool Playing
        {
            get
            {
                return playing;
            }
        }
         
        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value < minVolume)
                {
                    volume = minVolume;
                }
                else if (value > maxVolume)
                {
                    volume = maxVolume;
                }
                else
                {
                    volume = value;
                }
            }

        }
        //B5-Player8/10. ParamsParameters
        public void ParametrSong(params Song[] SongList)
        {
            foreach (Song item in SongList)
            {
                Console.WriteLine(item.title);
            }
        }
        //BL8-Player1/3.SongTuples.
        // my .net version is 4.7.2
        public (string Title, bool IsNext, (int Sec, int Min, int Hour)) GetSongData(Song song) 
        {
            var (str, boo, sec, min, hour) = song; 
            string s = str;
            bool d = boo;
            int f = sec;
            int f1 = min;
            int f2 = hour;
            return (Title: s, IsNext:d, (Sec: f, Min: f1, Hour: f2));
        }

        // BL8 - Player2 / 3.LikeDislike.
        public void ListSong(List<Song> list)
        {
            foreach (Song item in list)
            {
               var tuple =  GetSongData(item);
                if (item.Like == true) { Console.ForegroundColor = ConsoleColor.Green; }
                else if (item.Like == false) { Console.ForegroundColor = ConsoleColor.Red; }
                else if (item.Like == null) { Console.ResetColor(); }
                string paramertString = $"{tuple.Title}, {item.songGenre} - {tuple.Item3.Hour}:{tuple.Item3.Min}:{tuple.Item3.Sec}";
                string outputString = paramertString.StringSeparator(paramertString);
                Console.WriteLine(outputString);
            }
        }
        //B5-Player3/10. Method. 
        public void VolumeUp()
        {
            Volume = Volume + 1;
            Console.WriteLine("Volume " + Volume);

        }
        
        public void VolumeDown()
        {
            Volume = Volume - 1;
            Console.WriteLine("Volume " + Volume);
        }
        public void VolumeChange(int Step, string op)
        {
            if (op == "+")
            {
                Console.WriteLine($"up volume {Step}");
                Volume = Volume + Step;
            }
            else if (op == "-")
            {
                Console.WriteLine($"down volume {Step}");
                Volume = Volume - Step;
            }
        }
        public void Play(bool Loop = false) //change method play
        {
            if (Loop == false) //change method play
            {
                //Shufle(songs); //change method play
            }
            else //change method play
            {
                for (int i = 0; i < 5; i++) //change method play
                {
                    //Shufle(songs); //change method play
                }
            }
            if (playing == true)
            {
                Console.WriteLine("to Play has started");
                for (int i = 0; i < songs.Count; i++)
                {
                    Console.WriteLine(songs[i].title);
                    System.Threading.Thread.Sleep(2000);
                }
            }

        }
        public void LyricsOutput() // this is method for output to console B7-Player1/2. SongsListShuffle.
        {
            foreach (Song item in songs) // this is method for output to console B7-Player1/2. SongsListShuffle.
            {
                Console.WriteLine($"{item.title} --- {item.lyrics}"); // this is method for output to console B7-Player1/2. SongsListShuffle.
            }
        }
        public bool Stop()
        {
            if (isLock == false)
            {
                Console.WriteLine("Stop");
                playing = false;
            }

            return playing;
        }
        public bool Start()
        {
            if (isLock == false)
            {
                Console.WriteLine("Start");
                playing = true;
            }

            return playing;
        }
        public void Pause()
        {
        }
        public void Lock()
        {
            Console.WriteLine("Player is locked");
            Console.WriteLine("Before action " + isLock);
            isLock = true;
            Console.WriteLine("After action " + isLock);
        }
        public void UnLock()
        {
            Console.WriteLine("Player is unlocked");
            Console.WriteLine("Before action " + isLock);
            isLock = false;
            Console.WriteLine("After action " + isLock);
        }
        public void Load()
        {
        }
        public void Save()
        {
        }

        //public List<Song> Shufle(List<Song> oldList) //method shufle
        //{
            //List<Song> newList = new List<Song>(); //method shufle
            //for (int i = 0; i < oldList.Count + 1000; i++) //method shufle
            //{
                //int index = rnd.Next(0, oldList.Count); //method shufle
                //if (!(newList.Contains(oldList[index]))) //method shufle
                //{
                    //newList.Add(oldList[index]); //method shufle
                //}
                //else if (newList.Contains(oldList[index]))  //method shufle
                //{
                    //continue; //method shufle
                //}
            //}
            //return newList; //method shufle
        //}

        //public List<Song> SortByTitle(List<Song> oldList) //method to sort using custom Sorting class
        //{
            //List<Song> sortedSongsList = new List<Song>(); //method to sort using custom Sorting class
            //List<string> titleList = new List<string>(); //method to sort using custom Sorting class
            //foreach (Song item in oldList) //method to sort using custom Sorting class
            //{
                //titleList.Add(item.title); //method to sort using custom Sorting class

            //}
             //titleList.Sort(Comp); //method to sort using custom Sorting class
            //for (int i = 0; i < titleList.Count; i++) //method to sort using custom Sorting class
            //{
                //for (int j = 0; j < oldList.Count; j++) //method to sort using custom Sorting class
                //{
                    //if (titleList[i] == oldList[j].title) //method to sort using custom Sorting class
                    //{
                        //sortedSongsList.Add(oldList[j]); //method to sort using custom Sorting class
                    //}
                //}
                
            //}
            //return sortedSongsList; //method to sort using custom Sorting class
        //}
    }
}