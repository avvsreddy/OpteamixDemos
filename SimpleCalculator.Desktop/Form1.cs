namespace SimpleCalculator.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fno = int.Parse(textBox1.Text);
            int sno = int.Parse(textBox2.Text);
            int result = SimpleCalculator.BusinessLogic.Calculator.Add(fno, sno);
            MessageBox.Show($"The sum of {fno} and {sno} is {result}");
        }
    }
}
