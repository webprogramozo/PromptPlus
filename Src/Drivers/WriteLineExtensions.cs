﻿// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the PromptPlus project under MIT license
// This code was based on work from https://github.com/spectreconsole/spectre.console
// ***************************************************************************************

using PPlus.Drivers;

namespace PPlus
{
    public static partial class PromptPlus
    {
        /// <summary>
        /// Writes text line representation whie colors and Write single dash after.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="dashOptions"><see cref="DashOptions"/> character</param>
        /// <param name="extralines">Number lines to write after write value</param>
        /// <param name="style">The <see cref="Style"/> to write.</param>
        public static void SingleDash(string value, DashOptions dashOptions = DashOptions.AsciiSingleBorder, int extralines = 0, Style? style = null)
        {
            SingleDash(Console, value, dashOptions, extralines, style);
        }

        /// <summary>
        /// Writes text line representation whie colors and Write single dash after.
        /// </summary>
        /// <param name="consoleBase">The Console, see <see cref="IConsoleBase"/></param>
        /// <param name="value">The value to write.</param>
        /// <param name="dashOptions"><see cref="DashOptions"/> character</param>
        /// <param name="extralines">Number lines to write after write value</param>
        /// <param name="style">The <see cref="Style"/> to write.</param>
        public static void SingleDash(this IConsoleBase consoleBase, string value, DashOptions dashOptions = DashOptions.AsciiSingleBorder, int extralines = 0, Style? style = null)
        {
            var aux = Segment.Parse(value, style ?? consoleBase.DefaultStyle);
            if (aux.Length > 1)
            {
                throw new PromptPlusException("Text cannot be more than one line");
            }
            var wrapperChar = dashOptions switch
            {
                DashOptions.AsciiSingleBorder => Config.Symbols(Controls.SymbolType.SingleBorder).value[0],
                DashOptions.AsciiDoubleBorder => Config.Symbols(Controls.SymbolType.DoubleBorder).value[0],
                DashOptions.SingleBorder => Config.Symbols(Controls.SymbolType.SingleBorder).unicode[0],
                DashOptions.DoubleBorder => Config.Symbols(Controls.SymbolType.DoubleBorder).unicode[0],
                DashOptions.HeavyBorder => Config.Symbols(Controls.SymbolType.HeavyBorder).unicode[0],
                _ => throw new PromptPlusException($"dashOptions : {dashOptions} Not Implemented")
            };
            if (!consoleBase.IsUnicodeSupported)
            {
                switch (dashOptions)
                {
                    case DashOptions.SingleBorder:
                        wrapperChar = Config.Symbols(Controls.SymbolType.SingleBorder).value[0];
                        break;
                    case DashOptions.DoubleBorder:
                        wrapperChar = Config.Symbols(Controls.SymbolType.DoubleBorder).value[0];
                        break;
                    case DashOptions.HeavyBorder:
                        wrapperChar = Config.Symbols(Controls.SymbolType.HeavyBorder).value[0];
                        break;
                    default:
                        break;
                }
            }
            consoleBase.WriteLine(aux[0].Text, aux[0].Style);
            consoleBase.WriteLine(new string(wrapperChar, aux[0].Text.Length), aux[0].Style);
            consoleBase.WriteLines(extralines);
        }


        /// <summary>
        /// Write lines with line terminator
        /// </summary>
        /// <param name="steps">Numbers de lines.</param>
        public static void WriteLines(int steps = 1)
        {
            WriteLines(Console, steps);
        }

        /// <summary>
        /// Write lines with line terminator
        /// </summary>
        /// <param name="consoleBase">The Console, see <see cref="IConsoleBase"/></param>
        /// <param name="steps">Numbers de lines.</param>
        public static void WriteLines(this IConsoleBase consoleBase, int steps = 1)
        {
            for (int i = 0; i < steps; i++)
            {
                consoleBase.WriteLine("",null,true);
            }
        }

        /// <summary>
        /// Writes text line representation whie colors in a pair of lines of dashes.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <param name="dashOptions"><see cref="DashOptions"/> character</param>
        /// <param name="extralines">Number lines to write after write value</param>
        /// <param name="style">The <see cref="Style"/> to write.</param>
        public static void DoubleDash(string value, DashOptions dashOptions = DashOptions.AsciiSingleBorder, int extralines = 0, Style? style = null)
        {
            DoubleDash(Console, value, dashOptions, extralines, style);
        }

        /// <summary>
        /// Writes text line representation whie colors in a pair of lines of dashes.
        /// </summary>
        /// <param name="consoleBase">The Console, see <see cref="IConsoleBase"/></param>
        /// <param name="value">The value to write.</param>
        /// <param name="dashOptions"><see cref="DashOptions"/> character</param>
        /// <param name="extralines">Number lines to write after write value</param>
        /// <param name="style">The <see cref="Style"/> to write.</param>
        public static void DoubleDash(this IConsoleBase consoleBase, string value, DashOptions dashOptions = DashOptions.AsciiSingleBorder, int extralines = 0, Style? style = null)
        {
            var aux = Segment.Parse(value, style ?? consoleBase.DefaultStyle);
            if (aux.Length > 1)
            {
                throw new PromptPlusException("Text cannot be more than one line");
            }
            var wrapperChar = dashOptions switch
            {
                DashOptions.AsciiSingleBorder => Config.Symbols(Controls.SymbolType.SingleBorder).value[0],
                DashOptions.AsciiDoubleBorder => Config.Symbols(Controls.SymbolType.DoubleBorder).value[0],
                DashOptions.SingleBorder => Config.Symbols(Controls.SymbolType.SingleBorder).unicode[0],
                DashOptions.DoubleBorder => Config.Symbols(Controls.SymbolType.DoubleBorder).unicode[0],
                DashOptions.HeavyBorder => Config.Symbols(Controls.SymbolType.HeavyBorder).unicode[0],
                _ => throw new PromptPlusException($"dashOptions : {dashOptions}  Not Implemented")
            };
            if (!consoleBase.IsUnicodeSupported)
            {
                switch (dashOptions)
                {
                    case DashOptions.SingleBorder:
                        wrapperChar = Config.Symbols(Controls.SymbolType.SingleBorder).value[0];
                        break;
                    case DashOptions.DoubleBorder:
                        wrapperChar = Config.Symbols(Controls.SymbolType.DoubleBorder).value[0];
                        break;
                    case DashOptions.HeavyBorder:
                        wrapperChar = Config.Symbols(Controls.SymbolType.HeavyBorder).value[0];
                        break;
                    default:
                        break;
                }
            }
            consoleBase.WriteLine(new string(wrapperChar, aux[0].Text.Length), aux[0].Style);
            consoleBase.WriteLine(aux[0].Text, aux[0].Style);
            consoleBase.WriteLine(new string(wrapperChar, aux[0].Text.Length), aux[0].Style);
            consoleBase.WriteLines(extralines);
        }
    }
}
