﻿// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the PromptPlus project under MIT license
// ***************************************************************************************

using System.Globalization;
using PPlus;
using PPlus.Controls;

namespace TableSamples
{
    internal class Program
    {
        internal class MyComplexCol
        {
            public MyComplexCol(string value)
            {
                Name = value;
            }
            public string Id { get; } = Guid.NewGuid().ToString()[..8];
            public string Name { get; }
        }

        internal class MyTable
        {
            public int Id { get; set; }
            public required string MyText { get; set; }
            public DateTime? MyDate { get; set; }
            public required MyComplexCol ComplexCol { get; set; }
        }

        internal class MyTableManyCols
        {
            public int Id { get; set; }
            public required string MyText { get; set; }
            public string D01 { get; set; } = new string('x', 20);
            public string D02 { get; set; } = new string('x', 20);
            public string D03 { get; set; } = new string('x', 20);
            public string D04 { get; set; } = new string('x', 20);
            public string D05 { get; set; } = new string('x', 20);
            public string D06 { get; set; } = new string('x', 20);
            public string D07 { get; set; } = new string('x', 20);
            public string D08 { get; set; } = new string('x', 20);
            public string D09 { get; set; } = new string('x', 20);
            public string D10 { get; set; } = new string('x', 20);
            public string D11 { get; set; } = new string('x', 20);
            public string D12 { get; set; } = new string('x', 20);
            public string D13 { get; set; } = new string('x', 20);
            public string D14 { get; set; } = new string('x', 20);
            public string D15 { get; set; } = new string('x', 20);
            public string D16 { get; set; } = new string('x', 20);
            public string D17 { get; set; } = new string('x', 20);
            public string D18 { get; set; } = new string('x', 20);
            public string D19 { get; set; } = new string('x', 20);
            public string D20 { get; set; } = new string('x', 20);
            public string D21 { get; set; } = new string('x', 20);
            public string D22 { get; set; } = new string('x', 20);
            public string D23 { get; set; } = new string('x', 20);
            public string D24 { get; set; } = new string('x', 20);
            public string D25 { get; set; } = new string('x', 20);
            public string D26 { get; set; } = new string('x', 20);
            public string D27 { get; set; } = new string('x', 20);
            public string D28 { get; set; } = new string('x', 20);
            public string D29 { get; set; } = new string('x', 20);
            public string D30 { get; set; } = new string('x', 20);
            public string D31 { get; set; } = new string('x', 20);
        }

        internal static MyTable[] CreateItems(int max)
        {
            var result = new List<MyTable>();
            var flag = false;
            result.Add(new MyTable { Id = 0, MyDate = DateTime.Now, MyText = $"Test0 linha1{Environment.NewLine}Test0 linha2", ComplexCol = new MyComplexCol("C0") });
            for (int i = 1; i < max; i++)
            {
                flag = !flag;
                if (flag)
                {
                    result.Add(new MyTable { Id = i, MyText = $"Test{i}", ComplexCol = new MyComplexCol($"C{i}") });
                }
                else
                {
                    result.Add(new MyTable { Id = i, MyDate = DateTime.Now.AddDays(i), MyText = $"Test{i} very very very very very very very very very very very very very very very long", ComplexCol = new MyComplexCol($"C{i}") });
                }
            }
            return result.ToArray();
        }

