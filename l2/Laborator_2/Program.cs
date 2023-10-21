using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

class Program : GameWindow
{
    private float triangleX = 0.0f;
    private float triangleY = 0.0f;

    public Program(int width, int height) : base(width, height, GraphicsMode.Default, "OpenGL Control")
    {
        VSync = VSyncMode.On;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        GL.ClearColor(Color4.Black);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit);

        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadIdentity();

        GL.Begin(PrimitiveType.Triangles);

        GL.Color3((System.Drawing.Color)Color4.Red);
        GL.Vertex2(triangleX, triangleY);

        GL.Color3((System.Drawing.Color)Color4.Green);
        GL.Vertex2(triangleX + 0.2f, triangleY);

        GL.Color3((System.Drawing.Color)Color4.Blue);
        GL.Vertex2(triangleX + 0.1f, triangleY + 0.2f);

        GL.End();

        SwapBuffers();
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Key.A))
        {
            triangleX -= 0.01f;
        }
        if (keyboard.IsKeyDown(Key.D))
        {
            triangleX += 0.01f;
        }
    }

    protected override void OnMouseMove(MouseMoveEventArgs e)
    {
        base.OnMouseMove(e);

        // Calculează deplasarea relativă a cursorului mouse-ului între frame-uri
        float deltaX = e.XDelta / (float)Width;
        float deltaY = e.YDelta / (float)Height;

        // Ajustează poziția triunghiului folosind deplasarea relativă
        triangleX += deltaX;
        triangleY -= deltaY; // Observați că ajustăm și coordonata Y pentru a corecta direcția

        // Limitați poziția triunghiului la marginea ecranului (opțional)
        triangleX = Math.Max(Math.Min(triangleX, 1.0f), -1.0f);
        triangleY = Math.Max(Math.Min(triangleY, 1.0f), -1.0f);
    }

    static void Main(string[] args)
    {
        using (Program program = new Program(800, 600))
        {
            program.Run(60.0);
        }
    }
}
