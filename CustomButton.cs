using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab3
{
    public class CustomButton : Button
    {
        private readonly Color gradientStart = Color.FromArgb(2, 238, 255);
        private readonly Color gradientEnd = Color.FromArgb(150, 239, 246);

        private readonly Color hoverStart = Color.FromArgb(200, 187, 255);
        private readonly Color hoverEnd = Color.FromArgb(142, 130, 194);

        private readonly Color clickStart = Color.FromArgb(37, 18, 232);
        private readonly Color clickEnd = Color.FromArgb(19, 5, 126);

        private Color currentStart;
        private Color currentEnd;

        private readonly System.Windows.Forms.Timer animationTimer;
        private float animationProgress = 0f;
        private const float AnimationStep = 0.05f;

        public CustomButton()
        {
            currentStart = gradientStart;
            currentEnd = gradientEnd;

            animationTimer = new System.Windows.Forms.Timer { Interval = 16 };
            animationTimer.Tick += (s, e) =>
            {
                if (animationProgress < 1f)
                {
                    animationProgress += AnimationStep;
                    currentStart = BlendColors(gradientStart, targetStart, animationProgress);
                    currentEnd = BlendColors(gradientEnd, targetEnd, animationProgress);
                    Invalidate();
                }
                else
                {
                    animationTimer.Stop();
                }
            };
        }

        private Color targetStart;
        private Color targetEnd;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.ForeColor = this.ForeColor = Color.FromArgb(41, 19, 83);
            StartAnimation(hoverStart, hoverEnd);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            StartAnimation(gradientStart, gradientEnd);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            this.ForeColor = Color.White;
            StartAnimation(clickStart, clickEnd);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            this.ForeColor = this.ForeColor = Color.FromArgb(0, 54, 130);
            StartAnimation(hoverStart, hoverEnd);
        }

        private void StartAnimation(Color newStart, Color newEnd)
        {
            targetStart = newStart;
            targetEnd = newEnd;
            animationProgress = 0f;
            animationTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (LinearGradientBrush brush = new(this.ClientRectangle, currentStart, currentEnd, LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            TextRenderer.DrawText(
                g,
                this.Text,
                this.Font,
                ClientRectangle,
                this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private static Color BlendColors(Color color1, Color color2, float percentage)
        {
            int r = (int)(color1.R + (color2.R - color1.R) * percentage);
            int g = (int)(color1.G + (color2.G - color1.G) * percentage);
            int b = (int)(color1.B + (color2.B - color1.B) * percentage);
            return Color.FromArgb(r, g, b);
        }
    }
}
