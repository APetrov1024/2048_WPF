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
        //public int[,] Field { get; private set; }
        public int FieldValue
        {
            get
            {
                int value = values.GetEnumerator().Current;
                values.GetEnumerator().MoveNext();
                return value;
            }
        }

        private List<int> values = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};

        private Model model;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            this.model = new Model(4);
            //this.Field = new int[this.model.HSize, this.model.VSize];
            //UpdateField();
        }

        /*public void UpdateField()
        {
            for (int i = 0; i < this.model.HSize; i++)
                for (int j = 0; j < this.model.VSize; j++)
                    this.Field[i, j] = this.model.Get(new Coordinates(i, j));
            OnPropertyChanged("Field");
        }*/


        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
