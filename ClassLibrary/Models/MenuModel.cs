using System;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;

namespace ClassLibrary
{
    public class MenuModel
    {
        public int SelectedIndex { get; set; }
        public string[] Options { get; set; }
        public string ASCII { get; set; }
        public bool IsMainMenu { get; set; }

    }
}
