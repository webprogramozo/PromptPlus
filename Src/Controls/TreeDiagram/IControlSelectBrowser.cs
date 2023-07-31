﻿// ***************************************************************************************
// MIT LICENCE
// The maintenance and evolution is maintained by the PromptPlus project under MIT license
// ***************************************************************************************

using System;
using System.Collections.Generic;

namespace PPlus.Controls
{
    ///<inheritdoc cref="IPromptControls{T}"/>
    /// <summary>
    /// Represents the interface with all Methods of the Browser control
    /// </summary>
    public interface IControlSelectBrowser : IPromptControls<ItemBrowser>
    {
        /// <summary>
        /// Custom config the control.
        /// </summary>
        /// <param name="context">action to apply changes. <see cref="IPromptConfig"/></param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser Config(Action<IPromptConfig> context);

        /// <summary>
        /// Not show Spinner
        /// </summary>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser NoSpinner();

        /// <summary>
        /// Disabled ExpandAll Feature. Only item in Top-level are expanded
        /// <br>Overwrite Root option ExpandAll to false</br>
        /// </summary>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser DisabledRecursiveExpand();

        /// <summary>
        /// Overwrite <see cref="SpinnersType"/>. Default value is SpinnersType.Ascii
        /// <br>When use custom spinner, if has unicode values console does not support it, the rendering may not be as expected</br>
        /// </summary>
        /// <param name="spinnersType">The <see cref="SpinnersType"/></param>
        /// <param name="spinnerStyle">Style of spinner. <see cref="Style"/></param>
        /// <param name="speedAnimation">Number of mileseconds foreach interation of spinner. Valid only to SpinnersType.custom, otherwise will be ignored</param>
        /// <param name="customspinner">IEnumerable values for custom spinner. Valid only to SpinnersType.custom, otherwise will be ignored</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser Spinner(SpinnersType spinnersType, Style? spinnerStyle = null, int? speedAnimation = null, IEnumerable<string>? customspinner = null);

        /// <summary>
        /// Overwrite Styles Browser. <see cref="StyleBrowser"/>
        /// </summary>
        /// <param name="styletype">Styles Browser</param>
        /// <param name="value"><see cref="Style"/></param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser Styles(StyleBrowser styletype, Style value);

        /// <summary>
        /// Show lines of level. Default is true
        /// </summary>
        /// <param name="value">true Show lines, otherwise 'no'</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser ShowLines(bool value);

        /// <summary>
        /// Show expand SymbolType.Expanded. Default is true
        /// </summary>
        /// <param name="value">true Show Expanded SymbolType, otherwise 'no'</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser ShowExpand(bool value);

        /// <summary>
        /// Load only Folders on browser. Default is false
        /// </summary>
        /// <param name="value">true only Folders, otherwise Folders and files</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser OnlyFolders(bool value);

        /// <summary>
        /// Show folder and file size in browser. Default is true
        /// </summary>
        /// <param name="value">true Show size, otherwise 'no'</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser ShowSize(bool value);

        /// <summary>
        /// Accept hidden folder and files in browser. Default is false
        /// </summary>
        /// <param name="value">true accept hidden folder and files, otherwise 'no'</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser AcceptHiddenAttributes(bool value);

        /// <summary>
        /// Accept system folder and files in browser. Default is false
        /// </summary>
        /// <param name="value">true accept system folder and files, otherwise 'no'</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser AcceptSystemAttributes(bool value);

        /// <summary>
        /// Search folder pattern. Default is '*'
        /// </summary>
        /// <param name="value">Search pattern</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser SearchFolderPattern(string value);

        /// <summary>
        /// Search file pattern. Default is '*'
        /// </summary>
        /// <param name="value">Search pattern</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser SearchFilePattern(string value);

        /// <summary>
        /// Set max.item view per page.Default value for this control is 10.
        /// </summary>
        /// <param name="value">Number of Max.items</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser PageSize(int value);

        /// <summary>
        /// Filter strategy for filter items in colletion
        /// <br>Default value is FilterMode.Contains</br>
        /// </summary>
        /// <param name="value">Filter Mode</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser FilterType(FilterMode value);

        /// <summary>
        /// Set folder root to browser
        /// </summary>
        /// <param name="value">full path folder root</param>
        /// <param name="expandall">true expand all folder, otherwise 'no'</param>
        /// <param name="validselect">Accept select item that satisfy the function</param>
        /// <param name="setdisabled">Disabled all items that satisfy the disabled function</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser Root(string value, bool expandall = true, Func<ItemBrowser, bool>? validselect = null, Func<ItemBrowser, bool>? setdisabled = null);

        /// <summary>
        /// Default item (fullpath) seleted when started
        /// </summary>
        /// <param name="value">fullpath</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser Default(string value);

        /// <summary>
        /// Append name current folder on description
        /// </summary>
        /// <param name="value">true Append current name folder on description, not append</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser ShowCurrentFolder(bool value);

        /// <summary>
        /// Overwrite a HotKey toggle current name folder to FullPath. Default value is 'F2' 
        /// </summary>
        /// <param name="value">The <see cref="HotKey"/> to oggle current name folder to FullPath</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser HotKeyFullPath(HotKey value);

        /// <summary>
        /// Overwrite a HotKey expand/Collap current folder selected. Default value is 'F3' 
        /// </summary>
        /// <param name="value">The <see cref="HotKey"/> to expand/Collapse current folder selected</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser HotKeyToggleExpand(HotKey value);

        /// <summary>
        /// Overwrite a HotKey expand/Collap all folders. Default value is 'F4' 
        /// </summary>
        /// <param name="value">The <see cref="HotKey"/> to expand/Collap all folders</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser HotKeyToggleExpandAll(HotKey value);

        /// <summary>
        /// Action to execute after Expanded 
        /// </summary>
        /// <param name="value">The action</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser AfterExpanded(Action<ItemBrowser> value);

        /// <summary>
        /// Action to execute after Collapsed 
        /// </summary>
        /// <param name="value">The action</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser AfterCollapsed(Action<ItemBrowser> value);

        /// <summary>
        /// Action to execute before Expanded 
        /// </summary>
        /// <param name="value">The action</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser BeforeExpanded(Action<ItemBrowser> value);

        /// <summary>
        /// Action to execute before Collapsed 
        /// </summary>
        /// <param name="value">The action</param>
        /// <returns><see cref="IControlSelectBrowser"/></returns>
        IControlSelectBrowser BeforeCollapsed(Action<ItemBrowser> value);

    }
}