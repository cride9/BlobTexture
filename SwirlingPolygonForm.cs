using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatGPTYapping {
    public partial class SwirlingPolygonForm : Form {

        public SwirlingPolygonForm( ) {
            InitializeComponent( );
            this.DoubleBuffered = true;
            segments = new PointF[ numSegments ];
            CalculateLoopingPath( );
        }

        private PointF[ ] segments;
        private int numSegments = 100; // Number of segments in the snake
        private float segmentLength = 5.0f; // Length between segments

        private void CalculateLoopingPath( ) {
            // Calculate the center of the form
            PointF center = new PointF( this.ClientSize.Width / 2, this.ClientSize.Height / 2 );
            float radius = Math.Min( this.ClientSize.Width, this.ClientSize.Height ) / 4; // Radius of the circular path

            // Calculate each segment's position along a circular path
            for ( int i = 0; i < numSegments; i++ ) {
                float angle = ( float )i / numSegments * 2 * ( float )Math.PI; // Angle for this segment
                segments[ i ] = new PointF(
                    center.X + radius * ( float )Math.Cos( angle ),
                    center.Y + radius * ( float )Math.Sin( angle )
                );
            }
        }

        protected override void OnPaint( PaintEventArgs e ) {
            base.OnPaint( e );

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the pre-calculated static looping path
            using ( Pen pen = new Pen( Color.Blue, 10 ) ) {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                for ( int i = 0; i < segments.Length - 1; i++ ) {
                    g.DrawLine( pen, segments[ i ], segments[ i + 1 ] );
                }
                // Connect the tail to the head to complete the loop
                g.DrawLine( pen, segments[ segments.Length - 1 ], segments[ 0 ] );
            }
        }



    }
}

