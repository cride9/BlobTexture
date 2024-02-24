namespace ChatGPTYapping {
    partial class BlobForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( ) {
            tolarence = new TrackBar( );
            label1 = new Label( );
            label2 = new Label( );
            random = new TrackBar( );
            label3 = new Label( );
            segments = new TrackBar( );
            ( ( System.ComponentModel.ISupportInitialize )tolarence ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )random ).BeginInit( );
            ( ( System.ComponentModel.ISupportInitialize )segments ).BeginInit( );
            SuspendLayout( );
            // 
            // tolarence
            // 
            tolarence.Location = new Point( 12, 393 );
            tolarence.Maximum = 50;
            tolarence.Name = "tolarence";
            tolarence.Size = new Size( 104, 45 );
            tolarence.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point( 12, 375 );
            label1.Name = "label1";
            label1.Size = new Size( 57, 15 );
            label1.TabIndex = 1;
            label1.Text = "Tolarence";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point( 122, 375 );
            label2.Name = "label2";
            label2.Size = new Size( 52, 15 );
            label2.TabIndex = 3;
            label2.Text = "Random";
            // 
            // random
            // 
            random.Location = new Point( 122, 393 );
            random.Maximum = 200;
            random.Name = "random";
            random.Size = new Size( 104, 45 );
            random.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point( 232, 375 );
            label3.Name = "label3";
            label3.Size = new Size( 59, 15 );
            label3.TabIndex = 5;
            label3.Text = "Segments";
            // 
            // segments
            // 
            segments.Location = new Point( 232, 393 );
            segments.Maximum = 100;
            segments.Name = "segments";
            segments.Size = new Size( 104, 45 );
            segments.TabIndex = 4;
            // 
            // BlobForm
            // 
            AutoScaleDimensions = new SizeF( 7F, 15F );
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size( 800, 450 );
            Controls.Add( label3 );
            Controls.Add( segments );
            Controls.Add( label2 );
            Controls.Add( random );
            Controls.Add( label1 );
            Controls.Add( tolarence );
            Name = "BlobForm";
            Text = "ChatGPT yapping";
            ( ( System.ComponentModel.ISupportInitialize )tolarence ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )random ).EndInit( );
            ( ( System.ComponentModel.ISupportInitialize )segments ).EndInit( );
            ResumeLayout( false );
            PerformLayout( );
        }

        #endregion

        private TrackBar tolarence;
        private Label label1;
        private Label label2;
        private TrackBar random;
        private Label label3;
        private TrackBar segments;
    }
}
