namespace SiemensSimulator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.tb_msg = new System.Windows.Forms.TextBox();
            this.cb_num = new System.Windows.Forms.ComboBox();
            this.bt_del = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(37, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "DB:";
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_add.Location = new System.Drawing.Point(274, 29);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(108, 45);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // tb_msg
            // 
            this.tb_msg.Location = new System.Drawing.Point(12, 92);
            this.tb_msg.Multiline = true;
            this.tb_msg.Name = "tb_msg";
            this.tb_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_msg.Size = new System.Drawing.Size(573, 346);
            this.tb_msg.TabIndex = 4;
            // 
            // cb_num
            // 
            this.cb_num.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_num.FormattingEnabled = true;
            this.cb_num.Location = new System.Drawing.Point(101, 34);
            this.cb_num.Name = "cb_num";
            this.cb_num.Size = new System.Drawing.Size(121, 37);
            this.cb_num.TabIndex = 5;
            this.cb_num.Text = "1";
            // 
            // bt_del
            // 
            this.bt_del.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_del.Location = new System.Drawing.Point(427, 29);
            this.bt_del.Name = "bt_del";
            this.bt_del.Size = new System.Drawing.Size(108, 45);
            this.bt_del.TabIndex = 6;
            this.bt_del.Text = "移除";
            this.bt_del.UseVisualStyleBackColor = true;
            this.bt_del.Click += new System.EventHandler(this.bt_del_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 450);
            this.Controls.Add(this.bt_del);
            this.Controls.Add(this.cb_num);
            this.Controls.Add(this.tb_msg);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "西门子PLC数据块模拟";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox tb_msg;
        private System.Windows.Forms.ComboBox cb_num;
        private System.Windows.Forms.Button bt_del;
    }
}

