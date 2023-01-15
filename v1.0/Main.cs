using System;
using System.Windows.Forms;
using System.Collections.Generic;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.NaturalMotion;
using NativeUI;

namespace SMenu
{
    public class Main : Script
    {
        MenuPool pool;
        UIMenu menu;

        private void createMenu()
        {
            menu = new UIMenu("SMenu", "A mod menu by SeboTimes.");
        }

        private void createMoneyMenu()
        {
            UIMenu moneyMenu = pool.AddSubMenu(menu, "Money Menu");

            UIMenuItem item0 = new UIMenuItem("Give $1");
            UIMenuItem item1 = new UIMenuItem("Give $10");
            UIMenuItem item2 = new UIMenuItem("Give $100");
            UIMenuItem item3 = new UIMenuItem("Give $1000");
            UIMenuItem item4 = new UIMenuItem("Give $10000");

            moneyMenu.AddItem(item0);
            moneyMenu.AddItem(item1);
            moneyMenu.AddItem(item2);
            moneyMenu.AddItem(item3);
            moneyMenu.AddItem(item4);

            moneyMenu.OnItemSelect += (UIMenu sender, UIMenuItem selectedItem, int index) =>
            {
                if (selectedItem == item0)
                    Game.Player.Money += 1;
                if (selectedItem == item1)
                    Game.Player.Money += 10;
                if (selectedItem == item2)
                    Game.Player.Money += 100;
                if (selectedItem == item3)
                    Game.Player.Money += 1000;
                if (selectedItem == item4)
                    Game.Player.Money += 10000;
            };
        }

        public Main()
        {
            Tick += onTick;
            KeyDown += onKeyDown;

            pool = new MenuPool();
            createMenu();
            pool.Add(menu);

            createMoneyMenu();

            pool.RefreshIndex();

            UI.Notify("~y~SMenu ~g~loaded~w~!");
        }

        private void onTick(object sender, EventArgs e)
        {
            pool.ProcessMenus();
        }
        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                menu.Visible = !menu.Visible;
            }
        }
    }
}
