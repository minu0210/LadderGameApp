﻿using System.ComponentModel;
using System.Windows.Data;

namespace LadderGameApp.Classes
{
    public class User : Model.MainModel
    {

        private string name;
        private int count = 2;
        private string result;
        private int selectIndex;

        public string Name { get => name; set => name = value; }
        public int Count
        {
            get => count;
            set
            {
                if (count != value)
                {
                    count = value;
                    OnPropertyChanged("Count");

                }
            }
        }
        public string Result { get => result; set => result = value; }
        public int SelectIndex { get => selectIndex; set => selectIndex = value; }

    }
}