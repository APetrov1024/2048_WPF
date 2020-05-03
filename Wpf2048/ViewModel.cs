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
        public enum Actions { None, Left, Right, Up, Down };
        public enum GameStates { Running, Win, Fail, Continued};
        private Queue<string> values = new Queue<string>();
        private Model model;
        private int hFieldSize;
        private int vFieldSize;
        private int targetValue;
        private GameStates gameState;
        public event PropertyChangedEventHandler PropertyChanged;
        public delegate void GameStateHandler(GameStates state);
        public event GameStateHandler GameStateChanged;
        public GameStates GameState
        {
            get
            {
                return gameState;
            }
            set
            {
                if (this.gameState != value)
                {
                    gameState = value;
                    GameStateChanged?.Invoke(value);
                }
            }
        }
        public int TargetValue
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
            this.TargetValue = 2048;
            StartNewGame();
        }

        public void StartNewGame()
        {
            values = new Queue<string>();
            this.model = new Model(HFieldSize, VFieldSize);
            UpdateValues();
            GameState = GameStates.Running;
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
            if (this.GameState == GameStates.Running || this.GameState == GameStates.Continued)
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
                IsFail();
                if (this.GameState == GameStates.Running)
                    IsWin();
            }
        }

        private void IsFail()
        {
            if (this.model.IsHasNotMoves() && (!this.model.IsHaveValue(this.TargetValue) || this.GameState == GameStates.Continued))
                this.GameState = GameStates.Fail;
        }

        private void IsWin()
        {
            if (this.model.IsHaveValue(this.TargetValue))
                GameState = GameStates.Win;
        }

        public void ContinueGame()
        {
            if (this.GameState == GameStates.Win)
                GameState = GameStates.Continued;
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
