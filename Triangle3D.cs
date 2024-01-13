using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

using System;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;

namespace pregatire_test
{
     class Triangle3D
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private Color color;
        private bool visibility;
        private float linewidth;
        private float pointsize;
        private PolygonMode polMode;
        private float positionY;
        public Triangle3D(Vector3 pointA, Vector3 pointB, Vector3 pointC, Color color)
        {
            this.pointA = pointA;
            this.pointB = pointB;
            this.pointC = pointC;
            this.color = color;
            this.visibility = true;
            this.linewidth = 5f;
            this.pointsize = 5f;
            this.polMode = PolygonMode.Line;
            this.positionY = 0.0f;
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
            else 
                if(polMode == PolygonMode.Line) 
                { polMode=PolygonMode.Point; }
            
            else{polMode = PolygonMode.Fill; }

            }
        public void ToogleColor(Randomizer _r)
        {
            this.color=_r.getRandomColor();
        }
        public void Draw()
        {
            if (visibility)
            {
                GL.PointSize(pointsize);
                GL.LineWidth(linewidth);
                GL.PolygonMode(MaterialFace.FrontAndBack, polMode);
                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(color);
                // Setarea coordonatelor vârfurilor cu poziția verticală
                GL.Vertex3(pointA.X, pointA.Y + positionY, pointA.Z);
                GL.Vertex3(pointB.X, pointB.Y + positionY, pointB.Z);
                GL.Vertex3(pointC.X, pointC.Y + positionY, pointC.Z);
                GL.End();
            }
        }
        public void MoveUp(float delta)
        {
            // Mișcare în sus
            positionY += delta;
        }

        public void MoveDown(float delta)
        {
            // Mișcare în jos
            positionY -= delta;
        }

    }
}
