using System.Windows.Forms;

namespace XO
{
    public partial class Form1 : Form
    {
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(636, 624);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            ClientSize = new Size(636, 624);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            ResumeLayout(false);

        }
        private char turn = 'X';
        public Form1()
        {
            InitializeComponent();
            CreateGameField();
        }

        public void CreateGameField()
        {
            Button[] buttons = new Button[9];
            for (int i = 0; i < 9; i++)
            {
                buttons[i] = new Button();
                buttons[i].Text = (i + 1).ToString();
                buttons[i].Size = new Size(200, 200);
                buttons[i].Font = new Font("Segoe UI", 18F);
                buttons[i].Click += Button_Click;
            }

            flowLayoutPanel1.Controls.AddRange(buttons);
        }

        public void Button_Click(object? sender, EventArgs e)
        {
            var btn = sender as Button;
            btn.Text = turn.ToString();
            ChangeTurn();
            btn.Enabled = false;
        }

        private void ChangeTurn()
        {
            _ = turn == 'X' ? turn = 'O' : turn = 'X';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

