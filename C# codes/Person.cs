using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Person
    {
        public string name;
        private int amtAva = 0;
        public void addAmt(int amt)
        {
            amtAva += amt;
        }
        public int getAmt()
        {
            return amtAva;
        }
        public void removeAmt(int amt)
        {
            amtAva -= amt;
        }
    }
}
