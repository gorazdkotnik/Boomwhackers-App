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

        private int moveSpeed;
        private int animateSpeed;
        
        private Point destroyLocation;
        // Data needed for animation

        public CControlAnimator(int moveSpeed, int animateSpeed, Point destroyLocation)
        {
            this.moveSpeed = moveSpeed;
            this.destroyLocation = destroyLocation;
            this.animateSpeed = animateSpeed;
            
            timer = new Timer();
            timer.Tick += TimerTick;
            timer.Interval = this.animateSpeed;
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
                    control.Location = new Point(control.Location.X, control.Location.Y + moveSpeed);
                }
            }
        }
    }
}
