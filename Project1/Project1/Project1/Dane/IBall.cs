using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public interface IBall : IObservable<IBall>
    {
        int id { get; }

        double positionX { get; }
        double positionY { get; }

        int Radius { get; }
        double Mass { get; }

        double speedX { get; set; }
        double speedY { get; set; }

        double shiftX { get; set; }
        double shiftY { get; set; }
    }
}
