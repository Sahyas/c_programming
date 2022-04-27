using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ViewModel
{
    using Model;
    public class BallView : INotifyPropertyChanged
    { 

    private ModelApi model = new ModelApi();
        Random rng = new Random();
        private double myValue = 100;

        private void onPropertyChanged(string nazwa)
        {
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(nazwa));
        }


    public event PropertyChangedEventHandler PropertyChanged;

}

}
