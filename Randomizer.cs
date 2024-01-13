using OpenTK;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pregatire_test
{
     class Randomizer:Random
    {
        private Random r;
         public Randomizer()
        {
            r = new Random();
        }
        public Color getRandomColor()
        {
            int genR=r.Next(0,256);
            int genG= r.Next(0, 256);
            int genB = r.Next(0, 256);
            Color col=Color.FromArgb( genR, genG, genB);
            return col;
        }
        public Vector3 getRandomvector3(Randomizer _r)
        {
            Vector3 vector3 = new Vector3(_r.Next(-15, 15),
          _r.Next(-15, 15), _r.Next(-15, 15));
            return vector3;
        }
        public Vector3 getRandomvector3TriunghiColor(Randomizer _r)
        {
            Vector3 vector3 = new Vector3(_r.Next(0, 256)
           , _r.Next(0, 256), _r.Next(0, 256));
            return vector3;
        }

    }
}
