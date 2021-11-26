﻿// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the PromptPlus project under MIT license
// ***************************************************************************************

using System;
using System.Text;
using System.Threading;

using PPlus.Objects;

namespace PPlus.Drivers
{
    public interface IConsoleDriver
    {
        bool NoInterative { get; }
        Encoding OutputEncoding { get; set; }
        void Clear();
        void ClearLine(int top);
        void ClearRestOfLine(ConsoleColor? color);
        ConsoleKeyInfo ReadKey(bool intercept);
        ConsoleKeyInfo WaitKeypress(bool intercept, CancellationToken cancellationToken);
        void Beep();
        void Write(string value, ConsoleColor? color = null, ConsoleColor? colorbg = null);
        void Write(params ColorToken[] tokens);
        void WriteLine(string value = null, ConsoleColor? color = null, ConsoleColor? colorbg = null);
        void WriteLine(params ColorToken[] tokens);
        void SetCursorPosition(int left, int top);
        bool KeyAvailable { get; }
        bool CursorVisible { get; set; }
        int CursorLeft { get; }
        int CursorTop { get; }
        int BufferWidth { get; }
        int BufferHeight { get; }
        bool IsRunningTerminal { get; }
        ConsoleColor ForegroundColor { get; set; }
        ConsoleColor BackgroundColor { get; set; }

    }
}
