using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Drawing.Imaging;

namespace pregatire_test
{
   
     class Window3D : GameWindow
    {
        Color  DEFAULT_BKG_COLOR = Color.Aquamarine;
        Randomizer rando;
        KeyboardState previousKeyboardState;
        MouseState previousMouseState;
        Point3D firstPoint;
        Axes axe;
        Triangle3D tri,tri2;
        Pyramid3D myPyramid;
        Line_3D line;
        Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Purple };
        Vector3 A = new Vector3(0,0,0), B = new Vector3(-2,0,0), C= new Vector3(-1,1,0), D=new Vector3(-2,0,2);
        private Cub3D cub1 = new Cub3D();
        public Window3D() : base(800, 800, new GraphicsMode(32, 24, 0, 8), "Zghibarta Elena 3132a")
        {
            VSync = VSyncMode.On;
            displayHelp();
            rando = new Randomizer();
            firstPoint = new Point3D(rando);
            axe = new Axes();
            tri = new Triangle3D(A, B, C, rando.getRandomColor());
            tri2 = new Triangle3D(A, B, D, rando.getRandomColor());
            myPyramid = new Pyramid3D(
    new Vector3(1.0f, -1.0f, -1.0f),   // PointA
    new Vector3(-1.0f, -1.0f, -1.0f),   // PointB
    new Vector3(-1.0f, -1.0f, 1.0f),   // PointC
    new Vector3(1.0f, -1.0f, 1.0f),   // PointD
    new Vector3(0.0f, 0.0f, 0.0f),   // Apex
    colors);                 // Color ;
            line = new Line_3D(rando.getRandomvector3(rando), rando.getRandomvector3(rando), rando.getRandomColor());
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(DEFAULT_BKG_COLOR);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // setare viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            //setare perspectiva
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)Width / (float)Height, 1, 256);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            //setare camera
            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState thiskeyboard = Keyboard.GetState();
            MouseState thismouse=Mouse.GetState();
            if (thiskeyboard[Key.Escape])
            {
                Exit();
            }
            if (thiskeyboard[Key.B] && !previousKeyboardState[Key.B])
            {
                GL.ClearColor(rando.getRandomColor());
            }
            if (thiskeyboard[Key.R] && !previousKeyboardState[Key.R])
            {
                GL.ClearColor(DEFAULT_BKG_COLOR);
            }
            if (thiskeyboard[Key.H] && !previousKeyboardState[Key.H]) { displayHelp(); }
            if (thiskeyboard[Key.V] && !previousKeyboardState[Key.V]) { firstPoint.Visibility(); }
            if (thiskeyboard[Key.O] && !previousKeyboardState[Key.O]) { firstPoint.resize(); }
            if (thiskeyboard[Key.L] && !previousKeyboardState[Key.L]) { axe.TooglwVisibility(); }
            // Verificați tastele W și S și mișcați triunghiul în consecință
            if (thiskeyboard[Key.W] )
            {
                tri.MoveUp(0.1f);
                tri2.MoveUp(0.1f);
                tri.ToogleColor(rando);
                tri2.ToogleColor(rando);
                myPyramid.MoveAway(0.1f);
            }
            if (thiskeyboard[Key.S] )
            {
                tri.MoveDown(0.1f);
                tri2.MoveDown(0.1f);
                tri.ToogleColor(rando);
                tri2.ToogleColor(rando);
                myPyramid.MoveCloser(0.1f);
            }
            if (thismouse.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released)
            {
                myPyramid.ToogleVisibility();
            }
            if (thiskeyboard[Key.F] && !previousKeyboardState[Key.F])
            {
                myPyramid.TooglePolygonMode();
            }
            if (thiskeyboard[Key.X] && !previousKeyboardState[Key.X])
            {
                line.setColor(rando.getRandomColor());
            }
            if (thiskeyboard[Key.W])
            {
                cub1.Move(new Vector3(0.1f, 0.1f, -0.1f));
            }
            if (thiskeyboard[Key.P] && !previousKeyboardState[Key.P])
            {
                cub1.ModificareCulori();
            }
            if (thismouse.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton != ButtonState.Released)
            {
                cub1.Roatate(1f);
            }
            if (thiskeyboard[Key.Escape])
            {
                Exit();
            }
            if (thiskeyboard[Key.K] && !previousKeyboardState[Key.K])
            {
                cub1.ToogleVisibility();
            }
            previousKeyboardState =thiskeyboard;
            previousMouseState =thismouse;
            
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);


            // COD RENDER
            axe.Draw();
            firstPoint.DrawPoint3D();
            tri.Draw();
            tri2.Draw();
            myPyramid.Draw();
            line.DrawLine();
            cub1.Draw();
            SwapBuffers();
        }
        private void displayHelp()
        {
            Console.WriteLine("\n           Meniu");
            Console.WriteLine("B-schimba culoarea fundalului");
            Console.WriteLine("R-reset parametri");
            Console.WriteLine("esc- iesire din program");
            Console.WriteLine("H-meniu");
            Console.WriteLine("V-Toogle point visibility");
            Console.WriteLine("O-resize point");
            Console.WriteLine("L-Toogle exes visibility");
            Console.WriteLine("W,S-miscare triunghiuri sus/jos,miscare piramida in spate/in fata, W miscare cub in spate");
            Console.WriteLine("click dreapta - toogle pyramid visibility");
            Console.WriteLine("F - toogle pyramid PolygonMode");
            Console.WriteLine("X - toogle line color");
            Console.WriteLine("P - toogle cub face color");
            Console.WriteLine("K - toogle cub visibility");

        }
    }
}
