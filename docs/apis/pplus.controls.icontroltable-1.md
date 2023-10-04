# <img align="left" width="100" height="100" src="../images/icon.png">PromptPlus API:IControlTable<T> 

[![Build](https://github.com/FRACerqueira/PromptPlus/workflows/Build/badge.svg)](https://github.com/FRACerqueira/PromptPlus/actions/workflows/build.yml)
[![Publish](https://github.com/FRACerqueira/PromptPlus/actions/workflows/publish.yml/badge.svg)](https://github.com/FRACerqueira/PromptPlus/actions/workflows/publish.yml)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/FRACerqueira/PromptPlus/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/PromptPlus)](https://www.nuget.org/packages/PromptPlus/)
[![Downloads](https://img.shields.io/nuget/dt/PromptPlus)](https://www.nuget.org/packages/PromptPlus/)

[**Back to List Api**](./apis.md)

# IControlTable&lt;T&gt;

Namespace: PPlus.Controls

Represents the interface with all Methods of the Table control

```csharp
public interface IControlTable<T> : IPromptControls<ResultTable<T>>
```

#### Type Parameters

`T`<br>

Implements IPromptControls&lt;ResultTable&lt;T&gt;&gt;

## Methods

### <a id="methods-addcolumn"/>**AddColumn(Expression&lt;Func&lt;T, Object&gt;&gt;, UInt16, Func&lt;Object, String&gt;, Alignment, String, Alignment, Boolean, Boolean, Nullable&lt;UInt16&gt;)**

Add Column
 <br>AddColumn cannot be run with AutoFill

```csharp
IControlTable<T> AddColumn(Expression<Func<T, Object>> field, ushort width, Func<Object, String> format, Alignment alignment, string title, Alignment titlealignment, bool titlereplaceswidth, bool textcrop, Nullable<UInt16> maxslidinglines)
```

#### Parameters

`field` Expression&lt;Func&lt;T, Object&gt;&gt;<br>
Expression that defines the field associated with the column

`width` [UInt16](https://docs.microsoft.com/en-us/dotnet/api/system.uint16)<br>
column size

`format` [Func&lt;Object, String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
Function to format the field.If not informed, it will be ToString()

`alignment` [Alignment](./pplus.controls.alignment.md)<br>
alignment content

`title` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The Column title

`titlealignment` [Alignment](./pplus.controls.alignment.md)<br>
alignment title

`titlereplaceswidth` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
title width overrides column width when greater

`textcrop` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
If true the value will be truncated by the column size, otherwise, the content will be written in several lines

`maxslidinglines` [Nullable&lt;UInt16&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
Maximum Sliding Lines when the content length is greater than the column size and textcrop = false.

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-addformattype"/>**AddFormatType&lt;T1&gt;(Func&lt;Object, String&gt;)**

Global function to format columns by field type when not specified by 'AddColumn'.

```csharp
IControlTable<T> AddFormatType<T1>(Func<Object, String> funcfomatType)
```

#### Type Parameters

`T1`<br>
Type to convert

#### Parameters

`funcfomatType` [Func&lt;Object, String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.func-2)<br>
The function

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-additem"/>**AddItem(T, Boolean)**

Add item to row grid

```csharp
IControlTable<T> AddItem(T value, bool disable)
```

#### Parameters

`value` T<br>
Item to add

`disable` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
true item disabled, otherwise no

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-additems"/>**AddItems(IEnumerable&lt;T&gt;, Boolean)**

Add items to rows grid

```csharp
IControlTable<T> AddItems(IEnumerable<T> values, bool disable)
```

#### Parameters

`values` IEnumerable&lt;T&gt;<br>
items colletion to add

`disable` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
true item disabled, otherwise no

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-additemsto"/>**AddItemsTo(AdderScope, params T[])**

Add Items to rows grid with scope Disable/Remove [AdderScope](./pplus.controls.adderscope.md)<br>At startup the list items will be compared and will be removed or disabled <br>Tip: Use  for custom comparer

```csharp
IControlTable<T> AddItemsTo(AdderScope scope, params T[] values)
```

#### Parameters

`scope` [AdderScope](./pplus.controls.adderscope.md)<br>
scope Disable/Remove

`values` T[]<br>
items colletion

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-autofill"/>**AutoFill(params Nullable&lt;UInt16&gt;[])**

Auto generate Columns
 <br>AutoFill cannot be run with AddColumn and AutoFit<br>Header alignment will always be 'Center' <br>The content alignment will always be 'Left' and will always be with sliding lines<br>Columns are generated by the public properties of the data class recognized by .<br>TypeCode.DBNull and TypeCode.Object will be ignored.<br>The column size will be automatically adjusted by the title size (Name property) and the minmaxwidth parameter or content width when min/max width is null

```csharp
IControlTable<T> AutoFill(params Nullable<UInt16>[] minmaxwidth)
```

#### Parameters

`minmaxwidth` [Nullable&lt;UInt16&gt;[]](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
minimum and maximum width

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-autofit"/>**AutoFit(params UInt16[])**

Set the grid to auto-resize to current console width
 <br>AutoFit cannot be run with AutoFill

```csharp
IControlTable<T> AutoFit(params UInt16[] indexColumn)
```

#### Parameters

`indexColumn` [UInt16[]](https://docs.microsoft.com/en-us/dotnet/api/system.uint16)<br>
List (cardinality) of columns that will be affected.
 <br>If none all columns that will be affected

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-autoselect"/>**AutoSelect(Boolean)**

Automatically select and finalize item when only one item is in the list . Default false.

```csharp
IControlTable<T> AutoSelect(bool value)
```

#### Parameters

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Automatically select

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-changedescription"/>**ChangeDescription(Func&lt;T, Int32, Int32, String&gt;)**

Dynamically change the description using a user role

```csharp
IControlTable<T> ChangeDescription(Func<T, Int32, Int32, String> value)
```

#### Parameters

`value` Func&lt;T, Int32, Int32, String&gt;<br>
function to apply change
 <br>Func(T, int, int, string) = T = item, int = current row (base0) , int = current col (base0)

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-columnsnavigation"/>**ColumnsNavigation(Boolean)**

Enable Columns Navigation. Default false.
 <br>When the column size is greater than the screen size, the content will be truncated

```csharp
IControlTable<T> ColumnsNavigation(bool value)
```

#### Parameters

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Enable Columns Navigation

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-config"/>**Config(Action&lt;IPromptConfig&gt;)**

Custom config the control.

```csharp
IControlTable<T> Config(Action<IPromptConfig> context)
```

#### Parameters

`context` [Action&lt;IPromptConfig&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
action to apply changes. [IPromptConfig](./pplus.controls.ipromptconfig.md)

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-default"/>**Default(T)**

Default value selected.

```csharp
IControlTable<T> Default(T value)
```

#### Parameters

`value` T<br>
Value default

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-equalitems"/>**EqualItems(Func&lt;T, T, Boolean&gt;)**

Custom item comparator

```csharp
IControlTable<T> EqualItems(Func<T, T, Boolean> comparer)
```

#### Parameters

`comparer` Func&lt;T, T, Boolean&gt;<br>
function comparator

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-filterbycolumns"/>**FilterByColumns(FilterMode, params UInt16[])**

Set Columns used by Filter strategy.

```csharp
IControlTable<T> FilterByColumns(FilterMode filter, params UInt16[] indexColumn)
```

#### Parameters

`filter` [FilterMode](./pplus.controls.filtermode.md)<br>
Filter strategy for filter rows.Default value is FilterMode.Disabled

`indexColumn` [UInt16[]](https://docs.microsoft.com/en-us/dotnet/api/system.uint16)<br>
list (cardinality) of columns

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-hideheaders"/>**HideHeaders(Boolean)**

Hide columns headers. Default false.

```csharp
IControlTable<T> HideHeaders(bool value)
```

#### Parameters

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Hide headers

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-hideselectorrow"/>**HideSelectorRow(Boolean)**

Hide selector row. Default false.

```csharp
IControlTable<T> HideSelectorRow(bool value)
```

#### Parameters

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Hide selector row

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-interaction"/>**Interaction&lt;T1&gt;(IEnumerable&lt;T1&gt;, Action&lt;IControlTable&lt;T&gt;, T1&gt;)**

Execute a action foreach item of colletion passed as a parameter

```csharp
IControlTable<T> Interaction<T1>(IEnumerable<T1> values, Action<IControlTable<T>, T1> action)
```

#### Type Parameters

`T1`<br>
Layout external colletion

#### Parameters

`values` IEnumerable&lt;T1&gt;<br>
Colletion for interaction

`action` Action&lt;IControlTable&lt;T&gt;, T1&gt;<br>
Action to execute

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-layout"/>**Layout(TableLayout)**

The Table layout. Default value is 'TableLayout.SingleGridFull'

```csharp
IControlTable<T> Layout(TableLayout value)
```

#### Parameters

`value` [TableLayout](./pplus.controls.tablelayout.md)<br>
The [TableLayout](./pplus.controls.tablelayout.md)

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-orderby"/>**OrderBy(Expression&lt;Func&lt;T, Object&gt;&gt;)**

Sort rows by expression

```csharp
IControlTable<T> OrderBy(Expression<Func<T, Object>> value)
```

#### Parameters

`value` Expression&lt;Func&lt;T, Object&gt;&gt;<br>
expresion to sort the rows

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-orderbydescending"/>**OrderByDescending(Expression&lt;Func&lt;T, Object&gt;&gt;)**

Sort Descending rows by expression

```csharp
IControlTable<T> OrderByDescending(Expression<Func<T, Object>> value)
```

#### Parameters

`value` Expression&lt;Func&lt;T, Object&gt;&gt;<br>
expresion to sort the rows

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-overwritedefaultfrom"/>**OverwriteDefaultFrom(String, Nullable&lt;TimeSpan&gt;)**

Overwrite defaults start selected value with last result saved on history.

```csharp
IControlTable<T> OverwriteDefaultFrom(string value, Nullable<TimeSpan> timeout)
```

#### Parameters

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
name of file to save history

`timeout` [Nullable&lt;TimeSpan&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The timeout for valid items saved. Default value is 365 days

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-pagesize"/>**PageSize(Int32)**

Set max.item view per page.Default value for this control is 10.

```csharp
IControlTable<T> PageSize(int value)
```

#### Parameters

`value` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Number of Max.rows

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-preservetable"/>**PreserveTable(Boolean)**

Preserve table at end (user interaction). Default is false.

```csharp
IControlTable<T> PreserveTable(bool value)
```

#### Parameters

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
Preserve table at end

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-separatorrows"/>**SeparatorRows(Boolean)**

Set separator between rows. Default false.

```csharp
IControlTable<T> SeparatorRows(bool value)
```

#### Parameters

`value` [Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>
separator between rows

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-styles"/>**Styles(TableStyle, Style)**

Styles for Table elements

```csharp
IControlTable<T> Styles(TableStyle styletype, Style value)
```

#### Parameters

`styletype` [TableStyle](./pplus.controls.tablestyle.md)<br>
[TableStyle](./pplus.controls.tablestyle.md) of content

`value` [Style](./pplus.style.md)<br>
The [Style](./pplus.style.md)

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-title"/>**Title(String, Alignment, TableTitleMode)**

Set Title Table

```csharp
IControlTable<T> Title(string value, Alignment alignment, TableTitleMode titleMode)
```

#### Parameters

`value` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Title

`alignment` [Alignment](./pplus.controls.alignment.md)<br>
alignment title. Default value is Alignment.Center

`titleMode` [TableTitleMode](./pplus.controls.tabletitlemode.md)<br>
InLine(Default): Write the title above the grid. InRow : Write the title inside the grid as a row

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)

### <a id="methods-userinteraction"/>**UserInteraction(Func&lt;T, Int32, Int32, String&gt;, Func&lt;T, Int32, Int32, String&gt;)**

Wait Select row with [enter].Default not wait (only display all rows)

```csharp
IControlTable<T> UserInteraction(Func<T, Int32, Int32, String> selectedTemplate, Func<T, Int32, Int32, String> finishTemplate)
```

#### Parameters

`selectedTemplate` Func&lt;T, Int32, Int32, String&gt;<br>
message template function when selected item. 
 <br>Func(T, int, int, string) = T = item, int = current row (base0) , int = current col (base0)

`finishTemplate` Func&lt;T, Int32, Int32, String&gt;<br>
message template function when finish control with seleted item
 <br>Func(T, int, int, string) = T = item, int = current row (base0) , int = current col (base0)

#### Returns

[IControlTable&lt;T&gt;](./pplus.controls.icontroltable-1.md)


- - -
[**Back to List Api**](./apis.md)