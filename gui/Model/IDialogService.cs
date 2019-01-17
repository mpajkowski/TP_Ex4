﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Model
{
    interface IDialogService
    {
        void Show(string text);
        System.Windows.MessageBoxResult YesNo(string title, string text);
    }
}
