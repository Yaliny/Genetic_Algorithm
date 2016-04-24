namespace Genetic_Algorythm
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "Go!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "This is the C# implementation of  genetic algorithm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "for finding the optimal solution of the Knapsack problem.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "predefined weights and values. However, population size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Solving is avaliable for 5, 10, 15 and 20 items with";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "and number of generations are customized, as well as ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "crossover and mutation probabilities.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(256, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Solving can be performed in two modes: step by step";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(268, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "with output of the current population on every step, and";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(266, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "automatic calculation with output of the final population";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(104, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "and the best solution.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(188, 226);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "© Olena Primachova, 2016";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 242);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Genetic Algorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

