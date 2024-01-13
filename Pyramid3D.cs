
using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace pregatire_test
{
     class Pyramid3D
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private Vector3 pointD;
        private Vector3 apex;
        private Color[] colors;
        private bool visibility;
        private float linewidth;
        private float pointsize;
        private PolygonMode polMode;
        private float positionZ;
        public Pyramid3D(Vector3 pointA, Vector3 pointB, 
            Vector3 pointC, Vector3 pointD, Vector3 apex, Color[] color)
        {
            this.pointA = pointA;
            this.pointB = pointB;
            this.pointC = pointC;
            this.pointD = pointD;
            this.apex = apex;
            this.colors = color;
            this.visibility = true;
            this.linewidth = 5f;
            this.pointsize = 5f;
            this.polMode = PolygonMode.Fill;
            this.positionZ = 0;
        }
        public void ToogleVisibility()
        {
            this.visibility = !visibility;
        }

        public void TooglePolygonMode()
        {
            if (polMode == PolygonMode.Fill)
            {
                polMode = PolygonMode.Line;
            }
            else if (polMode == PolygonMode.Line)
            {
                polMode = PolygonMode.Point;
            }
            else
            {
                polMode = PolygonMode.Fill;
            }
        }
        public void ToogleColor(Randomizer _r)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = _r.getRandomColor();
            }
        }
        public void Draw()
        {
            if (visibility)
            {
                GL.PointSize(pointsize);
                GL.LineWidth(linewidth);
                GL.PolygonMode(MaterialFace.FrontAndBack, polMode);

                // Desenăm baza patrulateră
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(colors[0]);
                GL.Vertex3(pointA.X,pointA.Y,pointA.Z+positionZ);
                GL.Vertex3(pointB.X, pointB.Y, pointB.Z + positionZ);
                GL.Vertex3(pointC.X, pointC.Y, pointC.Z + positionZ);
                GL.Vertex3(pointD.X,pointD.Y, pointD.Z + positionZ);
                GL.End();

                // Desenăm fețele laterale ale piramidei
                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(colors[1]);
                GL.Vertex3(pointA.X, pointA.Y, pointA.Z + positionZ);
                GL.Vertex3(pointB.X,pointB.Y, pointB.Z + positionZ);
                GL.Vertex3(apex.X, apex.Y, apex.Z + positionZ);
                GL.End();

                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(colors[2]);
                GL.Vertex3(pointB.X,pointB.Y, pointB.Z + positionZ);
                GL.Vertex3(pointC.X, pointC.Y, pointC.Z + positionZ);
                GL.Vertex3(apex.X,apex.Y, apex.Z + positionZ);
                GL.End();

                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(colors[3]);
                GL.Vertex3(pointC.X, pointC.Y, pointC.Z + positionZ);
                GL.Vertex3(pointD.X,pointD.Y, pointD.Z + positionZ);
                GL.Vertex3(apex.X, apex.Y, apex.Z + positionZ);
                GL.End();

                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(colors[4]);
                GL.Vertex3(pointD.X,pointD.Y, pointD.Z + positionZ);
                GL.Vertex3(pointA.X, pointA.Y, pointA.Z + positionZ);
                GL.Vertex3(apex.X,apex.Y, apex.Z + positionZ);
                GL.End();
            }
        }
        public void MoveAway(float distance)
        {
            positionZ -= distance;
        }

        public void MoveCloser(float distance)
        {
            positionZ += distance;
        }
    }
    
    }
