using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGEA_DS
{
    public class VentanaCtrolEvento : Window
    {

        public void textbox_Alfabetico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
            }
            else
            {
                if (e.Key == Key.Oem3 | e.Key == Key.Oem1 | e.Key == Key.DeadCharProcessed)
                {
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        public void textbox_Numerico_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Shift)
            {
                e.Handled = true;
            }
            else
            {
                if ((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                       (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
                {
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        public void textbox_NumDinero_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if ((!textBox.Text.Equals("") &&
                textBox.Text.Contains(".") &&
                (e.Key == Key.OemPeriod)) ||
                (Keyboard.Modifiers == ModifierKeys.Shift))
            {
                e.Handled = true;
            }
            else
            {
                if ((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                       (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) ||
                       (e.Key == Key.OemPeriod))
                {
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        public void DataPicker_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
