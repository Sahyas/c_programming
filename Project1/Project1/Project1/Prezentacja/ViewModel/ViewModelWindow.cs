using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelWindow : INotifyPropertyChanged
    {
        private ModelAPI modelApi;
        private readonly double scale = 5.35;
        public ObservableCollection<BallModel> Balls { get; set; }
        public ICommand StartButtonClick { get; set; }
        private string inputText;
        private Task task;

        private bool state;

        public bool State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                RaisePropertyChanged(nameof(State));
            }
        }


        public string InputText
        {
            get
            {
                return inputText;
            }
            set
            {
                inputText = value;
                RaisePropertyChanged(nameof(InputText));
            }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                RaisePropertyChanged(nameof(ErrorMessage));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelWindow() : this(ModelAPI.CreateApi())
        {

        }

        public ViewModelWindow(ModelAPI baseModel)
        {
            State = true;
            this.modelApi = baseModel;
            StartButtonClick = new RelayCommand(() => StartButtonClickHandler());
            Balls = new ObservableCollection<BallModel>();
        }

        private void StartButtonClickHandler()
        {
            modelApi.addBallsAndStart(readFromTextBox());
            task = new Task(UpdatePosition);
            task.Start();
        }

        public void UpdatePosition()
        {
            while (true)
            {
                ObservableCollection<BallModel> treadList = new ObservableCollection<BallModel>();

                foreach (BallModel ball in modelApi.balls)
                {
                    treadList.Add(ball);
                }

                Balls = treadList;
                RaisePropertyChanged(nameof(Balls));
                Thread.Sleep(10);
            }
        }

        public int readFromTextBox()
        {
            int number;
            if (Int32.TryParse(InputText, out number) && InputText != "0")
            {
                number = Int32.Parse(InputText);
                ErrorMessage = "";
                State = false;
                if (number > 100)
                {
                    return 100;
                }
                return number;
            }
            ErrorMessage = "Nieprawidłowa liczba";
            return 0;
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

