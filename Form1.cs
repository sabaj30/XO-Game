namespace XO_Game
{
    public partial class Form1 : Form
    {
        private char turn = 'X';
        private readonly Button[] buttons = new Button[9];

        public Form1()
        {
            InitializeComponent();
            CreateGameField();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateGameField()
        {
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < 9; i++)
            {
                buttons[i] = new Button
                {
                    Text = "",
                    Size = new Size(200, 200),
                    Font = new Font("Segoe UI", 18F)
                };
                buttons[i].Click += Button_Click;

                flowLayoutPanel1.Controls.Add(buttons[i]);
            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Text != "") return;

            btn.Text = turn.ToString();
            btn.Enabled = false;

            if (CheckGameStatus()) return;

            SwitchTurn();
        }

        private void SwitchTurn() => turn = (turn == 'X') ? 'O' : 'X';

        private bool CheckGameStatus()
        {
            if (IsWinner())
            {
                ShowResult($"Winner is {turn} ");
                return true;
            }

            if (IsDraw())
            {
                ShowResult("Try Again");
                return true;
            }

            return false;
        }

        private bool IsWinner()
        {
            int[][] winningCombinations = {
                new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 },
                new[] { 0, 3, 6 }, new[] { 1, 4, 7 }, new[] { 2, 5, 8 },
                new[] { 0, 4, 8 }, new[] { 2, 4, 6 }
            };

            return winningCombinations.Any(combo =>
                buttons[combo[0]].Text == turn.ToString() &&
                buttons[combo[1]].Text == turn.ToString() &&
                buttons[combo[2]].Text == turn.ToString());
        }

        private bool IsDraw() => buttons.All(btn => btn.Text != "");

        private void ShowResult(string message)
        {
            MessageBox.Show(message, "نتیجه بازی");
            ResetGame();
        }

        private void ResetGame()
        {
            foreach (var btn in buttons)
            {
                btn.Text = "";
                btn.Enabled = true;
            }
            turn = 'X';
        }
    }
}
