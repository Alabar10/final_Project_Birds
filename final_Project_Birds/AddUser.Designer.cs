
namespace final_Project_Birds
{
    partial class AddUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addusername = new System.Windows.Forms.TextBox();
            this.addpassword = new System.Windows.Forms.TextBox();
            this.addID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Id";
            // 
            // addusername
            // 
            this.addusername.Location = new System.Drawing.Point(384, 95);
            this.addusername.Name = "addusername";
            this.addusername.Size = new System.Drawing.Size(119, 26);
            this.addusername.TabIndex = 3;
            this.addusername.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // addpassword
            // 
            this.addpassword.Location = new System.Drawing.Point(384, 161);
            this.addpassword.Name = "addpassword";
            this.addpassword.Size = new System.Drawing.Size(119, 26);
            this.addpassword.TabIndex = 4;
            this.addpassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // addID
            // 
            this.addID.Location = new System.Drawing.Point(384, 213);
            this.addID.Name = "addID";
            this.addID.Size = new System.Drawing.Size(119, 26);
            this.addID.TabIndex = 5;
            this.addID.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Sign In";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlueViolet;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addID);
            this.Controls.Add(this.addpassword);
            this.Controls.Add(this.addusername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addusername;
        private System.Windows.Forms.TextBox addpassword;
        private System.Windows.Forms.TextBox addID;
        private System.Windows.Forms.Button button1;
    }
}