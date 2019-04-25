using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Audioplayer
{
    static class ShufleExtension //L9-HW-Player-1/3.
    {
        public static Random rndAA = new Random(); //L9-HW-Player-1/3.
        public static CompareHelper Comp = new CompareHelper(); //L9-HW-Player-1/3.
        public static List<Song> ExtenShufle(this Player player, List<Song> oldList) //L9-HW-Player-1/3. 
        {  

            List<Song> newList = new List<Song>(); //L9-HW-Player-1/3.

            for (int i = 0; i < oldList.Count + 1000; i++) //L9-HW-Player-1/3.
            { 
                int index = rndAA.Next(0, oldList.Count); //L9-HW-Player-1/3.
                if (!newList.Contains(oldList[index])) //L9-HW-Player-1/3.
                { 
                    newList.Add(oldList[index]); //L9-HW-Player-1/3.
                } 
                else if (newList.Contains(oldList[index])) //L9-HW-Player-1/3.
                { 
                    continue; //L9-HW-Player-1/3.
                } 
            } 
            return newList; //L9-HW-Player-1/3.
        } 
        public static List<Song> ExtenSortByTitle(this Player player, List<Song> oldList)  //L9-HW-Player-1/3.
        { 
            List<Song> sortedSongsList = new List<Song>();  //L9-HW-Player-1/3.
            List<string> titleList = new List<string>();  //L9-HW-Player-1/3.
            foreach (Song item in oldList)  //L9-HW-Player-1/3.
            { 
                titleList.Add(item.title);  //L9-HW-Player-1/3.
            } 
            titleList.Sort(Comp); //L9-HW-Player-1/3.
            foreach (string item in titleList) { WriteLine("rrr  " + item); } //L9-HW-Player-1/3.
            for (int i = 0; i < titleList.Count; i++)  //L9-HW-Player-1/3.
            { 
                foreach (Song t in oldList) //L9-HW-Player-1/3.
                { 
                    if (titleList[i] == t.title) //L9-HW-Player-1/3.
                    { 
                        sortedSongsList.Add(t); //L9-HW-Player-1/3.
                    } 
                    else if (titleList[i] != t.title) //L9-HW-Player-1/3.
                    { 
                        continue; //L9-HW-Player-1/3.
                    } 
                } 
            } 
            return sortedSongsList; //L9-HW-Player-1/3. 
        } 
    } 
    public static class StringExtension //L9-HW-Player-2/3.
    { 
        public static string StringSeparator(this string str) //L9-HW-Player-2/3.
        { 
            string sInsert = str.Insert(13, "^Nnn"); //L9-HW-Player-2/3.
            string[] separ = { "^Nnn" }; //L9-HW-Player-2/3.
            string[] sss = sInsert.Split(separ, StringSplitOptions.None); //L9-HW-Player-2/3.
            string lastvar = sss[0] + "..."; //L9-HW-Player-2/3.
            return lastvar; //L9-HW-Player-2/3.
        } 
    } 
    [Flags] //filterbygenres 
    public enum Genres // enum Genres
    { 
        Pop = 1, Rock = 2, Metal = 4, Electro = 8 //filterbygenres 
    } 
    class Program
    {
        //B5-Player7/10. OutRefParameters.
        public static int TotalDur;
        public static string Prop = "s";
        public static int CreateSong(List<Song> s, ref int xshort, ref int ylong, out string _shortname, out string _longname)
        {
            Random rnd = new Random();
            _shortname = Prop;
            _longname = Prop;
            for (int i = 0; i < s.Count; i++)
            {
                
                s[i] = new Song();
                s[i].title = "songN" + i;
                WriteLine(s[i].title);
                s[i].duration = rnd.Next(500);
                WriteLine(s[i].duration);
                TotalDur = TotalDur + s[i].duration;
                WriteLine($"iteration {i} " + TotalDur);
                if (s[i].duration < xshort)
                {
                    xshort = s[i].duration;
                    _shortname = s[i].title;
                }
                if (s[i].duration > ylong)
                {
                    ylong = s[i].duration;
                    _longname = s[i].title;
                }
            }
            WriteLine(xshort + " " + _shortname);
            WriteLine(ylong + " " + _longname);
            return TotalDur;
        }
        // helper
        public static string GeneratorRandomStrings()
            
        {
            Random rndgen = new Random();
            string randomstring = "s";
            for (int i = 1; i < 5; i++)
            {
                randomstring = randomstring + Convert.ToString((char)rndgen.Next(100));
            }
            WriteLine("Result random generate" + randomstring);
            return randomstring;
        }
        //B5-Player9/10. MethodOverloading and B5-Player6/10. MethodParameters. 
        public static Song InitSong()
        {
            Random rndDefault = new Random();
            Song defaultsong = new Song();
            defaultsong.title = GeneratorRandomStrings();
            defaultsong.duration = rndDefault.Next(500);
            defaultsong.album = new Album ();
            defaultsong.artist = new Artist();
            defaultsong.lyrics = GeneratorRandomStrings();
            defaultsong.songPath = GeneratorRandomStrings();
            defaultsong.playlists = new List<Playlist>();
            return defaultsong;
        }
        public static Song InitSong(string _name)
        {
            var defsong = InitSong();
            defsong.title = _name;
            return defsong;
        }
        public static Song InitSong(string _title, int dur, Album _album, Artist _artist, string _lyrics, List<Playlist> _playlist)
        {
            Song initsong = new Song();
            initsong.title = _title;
            initsong.duration = dur;
            initsong.album = _album;
            initsong.artist = _artist;
            initsong.lyrics = _lyrics;
            initsong.songPath = GeneratorRandomStrings();
            initsong.playlists = _playlist;
            return initsong;
        }
        //B5-Player10/10. DefaultAndNamedParamters.
        public static Artist AddArtist(string _name = "unknown artist")
        {
            Artist artist = new Artist();
            artist.name = _name;
            return artist;
        }
        public static Album AddAlbum(string _name = "unknown album", int _year = 0)
        {
            Album album = new Album();
            album.name = _name;
            album.year = _year;
            return album;
        }
        public static List<Song> FilterByGenres(List<Song> songs, Genres genre) //filterbygenres 
        { 
            List<Song> FilterdList = new List<Song>(); //filterbygenres 
            IEnumerable<Song> selectedSongs = from t in songs //filterbygenres 
                                              where (t.songGenre & genre) == genre //filterbygenres 
                                              select t; //filterbygenres 
            foreach (Song t in selectedSongs) //filterbygenres 
            { 
                    FilterdList.Add(t); //filterbygenres 
            } 
            return FilterdList; //filterbygenres 
        } 
        static void Main(string[] args)
        {
            Player player = new Player();
            List<Song> songList = new List<Song>(); 
            for (int i = 0; i < 25; i++) 
            {
                songList.Add(new Song { title = i + "sssssssssss", IsNext=false, duration = 540, songGenre=Genres.Pop });

                if (i == 8 || i == 7 || i == 23 || i == 24) { songList[i].songGenre = Genres.Rock | Genres.Pop; }
                if (i == 1 || i == 2 || i == 20 || i == 13) { songList[i].songGenre = Genres.Rock | Genres.Pop | Genres.Electro; }
                if (i == 3 || i == 5 || i == 15 || i == 22) { songList[i].songGenre = Genres.Rock | Genres.Metal; }

                if (i == 3 || i == 7 || i == 23) { songList[i].LikeMethod(); }  //try like\dislike
                if (i == 5 || i == 8 || i == 22 || i == 21) { songList[i].DislikeMethod(); } //try like\dislike
            }
            Genres testfilter = Genres.Rock | Genres.Pop; //filterbygenres 
            List<Song> ListAfterFilter = FilterByGenres(songList, testfilter); //filterbygenres 
            player.ListSong(ListAfterFilter); //filterbygenres 
            // B5-Player2/10. Fields.
            Song song1 = new Song();
            song1.duration = 300;
            song1.title = "Cvet nastroenia sinii";
            //song1.songGenre = "Metal";
            song1.lyrics = "lalala";
            song1.artist = new Artist{name = "Kirkorov"};

            // B5-Player2/10. Fields.
            Song song2 = new Song();
            song2.duration = 300;
            song2.title = "Anaconda";
            //song2.songGenre = "Pop";
            song2.lyrics = "lalala";
            song2.artist = new Artist
            {
                name = "Minaj",
                band = new Band
                {
                    bandYear = 1988,
                    isExist = true
                }
            };
            song2.album = new Album
            {
                name = "MinajAlbum",
                path = "pathAlbum",
                year = 1988
            };
            
            song2.artist.band.bandTitle = "MinajBand";
            

            WriteLine("Now we try to use your keyboard");

            
            while (true)
            {
                switch (ReadLine())
                {
                    case "a":
                        {
                            player.VolumeUp();
                            break;
                        }
                    case "s":
                        {
                            player.VolumeDown();
                            break;
                        }
                    case "d":
                        {
                            player.Play();
                            break;
                        }
                    case "q":
                        {
                            player.Lock();
                            break;
                        }
                    case "w":
                        {
                            player.UnLock();
                            break;
                        }
                    case "e":
                        {
                            player.Start();
                            break;
                        }
                    case "r":
                        {
                            player.Stop();
                            break;
                        }

                }
            }



            ReadLine();
        }
    }
}