using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy6
{
    using System.Collections.Generic;

    public interface IPlaylist
    {
        void Add(Song song);
        void Remove(int songId);
        Song GetSongById(int songId);
        Song GetSongByName(string songName);
        List<Song> GetAllSongs();
    }

}
