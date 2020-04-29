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

        public int FieldValue
        {
            get
            {
                return values.Dequeue();
            }
        }

        private Queue<int> values = new Queue<int>();

        private Model model;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            this.model = new Model(4);
            UpdateValues();
        }

        public void UpdateValues()
        {
            for (int i = 0; i < this.model.HSize; i++)
                for (int j = 0; j < this.model.VSize; j++)
                    this.values.Enqueue(this.model.Get(new Coordinates(j, i)));
            OnPropertyChanged("FieldValue");
        }

        public void KeyPressed(Actions action)
        {
            switch (action)
            {
                case Actions.Down:
                    model.Action(Model.Directions.Down);
                    break;
                case Actions.Up:
                    model.Action(Model.Directions.Up);
                    break;
                case Actions.Left:
                    model.Action(Model.Directions.Left);
                    break;
                case Actions.Right:
                    model.Action(Model.Directions.Right);
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
