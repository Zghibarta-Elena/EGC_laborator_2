using OpenTK;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

using System.Collections.Generic;
using System.Drawing;

namespace pregatire_test
{

    public class Triunghi
    {
        public Vector3 punct1;
        public Vector3 punct2;
        public Vector3 punct3;
        public Vector3 culoare;

        public Triunghi(Vector3 punct1, Vector3 punct2, Vector3 punct3, Vector3 culoare)
        {
            this.punct1 = punct1;
            this.punct2 = punct2;
            this.punct3 = punct3;
            this.culoare = culoare;
        }
    }

    public class Cub3D
    {
        public List<Triunghi> triunghiuri;
        Randomizer rando;
        bool visibility;
        public Cub3D()

        {
            visibility = true;
            triunghiuri = new List<Triunghi>();
            rando = new Randomizer();

            Triunghi t1 = new Triunghi(
                new Vector3(0, 0, 0),
                new Vector3(1, 0, 0),
                new Vector3(1, 0, 1),
                rando.getRandomvector3TriunghiColor(rando)
                );

            Triunghi t2 = new Triunghi(
                new Vector3(0, 0, 0),
                new Vector3(1, 0, 1),
                new Vector3(0, 0, 1),
                                rando.getRandomvector3TriunghiColor(rando)

                );

            Triunghi t3 = new Triunghi(
                new Vector3(0, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(1, 0, 0),
                                rando.getRandomvector3TriunghiColor(rando)

                );
            Triunghi t4 = new Triunghi(
                new Vector3(0, 1, 0),
                new Vector3(1, 1, 0),
                new Vector3(1, 0, 0),
                rando.getRandomvector3TriunghiColor(rando)

                );
            Triunghi t5 = new Triunghi(
               new Vector3(0, 0, 0),
               new Vector3(0, 0, 1),
               new Vector3(0, 1, 1),
                rando.getRandomvector3TriunghiColor(rando)

               );
            Triunghi t6 = new Triunghi(
               new Vector3(0, 0, 0),
               new Vector3(0, 1, 1),
               new Vector3(0, 1, 0),
                rando.getRandomvector3TriunghiColor(rando)

               );
            Triunghi t7 = new Triunghi(
               new Vector3(1, 1, 1),
               new Vector3(0, 1, 1),
               new Vector3(0, 1, 0),
                               rando.getRandomvector3TriunghiColor(rando)

               );
            Triunghi t8 = new Triunghi(
               new Vector3(1, 1, 1),
               new Vector3(0, 1, 0),
               new Vector3(1, 1, 0),
                               rando.getRandomvector3TriunghiColor(rando)

               );
            Triunghi t9 = new Triunghi(
               new Vector3(0, 0, 1),
               new Vector3(0, 1, 1),
               new Vector3(1, 1, 1),
                               rando.getRandomvector3TriunghiColor(rando)

               );
            Triunghi t10 = new Triunghi(
               new Vector3(0, 0, 1),
               new Vector3(1, 1, 1),
               new Vector3(1, 0, 1),
                               rando.getRandomvector3TriunghiColor(rando)

               );
            Triunghi t11 = new Triunghi(
               new Vector3(1, 1, 1),
               new Vector3(1, 0, 0),
               new Vector3(1, 0, 1),
                               rando.getRandomvector3TriunghiColor(rando)

               );
            Triunghi t12 = new Triunghi(
               new Vector3(1, 1, 1),
               new Vector3(1, 1, 0),
               new Vector3(1, 0, 0),
                               rando.getRandomvector3TriunghiColor(rando)

               );

            triunghiuri.Add(t1);
            triunghiuri.Add(t2);
            triunghiuri.Add(t3);
            triunghiuri.Add(t4);
            triunghiuri.Add(t5);
            triunghiuri.Add(t6);
            triunghiuri.Add(t7);
            triunghiuri.Add(t8);
            triunghiuri.Add(t9);
            triunghiuri.Add(t10);
            triunghiuri.Add(t11);
            triunghiuri.Add(t12);
        }

        public void Draw()
        {
            if (visibility)
            {
                GL.Begin(PrimitiveType.Triangles);

                foreach (Triunghi t in triunghiuri)
                {
                    GL.Color3(t.culoare);
                    GL.Vertex3(t.punct1);
                    GL.Vertex3(t.punct2);
                    GL.Vertex3(t.punct3);


                }

                GL.End();
            }
        }
        public void ToogleVisibility()
        {
            visibility = !visibility;
        }
        public void ModificareCulori()
        {
            foreach (Triunghi t in triunghiuri)
            {
                t.culoare = rando.getRandomvector3TriunghiColor(rando);
            }
        }
        public void Move(Vector3 offset)
        {
            foreach (Triunghi t in triunghiuri)
            {
                t.punct1 += offset;
                t.punct2 += offset;
                t.punct3 += offset;
            }
        }

        public void Roatate(float offset)
        {
            foreach (Triunghi t in triunghiuri)
            {
                // Specify the rotation angle in radians
                float angleInRadians = (float)MathHelper.DegreesToRadians(offset);

                // Create a rotation matrix
                Matrix3 rotationMatrix = Matrix3.CreateRotationX(angleInRadians);

                t.punct1 = Vector3.Transform(t.punct1, rotationMatrix);
                t.punct2 = Vector3.Transform(t.punct2, rotationMatrix);
                t.punct3 = Vector3.Transform(t.punct3, rotationMatrix);
            }


        }
    }
}
