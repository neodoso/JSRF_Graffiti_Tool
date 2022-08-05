namespace JSRF_Graffiti_Tool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtb_xbox_debug_ip = new System.Windows.Forms.TextBox();
            this.txtb_xbox_jsrf_dir = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtb_xbox_login = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtb_xbox_pass = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtb_img_editor_path = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_img_editor = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtb_jsrf_original_dir = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_jsrf_original_dir = new System.Windows.Forms.Button();
            this.txtb_jsrf_mod_dir = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_jsrf_mod_dir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SS = new System.Windows.Forms.Button();
            this.btn_S = new System.Windows.Forms.Button();
            this.btn_M = new System.Windows.Forms.Button();
            this.btn_L = new System.Windows.Forms.Button();
            this.btn_XL = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_send_to_xbox = new System.Windows.Forms.Button();
            this.btn_restore = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtb_cxbx_dir = new System.Windows.Forms.TextBox();
            this.btn_sel_cxbx_dir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtb_xbox_debug_ip
            // 
            this.txtb_xbox_debug_ip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_xbox_debug_ip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_xbox_debug_ip.Location = new System.Drawing.Point(16, 235);
            this.txtb_xbox_debug_ip.Name = "txtb_xbox_debug_ip";
            this.txtb_xbox_debug_ip.Size = new System.Drawing.Size(104, 20);
            this.txtb_xbox_debug_ip.TabIndex = 32;
            this.txtb_xbox_debug_ip.TextChanged += new System.EventHandler(this.settings_save);
            // 
            // txtb_xbox_jsrf_dir
            // 
            this.txtb_xbox_jsrf_dir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_xbox_jsrf_dir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_xbox_jsrf_dir.Location = new System.Drawing.Point(10, 291);
            this.txtb_xbox_jsrf_dir.Name = "txtb_xbox_jsrf_dir";
            this.txtb_xbox_jsrf_dir.Size = new System.Drawing.Size(518, 20);
            this.txtb_xbox_jsrf_dir.TabIndex = 31;
            this.txtb_xbox_jsrf_dir.TextChanged += new System.EventHandler(this.settings_save);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(237, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Password";
            // 
            // txtb_xbox_login
            // 
            this.txtb_xbox_login.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_xbox_login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_xbox_login.Location = new System.Drawing.Point(126, 235);
            this.txtb_xbox_login.Name = "txtb_xbox_login";
            this.txtb_xbox_login.Size = new System.Drawing.Size(106, 20);
            this.txtb_xbox_login.TabIndex = 33;
            this.txtb_xbox_login.Text = "xbox";
            this.txtb_xbox_login.TextChanged += new System.EventHandler(this.settings_save);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(125, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Username";
            // 
            // txtb_xbox_pass
            // 
            this.txtb_xbox_pass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_xbox_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_xbox_pass.Location = new System.Drawing.Point(238, 235);
            this.txtb_xbox_pass.Name = "txtb_xbox_pass";
            this.txtb_xbox_pass.Size = new System.Drawing.Size(106, 20);
            this.txtb_xbox_pass.TabIndex = 34;
            this.txtb_xbox_pass.Text = "xbox";
            this.txtb_xbox_pass.TextChanged += new System.EventHandler(this.settings_save);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(263, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "JSRF game folder (Media) path on the Xbox hard drive";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Xbox IP address";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.label15);
            this.panel3.Location = new System.Drawing.Point(3, 178);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(919, 25);
            this.panel3.TabIndex = 39;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(3, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(154, 20);
            this.label15.TabIndex = 1;
            this.label15.Text = "JSRF Files (Xbox)";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(109, 7);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 1, 1, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(809, 395);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.txtb_cxbx_dir);
            this.panel1.Controls.Add(this.btn_sel_cxbx_dir);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtb_img_editor_path);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btn_img_editor);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.txtb_jsrf_original_dir);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_jsrf_original_dir);
            this.panel1.Controls.Add(this.txtb_jsrf_mod_dir);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btn_jsrf_mod_dir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtb_xbox_debug_ip);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtb_xbox_jsrf_dir);
            this.panel1.Controls.Add(this.txtb_xbox_pass);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtb_xbox_login);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 412);
            this.panel1.TabIndex = 41;
            // 
            // txtb_img_editor_path
            // 
            this.txtb_img_editor_path.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_img_editor_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_img_editor_path.Location = new System.Drawing.Point(10, 386);
            this.txtb_img_editor_path.Name = "txtb_img_editor_path";
            this.txtb_img_editor_path.Size = new System.Drawing.Size(518, 20);
            this.txtb_img_editor_path.TabIndex = 49;
            this.txtb_img_editor_path.TextChanged += new System.EventHandler(this.settings_save);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 370);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(463, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "Select your prefered image editor for editing textures (Gimp.exe, Paint.Net.exe, " +
    "Photoshop.exe ...)";
            // 
            // btn_img_editor
            // 
            this.btn_img_editor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_img_editor.Location = new System.Drawing.Point(535, 385);
            this.btn_img_editor.Name = "btn_img_editor";
            this.btn_img_editor.Size = new System.Drawing.Size(112, 23);
            this.btn_img_editor.TabIndex = 48;
            this.btn_img_editor.Text = "Select Image Editor";
            this.btn_img_editor.UseVisualStyleBackColor = true;
            this.btn_img_editor.Click += new System.EventHandler(this.btn_img_editor_Click);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.DimGray;
            this.panel8.Controls.Add(this.label14);
            this.panel8.Location = new System.Drawing.Point(1, 330);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(925, 25);
            this.panel8.TabIndex = 50;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(3, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(196, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "Preferred texture editor";
            // 
            // txtb_jsrf_original_dir
            // 
            this.txtb_jsrf_original_dir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_jsrf_original_dir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_jsrf_original_dir.Location = new System.Drawing.Point(10, 97);
            this.txtb_jsrf_original_dir.Name = "txtb_jsrf_original_dir";
            this.txtb_jsrf_original_dir.Size = new System.Drawing.Size(518, 20);
            this.txtb_jsrf_original_dir.TabIndex = 42;
            this.txtb_jsrf_original_dir.TextChanged += new System.EventHandler(this.settings_save);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(923, 25);
            this.panel2.TabIndex = 46;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(3, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(137, 20);
            this.label13.TabIndex = 1;
            this.label13.Text = "JSRF Files (PC)";
            // 
            // btn_jsrf_original_dir
            // 
            this.btn_jsrf_original_dir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_jsrf_original_dir.Location = new System.Drawing.Point(535, 96);
            this.btn_jsrf_original_dir.Name = "btn_jsrf_original_dir";
            this.btn_jsrf_original_dir.Size = new System.Drawing.Size(112, 23);
            this.btn_jsrf_original_dir.TabIndex = 40;
            this.btn_jsrf_original_dir.Text = "Select Folder";
            this.btn_jsrf_original_dir.UseVisualStyleBackColor = true;
            this.btn_jsrf_original_dir.Click += new System.EventHandler(this.btn_jsrf_original_dir_Click);
            // 
            // txtb_jsrf_mod_dir
            // 
            this.txtb_jsrf_mod_dir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_jsrf_mod_dir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_jsrf_mod_dir.Location = new System.Drawing.Point(10, 49);
            this.txtb_jsrf_mod_dir.Name = "txtb_jsrf_mod_dir";
            this.txtb_jsrf_mod_dir.Size = new System.Drawing.Size(518, 20);
            this.txtb_jsrf_mod_dir.TabIndex = 43;
            this.txtb_jsrf_mod_dir.TextChanged += new System.EventHandler(this.settings_save);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(223, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "TEX folder original files (for reverting changes)";
            // 
            // btn_jsrf_mod_dir
            // 
            this.btn_jsrf_mod_dir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_jsrf_mod_dir.Location = new System.Drawing.Point(535, 48);
            this.btn_jsrf_mod_dir.Name = "btn_jsrf_mod_dir";
            this.btn_jsrf_mod_dir.Size = new System.Drawing.Size(112, 23);
            this.btn_jsrf_mod_dir.TabIndex = 41;
            this.btn_jsrf_mod_dir.Text = "Select Folder";
            this.btn_jsrf_mod_dir.UseVisualStyleBackColor = true;
            this.btn_jsrf_mod_dir.Click += new System.EventHandler(this.btn_favfolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "TEX folder  (Media\\Mark\\TEX\\)   (modding)";
            // 
            // btn_SS
            // 
            this.btn_SS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SS.Location = new System.Drawing.Point(9, 7);
            this.btn_SS.Name = "btn_SS";
            this.btn_SS.Size = new System.Drawing.Size(94, 32);
            this.btn_SS.TabIndex = 42;
            this.btn_SS.Tag = "0";
            this.btn_SS.Text = "SS";
            this.btn_SS.UseVisualStyleBackColor = true;
            this.btn_SS.Click += new System.EventHandler(this.btn_graffiti_size_Click);
            // 
            // btn_S
            // 
            this.btn_S.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_S.Location = new System.Drawing.Point(9, 45);
            this.btn_S.Name = "btn_S";
            this.btn_S.Size = new System.Drawing.Size(94, 32);
            this.btn_S.TabIndex = 42;
            this.btn_S.Tag = "1";
            this.btn_S.Text = "S";
            this.btn_S.UseVisualStyleBackColor = true;
            this.btn_S.Click += new System.EventHandler(this.btn_graffiti_size_Click);
            // 
            // btn_M
            // 
            this.btn_M.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_M.Location = new System.Drawing.Point(9, 83);
            this.btn_M.Name = "btn_M";
            this.btn_M.Size = new System.Drawing.Size(94, 32);
            this.btn_M.TabIndex = 42;
            this.btn_M.Tag = "2";
            this.btn_M.Text = "M";
            this.btn_M.UseVisualStyleBackColor = true;
            this.btn_M.Click += new System.EventHandler(this.btn_graffiti_size_Click);
            // 
            // btn_L
            // 
            this.btn_L.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_L.Location = new System.Drawing.Point(9, 121);
            this.btn_L.Name = "btn_L";
            this.btn_L.Size = new System.Drawing.Size(94, 32);
            this.btn_L.TabIndex = 42;
            this.btn_L.Tag = "3";
            this.btn_L.Text = "L";
            this.btn_L.UseVisualStyleBackColor = true;
            this.btn_L.Click += new System.EventHandler(this.btn_graffiti_size_Click);
            // 
            // btn_XL
            // 
            this.btn_XL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XL.Location = new System.Drawing.Point(9, 159);
            this.btn_XL.Name = "btn_XL";
            this.btn_XL.Size = new System.Drawing.Size(94, 32);
            this.btn_XL.TabIndex = 42;
            this.btn_XL.Tag = "4";
            this.btn_XL.Text = "XL";
            this.btn_XL.UseVisualStyleBackColor = true;
            this.btn_XL.Click += new System.EventHandler(this.btn_graffiti_size_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.btn_SS);
            this.panel4.Controls.Add(this.btn_send_to_xbox);
            this.panel4.Controls.Add(this.btn_restore);
            this.panel4.Controls.Add(this.btn_import);
            this.panel4.Controls.Add(this.btn_edit);
            this.panel4.Controls.Add(this.btn_XL);
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Controls.Add(this.btn_S);
            this.panel4.Controls.Add(this.btn_L);
            this.panel4.Controls.Add(this.btn_M);
            this.panel4.Location = new System.Drawing.Point(0, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(923, 409);
            this.panel4.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8F);
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(3, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Selected graffiti:";
            // 
            // btn_send_to_xbox
            // 
            this.btn_send_to_xbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_send_to_xbox.Location = new System.Drawing.Point(8, 370);
            this.btn_send_to_xbox.Name = "btn_send_to_xbox";
            this.btn_send_to_xbox.Size = new System.Drawing.Size(94, 32);
            this.btn_send_to_xbox.TabIndex = 42;
            this.btn_send_to_xbox.Tag = "4";
            this.btn_send_to_xbox.Text = "Send to Xbox";
            this.btn_send_to_xbox.UseVisualStyleBackColor = true;
            this.btn_send_to_xbox.Click += new System.EventHandler(this.btn_send_to_xbox_Click);
            // 
            // btn_restore
            // 
            this.btn_restore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_restore.Location = new System.Drawing.Point(8, 333);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(94, 32);
            this.btn_restore.TabIndex = 42;
            this.btn_restore.Tag = "4";
            this.btn_restore.Text = "Restore original";
            this.btn_restore.UseVisualStyleBackColor = true;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // btn_import
            // 
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Location = new System.Drawing.Point(8, 297);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(94, 32);
            this.btn_import.TabIndex = 42;
            this.btn_import.Tag = "4";
            this.btn_import.Text = "Import selected";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Location = new System.Drawing.Point(8, 260);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(94, 32);
            this.btn_edit.TabIndex = 42;
            this.btn_edit.Tag = "4";
            this.btn_edit.Text = "Edit selected";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(931, 439);
            this.tabControl1.TabIndex = 44;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Graffitis";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(923, 413);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "exe";
            // 
            // txtb_cxbx_dir
            // 
            this.txtb_cxbx_dir.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_cxbx_dir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtb_cxbx_dir.Location = new System.Drawing.Point(8, 146);
            this.txtb_cxbx_dir.Name = "txtb_cxbx_dir";
            this.txtb_cxbx_dir.Size = new System.Drawing.Size(518, 20);
            this.txtb_cxbx_dir.TabIndex = 52;
            // 
            // btn_sel_cxbx_dir
            // 
            this.btn_sel_cxbx_dir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sel_cxbx_dir.Location = new System.Drawing.Point(533, 145);
            this.btn_sel_cxbx_dir.Name = "btn_sel_cxbx_dir";
            this.btn_sel_cxbx_dir.Size = new System.Drawing.Size(112, 23);
            this.btn_sel_cxbx_dir.TabIndex = 51;
            this.btn_sel_cxbx_dir.Text = "Select Folder";
            this.btn_sel_cxbx_dir.UseVisualStyleBackColor = true;
            this.btn_sel_cxbx_dir.Click += new System.EventHandler(this.btn_sel_cxbx_dir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Cxbx folder (optional, used to clear the cache)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(934, 441);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "JSRF Graffiti Tool  [v1]";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtb_xbox_debug_ip;
        private System.Windows.Forms.TextBox txtb_xbox_jsrf_dir;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtb_xbox_login;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtb_xbox_pass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtb_jsrf_original_dir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_jsrf_original_dir;
        public System.Windows.Forms.TextBox txtb_jsrf_mod_dir;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_jsrf_mod_dir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SS;
        private System.Windows.Forms.Button btn_S;
        private System.Windows.Forms.Button btn_M;
        private System.Windows.Forms.Button btn_L;
        private System.Windows.Forms.Button btn_XL;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_send_to_xbox;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtb_img_editor_path;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_img_editor;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_restore;
        public System.Windows.Forms.TextBox txtb_cxbx_dir;
        private System.Windows.Forms.Button btn_sel_cxbx_dir;
        private System.Windows.Forms.Label label2;
    }
}

