using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ViewModel
{
    using Model;
    public class BallView : INotifyPropertyChanged
    { 

    private Ball model = new Ball();

        private int myValue = 70;

        public int MyValue
        {
            get
            {
                return this.myValue;
            }
            set
            {
                this.myValue = value;
            }
        }

        public double wartoscPromienia 
        {
            get {
                return model.promien; 
            }
            set { 
                model.promien = value;
                onPropertyChanged(nameof(wartoscPromienia));
            }
        }
    private void onPropertyChanged(string nazwa)
        {
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nazwa));
        }


    public event PropertyChangedEventHandler PropertyChanged;

}

}
