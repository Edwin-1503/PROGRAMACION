namespace Sistema_de_Gestión_de_Reservas_de_Gimnasio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            Usuario u = new Usuario
            {
                Id = nextUserId++,
                Nombre = txtNombre.Text,
                Correo = txtCorreo.Text
            };

            usuarios.Add(u);
            cmbUsuarios.Items.Add(u);
            cmbUsuarios.DisplayMember = "Nombre";
            MessageBox.Show("Usuario registrado.");
        }


    }
}
