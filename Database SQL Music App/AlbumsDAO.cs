using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_SQL_Music_App
{
    internal class AlbumsDAO
    {
        string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=music;";

        public List<Album> GetAllAlbums()
        {          
            List<Album> returnThese = new List<Album>();
            //code to connect to database and retrieve all albums
            
            MySqlConnection connection = new MySqlConnection
                (connectionString);
            connection.Open();

            //define the query
            MySqlCommand command = new MySqlCommand
                ("SELECT ID, ALBUM_TITLE, ARTIST, YEAR, IMAGE_NAME, DESCRIPTION FROM albums", connection);
            using (MySqlDataReader reader = command.ExecuteReader())

            {
                while (reader.Read())
                {
                    Album a = new Album
                    {
                        ID = reader.GetInt32(0),
                        AlbumName = reader.GetString(1),
                        ArtistName = reader.GetString(2),
                        ReleaseYear = reader.GetInt32(3),
                        ImageURL = reader.GetString(4),
                        Description = reader.GetString(5)
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();

            return returnThese;
        }

        public List<Album> searchTitles(String searchTerm)
        {
            List<Album> returnThese = new List<Album>();
            //code to connect to database and retrieve all albums

            MySqlConnection connection = new MySqlConnection
                (connectionString);
            connection.Open();

            String searchWildPhrase = "%" + searchTerm + "%";
            //define the query
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT ID, ALBUM_TITLE, ARTIST, YEAR, IMAGE_NAME, DESCRIPTION FROM ALBUMS WHERE ALBUM_TITLE LIKE @search";
            command.Parameters.AddWithValue("@search", searchWildPhrase);
            command.Connection = connection;

            using (MySqlDataReader reader = command.ExecuteReader())

            {
                while (reader.Read())
                {
                    Album a = new Album
                    {
                        ID = reader.GetInt32(0),
                        AlbumName = reader.GetString(1),
                        ArtistName = reader.GetString(2),
                        ReleaseYear = reader.GetInt32(3),
                        ImageURL = reader.GetString(4),
                        Description = reader.GetString(5)
                    };
                    returnThese.Add(a);
                }
            }
            connection.Close();

            return returnThese;
        }
    }
}

