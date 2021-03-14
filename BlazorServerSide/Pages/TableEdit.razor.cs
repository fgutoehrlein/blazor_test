using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerSide.Pages
{
    public partial class TableEdit
    {
        public int XValue;
        public int YValue;
        public string HeadInputValue;

        public string[,] Table = new string[20,20];

        public void TakeTableInput(ChangeEventArgs e)
        {
            HeadInputValue = e.Value.ToString();
        }
        public void TakeHeadInputValue(ChangeEventArgs e)
       {
            Table[XValue, YValue] = e.Value.ToString();
        }
        public void ChangeValueBindForHeadInput(int x, int y)
        {
            XValue = x;
            YValue = y;
            HeadInputValue = Table[x, y];
        }
    }
}
