using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KrestikNolikWithInterface
{
    public interface IDescribeGame
    {
        bool IWinner();
        bool ILeftMoves();
        int INumberLeftMove();
    }
}
