﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cb0t
{
    public partial class EmoticonMenu : Form
    {
        public EmoticonMenu()
        {
            this.InitializeComponent();
            this.ClientSize = new Size(224, 224);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.emRegMenu1.EmoticonClicked += this.RegEmoticonClicked;

            for (int i = 0; i < Emoticons.ex_emotic.Length; i++)
            {
                ExtEm ee = new ExtEm(Emoticons.ex_emotic[i]);
                ee.BackColor = Color.White;
                ee.Size = new System.Drawing.Size(50, 50);
                ee.Location = new Point(1 + ((i % 4) * 50) + (i % 4), 1 + ((i / 4) * 50) + (i / 4));
                ee.Click += this.EmoticonClicked;
                this.emExtMenu1.Controls.Add(ee);
            }
        }

        private RoomPanel callback = null;

        public void SetCallback(RoomPanel cb)
        {
            this.callback = cb;
        }

        private void EmoticonMenu_Deactivate(object sender, EventArgs e)
        {
            this.callback = null;
            this.Hide();
        }

        private void RegEmoticonClicked(object sender, EmoticonShortcutEventArgs e)
        {
            if (this.callback != null)
            {
                this.callback.EmoticonCallback(e.Shortcut);
                this.callback = null;
            }

            this.Hide();
        }

        private void EmoticonClicked(object sender, EventArgs e)
        {
            String shortcut = ((ExtEm)sender).ShortcutText;

            if (this.callback != null)
            {
                this.callback.EmoticonCallback("(" + shortcut + ")");
                this.callback = null;
            }

            this.Hide();
        }
    }
}