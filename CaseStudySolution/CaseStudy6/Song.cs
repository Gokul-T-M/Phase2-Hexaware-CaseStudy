using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy6
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string SongGenre { get; set; }

        public Song(int songId, string songName, string songGenre)
        {
            SongId = songId;
            SongName = songName;
            SongGenre = songGenre;
        }
    }

}
