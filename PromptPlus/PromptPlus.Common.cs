﻿// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the PromptPlus project under MIT license
// ***************************************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;

using PPlus.Resources;

using PPlus.Drivers;

using PPlus.Internal;

using PPlus.Objects;

namespace PPlus
{
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "by design")]
    public static partial class PromptPlus
    {
        internal const int MaxShowTasks = 1;
        internal const int RollupFactor = 13;
        internal const int SpeedAnimation = 50;
        internal const int SliderWitdth = 30;
        internal const int ProgressgBarWitdth = 30;
        internal const int ProgressgBarDoneDelay = 1000;
        internal const int ProgressgBarCheckDelay = 50;

        internal static object LockObj = new object();

        static PromptPlus()
        {
            Symbols.MaskEmpty = new("■", "  ");
            Symbols.File = new("■", "- ");
            Symbols.Folder = new("►", "> ");
            Symbols.Prompt = new("→", "->");
            Symbols.Done = new("√", "V ");
            Symbols.Error = new("»", ">>");
            Symbols.Selector = new("›", "> ");
            Symbols.Selected = new("♦", "* ");
            Symbols.NotSelect = new("○", "  ");
            Symbols.TaskRun = new("♦", "* ");
            Symbols.Skiped = new("×", "x ");

            Symbols.IndentGroup = new("├─", "  |-");
            Symbols.IndentEndGroup = new("└─", "  |_");
            Symbols.SymbGroup = new("»", ">>");

            ConsoleDriver = new ConsoleDriver
            {
                OutputEncoding = Encoding.UTF8
            };
            AppCulture = Thread.CurrentThread.CurrentCulture;
            AppCultureUI = Thread.CurrentThread.CurrentUICulture;
            DefaultCulture = AppCulture;
            LoadConfigFromFile();
        }

        public static IConsoleDriver ConsoleDriver { get; private set; }

        internal static bool NoInterative => ConsoleDriver.NoInterative;

        internal static CultureInfo AppCulture { get; set; }

        internal static CultureInfo AppCultureUI { get; set; }

        internal static bool IsRunningWithCommandDotNet { get; set; }

        internal static string LocalizateFormatException(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    return Messages.InvalidTypeBoolean;
                case TypeCode.Byte:
                    return Messages.InvalidTypeByte;
                case TypeCode.Char:
                    return Messages.InvalidTypeChar;
                case TypeCode.DateTime:
                    return Messages.InvalidTypeDateTime;
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return Messages.InvalidTypeNumber;
                case TypeCode.DBNull:
                case TypeCode.Empty:
                case TypeCode.Object:
                case TypeCode.String:
                    break;
            }
            return Messages.Invalid;
        }

        public static void DriveConsole(IConsoleDriver value)
        {
            if (value == null)
            {
                return;
            }
            ConsoleDriver = value;
        }

        public static HotKey AbortAllPipesKeyPress { get; set; } = new(ConsoleKey.X, true, false, false);

        public static HotKey AbortKeyPress { get; set; } = new(ConsoleKey.Escape, false, false, false);

        public static HotKey TooltipKeyPress { get; set; } = new(ConsoleKey.F1, false, false, false);

        public static HotKey ResumePipesKeyPress { get; set; } = new(ConsoleKey.F2, false, false, false);

        public static HotKey ToggleVisibleDescription { get; set; } = new(ConsoleKey.F3, false, false, false);

        public static HotKey UnSelectFilter { get; set; } = new(ConsoleKey.F, true, false, false);

        public static HotKey SwitchViewPassword { get; set; } = new(ConsoleKey.V, true, false, false);

        public static HotKey SelectAll { get; set; } = new(ConsoleKey.A, true, false, false);

        public static HotKey InvertSelect { get; set; } = new(ConsoleKey.I, true, false, false);

        public static HotKey RemoveAll { get; set; } = new(ConsoleKey.R, true, false, false);


        private static CultureInfo s_defaultCulture;

        public static CultureInfo DefaultCulture
        {
            get
            {
                return s_defaultCulture;
            }
            set
            {
                if (!IsImplementedResource(value))
                {
                    if (File.Exists($"PromptPlus.{value.Name}.resources"))
                    {

                        var rm = ResourceManager.CreateFileBasedResourceManager($"PromptPlus", Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), null);
                        var innerField = typeof(PromptPlusResources).GetField("resourceMan", BindingFlags.NonPublic | BindingFlags.Static);
                        innerField.SetValue(null, rm);
                        s_defaultCulture = value;
                    }
                }
                else
                {
                    s_defaultCulture = value;
                }
                PromptPlusResources.Culture = s_defaultCulture;
                Messages.UpdateCulture();
            }
        }

        public static bool EnabledBeep { get; set; } = false;

        public static bool EnabledStandardTooltip { get; set; } = true;

        public static bool EnabledPromptTooltip { get; set; } = true;

        public static bool EnabledAbortKey { get; set; } = true;

        public static bool EnabledAbortAllPipes { get; set; } = true;

        public static char PasswordChar { get; set; } = '#';

        private static bool IsImplementedResource(CultureInfo cultureInfo)
        {
            if (cultureInfo.IsNeutralCulture || new CultureInfo(cultureInfo.TwoLetterISOLanguageName).IsNeutralCulture)
            {
                return true;
            }
            var code = cultureInfo.Name;
            if (code == "pt-BR")
            {
                return true;
            }
            return false;
        }

    }
}
