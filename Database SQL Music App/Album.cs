using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_SQL_Music_App
{
    internal class Album
    {
        public int ID { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public int ReleaseYear { get; set; }
        public string ImageURL { get; set; }
        public string description { get; set; }

        // coming soon: public List<Song> Songs { get; set; } songs in album
    }
}