        static void Main()
        {

            //Ensure ValueResult Culture for all controls
            PromptPlus.Config.DefaultCulture = new CultureInfo("en-us");

            var data = CreateItems(20);

            PromptPlus.DoubleDash("Control:Table - Autofill UserInteraction basic usage");

            var tbl = PromptPlus.Table<MyTable>("Your Prompt", "Descripion Table")
                .AddItems(data)
                .AutoFill(0,80)
                .AddFormatType<DateTime>(FmtDate)
                .UserInteraction(
                    selectedTemplate: (item, row, col) => $"Current ID : {item.Id}. [yellow]Current row {row}, Current col {col}[/]",
                    finishTemplate: (item, row, col) => $"[green]Selected ID : {item.Id}. Current row {row}, Current col {col}[/]")
                .Run();
            if (!tbl.IsAborted)
            {
            }

            PromptPlus.DoubleDash("Control:Table - Autofill UserInteraction with many columns and RowNavigation(Default)");
            PromptPlus.Table<MyTableManyCols>("Your Prompt", "Descripion Table")
                 .Interaction<object>(new Array[5], (ctrl, _) =>
                 {
                     ctrl.AddItem(new MyTableManyCols() { MyText = "x" });
                 })
                 .AutoFill()
                 .AddFormatType<DateTime>(FmtDate)
                 .UserInteraction(
                     selectedTemplate: (item, row, col) => $"Current ID : {item.Id}. [yellow]Current row {row}, Current col {col}[/]",
                     finishTemplate: (item, row, col) => $"[green]Selected ID : {item.Id}. Current row {row}, Current col {col}[/]")
                 .Run();

            PromptPlus.DoubleDash("Control:Table - Autofill UserInteraction with many columns and ColumnsNavigation");
            PromptPlus.Table<MyTableManyCols>("Your Prompt", "Descripion Table")
                 .Interaction<object>(new Array[5], (ctrl, _) =>
                 {
                     ctrl.AddItem(new MyTableManyCols() { MyText = "x" });
                 })
                 .AutoFill(10)
                 .AddFormatType<DateTime>(FmtDate)
                 .ColumnsNavigation()
                 .UserInteraction(
                     selectedTemplate: (item, row, col) => $"Current ID : {item.Id}. [yellow]Current row {row}, Current col {col}[/]",
                     finishTemplate: (item, row, col) => $"[green]Selected ID : {item.Id}. Current row {row}, Current col {col}[/]")
                 .Run();

            PromptPlus.DoubleDash("Control:Table - UserInteraction with with column definition");
            PromptPlus.Table<MyTable>("Your Prompt", "Descripion Table")
                .Title("Test", titleMode: TableTitleMode.InRow)
                .AddItem(new MyTable { Id = data.Length, MyText = $"Test{data.Length} disabled", ComplexCol = new MyComplexCol($"C{data.Length}") }, true)
                .AddItems(data)
                .AddColumn(field: (item) => item.Id, width: 10)
                .AddColumn(field: (item) => item.MyDate!, width: 15/*,alignment: Alignment.Center*/)
                .AddColumn(field: (item) => item.MyText, width: 20, format: (arg) => $"Text: {arg}", maxslidinglines: 2/*, textcrop:true*/)
                .AddColumn(field: (item) => item.MyText, width: 20, format: (arg) => $"Text1: {arg}", title: $"Mytext1", maxslidinglines: 2/*, textcrop:true*/)
                .AddColumn(field: (item) => item.MyText, width: 20, format: (arg) => $"Text2: {arg}", title: $"Mytext2", maxslidinglines: 2/*, textcrop:true*/)
                .AddColumn(field: (item) => item.MyText, width: 20, format: (arg) => $"Text3: {arg}", title: $"Mytext3", maxslidinglines: 2/*, textcrop:true*/)
                .AddColumn(field: (item) => item.MyText, width: 20, format: (arg) => $"Text4: {arg}", title: $"Mytext4", maxslidinglines: 2/*, textcrop:true*/)
                .AddColumn(field: (item) => item.MyText, width: 20, format: (arg) => $"Text5: {arg}", title: $"Mytext5", maxslidinglines: 2/*, textcrop:true*/)
                .AddColumn(field: (item) => item.MyText, width: 20, format: (arg) => $"Text8: {arg}", title: $"Mytext8", maxslidinglines: 2/*, textcrop:true*/)
                .AddColumn(field: (item) => item.MyText, width: 20, format: (arg) => $"Text9: {arg}", title: $"Mytext9", maxslidinglines: 2/*, textcrop:true*/)
                .AddColumn(field: (item) => item.MyText, width: 20, format: (arg) => $"Text10: {arg}", title: $"Mytext10", maxslidinglines: 2/*, textcrop:true*/)
                .AddColumn(field: (item) => item.ComplexCol, width: 20, format: (arg) => $"{((MyComplexCol)arg).Id}:{((MyComplexCol)arg).Name}")
                .AddColumn(field: (item) => item.ComplexCol.Name, width: 10)
                .AddFormatType<DateTime>(FmtDate)
                .UserInteraction(
                    selectedTemplate: (item, row, col) => $"Current ID : {item.Id}. [yellow]Current row {row}, Current col {col}[/]",
                    finishTemplate: (item, row, col) => $"[green]Selected ID : {item.Id}. Current row {row}, Current col {col}[/]")
                .Run();

            data = CreateItems(5);

            var typelayout = Enum.GetValues(typeof(TableLayout));
            var typetit = Enum.GetValues(typeof(TableTitleMode));
            //Title mode
            foreach (var itemt in typetit)
            {
                var tm = (TableTitleMode)Enum.Parse(typeof(TableTitleMode), itemt.ToString()!);
                //Title Grid mode
                foreach (var iteml in typelayout)
                {
                    var hideheaders = true;
                    //hideheaders (true/false)
                    for (int h = 0; h < 2; h++)
                    {
                        hideheaders = !hideheaders;
                        var seprow = true;
                        //SeparatorRows (true/false)
                        for (int i = 0; i < 2; i++)
                        {
                            seprow = !seprow;
                            PromptPlus.DoubleDash($"Autofill Layout({iteml}), Title({itemt}), sep.row({seprow}), hide headers({hideheaders})",style: Style.Default.Foreground(Color.Yellow));
                            var lt = (TableLayout)Enum.Parse(typeof(TableLayout), iteml.ToString()!);
                            PromptPlus.Table<MyTable>("")
                                .Title("Test", Alignment.Center, tm)
                                .SeparatorRows(seprow)
                                .HideHeaders(hideheaders)
                                .Layout(lt)
                                .AddItems(data)
                                .AutoFill()
                                .AddFormatType<DateTime>(FmtDate)
                                .Run(); PromptPlus.KeyPress("Press any key", cfg => cfg.ShowTooltip(false).HideAfterFinish(true)).Run();
                        }
                    }
                }
            }

        }

        private static string FmtDate(object arg)
        {
            var value = (DateTime)arg;
            return value.ToString("G");
        }
    }
}