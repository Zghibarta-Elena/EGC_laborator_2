using OpenTK;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace pregatire_test
{
    internal class Line_3D
    {
        private Vector3 pointA, pointB;
        private float linewidth;
        private float pointsize;
        private bool visibility;
        private Color color;

        public Line_3D(Vector3 pointA, Vector3 pointB, Color color)
        {
            this.pointA = pointA;
            this.pointB = pointB;
            linewidth = 1f;
            pointsize = 1f;
            visibility = true;
            this.color = color;
        }
        public void DrawLine()
        {
            if (visibility)
            {
                GL.PointSize(pointsize);
                GL.LineWidth(linewidth);
                GL.Color3(color);
                GL.Begin(PrimitiveType.Lines);
                GL.Vertex3(pointA);
                GL.Vertex3(pointB);
                GL.End();
            }
        }
        public void setColor(Color col)
        {
            this.color = col;
        }
    }
}
