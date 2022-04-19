﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ViewModel
{
    using Model;
    public class BallView : INotifyPropertyChanged
    { 

    private Ball model = new Ball();
        Random rng = new Random();
        private double myValue = 100;

        public double MyValue
        {
            get
            {
                return this.myValue;
            }
            set
            {
                this.myValue = value;
                onPropertyChanged(nameof(MyValue));
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

        public double wartoscX
        {
            get
            {
                return model.x;
            }
            set
            {
                model.x = rng.Next(500);
                onPropertyChanged(nameof(wartoscPromienia));
            }
        }

        public double wartoscY
        {
            get
            {
                return model.y;
            }
            set
            {
                model.y = rng.Next(500);
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
