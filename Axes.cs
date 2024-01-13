using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;

namespace pregatire_test
{
     class Axes
    {
        private bool visibility;
        public Axes() { visibility = true; }

        public void Draw()
        {
            if (visibility)
            {
                GL.Begin(PrimitiveType.Lines);

                // X axis (Red)
                GL.Color3(Color.Blue);
                GL.Vertex3(0.0f, 0.0f, 0.0f);
                GL.Vertex3(20, 0.0f, 0.0f);

                // Y axis (Green)
                GL.Color3(Color.Red);
                GL.Vertex3(0.0f, 0.0f, 0.0f);
                GL.Vertex3(0.0f, 20, 0.0f);

                // Z axis (Blue)
                GL.Color3(Color.Green);
                GL.Vertex3(0.0f, 0.0f, 0.0f);
                GL.Vertex3(0.0f, 0.0f, 20);

                GL.End();
            }
        }
        public void TooglwVisibility()
        {
            visibility = !visibility;
        }
    }
}
