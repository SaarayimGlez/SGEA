﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGEA_DS
{
    public class CtrolUsrCtrolEvento : UserControl
    {

        public void Textbox_Alfabetico_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.A && e.Key <= Key.Z) ||
                (e.Key == Key.Oem3 || e.Key == Key.Oem1 || e.Key == Key.DeadCharProcessed))
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        public void Textbox_Numerico_KeyDown(object sender, KeyEventArgs e)
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

        public void Textbox_NumDinero_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if ((!textBox.Text.Equals("") && textBox.Text.Contains(".") &&
                e.Key == Key.OemPeriod) || (Keyboard.Modifiers == ModifierKeys.Shift))
            {
                e.Handled = true;
            }
            else
            {
                if ((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                    (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key == Key.OemPeriod))
                {
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        public void Textbox_Espacio_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        public void DataPicker_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        public void Textbox_AlfInstitucion_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.Key == Key.D8 || e.Key == Key.D9) &&
                Keyboard.Modifiers == ModifierKeys.Shift) || (e.Key >= Key.A && e.Key <= Key.Z) ||
                (e.Key == Key.Oem3 || e.Key == Key.Oem1 || e.Key == Key.DeadCharProcessed ||
                e.Key == Key.OemMinus || e.Key == Key.Subtract))
            {
            }
            else
            {
                Textbox_Numerico_KeyDown(sender, e);
            }
        }
    }
}