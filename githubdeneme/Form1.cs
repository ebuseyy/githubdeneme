using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace githubdeneme
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-520STTO;Database=OGRDENEME;User Id=sa;Password=12345; Encrypt=false;");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into ogrenci (adi,soyadi) values('"+textBox1.Text+"','"+textBox2.Text+"')",baglanti);
            int sonuc=komut.ExecuteNonQuery();
            if (sonuc>0)
            {
                MessageBox.Show("kayýt baþarýlý");
           
                getir();
            }

            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("update ogrenci set Adi='"+textBox1.Text+"', Soyadi='"+textBox2.Text+"' where OgrID="+textBox3.Text+"",baglanti);
            
            int sonuc = komut.ExecuteNonQuery();
            if (sonuc > 0)
            {
                MessageBox.Show("güncelleme baþarýlý");
                getir();
            }

            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("delete from ogrenci where OgrID="+textBox3.Text+"",baglanti);
            int sonuc=komut.ExecuteNonQuery();
            if (sonuc>0)
            {
                MessageBox.Show("Silme baþarýlý");
                getir();
            }
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            getir();
        }

        public void getir()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Ogrenci", baglanti);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int sirano = dataGridView1.CurrentCell.RowIndex;

            textBox3.Text = dataGridView1.Rows[sirano].Cells["OgrID"].Value.ToString();

            textBox1.Text = dataGridView1.Rows[sirano].Cells["Adi"].Value.ToString();

            textBox2.Text = dataGridView1.Rows[sirano].Cells["Soyadi"].Value.ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.label1.Text = textBox3.Text;
            frm.ShowDialog();
        }
    }

 
}