using Dane;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public abstract class LogicAPI
    {
        public abstract void addBalls(int BallsNumber);

        public abstract void start();

        public abstract void stop();

        public abstract List<Ball> getBalls();

        public static LogicAPI Create(DaneAPI data = default(DaneAPI))
        {
            return new BussinessLogic(
                data == null ? DaneAPI.CreateDataAPI() : data);
        }

        private class BussinessLogic : LogicAPI
        {
            private DaneAPI daneAPI;
            private Task updatePosition;
            private Board Board;

            public BussinessLogic(DaneAPI daneAPI)
            {
                this.daneAPI = daneAPI;
                Board = new Board(550);
            }

            public override void addBalls(int BallsNumber)
            {
                Board.addBalls(BallsNumber);
            }

            public override List<Ball> getBalls()
            {
                return Board.balls;
            }

            public override void start()
            {
                if (Board.balls.Count > 0)
                {
                    updatePosition = Task.Run(Board.MoveBallsConstantly);
                }
            }

            public override void stop()
            {
                Board.balls.Clear();
            }
        }

    }
}
