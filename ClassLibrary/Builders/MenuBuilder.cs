using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MenuBuilder
    {
        private MenuModel _menu = new MenuModel();

        public MenuBuilder AddASCII(string ascii)
        {
            _menu.ASCII = ascii;
            return this;
        }

        public MenuBuilder AddOptions(string[] options)
        {
            _menu.Options = options;
            return this;
        }

        public MenuBuilder IsMainMenu(bool isMainMenu)
        {
            _menu.IsMainMenu = isMainMenu;
            return this;
        }

        public MenuBuilder AddSelectedIndex()
        {
            MenuOption menuOption = new MenuOption();
            _menu.SelectedIndex = menuOption.SelectOption(_menu);
            return this;
        }

        public MenuModel Build()
        {
            return _menu;
        }
    }
}
