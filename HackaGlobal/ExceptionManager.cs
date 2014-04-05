using System;
using System.Windows;

namespace HackaGlobal
{
    static class ExceptionManager
    {
        public static void Log(string message)
        {
            MessageBox.Show(message);
        }

        public static void Log(Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
}
