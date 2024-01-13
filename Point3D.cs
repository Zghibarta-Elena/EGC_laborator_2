using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

using System.Drawing;


namespace pregatire_test
{
    class Point3D
    {
        private Vector3 position;
        private bool visibility;
        private Color color;
        private float size;

        public Point3D(Randomizer _r)
        {
            this.position = new Vector3(3, -5, 11);
            this.size = 5f;
            this.visibility = true;
            this.color = _r.getRandomColor();
        }
        public void resize()
        {
            if (size == 5f){size = 20f; }
            else{ size = 5f;}
        }
        public void DrawPoint3D()
        {
            if (visibility)
            {
                GL.PointSize(size);
                GL.Begin(PrimitiveType.Points);
                GL.Color3(color);
                GL.Vertex3(position);
                GL.End();
            }
        }
        public void Visibility()
        {
            visibility = !visibility;
        }
       
    }
}