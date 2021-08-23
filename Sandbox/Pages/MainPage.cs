using System;
using System.Collections.Generic;
using System.Text;
using Graphite;
using Graphite.Controls;
using Graphite.Typography;
using ReMarkable.NET.Unix.Driver;
using SixLabors.Fonts;
using SixLabors.ImageSharp;

namespace Sandbox.Pages
{
    class MainPage : Panel
    {
        /// <inheritdoc />
        public override void LayoutControls()
        {
            //Create Status Bar
            var bottomToolbar = new HorizontalStackPanel
            {
                Size = new SizeF(Size.Width, 40)
            };
            bottomToolbar.Location = new PointF(0, Bounds.Height - bottomToolbar.Size.Height);
            
            bottomToolbar.Add(new WiFiIndicator
            {
                Size = new SizeF(50, 40),
                TextAlign = RectAlign.Top | RectAlign.Center
            });
            bottomToolbar.Add(new BatteryIndicator
            {
                Size = new SizeF(50, 40),
                TextAlign = RectAlign.Top | RectAlign.Center
            });
            bottomToolbar.Add(new Label
            {
                Text = $"{PassiveDevices.Battery.GetPercentage()*100:F0}%",
                Font = Fonts.SegoeUi.CreateFont(28),
                TextAlign = RectAlign.Top | RectAlign.Center,
                Size = new SizeF(80, 40)
            });

            Add(bottomToolbar);

            //Create Exit button

            Add(new Label
            {
                Text = "Click to Exit",
                Font = Fonts.SegoeUi.CreateFont(28),
                TextAlign = RectAlign.Top | RectAlign.Center,
                Size = new SizeF(80, 40),
                Location = new PointF((Bounds.Width / 2) - (80/2), (((Bounds.Height - bottomToolbar.Size.Height) / 2) - 100) -40)
            });

            var exitButton = new Graphite.Controls.Button
            {
                Size = new SizeF(400, 100),
                Text = "Quit",
                Font = Fonts.SegoeUi.CreateFont(28),
                ForegroundColor = Color.Black,
                TextAlign = RectAlign.Top | RectAlign.Center,
                Location = new PointF((Bounds.Width / 2) - (400 / 2), ((Bounds.Height - bottomToolbar.Size.Height)/2) - 100)
            };

            exitButton.FingerPress += ExitButton_FingerPress;
            exitButton.StylusPress += ExitButton_StylusPress;

            Add(exitButton);
        }

        private void ExitButton_StylusPress(object sender, StylusPressEventArgs e)
        {
            var button = sender as Graphite.Controls.Button;
            button.Text = "Exiting";
        }

        private void ExitButton_FingerPress(object sender, ReMarkable.NET.Unix.Driver.Touchscreen.FingerState e)
        {
            var button = sender as Graphite.Controls.Button;
            button.Text = "Exiting";
        }
    }
}
