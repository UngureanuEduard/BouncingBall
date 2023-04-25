namespace BouncingBall
{
    public partial class Form1 : Form
    {
        private int ballWidth = 70;
        private int ballHeight = 70;
        private int ballPosX = 0;
        private int ballPosY = 0;
        private int moveStepX = 4;
        private int moveStepY = 4;
        private int rectX, rectY;
        private Color selectedColor;
        public Form1()
        {
            InitializeComponent();
        }

        private void PaintCircle(object sender, PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(selectedColor))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.Clear(this.BackColor);

                e.Graphics.FillEllipse(brush, ballPosX, ballPosY, ballWidth, ballHeight);
                e.Graphics.DrawEllipse(Pens.Black, ballPosX, ballPosY, ballWidth, ballHeight);
            }

            using (Pen pen = new Pen(Color.Black, 2))
            {
                rectX = (this.ClientSize.Width - 700) / 2;
                rectY = (this.ClientSize.Height - 400) / 2;
                Rectangle rect = new Rectangle(rectX, rectY, 700, 400);
                e.Graphics.DrawRectangle(pen, rect);
            }

        }

        private void MoveBall(object sender, EventArgs e)
        {
            ballPosX = ballPosX + moveStepX;
            ballPosY = ballPosY + moveStepY;

            if (ballPosX < rectX || ballPosX + ballWidth > rectX + 700)
            {
                moveStepX = -moveStepX;
                ballPosX = Math.Max(ballPosX, rectX);
                ballPosX = Math.Min(ballPosX, rectX + 700 - ballWidth);
            }

            if (ballPosY < rectY || ballPosY + ballHeight > rectY + 400)
            {
                moveStepY = -moveStepY;
                ballPosY = Math.Max(ballPosY, rectY);
                ballPosY = Math.Min(ballPosY, rectY + 400 - ballHeight);
            }

            this.Invalidate();
        }

        private void culoareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
            }
        }
    }
}