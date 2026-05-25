namespace MTDemoWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // red
            new Thread(() =>
            {
                Graphics g = panel1.CreateGraphics();
                Random rand = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    int x = rand.Next(panel1.Width);
                    int y = rand.Next(panel1.Height);
                    g.DrawRectangle(Pens.Red, x, y, 10, 10);
                    Thread.Sleep(10);
                }
            }).Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // blue
            Task.Factory.StartNew(() =>
            {
                Graphics g = panel2.CreateGraphics();
                Random rand = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    int x = rand.Next(panel2.Width);
                    int y = rand.Next(panel2.Height);
                    g.DrawRectangle(Pens.Blue, x, y, 10, 10);
                    Thread.Sleep(10);
                }
            });
        }
    }
}
