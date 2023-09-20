namespace KarateWindowsFormsApplication
{
    partial class FrmEditME_IN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditME_IN));
            this.label6 = new System.Windows.Forms.Label();
            this.btnEdit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtME_IN_ID = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnSearch = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCards1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataview)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(360, 84);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(497, 136);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(60, 132);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(521, 84);
            this.dateTimePicker1.onValueChanged += new System.EventHandler(this.dateTimePicker1_onValueChanged);
            // 
            // btnCanacel
            // 
            this.btnCanacel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCanacel.IconRightVisible = true;
            this.btnCanacel.IconVisible = true;
            this.btnCanacel.IconZoom = 70D;
            this.btnCanacel.Location = new System.Drawing.Point(229, 366);
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.Controls.Add(this.btnSearch);
            this.bunifuCards1.Controls.Add(this.btnEdit);
            this.bunifuCards1.Controls.Add(this.txtME_IN_ID);
            this.bunifuCards1.Controls.Add(this.label6);
            this.bunifuCards1.Location = new System.Drawing.Point(344, 193);
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.Size = new System.Drawing.Size(824, 442);
            this.bunifuCards1.Controls.SetChildIndex(this.label6, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.txtME_IN_ID, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.btnEdit, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.btnSearch, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.btnAdd, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.label1, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.label2, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.label3, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.listboxMembers, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.listboxInstructor, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.bunifuCards1.Controls.SetChildIndex(this.btnCanacel, 0);
            // 
            // listboxMembers
            // 
            this.listboxMembers.Location = new System.Drawing.Point(64, 158);
            this.listboxMembers.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listboxInstructor
            // 
            this.listboxInstructor.Location = new System.Drawing.Point(501, 161);
            this.listboxInstructor.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // btnAdd
            // 
            this.btnAdd.IconRightVisible = true;
            this.btnAdd.IconVisible = true;
            this.btnAdd.Location = new System.Drawing.Point(439, 366);
            // 
            // btnFrmDelMemberInstructor
            // 
            this.btnFrmDelMemberInstructor.IconRightVisible = true;
            this.btnFrmDelMemberInstructor.IconVisible = true;
            // 
            // btnFrmEditMemberInstructor
            // 
            this.btnFrmEditMemberInstructor.IconRightVisible = true;
            this.btnFrmEditMemberInstructor.IconVisible = true;
            // 
            // btnFrmAddMemberInstructor
            // 
            this.btnFrmAddMemberInstructor.BackColor = System.Drawing.Color.Gray;
            this.btnFrmAddMemberInstructor.IconRightVisible = true;
            this.btnFrmAddMemberInstructor.IconVisible = true;
            // 
            // btnFrmMembersInstructorsList
            // 
            this.btnFrmMembersInstructorsList.IconRightVisible = true;
            this.btnFrmMembersInstructorsList.IconVisible = true;
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(11)))));
            // 
            // btnFrmSubscription
            // 
            this.btnFrmSubscription.FlatAppearance.BorderSize = 0;
            this.btnFrmSubscription.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmSubscription.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmSubscription.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(11)))));
            // 
            // btnFrmPayment
            // 
            this.btnFrmPayment.FlatAppearance.BorderSize = 0;
            this.btnFrmPayment.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(11)))));
            // 
            // btnFrmBeltTest
            // 
            this.btnFrmBeltTest.FlatAppearance.BorderSize = 0;
            this.btnFrmBeltTest.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmBeltTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmBeltTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(11)))));
            // 
            // btnFrmBeltRanks
            // 
            this.btnFrmBeltRanks.FlatAppearance.BorderSize = 0;
            this.btnFrmBeltRanks.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmBeltRanks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmBeltRanks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(11)))));
            // 
            // btnFrmMembersInstructor
            // 
            this.btnFrmMembersInstructor.FlatAppearance.BorderSize = 0;
            this.btnFrmMembersInstructor.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmMembersInstructor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmMembersInstructor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(11)))));
            // 
            // btnFrmUsers
            // 
            this.btnFrmUsers.FlatAppearance.BorderSize = 0;
            this.btnFrmUsers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(11)))));
            // 
            // btnFrmInstructor
            // 
            this.btnFrmInstructor.FlatAppearance.BorderSize = 0;
            this.btnFrmInstructor.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmInstructor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmInstructor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(11)))));
            // 
            // btnFrmMembers
            // 
            this.btnFrmMembers.FlatAppearance.BorderSize = 0;
            this.btnFrmMembers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmMembers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFrmMembers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(11)))));
            // 
            // btnFrmDashboard
            // 
            this.btnFrmDashboard.FlatAppearance.BorderSize = 0;
            this.btnFrmDashboard.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnFrmDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(74)))));
            this.btnFrmDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(108)))), ((int)(((byte)(11)))));
            // 
            // btnCloseFrm
            // 
            this.btnCloseFrm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCloseFrm.FlatAppearance.BorderSize = 0;
            this.btnCloseFrm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnCloseFrm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Imprint MT Shadow", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(74)))));
            this.label6.Location = new System.Drawing.Point(139, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 46);
            this.label6.TabIndex = 105;
            this.label6.Text = "Members Instructors \r\nID";
            // 
            // btnEdit
            // 
            this.btnEdit.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(28)))), ((int)(((byte)(228)))), ((int)(((byte)(31)))));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.BorderRadius = 7;
            this.btnEdit.ButtonText = "Save";
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.DisabledColor = System.Drawing.Color.Gray;
            this.btnEdit.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEdit.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnEdit.Iconimage")));
            this.btnEdit.Iconimage_right = null;
            this.btnEdit.Iconimage_right_Selected = null;
            this.btnEdit.Iconimage_Selected = null;
            this.btnEdit.IconMarginLeft = 0;
            this.btnEdit.IconMarginRight = 0;
            this.btnEdit.IconRightVisible = true;
            this.btnEdit.IconRightZoom = 0D;
            this.btnEdit.IconVisible = true;
            this.btnEdit.IconZoom = 75D;
            this.btnEdit.IsTab = false;
            this.btnEdit.Location = new System.Drawing.Point(439, 366);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(28)))), ((int)(((byte)(228)))), ((int)(((byte)(31)))));
            this.btnEdit.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnEdit.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEdit.selected = false;
            this.btnEdit.Size = new System.Drawing.Size(137, 39);
            this.btnEdit.TabIndex = 107;
            this.btnEdit.Text = "Save";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEdit.Textcolor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEdit.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtME_IN_ID
            // 
            this.txtME_IN_ID.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtME_IN_ID.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(59)))), ((int)(((byte)(74)))));
            this.txtME_IN_ID.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtME_IN_ID.BorderThickness = 3;
            this.txtME_IN_ID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtME_IN_ID.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtME_IN_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtME_IN_ID.isPassword = false;
            this.txtME_IN_ID.Location = new System.Drawing.Point(352, 12);
            this.txtME_IN_ID.Margin = new System.Windows.Forms.Padding(4);
            this.txtME_IN_ID.Name = "txtME_IN_ID";
            this.txtME_IN_ID.Size = new System.Drawing.Size(221, 44);
            this.txtME_IN_ID.TabIndex = 121;
            this.txtME_IN_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Image = global::KarateWindowsFormsApplication.Properties.Resources.icons8_search_30px;
            this.btnSearch.ImageActive = null;
            this.btnSearch.Location = new System.Drawing.Point(580, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 44);
            this.btnSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSearch.TabIndex = 113;
            this.btnSearch.TabStop = false;
            this.btnSearch.Zoom = 10;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmEditME_IN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1213, 660);
            this.ForeColor = System.Drawing.SystemColors.Info;
            this.Name = "FrmEditME_IN";
            this.Load += new System.EventHandler(this.FrmEditME_IN_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataview)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label label6;
        protected Bunifu.Framework.UI.BunifuFlatButton btnEdit;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtME_IN_ID;
        private Bunifu.Framework.UI.BunifuImageButton btnSearch;
    }
}
