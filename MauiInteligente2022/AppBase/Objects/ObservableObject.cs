﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiInteligente2022.AppBase.Objects {
    internal class ObservableObject : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
