﻿// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the PromptPlus project under MIT license
// ***************************************************************************************

using System;
using System.Collections.Generic;
using System.Globalization;
using PPlus.Controls.Objects;

namespace PPlus.Controls
{
    internal class TableOptions<T> : BaseOptions
    {
        private TableOptions() : base(null, null, null, true)
        {
            throw new PromptPlusException("TableOptions CTOR NotImplemented");
        }

        internal TableOptions(StyleSchema styleSchema, ConfigControls config, IConsoleControl console, bool showcursor) : base(styleSchema, config, console, showcursor)
        {
            TimeoutOverwriteDefault = config.HistoryTimeout;
            PageSize = config.PageSize;
            GridStyle = styleSchema.Prompt();
            HeaderStyle = styleSchema.Prompt();
            TitleStyle = styleSchema.Prompt();
            SelectedHeaderStyle = styleSchema.Selected();
            ContentStyle = styleSchema.Prompt();
            DisabledContentStyle = styleSchema.Disabled();
            SelectedContentStyle = styleSchema.Selected();
        }

        public bool IsOrderDescending { get; set; }

        public Func<T, object> OrderBy { get; set; }

        public FilterMode FilterType { get; set; } = FilterMode.Contains;

        public string? OverwriteDefaultFrom { get; set; } = null;

        public TimeSpan TimeoutOverwriteDefault { get; set; }

        public List<ItemTableRow<T>> Items { get; set; } = new();

        public List<T> DisableItems { get; set; } = new();

        public List<T> RemoveItems { get; set; } = new();

        public Func<T, T, bool> EqualItems { get; set; }

        public Optional<T> DefaultValue { get; set; } = Optional<T>.Create(null);

        public int PageSize { get; set; }

        public CultureInfo CurrentCulture { get; set; } = null;

        public byte[] FilterColumns { get; set; } = Array.Empty<byte>();

        public TableLayout Layout { get; set; } = TableLayout.SingleGrid;

        public Style GridStyle { get; set; }

        public Style TitleStyle { get; set; }

        public Style HeaderStyle { get; set; }

        public Style SelectedHeaderStyle { get; set; }

        public Style ContentStyle { get; set; }

        public Style DisabledContentStyle { get; set; }

        public Style SelectedContentStyle { get; set; }

        public string Title { get; set; } = string.Empty;

        public Alignment TitleAlignment { get; set; } = Alignment.Center;

        public TableTitleMode TitleMode { get; set; } = TableTitleMode.InLine;

        public List<ItemItemColumn<T>> Columns { get; set; } = new List<ItemItemColumn<T>>();

        public List<ItemTableHeader> Headers { get; set; } = new();

        public List<ItemTableHeader> MergeHeaders { get; set; } = new();

        public bool UseSeparator { get; set; }

        public bool HasAutoFit{ get; set; }

        public byte[] AutoFitColumns { get; set; } = Array.Empty<byte>();

        public Dictionary<Type,Func<object,string>> FormatTypes = new();

        public bool IsInteraction { get; set; }

        public bool IsColumnsNavigation { get; set; }

        public Func<T, byte, string> SelectedTemplate { get; set; }
        public Func<T, byte, string> FinishTemplate { get; set; }

        public bool RemoveTableAtFinish { get; set; } = true;
    }
}
