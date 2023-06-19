using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caro
{
    public class ThongTInNguoiChoi
    {
        private Point point;
        public Point Point 
        { 
            get { return point; }
            set { point = value; }
        }
        private int curentPlayer;
        public int CurentPlayer
        { 
            get { return curentPlayer; }     
            set { curentPlayer = value; } 
        }
        public ThongTInNguoiChoi (Point p , int currentPlayer)
        {
            this.Point = p;
            this.CurentPlayer = currentPlayer;
        }
    }
}
