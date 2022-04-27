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
                Board = new Board(800);
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
                updatePosition = Task.Run(Board.MoveBallsConstantly);
            }
        }

    }
}
