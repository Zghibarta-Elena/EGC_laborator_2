using System;


namespace pregatire_test
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (Window3D ex = new Window3D())
            {
                ex.Run(30.0, 0.0);
            }
        }
    }
}
