namespace StudentHouses
{
    partial class ViewEventcs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Event = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.lblOrg = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblOrganizer = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.Event.SuspendLayout();
            this.SuspendLayout();
            // 
            // Event
            // 
            this.Event.Controls.Add(this.lblTitle);
            this.Event.Controls.Add(this.lblR);
            this.Event.Controls.Add(this.lblOrg);
            this.Event.Controls.Add(this.lblData);
            this.Event.Controls.Add(this.textBox);
            this.Event.Controls.Add(this.lblDesc);
            this.Event.Controls.Add(this.lblRoom);
            this.Event.Controls.Add(this.lblOrganizer);
            this.Event.Controls.Add(this.lblDate);
            this.Event.Controls.Add(this.Title);
            this.Event.Location = new System.Drawing.Point(12, 12);
            this.Event.Name = "Event";
            this.Event.Size = new System.Drawing.Size(728, 340);
            this.Event.TabIndex = 0;
            this.Event.TabStop = false;
            this.Event.Text = "Event View";
            this.Event.Enter += new System.EventHandler(this.Event_Enter);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblTitle.Location = new System.Drawing.Point(378, 41);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(70, 26);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "label4";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblR.Location = new System.Drawing.Point(625, 98);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(70, 26);
            this.lblR.TabIndex = 8;
            this.lblR.Text = "label3";
            // 
            // lblOrg
            // 
            this.lblOrg.AutoSize = true;
            this.lblOrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblOrg.Location = new System.Drawing.Point(404, 98);
            this.lblOrg.Name = "lblOrg";
            this.lblOrg.Size = new System.Drawing.Size(70, 26);
            this.lblOrg.TabIndex = 7;
            this.lblOrg.Text = "label2";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblData.Location = new System.Drawing.Point(127, 98);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(70, 26);
            this.lblData.TabIndex = 6;
            this.lblData.Text = "label1";
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBox.Location = new System.Drawing.Point(45, 229);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(650, 91);
            this.textBox.TabIndex = 5;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold);
            this.lblDesc.Location = new System.Drawing.Point(50, 184);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(146, 30);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description:";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold);
            this.lblRoom.Location = new System.Drawing.Point(535, 94);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(84, 30);
            this.lblRoom.TabIndex = 3;
            this.lblRoom.Text = "Room:";
            // 
            // lblOrganizer
            // 
            this.lblOrganizer.AutoSize = true;
            this.lblOrganizer.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold);
            this.lblOrganizer.Location = new System.Drawing.Point(270, 94);
            this.lblOrganizer.Name = "lblOrganizer";
            this.lblOrganizer.Size = new System.Drawing.Size(128, 30);
            this.lblOrganizer.TabIndex = 2;
            this.lblOrganizer.Text = "Organizer:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(50, 94);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(71, 30);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date:";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft YaHei", 13F, System.Drawing.FontStyle.Bold);
            this.Title.Location = new System.Drawing.Point(289, 35);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(80, 34);
            this.Title.TabIndex = 0;
            this.Title.Text = "Title:";
            // 
            // ViewEventcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 367);
            this.Controls.Add(this.Event);
            this.Name = "ViewEventcs";
            this.Text = "ViewEventcs";
            this.Event.ResumeLayout(false);
            this.Event.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Event;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblOrganizer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Label lblOrg;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.TextBox textBox;
    }
}