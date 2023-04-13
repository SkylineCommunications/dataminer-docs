---
uid: UIComponentsCustomTableContextMenu
---

# Custom table context menu

It is possible to define a custom context menu for tables.

> [!TIP]
> DIS provides a plugin (*Extensions > DIS > Plugins > Add Table Context Menu*) that can be used to create custom context menus that make use of the [Skyline.DataMiner.Protocol.TableContextMenu](https://www.nuget.org/packages/Skyline.DataMiner.Utils.Table.ContextMenu) NuGet package.

To define a custom context menu, define a parameter with the same name as the table and the suffix "_ContextMenu". Each discrete entry represents a menu item and can be one of the following types:

- Action: This will trigger the QAction.
- Action with dependencies: The user will be asked to enter a value for each parameter specified in the [dependencyValues](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-dependencyValues) attribute.
- Action with [rowselection](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-options#tableselection): This is only available if the user has selected one or more rows in the table. The index of each row will be passed to the QAction.
- Action with [confirmation](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-options#confirmabc): This action will only be executed when the user confirms the pop-up.
- [Automation script](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-options#script): This will start an Automation script instead of triggering a QAction. It uses the same syntax as for Visio and you can use * for dummies to use the current element and specify parameter IDs of columns of the selected row to use as values for script parameters.
- [Separator](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-options#separator): This displays a separator line between menu items.

```xml
<Param id="2099">
   <Name>myTable_ContextMenu</Name>
   <Description>Context Menu for My Table</Description>
  <Type>write</Type>
  <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
  <Display>
     <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
      <Type>discreet</Type>
      <Discreets>
         <Discreet dependencyValues="2001;2002;2003;2004;2005">
            <Display>Add new row...</Display>
            <Value>add</Value>
         </Discreet>
         <Discreet options="table:singleSelection" dependencyValues="2001;2002?;2003:[value:2003];2004?:[value:2004]">
            <Display>Duplicate item...</Display>
            <Value>duplicate</Value>
         </Discreet>
         <Discreet options="table:selection;confirm:The selected item(s) will be deleted permanently.">
            <Display>Delete selected row(s)...</Display>
            <Value>delete</Value>
         </Discreet>
         <Discreet options="separator">
            <Display>Separator -1</Display>
            <Value>-1</Value>
         </Discreet>
         <Discreet options="rowTextColor=#00FF00">
            <Display>Green</Display>
            <Value>1</Value>
         </Discreet>
         <Discreet>
            <Display>Clear table</Display>
            <Value>clear</Value>
         </Discreet>
         <Discreet options="separator">
            <Display>Separator 2</Display>
            <Value>-2</Value>
         </Discreet>
         <!-- Level must be first option in the list of options into the Discreet@options attribute -->
         <Discreet options="level:5">
            <Display>Depends on Level Access</Display>
            <Value>access</Value>
         </Discreet>
         <!-- Script must be last option in the list of options into the Discreet@options attribute -->
         <Discreet options="script:Context Menu from a Protocol|d1=[this element]|p1=[value:1001];p2=[value:2002]|||NoConfirmation">
            <Display>Start script</Display>
            <Value>script1</Value>
         </Discreet>
      </Discreets>
  </Measurement>
</Param>
```

A QAction needs to trigger on this context menu parameter to handle the actions of the menu item. The Run() method will receive a string array argument that contains information related to the context menu:

```csharp
public static void Run(SLProtocolExt protocol, object contextMenu)
```

For example, consider the following menu item definition:

```xml
<Discreets>
   <Discreet dependencyValues="1011;1012" options="table:selection">
      <Display>Load Configuration</Display>
      <Value>load</Value>
   </Discreet>
</Discreets>
```

In a QAction, you can process the context menu data as follows:

```csharp
string[] contextMenuData = (string[]) contextMenu;
```

- contextMenuData [0] = client identifier (reserved for future use).
- contextMenuData [1] = action, discrete value (in the example above, the value would be "load").
- contextMenuData [2…n] = additional entries depending on the action: an entry per dependency value defined in the dependencyValues attribute (if any) followed by entries denoting the primary keys of the selected rows (if any).

In the example above, contextMenuData[2] contains the provided value for parameter 1011, contextMenuData[3] contains the provided value for parameter 1012, contextMenuData [4...n] contains the primary keys of the rows that were selected.

> [!NOTE]
> Selecting a context menu item does not perform a normal set. The QAction will immediately be triggered, similar to the NT_ALL_TRAP_INFO setDataMinerInfoMessage.

```xml
<QAction id="2099" encoding="csharp" triggers="2099">
<![CDATA[
using System;
using System.Collections;
using Skyline.DataMiner.Scripting;

/// <summary>
/// Process custom context menu action.
/// </summary>
public class QAction
{
    /// <summary>
    /// QAction entry point.
    /// </summary>
    /// <param name="protocol">Link with SLProtocol process.</param>
    /// <param name="contextData">Context menu data.</param>
    public static void Run(SLProtocol protocol, object contextData)
    {
        var sa = contextData as string[];
    
        if (sa == null || sa.Length < 2)
        {
            return;
        }
    
        if (sa[1] == "add")
        {
            object[] tmpRow = new object[5];
            
            for (int i = 0; i < 5; i++)
            {
                tmpRow[i] = sa[i + 2];
            }
    
            protocol.NotifyProtocol(149 /*NT_ADD_ROW*/, 2000, (string)sa[2]);
            protocol.SetRow(2000, (string)sa[2], tmpRow);
        }
        else if (sa[1] == "delete")
        {
            for (int i = 2; i < sa.Length; i++)
            {
                protocol.DeleteRow(2000, sa[i]);
            }
        }
        else if (sa[1] == "clear")
        {
            string[] primaryKeys = protocol.GetKeys(2000, NotifyProtocol.KeyType.Index);
        
            if (primaryKeys.Length > 0)
            {
                protocol.DeleteRow(2000, primaryKeys);
            }
        }
    }
}
]]>
</QAction>
```

> [!NOTE]
> From DataMiner 10.1.4 (RN 28753) onwards, when you open a context menu of a table and select an option from it, an information event will be generated similar to the one that is generated when you set a parameter. This information event will contain the following data:
>
> - Parameter description: The full display name of the context menu parameter, in the format <TableName>_ContextMenu.
> - Parameter value: A value in the format `Set by <user> to <command display value>`. If there are dependency values, the value will have the following format: `Set by <user> to <command display value>: "<dependency 1>"; "<dependency 2>"`.

## Placeholders

When defining menu items, you can use one or more of the following placeholders both in the options attribute and the Display tag. Feature introduced in DataMiner 8.5.0 (RN 7360).

|Placeholder|Refers to|
|--- |--- |
|[var:abc]|A session variable.|
|[cardvar:abc]|A card-scope session variable. *Feature introduced in DataMiner 8.5.1 (RN 7912).*|
|[pagevar:abc]|A Visio page-scope session variable. *Feature introduced in DataMiner 8.5.1 (RN 7912).*|
|[this element]|The element that holds the dynamic table. This way, you can for example add a dummy to a script or display an element ID.|
|[property:abc]|The value of an element property.|
|[value:123]|The cell value found in the selected row of the specified column. 123 has to be a column parameter ID.|
|[tableindex], [primarykey]|The primary key for the selected row.|
|[displaytableindex], [displaykey]|The display key for the selected row.|
|[param:12/34,56:78]|The value of a parameter, where 12 is the DMA ID, 34 is the element ID, 56 is the column parameter ID, and 78 is the display key value. See warning below.|

Values used in a [param:...] placeholder must be available. If not, a blocking server call may occur.

> [!NOTE]
>
> - When inside an element card, other parameters of the same element should be instantly available.
> - When on a Visio page, an invisible shape linked to the parameter in question should be placed on the same page.
> - Never refer to table cells in [param:...] placeholders.

By default, all indexes are handled as display keys. Use the prefix "^pk^" to indicate that the specified index is a primary key.

Example:

- [param:506:^pk^1] = value of column 506, row with primary key "1".
- [param:506:1] = value of column 506, row with display key "1".

> [!NOTE]
>
> - From DataMiner 9.5.3 (RN 15743) onwards, using the prefix "^pk^" to indicate that the following index is a primary key index instead of a display index is supported in button values.
> - From DataMiner 9.5.4 (RN 16071) onwards, when placeholders are used in button values, it is possible to use the prefix ^pk^ using the placeholder syntax described below.

From DataMiner 9.5.2 onwards (RN 14711), it is also possible to insert the following dynamic values into button
values and context menu items.

|Syntax|Value|
|--- |--- |
|{sessionVar:x}|Value of session variable x|
|{pageVar:x}|Value of page variable x|
|{cardVar:x}|Value of card variable x|
|{elementName}|Name of the current element|
|{elementProperty:x}|Value of the element property x|
|{rowPK}|Primary key of the current row|
|{rowDK}|Display key of the current row|
|{extPID:epid/pid/key}|Value of a parameter from another element: **epid** = Parameter ID of the parameter containing the element ID (format "DMAID/element ID", e.g. 200/400, **pid** = Parameter ID, **key** = Row key (optional) )|
|{extPID:[dmaID/eID]/pid/key}|Value of a parameter from another element: *[dmaID/eID]* = Element ID (format "dmaid/eid"), **pid** = Parameter ID, **key** = Row key (optional) *Feature introduced in DataMiner 9.5.4 (RN 16071).*|
|{pid:x/k}|Value of a parameter from the current element: **x** = Parameter ID, **k** = Row key (optional) Note: Row key (k) can be omitted if the parameter is a column of the current row.|
|{fkPid:x}|Value of the column with parameter ID x of the first row with a foreign key relation to the current row.|

The following types of recursion are supported:

- Dynamic value inside dynamic value.
  Example: {pid:1004/{pid:102}} will be replaced by the value found in column 1004 on the row of which the index is stored in parameter 102.
- Dynamic value refers to another dynamic value.
  Example: If you use {pid:1003}, and the value of parameter 1003 is "{pid:1004}", then {pid:1003} will be replaced by the value of parameter 1004. If the row index is not specified in a placeholder, then the current row index will be used. In other words, if parameters 1003 and 1004 in the example above are column parameters, the current row index will be used to retrieve the value of column 1004. This type of recursion goes up to 5 levels deep.

> [!NOTE]
>
> - Not all placeholders listed in the table above can be used in all situations. If you use a placeholder in a situation where the value cannot be resolved, the placeholder will be replaced by an empty string.
> - From DataMiner 9.5.2 onwards (RN 14506), the placeholders are supported in URLs of buttons of type "open" in an EPM (formerly known as CPE) environment.

Examples

```xml
<Discreet>
    <Display>Example</Display>
    <Value type="open">http://example.com/{elementName}</Value>
</Discreet>
```

```xml
<Discreet options="table:singleselection;confirm:Are you sure you want to delete {rowDK}?">
    <Display>Delete selected row(s)...</Display>
    <Value>delete</Value>
</Discreet>
```

## Sending feedback to the client

When a QAction is executed via a context menu, that QAction can send an INFO or ERROR feedback message to the client, which will be displayed in a message box.

To do so, use the protocol.ShowInformationMessage(“xyz”) method.

You can also send a feedback message by setting a parameter named “xxx_QActionFeedback” (xxx being the name of the table) to one of the following values:

- yyy|INFO|abc
- yyy|ERROR|xyz

yyy is the unique ID of the client to which to send the message. This ID can be retrieved from the first cell of the object containing the context menu data.

*Feature introduced in DataMiner 8.5.0 (RN 7360).*

## See also

DataMiner Protocol Markup Language:

- [Protocol.Params.Param.Measurement.Discreets.Discreet options: script:...](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-options#script)
- [Protocol.Params.Param.Measurement.Discreets.Discreet options: separator](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-options#separator)
- [Protocol.Params.Param.Measurement.Discreets.Discreet options: table:selection](xref:Protocol.Params.Param.Measurement.Discreets.Discreet-options#tableselection)
