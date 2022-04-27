using System;

namespace Dane
{
    public abstract class DaneAPI
    {
        public static DaneAPI CreateDataAPI()
        {
            return new DaneBall();
        }

        private class DaneBall : DaneAPI
        {
            public DaneBall()
            {
                //do sth in future
            }
                

        }
    }
}
