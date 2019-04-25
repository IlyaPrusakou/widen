using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Audioplayer
{
    public class CompareHelper : IComparer<string> 
    {
        public int Compare(string x, string y) 
        {
            if (Convert.ToInt32(x[0]) < Convert.ToInt32(y[0])) 
            {
                return -1;
            }
            else if (Convert.ToInt32(x[0]) > Convert.ToInt32(y[0]))
            {
                return 1;
            }
            else
            {
                return 0;
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
        public List<Song> songs; 
        public Random rnd = new Random();
        public CompareHelper Comp = new CompareHelper(); 

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
        public (string Title, bool IsNext, (int Sec, int Min, int Hour)) GetSongData(Song song) //L9-HW-Player-3/3. 
        { 
            var (str, boo, sec, min, hour) = song; //L9-HW-Player-3/3. 
            string s = str; //L9-HW-Player-3/3.
            bool d = boo; //L9-HW-Player-3/3.
            int f = sec; //L9-HW-Player-3/3.
            int f1 = min; //L9-HW-Player-3/3.
            int f2 = hour; //L9-HW-Player-3/3.
            return (Title: s, IsNext:d, (Sec: f, Min: f1, Hour: f2)); //L9-HW-Player-3/3.
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
                string outputString = paramertString.StringSeparator();
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
        public void Play(bool Loop = false) 
        {
            if (Loop == false) 
            {
                ShufleExtension.ExtenShufle(this, songs);
            }
            else 
            {
                for (int i = 0; i < 5; i++) 
                {
                    ShufleExtension.ExtenShufle(this, songs);
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
        public void LyricsOutput() 
        {
            foreach (Song item in songs) 
            {
                Console.WriteLine($"{item.title} --- {item.lyrics}"); 
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
    }
}