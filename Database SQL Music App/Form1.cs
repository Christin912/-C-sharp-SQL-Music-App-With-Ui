namespace Database_SQL_Music_App
{
    public partial class Form1 : Form
    {
        BindingSource albumBindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            Album a1 = new Album

            {
                ID = 1,
                AlbumName = "The Dark Side of the Moon",
                ArtistName = "Pink Floyd",
                ReleaseYear = 1973,
                ImageURL = "https://example.com/darkside.jpg",
                description = "A landmark album in rock history."
            };
            Album a2 = new Album
            {
                ID = 1,
                AlbumName = "The darker Side of the Moon",
                ArtistName = "Pink man",
                ReleaseYear = 1973,
                ImageURL = "https://example.com/darkside.jpg",
                description = "A landmark album in rock history."


            };
            albumsDAO.albums.Add(a1);
            albumsDAO.albums.Add(a2);

            //connect the list to the grid view
            albumBindingSource.DataSource = albumsDAO.albums;

            dataGridView1.DataSource = albumBindingSource;


        }
    }
}
    