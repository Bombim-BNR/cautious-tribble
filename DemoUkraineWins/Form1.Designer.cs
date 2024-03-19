namespace DemoUkraineWins
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            gbMap = new GroupBox();
            btnDeselect = new Button();
            lbCaptured = new Label();
            btnMobilize = new Button();
            btnAttack = new Button();
            btnTransport = new Button();
            gbNews = new GroupBox();
            lbNews = new Label();
            gbWorkspace = new GroupBox();
            lbToDo = new Label();
            btnCancel = new Button();
            gbInfo = new GroupBox();
            lbInfo = new Label();
            helpProvider1 = new HelpProvider();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            gbMap.SuspendLayout();
            gbNews.SuspendLayout();
            gbWorkspace.SuspendLayout();
            gbInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.ImageLocation = "map.png";
            pictureBox1.Location = new Point(6, 50);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(931, 808);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // gbMap
            // 
            gbMap.Controls.Add(btnDeselect);
            gbMap.Controls.Add(lbCaptured);
            gbMap.Controls.Add(pictureBox1);
            gbMap.Font = new Font("Cascadia Mono", 15F, FontStyle.Bold);
            gbMap.Location = new Point(12, 13);
            gbMap.Name = "gbMap";
            gbMap.Size = new Size(943, 864);
            gbMap.TabIndex = 3;
            gbMap.TabStop = false;
            gbMap.Text = "Map";
            // 
            // btnDeselect
            // 
            btnDeselect.BackColor = Color.SeaGreen;
            btnDeselect.FlatStyle = FlatStyle.Flat;
            btnDeselect.Font = new Font("Cascadia Mono", 13F, FontStyle.Bold);
            btnDeselect.Location = new Point(620, 817);
            btnDeselect.Name = "btnDeselect";
            btnDeselect.Size = new Size(317, 41);
            btnDeselect.TabIndex = 8;
            btnDeselect.Text = "Deselect";
            btnDeselect.UseVisualStyleBackColor = false;
            btnDeselect.Visible = false;
            btnDeselect.Click += btnDeselect_Click;
            // 
            // lbCaptured
            // 
            lbCaptured.AutoSize = true;
            lbCaptured.BackColor = Color.Transparent;
            lbCaptured.Font = new Font("Cascadia Mono", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbCaptured.ForeColor = Color.Black;
            lbCaptured.Location = new Point(6, 806);
            lbCaptured.Name = "lbCaptured";
            lbCaptured.Size = new Size(0, 52);
            lbCaptured.TabIndex = 3;
            // 
            // btnMobilize
            // 
            btnMobilize.BackColor = Color.SeaGreen;
            btnMobilize.Enabled = false;
            btnMobilize.FlatStyle = FlatStyle.Flat;
            btnMobilize.Font = new Font("Cascadia Mono", 20F, FontStyle.Bold);
            btnMobilize.Location = new Point(12, 42);
            btnMobilize.Name = "btnMobilize";
            btnMobilize.Size = new Size(528, 105);
            btnMobilize.TabIndex = 4;
            btnMobilize.Text = "Mobilize";
            btnMobilize.UseVisualStyleBackColor = false;
            btnMobilize.Click += btnMobilize_Click;
            // 
            // btnAttack
            // 
            btnAttack.BackColor = Color.SeaGreen;
            btnAttack.Enabled = false;
            btnAttack.FlatStyle = FlatStyle.Flat;
            btnAttack.Font = new Font("Cascadia Mono", 20F, FontStyle.Bold);
            btnAttack.Location = new Point(12, 153);
            btnAttack.Name = "btnAttack";
            btnAttack.Size = new Size(528, 105);
            btnAttack.TabIndex = 5;
            btnAttack.Text = "Attack";
            btnAttack.UseVisualStyleBackColor = false;
            btnAttack.Click += btnAttack_Click;
            // 
            // btnTransport
            // 
            btnTransport.BackColor = Color.SeaGreen;
            btnTransport.Enabled = false;
            btnTransport.FlatStyle = FlatStyle.Flat;
            btnTransport.Font = new Font("Cascadia Mono", 20F, FontStyle.Bold);
            btnTransport.Location = new Point(12, 264);
            btnTransport.Name = "btnTransport";
            btnTransport.Size = new Size(528, 105);
            btnTransport.TabIndex = 6;
            btnTransport.Text = "Transport";
            btnTransport.UseVisualStyleBackColor = false;
            btnTransport.Click += btnTransport_Click;
            // 
            // gbNews
            // 
            gbNews.Controls.Add(lbNews);
            gbNews.Font = new Font("Cascadia Mono", 15F, FontStyle.Bold);
            gbNews.Location = new Point(961, 670);
            gbNews.Name = "gbNews";
            gbNews.Size = new Size(546, 207);
            gbNews.TabIndex = 4;
            gbNews.TabStop = false;
            gbNews.Text = "News";
            // 
            // lbNews
            // 
            lbNews.AutoSize = true;
            lbNews.BackColor = Color.Transparent;
            lbNews.Font = new Font("Cascadia Mono", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbNews.Location = new Point(6, 50);
            lbNews.Name = "lbNews";
            lbNews.Size = new Size(505, 104);
            lbNews.TabIndex = 1;
            lbNews.Text = "All actions of russia\r\nwill be here";
            // 
            // gbWorkspace
            // 
            gbWorkspace.Controls.Add(lbToDo);
            gbWorkspace.Controls.Add(btnCancel);
            gbWorkspace.Controls.Add(btnMobilize);
            gbWorkspace.Controls.Add(btnTransport);
            gbWorkspace.Controls.Add(btnAttack);
            gbWorkspace.Font = new Font("Cascadia Mono", 15F, FontStyle.Bold);
            gbWorkspace.Location = new Point(961, 285);
            gbWorkspace.Name = "gbWorkspace";
            gbWorkspace.Size = new Size(546, 390);
            gbWorkspace.TabIndex = 3;
            gbWorkspace.TabStop = false;
            gbWorkspace.Text = "Workspace";
            // 
            // lbToDo
            // 
            lbToDo.AutoSize = true;
            lbToDo.BackColor = Color.Transparent;
            lbToDo.Font = new Font("Cascadia Mono", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbToDo.Location = new Point(22, 109);
            lbToDo.Name = "lbToDo";
            lbToDo.Size = new Size(505, 104);
            lbToDo.TabIndex = 3;
            lbToDo.Text = "Select city to attack\r\non the map";
            lbToDo.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.SeaGreen;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Cascadia Mono", 20F, FontStyle.Bold);
            btnCancel.Location = new Point(12, 307);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(528, 62);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // gbInfo
            // 
            gbInfo.Controls.Add(lbInfo);
            gbInfo.Font = new Font("Cascadia Mono", 15F, FontStyle.Bold);
            gbInfo.Location = new Point(961, 13);
            gbInfo.Name = "gbInfo";
            gbInfo.Size = new Size(546, 266);
            gbInfo.TabIndex = 2;
            gbInfo.TabStop = false;
            gbInfo.Text = "Info";
            // 
            // lbInfo
            // 
            lbInfo.AutoSize = true;
            lbInfo.BackColor = Color.Transparent;
            lbInfo.Font = new Font("Cascadia Mono", 20F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lbInfo.Location = new Point(6, 38);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new Size(413, 52);
            lbInfo.TabIndex = 2;
            lbInfo.Text = "City info is here";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSeaGreen;
            ClientSize = new Size(1519, 889);
            Controls.Add(gbWorkspace);
            Controls.Add(gbNews);
            Controls.Add(gbMap);
            Controls.Add(gbInfo);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            gbMap.ResumeLayout(false);
            gbMap.PerformLayout();
            gbNews.ResumeLayout(false);
            gbNews.PerformLayout();
            gbWorkspace.ResumeLayout(false);
            gbWorkspace.PerformLayout();
            gbInfo.ResumeLayout(false);
            gbInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private GroupBox gbMap;
        private Button btnMobilize;
        private Button btnAttack;
        private Button btnTransport;
        private GroupBox gbNews;
        private Label lbNews;
        private GroupBox gbWorkspace;
        private GroupBox gbInfo;
        private Label lbInfo;
        private Label lbCaptured;
        private Button btnCancel;
        private Label lbToDo;
        private Button btnDeselect;
        private HelpProvider helpProvider1;
    }
}
