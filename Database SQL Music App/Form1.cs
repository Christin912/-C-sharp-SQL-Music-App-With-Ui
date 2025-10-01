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

        private void LoadImageWithHeaders(string url)
        {
            var request = System.Net.WebRequest.Create(url);
            // Set a browser-like User-Agent header
            request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36");

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBox1.Image = System.Drawing.Image.FromStream(stream);
            }
        }

        // Example usage in your button click handler:
        private void button1_Click_1(object sender, EventArgs e)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            //connect the list to the grid view
            albumBindingSource.DataSource = albumsDAO.GetAllAlbums();

            dataGridView1.DataSource = albumBindingSource;

                  LoadImageWithHeaders("https://upload.wikimedia.org/wikipedia/en/4/42/Beatles_-_Abbey_Road.jpg");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();
            //connect the list to the grid view
            albumBindingSource.DataSource = albumsDAO.searchTitles
                (textBox1.Text);

            dataGridView1.DataSource = albumBindingSource;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            //get row number clikced
            int rowClicked = dataGridView.CurrentRow.Index;
            // MessageBox.Show("Row clicked: " + rowClicked);

            String imageURL = dataGridView.Rows[rowClicked].Cells[4].Value.ToString();

            // MessageBox.Show("URL="+ imageURL);

            LoadImageWithHeaders(imageURL);
        }   
    }
}