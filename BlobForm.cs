
using Microsoft.VisualBasic.Logging;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChatGPTYapping {
    public partial class BlobForm : Form {

        System.Windows.Forms.Timer timer = new( ) { Interval = 16, Enabled = true };
        readonly Pen pen = new Pen( new SolidBrush( Color.Black ) );
        (float, float, float) vars = (1f, 2f, 3f);
        List<Polygons> Polygons = new( );
        public BlobForm( ) {
            InitializeComponent( );
            timer.Tick += ( sender, e ) => Invalidate( );
            DoubleBuffered = true;

            Polygons = new List<Polygons> {
                new Polygons( new( 100, 200 ), 50, 75, 50 ),
                new Polygons( new( 200, 200 ), 50, 100, 50 ),
                new Polygons( new( 300, 200 ), 50, 125, 50 ),
                new Polygons( new( 400, 200 ), 50, 150, 50 ),
                new Polygons( new( 500, 200 ), 50, 175, 50 ),
                new Polygons( new( 600, 200 ), 50, 200, 50 ),
            };

        }

        protected override void OnPaint( PaintEventArgs e ) {

            base.OnPaint( e );

            for ( int i = 0; i < Polygons.Count; i++ ) {
                Polygons[ i ].GetPolygonPath( random.Value, segments.Value );
                for ( int j = 0; j < Polygons.Count; j++ ) {

                    if ( i == j )
                        continue;

                    try {
                        MakeDistanceBetween( Polygons[ i ], Polygons[ j ] );

                    }
                    catch {

                    }
                }
            }
            Polygons.ForEach( it => {

                it.FixDistances( );
                if ( it.points.Count > 1 )
                    e.Graphics.DrawPolygon( pen, it.points.ToArray( ) );
            } );
        }

        public static PointF CalculateDistance( PointF point1, PointF point2 ) {
            // Calculate the differences in the X and Y coordinates
            float distanceX = point2.X - point1.X;
            float distanceY = point2.Y - point1.Y;

            // Return the distances as a new PointF
            return new PointF( distanceX, distanceY );
        }

        void MakeDistanceBetween( Polygons poly1, Polygons poly2 ) {

            var p1 = poly1.points;
            var p2 = poly2.points;

            for ( int i = 0; i < p1.Count; i++ ) {

                for ( int j = 0; j < p2.Count; j++ ) {

                    PointF vector = CalculateDistance( p1[ i ], p2[ j ] ); // Vector from point1 to point2
                    float distance = ( float )Math.Sqrt( vector.X * vector.X + vector.Y * vector.Y ); // Calculate the actual distance

                    if ( distance < tolarence.Value ) {
                        // The amount to move points to ensure the distance is 20
                        float adjustment = ( tolarence.Value - distance ) / 2;

                        // Calculate the adjustment vector without normalizing it
                        float adjustX = vector.X * adjustment / distance;
                        float adjustY = vector.Y * adjustment / distance;

                        var calculatedPoint1 = new PointF( p1[ i ].X - adjustX, p1[ i ].Y - adjustY );
                        var calculatedPoint2 = new PointF( p2[ j ].X + adjustX, p2[ j ].Y + adjustY );

                        if ( CalculateDistance( calculatedPoint1, (PointF)poly2.center ).ToVector2().Length() 
                            > CalculateDistance( p1[ i ], ( PointF )poly2.center ).ToVector2().Length() ) {

                            // Move p1[i] away from p2[j]
                            p1[ i ] = new PointF( p1[ i ].X - adjustX, p1[ i ].Y - adjustY );
                        }
                        if ( CalculateDistance( calculatedPoint2, ( PointF )poly1.center ).ToVector2( ).Length( )
                            > CalculateDistance( p2[ i ], ( PointF )poly1.center ).ToVector2( ).Length( ) ) {

                            // Move p2[j] further in the direction of the vector to increase distance
                            p2[ j ] = new PointF( p2[ j ].X + adjustX, p2[ j ].Y + adjustY );
                        }
                    }
                }
            }
        }
    }

    public class Polygons {

        public List<PointF> points = new( );
        public Point center = Point.Empty;
        public int segments = 0;
        public float x = 0;
        public float y = 0;

        public Polygons( Point center, float x, float y, int segments ) {

            this.center = center;
            this.x = x;
            this.y = y;
            this.segments = segments;
            GetPolygonPath( );
        }

        public void GetPolygonPath( float random = 0, int segments = 0 ) {

            if ( segments != 0 )
                this.segments = segments;
            float flStep = ( float )( 2 * Math.PI ) / this.segments;

            List<PointF> pointsList = new( );

            for ( float rotation = 0; rotation < ( Math.PI * 2.0 ); rotation += flStep ) {
                PointF something = new PointF(
                    ( float )( x * Math.Sin( rotation ) + center.X + Math.Cos( random ) * ( x / 10f ) ),
                    ( float )( y * Math.Cos( rotation ) + center.Y + Math.Cos( random ) * ( y / 10f ) ) );

                pointsList.Add( something );
                random += 0.2f;
            }
            pointsList[ 0 ] = pointsList.Last( );
                
            points = pointsList;
        }

        public void FixDistances( ) {

            for ( int i = 0; i < points.Count; i++ ) {

                var vectorFromMiddle = BlobForm.CalculateDistance( points[ i ], ( PointF )center );
                var vectorFromEdge = BlobForm.CalculateDistance( points[ i ], new PointF(center.X + x + 10, center.Y + y + 10) );
                if ( vectorFromMiddle.ToVector2().Length() > vectorFromEdge.ToVector2().Length() ) {

                    points.RemoveAt( i );
                }
            }
        }
    }
}