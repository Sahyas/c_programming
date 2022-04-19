using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ViewModel
{
    using Model;
    public class BallView : INotifyPropertyChanged
    { 

    private BallView model = new BallView();

        public double wartoscPromienia 
        {
            get {
                return model.wartoscPromienia; 
            }
            set { 
                model.wartoscPromienia = value;
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
