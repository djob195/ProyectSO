namespace parcial2_1
{
    partial class CHAT
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
            this.TCChat = new System.Windows.Forms.TabControl();
            this.TPC = new System.Windows.Forms.TabPage();
            this.pnOtherChat = new System.Windows.Forms.Panel();
            this.btnConectarChat = new System.Windows.Forms.Button();
            this.tbMyAlias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbMyAlias = new System.Windows.Forms.Label();
            this.tbOtherChat = new System.Windows.Forms.TextBox();
            this.lbOtherChatsOff = new System.Windows.Forms.Label();
            this.dgvOffChat = new System.Windows.Forms.DataGridView();
            this.AliasChatOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meOtherChatOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnMyChat = new System.Windows.Forms.Panel();
            this.lbPortMyChat = new System.Windows.Forms.Label();
            this.NUDPort = new System.Windows.Forms.NumericUpDown();
            this.btnInicializarChat = new System.Windows.Forms.Button();
            this.tbAliasMyChat = new System.Windows.Forms.TextBox();
            this.lbAliasMyChat = new System.Windows.Forms.Label();
            this.btnEnviarMessage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnOption = new System.Windows.Forms.Panel();
            this.rbMessage = new System.Windows.Forms.RadioButton();
            this.rbPath = new System.Windows.Forms.RadioButton();
            this.lbSeleccionarChat = new System.Windows.Forms.Label();
            this.RTBMessage = new System.Windows.Forms.RichTextBox();
            this.lbDGVOtherChats = new System.Windows.Forms.Label();
            this.lbDGVMyChat = new System.Windows.Forms.Label();
            this.DGVOtherChats = new System.Windows.Forms.DataGridView();
            this.idClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVMyChat = new System.Windows.Forms.DataGridView();
            this.aliasMyChat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbPath = new System.Windows.Forms.Label();
            this.DGVPath = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAlerts = new System.Windows.Forms.DataGridView();
            this.portChatAlerts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Razon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbDGVAlerts = new System.Windows.Forms.Label();
            this.lbDGVMessage = new System.Windows.Forms.Label();
            this.DGVChats = new System.Windows.Forms.DataGridView();
            this.aliasChat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aliasUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TCChat.SuspendLayout();
            this.TPC.SuspendLayout();
            this.pnOtherChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffChat)).BeginInit();
            this.pnMyChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPort)).BeginInit();
            this.pnOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOtherChats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMyChat)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVChats)).BeginInit();
            this.SuspendLayout();
            // 
            // TCChat
            // 
            this.TCChat.Controls.Add(this.TPC);
            this.TCChat.Controls.Add(this.tabPage2);
            this.TCChat.Location = new System.Drawing.Point(12, 12);
            this.TCChat.Name = "TCChat";
            this.TCChat.SelectedIndex = 0;
            this.TCChat.Size = new System.Drawing.Size(789, 381);
            this.TCChat.TabIndex = 0;
            // 
            // TPC
            // 
            this.TPC.Controls.Add(this.pnOtherChat);
            this.TPC.Controls.Add(this.lbOtherChatsOff);
            this.TPC.Controls.Add(this.dgvOffChat);
            this.TPC.Controls.Add(this.pnMyChat);
            this.TPC.Controls.Add(this.btnEnviarMessage);
            this.TPC.Controls.Add(this.label1);
            this.TPC.Controls.Add(this.pnOption);
            this.TPC.Controls.Add(this.lbSeleccionarChat);
            this.TPC.Controls.Add(this.RTBMessage);
            this.TPC.Controls.Add(this.lbDGVOtherChats);
            this.TPC.Controls.Add(this.lbDGVMyChat);
            this.TPC.Controls.Add(this.DGVOtherChats);
            this.TPC.Controls.Add(this.DGVMyChat);
            this.TPC.Location = new System.Drawing.Point(4, 22);
            this.TPC.Name = "TPC";
            this.TPC.Padding = new System.Windows.Forms.Padding(3);
            this.TPC.Size = new System.Drawing.Size(781, 355);
            this.TPC.TabIndex = 0;
            this.TPC.Text = "Inicializacion";
            this.TPC.UseVisualStyleBackColor = true;
            // 
            // pnOtherChat
            // 
            this.pnOtherChat.Controls.Add(this.btnConectarChat);
            this.pnOtherChat.Controls.Add(this.tbMyAlias);
            this.pnOtherChat.Controls.Add(this.label3);
            this.pnOtherChat.Controls.Add(this.lbMyAlias);
            this.pnOtherChat.Controls.Add(this.tbOtherChat);
            this.pnOtherChat.Location = new System.Drawing.Point(408, 19);
            this.pnOtherChat.Name = "pnOtherChat";
            this.pnOtherChat.Size = new System.Drawing.Size(367, 66);
            this.pnOtherChat.TabIndex = 25;
            // 
            // btnConectarChat
            // 
            this.btnConectarChat.Location = new System.Drawing.Point(224, 30);
            this.btnConectarChat.Name = "btnConectarChat";
            this.btnConectarChat.Size = new System.Drawing.Size(129, 23);
            this.btnConectarChat.TabIndex = 7;
            this.btnConectarChat.Text = "Conectar Chat";
            this.btnConectarChat.UseVisualStyleBackColor = true;
            this.btnConectarChat.Click += new System.EventHandler(this.btnConectarChat_Click);
            // 
            // tbMyAlias
            // 
            this.tbMyAlias.Location = new System.Drawing.Point(105, 6);
            this.tbMyAlias.Name = "tbMyAlias";
            this.tbMyAlias.Size = new System.Drawing.Size(100, 20);
            this.tbMyAlias.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Alias de other Chat";
            // 
            // lbMyAlias
            // 
            this.lbMyAlias.AutoSize = true;
            this.lbMyAlias.Location = new System.Drawing.Point(3, 12);
            this.lbMyAlias.Name = "lbMyAlias";
            this.lbMyAlias.Size = new System.Drawing.Size(43, 13);
            this.lbMyAlias.TabIndex = 23;
            this.lbMyAlias.Text = "Mi Alias";
            // 
            // tbOtherChat
            // 
            this.tbOtherChat.Location = new System.Drawing.Point(105, 32);
            this.tbOtherChat.Name = "tbOtherChat";
            this.tbOtherChat.Size = new System.Drawing.Size(100, 20);
            this.tbOtherChat.TabIndex = 19;
            // 
            // lbOtherChatsOff
            // 
            this.lbOtherChatsOff.AutoSize = true;
            this.lbOtherChatsOff.Location = new System.Drawing.Point(536, 101);
            this.lbOtherChatsOff.Name = "lbOtherChatsOff";
            this.lbOtherChatsOff.Size = new System.Drawing.Size(116, 13);
            this.lbOtherChatsOff.TabIndex = 22;
            this.lbOtherChatsOff.Text = "Other Chats (OFFLINE)";
            // 
            // dgvOffChat
            // 
            this.dgvOffChat.AllowUserToAddRows = false;
            this.dgvOffChat.AllowUserToDeleteRows = false;
            this.dgvOffChat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOffChat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AliasChatOff,
            this.meOtherChatOff});
            this.dgvOffChat.Location = new System.Drawing.Point(530, 117);
            this.dgvOffChat.Name = "dgvOffChat";
            this.dgvOffChat.ReadOnly = true;
            this.dgvOffChat.Size = new System.Drawing.Size(245, 81);
            this.dgvOffChat.TabIndex = 21;
            // 
            // AliasChatOff
            // 
            this.AliasChatOff.HeaderText = "Alias Chat";
            this.AliasChatOff.Name = "AliasChatOff";
            this.AliasChatOff.ReadOnly = true;
            // 
            // meOtherChatOff
            // 
            this.meOtherChatOff.HeaderText = "Me (Alias)";
            this.meOtherChatOff.Name = "meOtherChatOff";
            this.meOtherChatOff.ReadOnly = true;
            // 
            // pnMyChat
            // 
            this.pnMyChat.Controls.Add(this.lbPortMyChat);
            this.pnMyChat.Controls.Add(this.NUDPort);
            this.pnMyChat.Controls.Add(this.btnInicializarChat);
            this.pnMyChat.Controls.Add(this.tbAliasMyChat);
            this.pnMyChat.Controls.Add(this.lbAliasMyChat);
            this.pnMyChat.Location = new System.Drawing.Point(20, 19);
            this.pnMyChat.Name = "pnMyChat";
            this.pnMyChat.Size = new System.Drawing.Size(370, 63);
            this.pnMyChat.TabIndex = 20;
            // 
            // lbPortMyChat
            // 
            this.lbPortMyChat.AutoSize = true;
            this.lbPortMyChat.Location = new System.Drawing.Point(8, 11);
            this.lbPortMyChat.Name = "lbPortMyChat";
            this.lbPortMyChat.Size = new System.Drawing.Size(68, 13);
            this.lbPortMyChat.TabIndex = 8;
            this.lbPortMyChat.Text = "Port My Chat";
            // 
            // NUDPort
            // 
            this.NUDPort.Location = new System.Drawing.Point(148, 6);
            this.NUDPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NUDPort.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDPort.Name = "NUDPort";
            this.NUDPort.Size = new System.Drawing.Size(50, 20);
            this.NUDPort.TabIndex = 0;
            this.NUDPort.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnInicializarChat
            // 
            this.btnInicializarChat.Location = new System.Drawing.Point(240, 31);
            this.btnInicializarChat.Name = "btnInicializarChat";
            this.btnInicializarChat.Size = new System.Drawing.Size(127, 23);
            this.btnInicializarChat.TabIndex = 1;
            this.btnInicializarChat.Text = "Inicializar Chat";
            this.btnInicializarChat.UseVisualStyleBackColor = true;
            this.btnInicializarChat.Click += new System.EventHandler(this.btnInicializarChat_Click);
            // 
            // tbAliasMyChat
            // 
            this.tbAliasMyChat.Location = new System.Drawing.Point(101, 35);
            this.tbAliasMyChat.Name = "tbAliasMyChat";
            this.tbAliasMyChat.Size = new System.Drawing.Size(100, 20);
            this.tbAliasMyChat.TabIndex = 16;
            // 
            // lbAliasMyChat
            // 
            this.lbAliasMyChat.AutoSize = true;
            this.lbAliasMyChat.Location = new System.Drawing.Point(8, 41);
            this.lbAliasMyChat.Name = "lbAliasMyChat";
            this.lbAliasMyChat.Size = new System.Drawing.Size(86, 13);
            this.lbAliasMyChat.TabIndex = 15;
            this.lbAliasMyChat.Text = "Alias de My Chat";
            // 
            // btnEnviarMessage
            // 
            this.btnEnviarMessage.Location = new System.Drawing.Point(34, 322);
            this.btnEnviarMessage.Name = "btnEnviarMessage";
            this.btnEnviarMessage.Size = new System.Drawing.Size(75, 23);
            this.btnEnviarMessage.TabIndex = 14;
            this.btnEnviarMessage.Text = "Enviar Mensaje";
            this.btnEnviarMessage.UseVisualStyleBackColor = true;
            this.btnEnviarMessage.Click += new System.EventHandler(this.btnEnviarMessage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(599, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Seleccionar la razón del mensaje";
            // 
            // pnOption
            // 
            this.pnOption.Controls.Add(this.rbMessage);
            this.pnOption.Controls.Add(this.rbPath);
            this.pnOption.Location = new System.Drawing.Point(602, 238);
            this.pnOption.Name = "pnOption";
            this.pnOption.Size = new System.Drawing.Size(154, 69);
            this.pnOption.TabIndex = 12;
            // 
            // rbMessage
            // 
            this.rbMessage.AutoSize = true;
            this.rbMessage.Location = new System.Drawing.Point(36, 36);
            this.rbMessage.Name = "rbMessage";
            this.rbMessage.Size = new System.Drawing.Size(68, 17);
            this.rbMessage.TabIndex = 1;
            this.rbMessage.Text = "Message";
            this.rbMessage.UseVisualStyleBackColor = true;
            // 
            // rbPath
            // 
            this.rbPath.AutoSize = true;
            this.rbPath.Checked = true;
            this.rbPath.Location = new System.Drawing.Point(36, 13);
            this.rbPath.Name = "rbPath";
            this.rbPath.Size = new System.Drawing.Size(47, 17);
            this.rbPath.TabIndex = 0;
            this.rbPath.TabStop = true;
            this.rbPath.Text = "Path";
            this.rbPath.UseVisualStyleBackColor = true;
            // 
            // lbSeleccionarChat
            // 
            this.lbSeleccionarChat.AutoSize = true;
            this.lbSeleccionarChat.Location = new System.Drawing.Point(30, 222);
            this.lbSeleccionarChat.Name = "lbSeleccionarChat";
            this.lbSeleccionarChat.Size = new System.Drawing.Size(275, 13);
            this.lbSeleccionarChat.TabIndex = 11;
            this.lbSeleccionarChat.Text = "Seleccionar un chat (Other Chat) para enviar un mensaje";
            // 
            // RTBMessage
            // 
            this.RTBMessage.Location = new System.Drawing.Point(33, 238);
            this.RTBMessage.Name = "RTBMessage";
            this.RTBMessage.Size = new System.Drawing.Size(539, 69);
            this.RTBMessage.TabIndex = 10;
            this.RTBMessage.Text = "";
            this.RTBMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RTBMessage_KeyPress);
            // 
            // lbDGVOtherChats
            // 
            this.lbDGVOtherChats.AutoSize = true;
            this.lbDGVOtherChats.Location = new System.Drawing.Point(180, 101);
            this.lbDGVOtherChats.Name = "lbDGVOtherChats";
            this.lbDGVOtherChats.Size = new System.Drawing.Size(63, 13);
            this.lbDGVOtherChats.TabIndex = 5;
            this.lbDGVOtherChats.Text = "Other Chats";
            // 
            // lbDGVMyChat
            // 
            this.lbDGVMyChat.AutoSize = true;
            this.lbDGVMyChat.Location = new System.Drawing.Point(28, 101);
            this.lbDGVMyChat.Name = "lbDGVMyChat";
            this.lbDGVMyChat.Size = new System.Drawing.Size(59, 13);
            this.lbDGVMyChat.TabIndex = 4;
            this.lbDGVMyChat.Text = "Connected";
            // 
            // DGVOtherChats
            // 
            this.DGVOtherChats.AllowUserToAddRows = false;
            this.DGVOtherChats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVOtherChats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idClient,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3});
            this.DGVOtherChats.Location = new System.Drawing.Point(183, 117);
            this.DGVOtherChats.Name = "DGVOtherChats";
            this.DGVOtherChats.ReadOnly = true;
            this.DGVOtherChats.Size = new System.Drawing.Size(327, 81);
            this.DGVOtherChats.TabIndex = 3;
            this.DGVOtherChats.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DGVOtherChats_UserDeletedRow);
            // 
            // idClient
            // 
            this.idClient.HeaderText = "index";
            this.idClient.Name = "idClient";
            this.idClient.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Alias Chat";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Me (Alias)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // DGVMyChat
            // 
            this.DGVMyChat.AllowUserToAddRows = false;
            this.DGVMyChat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMyChat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aliasMyChat});
            this.DGVMyChat.Enabled = false;
            this.DGVMyChat.Location = new System.Drawing.Point(31, 117);
            this.DGVMyChat.Name = "DGVMyChat";
            this.DGVMyChat.ReadOnly = true;
            this.DGVMyChat.Size = new System.Drawing.Size(146, 81);
            this.DGVMyChat.TabIndex = 2;
            this.DGVMyChat.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DGVMyChat_UserDeletedRow);
            // 
            // aliasMyChat
            // 
            this.aliasMyChat.HeaderText = "Alias";
            this.aliasMyChat.Name = "aliasMyChat";
            this.aliasMyChat.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbPath);
            this.tabPage2.Controls.Add(this.DGVPath);
            this.tabPage2.Controls.Add(this.dgvAlerts);
            this.tabPage2.Controls.Add(this.lbDGVAlerts);
            this.tabPage2.Controls.Add(this.lbDGVMessage);
            this.tabPage2.Controls.Add(this.DGVChats);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(781, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chats ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.Location = new System.Drawing.Point(388, 29);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(29, 13);
            this.lbPath.TabIndex = 5;
            this.lbPath.Text = "Path";
            // 
            // DGVPath
            // 
            this.DGVPath.AllowUserToAddRows = false;
            this.DGVPath.AllowUserToDeleteRows = false;
            this.DGVPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6});
            this.DGVPath.Location = new System.Drawing.Point(391, 45);
            this.DGVPath.Name = "DGVPath";
            this.DGVPath.ReadOnly = true;
            this.DGVPath.Size = new System.Drawing.Size(346, 150);
            this.DGVPath.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Alias Chat";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Alias User";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "path";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dgvAlerts
            // 
            this.dgvAlerts.AllowUserToAddRows = false;
            this.dgvAlerts.AllowUserToDeleteRows = false;
            this.dgvAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlerts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.portChatAlerts,
            this.Razon});
            this.dgvAlerts.Location = new System.Drawing.Point(18, 240);
            this.dgvAlerts.Name = "dgvAlerts";
            this.dgvAlerts.ReadOnly = true;
            this.dgvAlerts.Size = new System.Drawing.Size(244, 52);
            this.dgvAlerts.TabIndex = 3;
            // 
            // portChatAlerts
            // 
            this.portChatAlerts.HeaderText = "Alias Chat";
            this.portChatAlerts.Name = "portChatAlerts";
            this.portChatAlerts.ReadOnly = true;
            // 
            // Razon
            // 
            this.Razon.HeaderText = "Razon";
            this.Razon.Name = "Razon";
            this.Razon.ReadOnly = true;
            // 
            // lbDGVAlerts
            // 
            this.lbDGVAlerts.AutoSize = true;
            this.lbDGVAlerts.Location = new System.Drawing.Point(15, 224);
            this.lbDGVAlerts.Name = "lbDGVAlerts";
            this.lbDGVAlerts.Size = new System.Drawing.Size(39, 13);
            this.lbDGVAlerts.TabIndex = 2;
            this.lbDGVAlerts.Text = "Alertas";
            // 
            // lbDGVMessage
            // 
            this.lbDGVMessage.AutoSize = true;
            this.lbDGVMessage.Location = new System.Drawing.Point(15, 29);
            this.lbDGVMessage.Name = "lbDGVMessage";
            this.lbDGVMessage.Size = new System.Drawing.Size(52, 13);
            this.lbDGVMessage.TabIndex = 1;
            this.lbDGVMessage.Text = "Mensajes";
            // 
            // DGVChats
            // 
            this.DGVChats.AllowUserToAddRows = false;
            this.DGVChats.AllowUserToDeleteRows = false;
            this.DGVChats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVChats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aliasChat,
            this.aliasUser,
            this.message});
            this.DGVChats.Location = new System.Drawing.Point(18, 45);
            this.DGVChats.Name = "DGVChats";
            this.DGVChats.ReadOnly = true;
            this.DGVChats.Size = new System.Drawing.Size(346, 150);
            this.DGVChats.TabIndex = 0;
            // 
            // aliasChat
            // 
            this.aliasChat.HeaderText = "Alias Chat";
            this.aliasChat.Name = "aliasChat";
            this.aliasChat.ReadOnly = true;
            // 
            // aliasUser
            // 
            this.aliasUser.HeaderText = "Alias User";
            this.aliasUser.Name = "aliasUser";
            this.aliasUser.ReadOnly = true;
            // 
            // message
            // 
            this.message.HeaderText = "Message";
            this.message.Name = "message";
            this.message.ReadOnly = true;
            // 
            // CHAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 397);
            this.Controls.Add(this.TCChat);
            this.Name = "CHAT";
            this.Text = "CHAT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CHAT_FormClosing);
            this.Load += new System.EventHandler(this.CHAT_Load);
            this.TCChat.ResumeLayout(false);
            this.TPC.ResumeLayout(false);
            this.TPC.PerformLayout();
            this.pnOtherChat.ResumeLayout(false);
            this.pnOtherChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffChat)).EndInit();
            this.pnMyChat.ResumeLayout(false);
            this.pnMyChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPort)).EndInit();
            this.pnOption.ResumeLayout(false);
            this.pnOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOtherChats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMyChat)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlerts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVChats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TCChat;
        private System.Windows.Forms.TabPage TPC;
        private System.Windows.Forms.Button btnEnviarMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnOption;
        private System.Windows.Forms.RadioButton rbMessage;
        private System.Windows.Forms.RadioButton rbPath;
        private System.Windows.Forms.Label lbSeleccionarChat;
        private System.Windows.Forms.RichTextBox RTBMessage;
        private System.Windows.Forms.Label lbPortMyChat;
        private System.Windows.Forms.Button btnConectarChat;
        private System.Windows.Forms.Label lbDGVOtherChats;
        private System.Windows.Forms.Label lbDGVMyChat;
        private System.Windows.Forms.DataGridView DGVOtherChats;
        private System.Windows.Forms.DataGridView DGVMyChat;
        private System.Windows.Forms.Button btnInicializarChat;
        private System.Windows.Forms.NumericUpDown NUDPort;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvAlerts;
        private System.Windows.Forms.Label lbDGVAlerts;
        private System.Windows.Forms.Label lbDGVMessage;
        private System.Windows.Forms.DataGridView DGVChats;
        private System.Windows.Forms.TextBox tbOtherChat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAliasMyChat;
        private System.Windows.Forms.Label lbAliasMyChat;
        private System.Windows.Forms.Panel pnMyChat;
        private System.Windows.Forms.Label lbOtherChatsOff;
        private System.Windows.Forms.DataGridView dgvOffChat;
        private System.Windows.Forms.DataGridViewTextBoxColumn AliasChatOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn meOtherChatOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn aliasMyChat;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.DataGridView DGVPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn portChatAlerts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Razon;
        private System.Windows.Forms.DataGridViewTextBoxColumn aliasChat;
        private System.Windows.Forms.DataGridViewTextBoxColumn aliasUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TextBox tbMyAlias;
        private System.Windows.Forms.Label lbMyAlias;
        private System.Windows.Forms.Panel pnOtherChat;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}

