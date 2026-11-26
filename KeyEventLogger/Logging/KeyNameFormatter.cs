using System.Windows.Forms;

namespace KeyEventLogger.Logging
{
    /// <summary>Tuş kodlarını kullanıcının okuyabileceği adlara çevirir.</summary>
    public static class KeyNameFormatter
    {
        public static bool IsModifierKey(Keys key)
        {
            switch (key)
            {
                case Keys.ShiftKey:
                case Keys.LShiftKey:
                case Keys.RShiftKey:
                case Keys.ControlKey:
                case Keys.LControlKey:
                case Keys.RControlKey:
                case Keys.Menu:
                case Keys.LMenu:
                case Keys.RMenu:
                    return true;
                default:
                    return false;
            }
        }

        public static string Format(Keys key)
        {
            switch (key)
            {
                case Keys.ShiftKey:
                case Keys.LShiftKey:
                case Keys.RShiftKey:
                    return "Shift";
                case Keys.ControlKey:
                case Keys.LControlKey:
                case Keys.RControlKey:
                    return "Ctrl";
                case Keys.Menu:
                case Keys.LMenu:
                case Keys.RMenu:
                    return "Alt";
                case Keys.Return:
                    return "Enter";
                case Keys.Back:
                    return "Backspace";
                case Keys.Space:
                    return "Boşluk";
                case Keys.Capital:
                    return "CapsLock";
                case Keys.Next:
                    return "PageDown";
                case Keys.Prior:
                    return "PageUp";
                case Keys.Oemcomma:
                    return ",";
                case Keys.OemPeriod:
                    return ".";
                case Keys.OemMinus:
                    return "-";
                case Keys.Oemplus:
                    return "+";
            }

            // D0..D9 -> "0".."9"
            if (key >= Keys.D0 && key <= Keys.D9)
            {
                return ((int)(key - Keys.D0)).ToString();
            }
            if (key >= Keys.NumPad0 && key <= Keys.NumPad9)
            {
                return "Num" + (int)(key - Keys.NumPad0);
            }
            return key.ToString();
        }

        public static string FormatChar(char c)
        {
            switch (c)
            {
                case ' ':
                    return "' ' (boşluk)";
                case '\r':
                    return "\\r (Enter)";
                case '\b':
                    return "\\b (Backspace)";
                case '\t':
                    return "\\t (Tab)";
                case (char)27:
                    return "Esc";
            }
            if (char.IsControl(c))
            {
                return "Kontrol karakteri #" + (int)c;
            }
            return "'" + c + "'";
        }
    }
}
