using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public abstract class Model
    {
        public abstract int RectangleHeight { get; }
        public abstract int RectangleWidth { get; }
        public abstract int BallsNumber { get; }
        public static Model CreateApi()
        {
            ModelAPI model = new ModelAPI();
            return model;
        }


    }
}
