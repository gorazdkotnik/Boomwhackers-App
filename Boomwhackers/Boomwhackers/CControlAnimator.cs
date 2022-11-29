using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boomwhackers
{
    public class CControlAnimator : IAnimator
    {
        public Control control { get; set; }
        private Timer timer;

        private int moveAmount;
        private int animateInterval;
        
        private Point destroyLocation;
        // Data needed for animation

        public CControlAnimator(int moveAmount, int animateInterval, Point destroyLocation)
        {
            this.moveAmount = moveAmount;
            this.destroyLocation = destroyLocation;
            this.animateInterval = animateInterval;
            
            timer = new Timer();
            timer.Tick += TimerTick;
            timer.Interval = this.animateInterval;
        }

        public CControlAnimator(int moveSpeed, int animateSpeed) : this(moveSpeed, animateSpeed, new Point(-1, -1)) { }

        public CControlAnimator() : this(1, 1) { }

        public virtual void Start()
        {
            timer.Enabled = true;
        }

        public virtual void Stop()
        {
            timer.Enabled = false;
        }

        public void TimerTick(object sender, EventArgs e)
        {
            // Do the animation
            if (control != null)
            {
                if (control.Location.Y == destroyLocation.Y && destroyLocation.Y != -1)
                {
                    control.Dispose();
                    Stop();
                }
                else
                {
                    control.Location = new Point(control.Location.X, control.Location.Y + moveAmount);
                }
            }
        }
    }
}
