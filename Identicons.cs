//  Copyright (c) 2007 Daniel Schick (original) 
//  Copyright (c) 2016 Martin Staufcik (modifications)

// This code is base on the source code created by Daniel Schick.
// Some modifications: 
// * the dimension is 4x4 instead of original 3x3
// * added a new symetric shape (p15)
// * removed the outline

#region GPL

// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace IdenticonGeneratorTest
{
    public class Identicon
    {
        private static List<GraphicsPath> shapes = new List<GraphicsPath>(16);
        private static List<int> symshapes = new List<int>(4);

        private static bool initialized = false;

        private static void Initialize()
        {
            for (int i = 0; i < 16; i++)
            {
                GraphicsPath gp = new GraphicsPath();
                GraphicsPath ip = new GraphicsPath();
                shapes.Add(gp);
            }

            // initializing the 16 shapes

            #region obere Reihe

            PointF[] p0 = new PointF[4];
            p0[0].X = 0; p0[0].Y = 0;
            p0[1].X = 1; p0[1].Y = 0;
            p0[2].X = 0; p0[2].Y = 1;
            p0[3].X = 1; p0[3].Y = 1;
            shapes[0].AddPolygon(p0);

            PointF[] p1 = new PointF[3];
            p1[0].X = 0; p1[0].Y = 0;
            p1[1].X = 1; p1[1].Y = 0;
            p1[2].X = 0; p1[2].Y = 1;
            shapes[1].AddPolygon(p1);

            PointF[] p2 = new PointF[3];
            p2[0].X = 0; p2[0].Y = 1;
            p2[1].X = 0.5F; p2[1].Y = 0;
            p2[2].X = 1; p2[2].Y = 1;
            shapes[2].AddPolygon(p2);

            PointF[] p3 = new PointF[4];
            p3[0].X = 0; p3[0].Y = 0;
            p3[1].X = 0.5F; p3[1].Y = 0;
            p3[2].X = 0.5F; p3[2].Y = 1;
            p3[3].X = 0; p3[3].Y = 1;
            shapes[3].AddPolygon(p3);

            PointF[] p4 = new PointF[4];
            p4[0].X = 0.5F; p4[0].Y = 0;
            p4[1].X = 1; p4[1].Y = 0.5F;
            p4[2].X = 0.5F; p4[2].Y = 1;
            p4[3].X = 0; p4[3].Y = 0.5F;
            shapes[4].AddPolygon(p4);

            PointF[] p5 = new PointF[4];
            p5[0].X = 0; p5[0].Y = 0;
            p5[1].X = 1; p5[1].Y = 0.5F;
            p5[2].X = 1; p5[2].Y = 1;
            p5[3].X = 0.5F; p5[3].Y = 1;
            shapes[5].AddPolygon(p5);

            PointF[] p61 = new PointF[3];
            p61[0].X = 0.5F; p61[0].Y = 0;
            p61[1].X = 0.75F; p61[1].Y = 0.5F;
            p61[2].X = 0.25F; p61[2].Y = 0.5F;
            shapes[6].AddPolygon(p61);

            PointF[] p62 = new PointF[3];
            p62[0].X = 0.75F; p62[0].Y = 0.5F;
            p62[1].X = 1; p62[1].Y = 1;
            p62[2].X = 0.5F; p62[2].Y = 1;
            shapes[6].AddPolygon(p62);

            PointF[] p63 = new PointF[3];
            p63[0].X = 0.25F; p63[0].Y = 0.5F;
            p63[1].X = 0.5F; p63[1].Y = 1;
            p63[2].X = 0; p63[2].Y = 1;
            shapes[6].AddPolygon(p63);

            PointF[] p7 = new PointF[3];
            p7[0].X = 0; p7[0].Y = 0;
            p7[1].X = 1; p7[1].Y = 0.5F;
            p7[2].X = 0.5F; p7[2].Y = 1;

            #endregion

            #region untere Reihe

            PointF[] p8 = new PointF[4];
            p8[0].X = 0.25F; p8[0].Y = 0.25F;
            p8[1].X = 0.75F; p8[1].Y = 0.25F;
            p8[2].X = 0.75F; p8[2].Y = 0.75F;
            p8[3].X = 0.25F; p8[3].Y = 0.75F;
            shapes[8].AddPolygon(p8);

            PointF[] p91 = new PointF[3];
            p91[0].X = 0.5F; p91[0].Y = 0;
            p91[1].X = 1; p91[1].Y = 0;
            p91[2].X = 0.5F; p91[2].Y = 0.5F;
            shapes[9].AddPolygon(p91);

            PointF[] p92 = new PointF[3];
            p92[0].X = 0; p92[0].Y = 0.5F;
            p92[1].X = 0.5F; p92[1].Y = 0.5F;
            p92[2].X = 0; p92[2].Y = 1;
            shapes[9].AddPolygon(p92);

            PointF[] p10 = new PointF[4];
            p10[0].X = 0; p10[0].Y = 0;
            p10[1].X = 0.5F; p10[1].Y = 0;
            p10[2].X = 0.5F; p10[2].Y = 0.5F;
            p10[3].X = 0; p10[3].Y = 0.5F;
            shapes[10].AddPolygon(p10);

            PointF[] p11 = new PointF[3];
            p11[0].X = 0; p11[0].Y = 0.5F;
            p11[1].X = 1; p11[1].Y = 0.5F;
            p11[2].X = 0.5F; p11[2].Y = 1;
            shapes[11].AddPolygon(p11);

            PointF[] p12 = new PointF[3];
            p12[0].X = 0; p12[0].Y = 1;
            p12[1].X = 0.5F; p12[1].Y = 0.5F;
            p12[2].X = 1; p12[2].Y = 1;
            shapes[12].AddPolygon(p12);

            PointF[] p13 = new PointF[3];
            p13[0].X = 0.5F; p13[0].Y = 0;
            p13[1].X = 0.5F; p13[1].Y = 0.5F;
            p13[2].X = 0; p13[2].Y = 0.5F;
            shapes[13].AddPolygon(p13);

            PointF[] p14 = new PointF[3];
            p14[0].X = 0; p14[0].Y = 0;
            p14[1].X = 0.5F; p14[1].Y = 0;
            p14[2].X = 0; p14[2].Y = 0.5F;
            shapes[14].AddPolygon(p14);

            PointF[] p15 = new PointF[8];
            p15[0].X = 0; p15[0].Y = 0;
            p15[1].X = 0.5F; p15[1].Y = 0.25F;
            p15[2].X = 1; p15[2].Y = 0;
            p15[3].X = 0.75F; p15[3].Y = 0.5F;
            p15[4].X = 1; p15[4].Y = 1;
            p15[5].X = 0.5F; p15[5].Y = 0.75F;
            p15[6].X = 0; p15[6].Y = 1;
            p15[7].X = 0.25F; p15[7].Y = 0.5F;
            shapes[15].AddPolygon(p15);

            #endregion

            symshapes = new List<int>();
            symshapes.Add(0);
            symshapes.Add(4);
            symshapes.Add(8);
            symshapes.Add(15);

            initialized = true;
        }

        private static int GetX(int i, int d)
        {
            switch (i)
            {
                case 0: return d == 1 ? 1 : 0;
                case 1: return d == 1 ? 2 : 3;
                case 2: return d == 1 ? 2 : 3;
                case 3: return d == 1 ? 1 : 0;
            }
            throw new Exception();
        }

        private static int GetY(int i, int d)
        {
            switch (i)
            {
                case 0: return d == 1 ? 1 : 0;
                case 1: return d == 1 ? 1 : 0;
                case 2: return d == 1 ? 2 : 3;
                case 3: return d == 1 ? 2 : 3;
            }
            throw new Exception();
        }

        /// <summary>
        /// creates a new Identicon
        /// </summary>
        /// <param name="source">source value, e.g. a hash created from a username, an ip address,..</param>
        /// <param name="size">side length</param>
        /// <returns>a 24 bpp bitmap</returns>
        public static Image CreateIdenticon(int source, uint size)
        {
            if (size == 0) return null;
            if (!initialized) Initialize();
            Bitmap bi = new Bitmap((int)size, (int)size);
            Graphics g = Graphics.FromImage(bi);
            g.Clear(Color.White);
            //g.SmoothingMode = SmoothingMode.HighQuality; // try different settings

            int middleindex = symshapes[source & 3]; // first 2 bits for middle shapes
            int sideindex = (source >> 2) & 15; // next 4 bits for side shapes
            int cornerindex = (source >> 6) & 15; // next 4 for corners
            int siderot = (source >> 10) & 3; // 2 bits for side offset rotation
            int cornerrot = (source >> 12) & 3; // 2 bits for corner offset rotation

            float shapesize = (float)size / 4.0F; // adjust the shape size to the target bitmap size
            Matrix sizeMatrix = new Matrix();
            sizeMatrix.Scale(shapesize, shapesize);
            Matrix tlrMatrix = new Matrix(); // translates 1 unit to the right
            tlrMatrix.Translate(shapesize, 0);
            Matrix tldMatrix = new Matrix(); // translates 1 unit down
            tldMatrix.Translate(0, shapesize);

            // inversion per shape

            // calculate color
            int red = (source >> 14) & 31;
            int green = (source >> 19) & 31;
            int blue = (source >> 24) & 31;
            Color shapecolor = Color.FromArgb(red * 8, green * 8, blue * 8);

            // remaining bits to decide shape flipping
            bool flipcenter = ((source >> 29) & 1) == 1;
            bool flipcorner = ((source >> 30) & 1) == 1;
            bool flipsides = ((source >> 31) & 1) == 1;

            using (SolidBrush sb = new SolidBrush(shapecolor), wb = new SolidBrush(Color.White))
            {

                #region Transform and move shapes into position

                // four identical pieces for the center
                DrawSegment(g, middleindex, 0, sizeMatrix, tlrMatrix, tldMatrix, false, shapesize, 1, 1, sb, wb);
                DrawSegment(g, middleindex, 0, sizeMatrix, tlrMatrix, tldMatrix, flipcenter, shapesize, 2, 1, sb, wb);
                DrawSegment(g, middleindex, 0, sizeMatrix, tlrMatrix, tldMatrix, false, shapesize, 2, 2, sb, wb);
                DrawSegment(g, middleindex, 0, sizeMatrix, tlrMatrix, tldMatrix, flipcenter, shapesize, 1, 2, sb, wb);

                for (int i = 0; i < 4; i++)
                {
                    // corner
                    DrawSegment(g, cornerindex, i + siderot, sizeMatrix, tlrMatrix, tldMatrix, flipcorner, shapesize, GetX(i, 2), GetY(i, 2), sb, wb);

                    // two outer side squares
                    DrawSegment(g, sideindex, i + siderot, sizeMatrix, tlrMatrix, tldMatrix, false, shapesize, GetX(i, 1), GetY(i, 2), sb, wb);
                    DrawSegment(g, sideindex, i + siderot, sizeMatrix, tlrMatrix, tldMatrix, flipsides, shapesize, GetX(i, 2), GetY(i, 1), sb, wb);
                }

                #endregion
            }
            return bi;
        }

        private static void DrawSegment(Graphics g, int shapeindex, int rotation, Matrix sizeMatrix, Matrix tlrMatrix, Matrix tldMatrix, bool flip, float shapesize, int x, int y, SolidBrush sb, SolidBrush wb)
        {
            GraphicsPath g1 = shapes[shapeindex].Clone() as GraphicsPath;
            RotatePath90(g1, rotation);
            g1.Transform(sizeMatrix);

            for (var i = 0; i < x; i++)
            {
                g1.Transform(tlrMatrix);
            }
            for (var i = 0; i < y; i++)
            {
                g1.Transform(tldMatrix);
            }

            if (flip)
            {
                g.FillRectangle(sb, shapesize * x, shapesize * y, shapesize, shapesize);
                g.FillPath(wb, g1);
            }
            else
            {
                g.FillPath(sb, g1);
            }
        }

        /// <summary>
        /// helper func to rotate input matrix
        /// </summary>
        private static void RotatePath90(GraphicsPath gp, int times)
        {
            Matrix rotMatrix = new Matrix();
            rotMatrix.RotateAt(90.0F, new PointF(0.5F, 0.5f));

            times = times % 4;
            for (int i = 0; i < times; i++)
                gp.Transform(rotMatrix);
        }

    }
}

