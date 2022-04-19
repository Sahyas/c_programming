using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Ball
    {
        public double promien;
        public double x;
        public double y;
        
        Random rng = new Random();

        public Ball()
        {
            promien = 0;
            x = 0;
            y = 0;
        }
    }
}
