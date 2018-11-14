using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public enum MoveButton { None, ToLeft, ToRight, ToUp, ToDown}

    public class Game
    {
        private Random rnd = new Random();
        private int[,] _gameField = new int[4, 4];
        public int zeroX { get; private set; }
        public int zeroY { get; private set; }

        public int this[int x, int y]
        {
            get => _gameField[y, x];
        }

        public bool IsWin()
        {
            //Проверка победы
            for (int i = 0; i < 15; i++)
            {

                if (_gameField[i % 4, i / 4] != (i + 1))
                {
                    return false;
                }

            }
            return true;

        }


        public void zeroUp()
        {
            if (zeroY == 3) return;

            _gameField[zeroX, zeroY] = _gameField[zeroX, zeroY + 1];
            ++zeroY;
            _gameField[zeroX, zeroY] = 0;

        }
        public void zeroDown()
        {
            if (zeroY == 0) return;

            _gameField[zeroX, zeroY] = _gameField[zeroX, zeroY - 1];
            --zeroY;
            _gameField[zeroX, zeroY] = 0;
        }

        public void zeroLeft()
        {
            if (zeroX == 3) return;

            _gameField[zeroX, zeroY] = _gameField[zeroX + 1, zeroY];
            ++zeroX;
            _gameField[zeroX, zeroY] = 0;
        }
        public void zeroRight()
        {
            if (zeroX == 0) return;

            _gameField[zeroX, zeroY] = _gameField[zeroX - 1, zeroY];
            --zeroX;
            _gameField[zeroX, zeroY] = 0;
        }



        public Game()
        {
            InitGame();
        }

        public void InitGame()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };

            for (int n = 0, i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j, ++n)
                {
                    _gameField[j, i] = arr[n];
                    if (arr[n] == 0)
                    {
                        zeroX = j;
                        zeroY = i;
                    }
                }
            }
            Shuffle(arr);
        }

        public MoveButton CheckAndGo(int value)
        {
            if (zeroX > 0 && _gameField[zeroX - 1, zeroY] == value)
            {
                zeroRight();
                return MoveButton.ToRight;
            }
            if (zeroX < 3 && _gameField[zeroX + 1, zeroY] == value)
            {
                zeroLeft();
                return MoveButton.ToLeft;
            }
            if (zeroY > 0 && _gameField[zeroX, zeroY - 1] == value)
            {
                zeroDown();
                return MoveButton.ToDown;
            }
            if (zeroY < 3 && _gameField[zeroX, zeroY + 1] == value)
            {
                zeroUp();
                return MoveButton.ToUp;
            }

            return MoveButton.None;
        }

        private void Shuffle(int[] arr)
        {
            //Перемешивание
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                switch (rand.Next(4))
                {
                    case 0:
                        this.zeroDown();
                        break;
                    case 1:
                        this.zeroUp();
                        break;
                    case 2:
                        this.zeroRight();
                        break;
                    case 3:
                        this.zeroLeft();
                        break;
                }
            }
        
        }
        
    }
}
    
