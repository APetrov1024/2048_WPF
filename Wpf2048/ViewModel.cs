using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Game2048_Model;

namespace Wpf2048
{
    class ViewModel: INotifyPropertyChanged
    {
        public enum Actions { None, Left, Right, Up, Down, Restart };
        private Queue<string> values = new Queue<string>();
        private Model model;
        public event PropertyChangedEventHandler PropertyChanged;
        private int hFieldSize;
        private int vFieldSize;
        private int targetValue;
        private int TargetValue
        {
            get
            {
                return this.targetValue;
            }
            set 
            {
                if ((value != this.targetValue) && (value > 0) && (value % 2 == 0))
                    this.targetValue = value;
                OnPropertyChanged("TargetValue");
            }
        }
        public int HFieldSize
        {
            get
            {
                return this.hFieldSize;
            }
            set
            {
                if ((value > 0) && (value != this.hFieldSize)) this.hFieldSize = value;
                OnPropertyChanged("HFieldSize");
            }
        }
        public int VFieldSize
        {
            get
            {
                return this.vFieldSize;
            }
            set
            {
                if ((value > 0) && (value != this.vFieldSize)) this.vFieldSize = value;
                OnPropertyChanged("VFieldSize");
            }
        }
        public string FieldValue
        {
            get
            {
                if (values.Count > 0)
                    return this.values.Dequeue();
                else
                    return "err";
            }
        }

        public ViewModel()
        {
            this.VFieldSize = 4;
            this.HFieldSize = 4;
            StartNewGame();
        }

        public void StartNewGame()
        {
            values = null;
            values = new Queue<string>();
            this.model = new Model(HFieldSize, VFieldSize);
            UpdateValues();
        }

        public void UpdateValues()
        {
            values.Clear();
            for (int i = 0; i < this.model.HSize; i++)
                for (int j = 0; j < this.model.VSize; j++)
                {
                    int value = this.model.Get(new Coordinates(j, i));
                    if (value > 0)
                        this.values.Enqueue(value.ToString());
                    else
                        this.values.Enqueue("");
                }
            OnPropertyChanged("FieldValue");
        }

        public void KeyPressed(Actions action)
        {
            switch (action)
            {
                case Actions.Down:
                    this.model.Action(Model.Directions.Down);
                    break;
                case Actions.Up:
                    this.model.Action(Model.Directions.Up);
                    break;
                case Actions.Left:
                    model.Action(Model.Directions.Left);
                    break;
                case Actions.Right:
                    this.model.Action(Model.Directions.Right);
                    break;
            }
            UpdateValues();
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
