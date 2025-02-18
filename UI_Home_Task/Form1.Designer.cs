namespace UI_Home_Task
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            textBoxValueA = new TextBox();
            textBoxValueB = new TextBox();
            comboBoxOperation = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(186, 129);
            button1.Margin = new Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new Size(125, 44);
            button1.TabIndex = 0;
            button1.Text = "Calculate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxValueA
            // 
            textBoxValueA.Location = new Point(32, 46);
            textBoxValueA.Margin = new Padding(5, 6, 5, 6);
            textBoxValueA.Name = "textBoxValueA";
            textBoxValueA.Size = new Size(133, 31);
            textBoxValueA.TabIndex = 1;
            textBoxValueA.Text = "Input 1";
            // 
            // textBoxValueB
            // 
            textBoxValueB.Location = new Point(325, 46);
            textBoxValueB.Margin = new Padding(5, 6, 5, 6);
            textBoxValueB.Name = "textBoxValueB";
            textBoxValueB.Size = new Size(134, 31);
            textBoxValueB.TabIndex = 2;
            textBoxValueB.Text = "Input 2";
            // 
            // comboBoxOperation
            // 
            comboBoxOperation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOperation.FormattingEnabled = true;
            comboBoxOperation.Items.AddRange(new object[] { "Add", "Subtract", "Multiply", "Divide" });
            comboBoxOperation.Location = new Point(181, 46);
            comboBoxOperation.Margin = new Padding(5, 6, 5, 6);
            comboBoxOperation.Name = "comboBoxOperation";
            comboBoxOperation.Size = new Size(129, 33);
            comboBoxOperation.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 502);
            Controls.Add(button1);
            Controls.Add(textBoxValueA);
            Controls.Add(textBoxValueB);
            Controls.Add(comboBoxOperation);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxValueA;
        private System.Windows.Forms.TextBox textBoxValueB;
        private System.Windows.Forms.ComboBox comboBoxOperation;
    }
}
