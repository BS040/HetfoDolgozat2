using ClassLibrary.Data;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private List<int> tippek = new List<int>();
        Adatbazis db = new Adatbazis();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(800, 700);
            btnSorsor.Enabled = false;
            panel.Size = new Size(550, 500);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    CheckBox box = new CheckBox();
                    box.Location = new Point(i * 50, j * 50);
                    box.AutoSize = true;
                    box.Text = (j * 8 + i + 1).ToString();
                    box.CheckedChanged += checkBox1_CheckedChanged;
                    panel.Controls.Add(box);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var box = (CheckBox)sender;
            if (box.Checked)
            {
                tippek.Add(Convert.ToInt32(box.Text));
                if (tippek.Count == 6)
                {
                    btnSorsor.Enabled = true;
                    kapcsol();
                }
            }
            else
            {
                tippek.Remove(Convert.ToInt32(box.Text));
                if (tippek.Count == 5)
                {
                    btnSorsor.Enabled = false;
                    kapcsol();

                }
            }
        }
        private void kapcsol()
        {
            if (tippek.Count == 6)
                foreach (CheckBox box in panel.Controls)
                {

                    if (!box.Checked) box.Enabled = false;
                }
            else
                foreach (CheckBox box in panel.Controls)
                {
                    box.Enabled = true;
                }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSorsor_Click(object sender, EventArgs e)
        {
            HashSet<int> keszlet = new HashSet<int>();

            Random rnd = new Random();

            do
            {
                keszlet.Add(rnd.Next(1,49));
            } while (keszlet.Count() != 6);

            lbl.Text = "Sorsolt számok: ";
            lbl.Text += string.Join("; ", keszlet) + "\n";
            lbl.Text += "Leadott tippek: ";
            lbl.Text += string.Join("; ", tippek) + "\n";
            lbl.Text += "Eltalált számok: ";
            lbl.Text += string.Join("; ", keszlet.Intersect(tippek));

            db.Huzas.Add(new ClassLibrary.Models.Huzas(string.Join(";", keszlet)));
            db.SaveChanges();   
        }
    }
}
