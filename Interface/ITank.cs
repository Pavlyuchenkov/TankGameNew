using System;
using System.Collections.Generic;
using System.Text;

namespace TestGameInterface
{
    interface ITank
    {
        double Ammu { get; set; }
        double Armor { get; set; }
        double Damage { get; set; }
        double Hp { get; set; }

        void Impact(double enm_Damage);
        void BuyAmmu();
        void Repair();
        void Shoot(ITank unit);
        void StatInfo();
    }
}
