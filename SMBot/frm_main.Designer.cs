namespace SMBot
{
    partial class frm_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.tc_main = new System.Windows.Forms.TabControl();
            this.tp_followBot = new System.Windows.Forms.TabPage();
            this.lbl_fb_unfollow = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_fb_current = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_fb_followed = new System.Windows.Forms.Label();
            this.btn_fb_unfollowStart = new System.Windows.Forms.Button();
            this.cb_fb_follows = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_fb_bots = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_fb_followStart = new System.Windows.Forms.Button();
            this.nud_fb_follows = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_fb_stream = new System.Windows.Forms.TextBox();
            this.tp_messenger = new System.Windows.Forms.TabPage();
            this.btn_msg_start = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.rtb_msg_speak = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_msg_stream = new System.Windows.Forms.TextBox();
            this.tp_accountCreator = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.cb_email = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_acc_start = new System.Windows.Forms.Button();
            this.lbl_acc_errors = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_acc_created = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nud_acc_accounts = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.tp_settings = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_setColors = new System.Windows.Forms.Button();
            this.tb_errorColor = new System.Windows.Forms.TextBox();
            this.tb_debugColor = new System.Windows.Forms.TextBox();
            this.tb_successColor = new System.Windows.Forms.TextBox();
            this.btn_shuffleAccounts = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_sleepTime = new System.Windows.Forms.Button();
            this.nud_sleepTime = new System.Windows.Forms.NumericUpDown();
            this.btn_reload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_debug = new System.Windows.Forms.RichTextBox();
            this.lv_accounts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cd_main = new System.Windows.Forms.ColorDialog();
            this.tc_main.SuspendLayout();
            this.tp_followBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_fb_follows)).BeginInit();
            this.tp_messenger.SuspendLayout();
            this.tp_accountCreator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_acc_accounts)).BeginInit();
            this.tp_settings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sleepTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_main
            // 
            this.tc_main.Controls.Add(this.tp_followBot);
            this.tc_main.Controls.Add(this.tp_messenger);
            this.tc_main.Controls.Add(this.tp_accountCreator);
            this.tc_main.Controls.Add(this.tp_settings);
            this.tc_main.Location = new System.Drawing.Point(12, 12);
            this.tc_main.Name = "tc_main";
            this.tc_main.SelectedIndex = 0;
            this.tc_main.Size = new System.Drawing.Size(248, 223);
            this.tc_main.TabIndex = 0;
            // 
            // tp_followBot
            // 
            this.tp_followBot.Controls.Add(this.lbl_fb_unfollow);
            this.tp_followBot.Controls.Add(this.label5);
            this.tp_followBot.Controls.Add(this.lbl_fb_current);
            this.tp_followBot.Controls.Add(this.label8);
            this.tp_followBot.Controls.Add(this.lbl_fb_followed);
            this.tp_followBot.Controls.Add(this.btn_fb_unfollowStart);
            this.tp_followBot.Controls.Add(this.cb_fb_follows);
            this.tp_followBot.Controls.Add(this.label4);
            this.tp_followBot.Controls.Add(this.lbl_fb_bots);
            this.tp_followBot.Controls.Add(this.label2);
            this.tp_followBot.Controls.Add(this.btn_fb_followStart);
            this.tp_followBot.Controls.Add(this.nud_fb_follows);
            this.tp_followBot.Controls.Add(this.label1);
            this.tp_followBot.Controls.Add(this.tb_fb_stream);
            this.tp_followBot.Location = new System.Drawing.Point(4, 22);
            this.tp_followBot.Name = "tp_followBot";
            this.tp_followBot.Padding = new System.Windows.Forms.Padding(3);
            this.tp_followBot.Size = new System.Drawing.Size(240, 197);
            this.tp_followBot.TabIndex = 0;
            this.tp_followBot.Text = "Follow Bot";
            this.tp_followBot.UseVisualStyleBackColor = true;
            // 
            // lbl_fb_unfollow
            // 
            this.lbl_fb_unfollow.AutoSize = true;
            this.lbl_fb_unfollow.Location = new System.Drawing.Point(73, 153);
            this.lbl_fb_unfollow.Name = "lbl_fb_unfollow";
            this.lbl_fb_unfollow.Size = new System.Drawing.Size(13, 13);
            this.lbl_fb_unfollow.TabIndex = 13;
            this.lbl_fb_unfollow.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Unfollowed:";
            // 
            // lbl_fb_current
            // 
            this.lbl_fb_current.AutoSize = true;
            this.lbl_fb_current.Location = new System.Drawing.Point(64, 174);
            this.lbl_fb_current.Name = "lbl_fb_current";
            this.lbl_fb_current.Size = new System.Drawing.Size(82, 13);
            this.lbl_fb_current.TabIndex = 11;
            this.lbl_fb_current.Text = "Doing nothing...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Currently:";
            // 
            // lbl_fb_followed
            // 
            this.lbl_fb_followed.AutoSize = true;
            this.lbl_fb_followed.Location = new System.Drawing.Point(63, 136);
            this.lbl_fb_followed.Name = "lbl_fb_followed";
            this.lbl_fb_followed.Size = new System.Drawing.Size(13, 13);
            this.lbl_fb_followed.TabIndex = 9;
            this.lbl_fb_followed.Text = "0";
            // 
            // btn_fb_unfollowStart
            // 
            this.btn_fb_unfollowStart.Location = new System.Drawing.Point(11, 90);
            this.btn_fb_unfollowStart.Name = "btn_fb_unfollowStart";
            this.btn_fb_unfollowStart.Size = new System.Drawing.Size(212, 23);
            this.btn_fb_unfollowStart.TabIndex = 8;
            this.btn_fb_unfollowStart.Text = "Start Unfollowing";
            this.btn_fb_unfollowStart.UseVisualStyleBackColor = true;
            this.btn_fb_unfollowStart.Click += new System.EventHandler(this.btn_fb_unfollowStart_Click);
            // 
            // cb_fb_follows
            // 
            this.cb_fb_follows.AutoSize = true;
            this.cb_fb_follows.Location = new System.Drawing.Point(146, 12);
            this.cb_fb_follows.Name = "cb_fb_follows";
            this.cb_fb_follows.Size = new System.Drawing.Size(61, 17);
            this.cb_fb_follows.TabIndex = 7;
            this.cb_fb_follows.Text = "Follows";
            this.cb_fb_follows.UseVisualStyleBackColor = true;
            this.cb_fb_follows.CheckedChanged += new System.EventHandler(this.cb_fb_follows_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Followed:";
            // 
            // lbl_fb_bots
            // 
            this.lbl_fb_bots.AutoSize = true;
            this.lbl_fb_bots.Location = new System.Drawing.Point(42, 119);
            this.lbl_fb_bots.Name = "lbl_fb_bots";
            this.lbl_fb_bots.Size = new System.Drawing.Size(13, 13);
            this.lbl_fb_bots.TabIndex = 5;
            this.lbl_fb_bots.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bots:";
            // 
            // btn_fb_followStart
            // 
            this.btn_fb_followStart.Location = new System.Drawing.Point(11, 61);
            this.btn_fb_followStart.Name = "btn_fb_followStart";
            this.btn_fb_followStart.Size = new System.Drawing.Size(212, 23);
            this.btn_fb_followStart.TabIndex = 3;
            this.btn_fb_followStart.Text = "Start Following";
            this.btn_fb_followStart.UseVisualStyleBackColor = true;
            this.btn_fb_followStart.Click += new System.EventHandler(this.btn_fb_followStart_Click);
            // 
            // nud_fb_follows
            // 
            this.nud_fb_follows.Enabled = false;
            this.nud_fb_follows.Location = new System.Drawing.Point(131, 35);
            this.nud_fb_follows.Name = "nud_fb_follows";
            this.nud_fb_follows.Size = new System.Drawing.Size(92, 20);
            this.nud_fb_follows.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Streamer Name:";
            // 
            // tb_fb_stream
            // 
            this.tb_fb_stream.Location = new System.Drawing.Point(11, 35);
            this.tb_fb_stream.Name = "tb_fb_stream";
            this.tb_fb_stream.Size = new System.Drawing.Size(109, 20);
            this.tb_fb_stream.TabIndex = 0;
            // 
            // tp_messenger
            // 
            this.tp_messenger.Controls.Add(this.btn_msg_start);
            this.tp_messenger.Controls.Add(this.label7);
            this.tp_messenger.Controls.Add(this.rtb_msg_speak);
            this.tp_messenger.Controls.Add(this.label6);
            this.tp_messenger.Controls.Add(this.tb_msg_stream);
            this.tp_messenger.Location = new System.Drawing.Point(4, 22);
            this.tp_messenger.Name = "tp_messenger";
            this.tp_messenger.Padding = new System.Windows.Forms.Padding(3);
            this.tp_messenger.Size = new System.Drawing.Size(240, 197);
            this.tp_messenger.TabIndex = 1;
            this.tp_messenger.Text = "Messenger";
            this.tp_messenger.UseVisualStyleBackColor = true;
            // 
            // btn_msg_start
            // 
            this.btn_msg_start.Location = new System.Drawing.Point(11, 160);
            this.btn_msg_start.Name = "btn_msg_start";
            this.btn_msg_start.Size = new System.Drawing.Size(216, 23);
            this.btn_msg_start.TabIndex = 6;
            this.btn_msg_start.Text = "Start";
            this.btn_msg_start.UseVisualStyleBackColor = true;
            this.btn_msg_start.Click += new System.EventHandler(this.btn_msg_start_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "What do we say?:";
            // 
            // rtb_msg_speak
            // 
            this.rtb_msg_speak.Location = new System.Drawing.Point(11, 69);
            this.rtb_msg_speak.Name = "rtb_msg_speak";
            this.rtb_msg_speak.Size = new System.Drawing.Size(216, 84);
            this.rtb_msg_speak.TabIndex = 4;
            this.rtb_msg_speak.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Streamer Name:";
            // 
            // tb_msg_stream
            // 
            this.tb_msg_stream.Location = new System.Drawing.Point(11, 28);
            this.tb_msg_stream.Name = "tb_msg_stream";
            this.tb_msg_stream.Size = new System.Drawing.Size(216, 20);
            this.tb_msg_stream.TabIndex = 2;
            // 
            // tp_accountCreator
            // 
            this.tp_accountCreator.Controls.Add(this.label9);
            this.tp_accountCreator.Controls.Add(this.cb_email);
            this.tp_accountCreator.Controls.Add(this.pictureBox1);
            this.tp_accountCreator.Controls.Add(this.btn_acc_start);
            this.tp_accountCreator.Controls.Add(this.lbl_acc_errors);
            this.tp_accountCreator.Controls.Add(this.label14);
            this.tp_accountCreator.Controls.Add(this.lbl_acc_created);
            this.tp_accountCreator.Controls.Add(this.label11);
            this.tp_accountCreator.Controls.Add(this.nud_acc_accounts);
            this.tp_accountCreator.Controls.Add(this.label10);
            this.tp_accountCreator.Location = new System.Drawing.Point(4, 22);
            this.tp_accountCreator.Name = "tp_accountCreator";
            this.tp_accountCreator.Padding = new System.Windows.Forms.Padding(3);
            this.tp_accountCreator.Size = new System.Drawing.Size(240, 197);
            this.tp_accountCreator.TabIndex = 2;
            this.tp_accountCreator.Text = "Account Creator";
            this.tp_accountCreator.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Email:";
            // 
            // cb_email
            // 
            this.cb_email.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_email.FormattingEnabled = true;
            this.cb_email.Location = new System.Drawing.Point(47, 35);
            this.cb_email.Name = "cb_email";
            this.cb_email.Size = new System.Drawing.Size(185, 21);
            this.cb_email.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SMBot.Properties.Resources._10447157_10204472368714485_4851191193616864255_n;
            this.pictureBox1.Location = new System.Drawing.Point(9, 126);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btn_acc_start
            // 
            this.btn_acc_start.Location = new System.Drawing.Point(9, 60);
            this.btn_acc_start.Name = "btn_acc_start";
            this.btn_acc_start.Size = new System.Drawing.Size(223, 23);
            this.btn_acc_start.TabIndex = 6;
            this.btn_acc_start.Text = "Start";
            this.btn_acc_start.UseVisualStyleBackColor = true;
            this.btn_acc_start.Click += new System.EventHandler(this.btn_acc_start_Click);
            // 
            // lbl_acc_errors
            // 
            this.lbl_acc_errors.AutoSize = true;
            this.lbl_acc_errors.Location = new System.Drawing.Point(102, 108);
            this.lbl_acc_errors.Name = "lbl_acc_errors";
            this.lbl_acc_errors.Size = new System.Drawing.Size(13, 13);
            this.lbl_acc_errors.TabIndex = 5;
            this.lbl_acc_errors.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(63, 108);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Errors:";
            // 
            // lbl_acc_created
            // 
            this.lbl_acc_created.AutoSize = true;
            this.lbl_acc_created.Location = new System.Drawing.Point(102, 89);
            this.lbl_acc_created.Name = "lbl_acc_created";
            this.lbl_acc_created.Size = new System.Drawing.Size(13, 13);
            this.lbl_acc_created.TabIndex = 3;
            this.lbl_acc_created.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Accounts Created:";
            // 
            // nud_acc_accounts
            // 
            this.nud_acc_accounts.Location = new System.Drawing.Point(125, 10);
            this.nud_acc_accounts.Name = "nud_acc_accounts";
            this.nud_acc_accounts.Size = new System.Drawing.Size(107, 20);
            this.nud_acc_accounts.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "How Many Accounts?:";
            // 
            // tp_settings
            // 
            this.tp_settings.Controls.Add(this.groupBox3);
            this.tp_settings.Controls.Add(this.btn_shuffleAccounts);
            this.tp_settings.Controls.Add(this.label3);
            this.tp_settings.Controls.Add(this.btn_sleepTime);
            this.tp_settings.Controls.Add(this.nud_sleepTime);
            this.tp_settings.Controls.Add(this.btn_reload);
            this.tp_settings.Location = new System.Drawing.Point(4, 22);
            this.tp_settings.Name = "tp_settings";
            this.tp_settings.Padding = new System.Windows.Forms.Padding(3);
            this.tp_settings.Size = new System.Drawing.Size(240, 197);
            this.tp_settings.TabIndex = 3;
            this.tp_settings.Text = "Settings";
            this.tp_settings.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_setColors);
            this.groupBox3.Controls.Add(this.tb_errorColor);
            this.groupBox3.Controls.Add(this.tb_debugColor);
            this.groupBox3.Controls.Add(this.tb_successColor);
            this.groupBox3.Location = new System.Drawing.Point(6, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 130);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Color Coating";
            // 
            // btn_setColors
            // 
            this.btn_setColors.Location = new System.Drawing.Point(6, 97);
            this.btn_setColors.Name = "btn_setColors";
            this.btn_setColors.Size = new System.Drawing.Size(216, 23);
            this.btn_setColors.TabIndex = 8;
            this.btn_setColors.Text = "Set Colors";
            this.btn_setColors.UseVisualStyleBackColor = true;
            this.btn_setColors.Click += new System.EventHandler(this.SetColors);
            // 
            // tb_errorColor
            // 
            this.tb_errorColor.ForeColor = System.Drawing.Color.Red;
            this.tb_errorColor.Location = new System.Drawing.Point(6, 19);
            this.tb_errorColor.Name = "tb_errorColor";
            this.tb_errorColor.Size = new System.Drawing.Size(216, 20);
            this.tb_errorColor.TabIndex = 5;
            this.tb_errorColor.Text = "Error Text Color";
            this.tb_errorColor.Click += new System.EventHandler(this.ErrorColor);
            // 
            // tb_debugColor
            // 
            this.tb_debugColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tb_debugColor.Location = new System.Drawing.Point(6, 71);
            this.tb_debugColor.Name = "tb_debugColor";
            this.tb_debugColor.Size = new System.Drawing.Size(216, 20);
            this.tb_debugColor.TabIndex = 7;
            this.tb_debugColor.Text = "Debug Text Color";
            this.tb_debugColor.Click += new System.EventHandler(this.DebugColor);
            // 
            // tb_successColor
            // 
            this.tb_successColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tb_successColor.Location = new System.Drawing.Point(6, 45);
            this.tb_successColor.Name = "tb_successColor";
            this.tb_successColor.Size = new System.Drawing.Size(216, 20);
            this.tb_successColor.TabIndex = 6;
            this.tb_successColor.Text = "Success Text Color";
            this.tb_successColor.Click += new System.EventHandler(this.SuccessColor);
            // 
            // btn_shuffleAccounts
            // 
            this.btn_shuffleAccounts.Location = new System.Drawing.Point(123, 32);
            this.btn_shuffleAccounts.Name = "btn_shuffleAccounts";
            this.btn_shuffleAccounts.Size = new System.Drawing.Size(108, 23);
            this.btn_shuffleAccounts.TabIndex = 4;
            this.btn_shuffleAccounts.Text = "Check For Dupes";
            this.btn_shuffleAccounts.UseVisualStyleBackColor = true;
            this.btn_shuffleAccounts.Click += new System.EventHandler(this.DupeChecker);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "ms";
            // 
            // btn_sleepTime
            // 
            this.btn_sleepTime.Location = new System.Drawing.Point(9, 3);
            this.btn_sleepTime.Name = "btn_sleepTime";
            this.btn_sleepTime.Size = new System.Drawing.Size(108, 23);
            this.btn_sleepTime.TabIndex = 2;
            this.btn_sleepTime.Text = "Set Sleep Time";
            this.btn_sleepTime.UseVisualStyleBackColor = true;
            this.btn_sleepTime.Click += new System.EventHandler(this.SetSleepTime);
            // 
            // nud_sleepTime
            // 
            this.nud_sleepTime.Location = new System.Drawing.Point(123, 6);
            this.nud_sleepTime.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nud_sleepTime.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_sleepTime.Name = "nud_sleepTime";
            this.nud_sleepTime.Size = new System.Drawing.Size(69, 20);
            this.nud_sleepTime.TabIndex = 1;
            this.nud_sleepTime.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // btn_reload
            // 
            this.btn_reload.Location = new System.Drawing.Point(9, 32);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(108, 23);
            this.btn_reload.TabIndex = 0;
            this.btn_reload.Text = "Reload Accounts";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.ReloadAccounts);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_debug);
            this.groupBox1.Location = new System.Drawing.Point(12, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Debug";
            // 
            // rtb_debug
            // 
            this.rtb_debug.BackColor = System.Drawing.SystemColors.Control;
            this.rtb_debug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_debug.DetectUrls = false;
            this.rtb_debug.Location = new System.Drawing.Point(6, 19);
            this.rtb_debug.Name = "rtb_debug";
            this.rtb_debug.ReadOnly = true;
            this.rtb_debug.Size = new System.Drawing.Size(593, 75);
            this.rtb_debug.TabIndex = 0;
            this.rtb_debug.Text = "";
            // 
            // lv_accounts
            // 
            this.lv_accounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_accounts.FullRowSelect = true;
            this.lv_accounts.Location = new System.Drawing.Point(6, 21);
            this.lv_accounts.Name = "lv_accounts";
            this.lv_accounts.Size = new System.Drawing.Size(339, 196);
            this.lv_accounts.TabIndex = 2;
            this.lv_accounts.UseCompatibleStateImageBehavior = false;
            this.lv_accounts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 91;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Message";
            this.columnHeader2.Width = 225;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_accounts);
            this.groupBox2.Location = new System.Drawing.Point(266, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 223);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accounts";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 353);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tc_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(645, 392);
            this.MinimumSize = new System.Drawing.Size(645, 392);
            this.Name = "frm_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SM Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_main_FormClosing);
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.tc_main.ResumeLayout(false);
            this.tp_followBot.ResumeLayout(false);
            this.tp_followBot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_fb_follows)).EndInit();
            this.tp_messenger.ResumeLayout(false);
            this.tp_messenger.PerformLayout();
            this.tp_accountCreator.ResumeLayout(false);
            this.tp_accountCreator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_acc_accounts)).EndInit();
            this.tp_settings.ResumeLayout(false);
            this.tp_settings.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_sleepTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_main;
        private System.Windows.Forms.TabPage tp_followBot;
        private System.Windows.Forms.TabPage tp_messenger;
        private System.Windows.Forms.Label lbl_fb_current;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_fb_followed;
        private System.Windows.Forms.Button btn_fb_unfollowStart;
        private System.Windows.Forms.CheckBox cb_fb_follows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_fb_bots;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_fb_followStart;
        private System.Windows.Forms.NumericUpDown nud_fb_follows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_fb_stream;
        private System.Windows.Forms.Button btn_msg_start;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtb_msg_speak;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_msg_stream;
        private System.Windows.Forms.TabPage tp_accountCreator;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_acc_start;
        private System.Windows.Forms.Label lbl_acc_errors;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_acc_created;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nud_acc_accounts;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtb_debug;
        private System.Windows.Forms.ListView lv_accounts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_fb_unfollow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tp_settings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_setColors;
        private System.Windows.Forms.TextBox tb_errorColor;
        private System.Windows.Forms.TextBox tb_debugColor;
        private System.Windows.Forms.TextBox tb_successColor;
        private System.Windows.Forms.Button btn_shuffleAccounts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_sleepTime;
        private System.Windows.Forms.NumericUpDown nud_sleepTime;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.ColorDialog cd_main;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cb_email;
    }
}

