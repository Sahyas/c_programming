using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Dane;

namespace Dane
{
    internal class DAO : IDisposable
    {
        private BlockingCollection<String> buffer = new BlockingCollection<String>();
        private Task fileWritter;
        private StreamWriter sw;

        public DAO()
        {
            fileWritter = new Task(() => writter());
            fileWritter.Start();
        }

        public void addToBuffer(Ball ball)
        {
            string log = " Ball "
                    + ball.id
                    + " moved: "
                    + " positionX: "
                    + Math.Round(ball.positionX, 4)
                    + " positionY: "
                    + Math.Round(ball.positionY, 4)
                    + " speedX: "
                    + Math.Round(ball.speedX, 4)
                    + " speedY: "
                    + Math.Round(ball.speedY, 4);

            buffer.Add(log);
        }

        public void Dispose()
        {
            sw.Dispose();
            fileWritter.Dispose();
        }

        public void writter()
        {
            sw = new StreamWriter("../../../../../Dane/log.txt", append: false);
            try
            {
                foreach (string i in buffer.GetConsumingEnumerable())
                {
                    sw.WriteLine(i);
                }
            }
            finally
            {
                Dispose();
            }
        }

        public void wrtiteToFile(string log)
        {
            try
            {
                sw.WriteLine(log);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file cannot be found.");
            }
            catch (IOException)
            {
                Console.WriteLine("An I/O error has occurred.");
            }
        }
    }
}
