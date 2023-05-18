namespace WinFormsApp3
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }
        
        Point point;
        Button button;
        static bool clickForm = false;

        private void CreateButtons()
        {
            button = new();
            button.Text = "0_0";
            this.Controls.Add(button);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            clickForm = true;
            point = new(e.X, e.Y);
            CreateButtons();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) => clickForm = false;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clickForm)
            {
                if (e.X < point.X)
                {
                    if (e.Y < point.Y)
                    {
                        button.Location = new(point.X - button.Width, point.Y - button.Height);
                        button.Size = new(point.X - e.X, point.Y - e.Y);
                    }
                    else
                    {
                        button.Location = new(point.X - button.Width, point.Y);
                        button.Size = new(point.X - e.X, e.Y - point.Y);
                    }
                }
                else
                {
                    if (e.Y < point.Y)
                    {
                        button.Location = new(point.X, point.Y - button.Height);
                        button.Size = new(e.X - point.X, point.Y - e.Y);
                    }
                    else
                    {
                        button.Location = new(point.X, point.Y);
                        button.Size = new(e.X - point.X, e.Y - point.Y);
                    }
                }
            }
        }
    }
}