using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is used at the side panel texts
namespace RiceInventorySystem {
    public class CustomLabel : Label {
        private Label label1;

        public CustomLabel() {
            this.SetStyle(ControlStyles.UserPaint, true); //Call in constructor, Use UserPaint
        }

        protected override void OnPaint(PaintEventArgs e) {
            //Change disable color instead of using the default gray color
            if (!Enabled) {
                SolidBrush drawBrush = new SolidBrush(Color.WhiteSmoke); //Choose disable label color

                e.Graphics.DrawString(Text, Font, drawBrush, 0f, 0f); //Draw whatever text was on the label
            }
            else {
                base.OnPaint(e); //Default Forecolours
            }
        }

        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.ResumeLayout(false);

        }

        private void label1_Click(object sender, EventArgs e) {

        }
    }
}
