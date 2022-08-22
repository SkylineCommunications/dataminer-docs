---
uid: DIS_2.26
---

# DIS 2.26

## New features

### IDE

#### Solution-based protocol development \[ID_25536\]

It is now possible to develop DataMiner protocols as Visual Studio solutions.

##### Creating a new protocol solution

To create a new protocol solution containing a basic protocol with one precompiled, basic QAction, select *File \> New \> DataMiner Protocol Solution…*

##### Converting an existing protocol XML file to a protocol solution

To convert an existing protocol XML file to a protocol solution, select *DIS \> Protocol \> Convert to Solution...*

A new protocol solution will be created, and the existing protocol XML file will be added. However, the \<QAction> tags will not contain any C# code. For each of the QActions in the original protocol XML file, a new C# project will be created, and any DLL imports specified in the original QActions will be converted to references on the C# projects (pointing either to other C# projects or to DLL files).

> [!NOTE]
> When you open a protocol, DIS will automatically detect whether the protocol is solution-based. A protocol will be considered solution-based when the solution has a “Solution Items” folder containing a “protocol.xml” file and a “QActions” folder containing at least one C# project named “QAction\_\<id>”.

##### Editing QActions

To edit a QAction, you now have two options:

- Click the edit icon next to the \<QAction> tag in the protocol XML file (as before), or
- Open Visual Studio’s Solution Explorer window, go to the QAction\_\<id> project and open the QAction\_\<id>.cs file.

> [!NOTE]
>
> - A QAction project can contain several \*.cs files. These files will then be combined when compiling the protocol.
> - It is recommended to place all “using” directives inside the namespace instead of at the top of the file.
> - DLL imports now need to be configured by adding references on the C# project itself. Those references can either refer to external DLL files (in C:\\DataMiner\\ProtocolScripts or C:\\DataMiner\\Files) or to other QActions in the solution. The latter will at compilation be translated to “\[ProtocolName\].\[ProtocolVersion\].QAction.\<id>.dll” imports in the protocol.

##### Uploading a protocol to a DataMiner Agent

Because the QActions of a solution-based protocol are empty in the protocol XML file, the protocol first needs to be compiled before it can be uploaded to a DataMiner Agent. Only at compilation will the code in all QAction projects and files found in the solution be copied to the correct \<QAction> tags in the protocol XML file.

A protocol will automatically be compiled when you click the *Publish* button at the top of the file tab, or when you right-click and select *Copy Protocol to Clipboard*.

##### Saving a compiled protocol to a file

To save a compiled protocol to a file, select *File \> Save Compiled Protocol As...*

### Validator

#### New checks and error messages \[ID_24636\]

The following checks and error messages have been added.

| ID     | Check                      | Error message                                                                                      |
|--------|----------------------------|----------------------------------------------------------------------------------------------------|
| 2.53.1 | MissingTableNameAsPrefixes | Missing table name '{tableName}' in front of column names. Table PID '{tablePid}'.                 |
| 2.53.2 | MissingTableNameAsPrefix   | Missing table name '{tableName}' in front of column name '{columnName}'. Column PID '{columnPid}'. |

### XML Schema

#### Protocol XML Schema now accepts 'certificate' for Session@loginMethod attribute \[ID_25384\]

The Protocol XML Schema now accepts the value “certificate” for the Session@loginMethod attribute.

### Class Library

#### Retrieving data from partial tables \[ID_24951\]

The Class Library is now able to retrieve data from partial tables.

##### GetData method

The IDmsTable GetData method will now return the entire contents of a partial table.

Up to now, it would only return the first page of such a table.

##### QueryData method

The new IDmsTable QueryData method will return an IEnumerable\<object\[\]\>, i.e. a collection of row objects.

To this method, you can pass a column filter as an ICollection\<ITableFilter>, in which each ITableFilter item contains a ColumnPid, a ColumnValue and a CompareType property. If, for example, you only want to retrieve the rows in which column parameter 1003 is set to “test”, you can specify the following:

```csharp
ITableFilterItem filter = new TableFilterItem
{
    ColumnPid = 1013,
    ColumnValue = "test",
    CompareType = CompareType.Equal
};
```

> [!NOTE]
>
> - Using GetData will retrieve the entire table in one request. If you only need to retrieve a portion of a table, consider using QueryData instead.
> - Using QueryData without a filter will retrieve the entire table in multiple requests (one request per page).
> - Using QueryData with a filter will retrieve the table rows matching the filter in one request.

#### Matrix Helper: Serialized matrix status information \[ID_25127\]

The Matrix Helper classes now have an extra constructor that allows passing the ID of the serialized parameter, a single displayed read parameter of which the measurement type is set to string. The Matrix Helper object will then fill this parameter with the entire matrix status (labels, locks, crosspoints, etc.) in JSON format.

This matrix status information can then be read by, for example, the Generic Matrix Virtualization protocol or any other external element that is able to deserialize the JSON content to an object of the MatrixStatus class, which can be found in the same namespace as the Matrix Helper.

#### Retrieving SNMP connection information & creating elements with SNMP connections \[ID_25585\]

The Class Library now supports the retrieval of information from the following SNMP connections as well as the creation of elements with these types of connections:

- SNMPv1 connections
- SNMPv2 connections
- SNMPv3 connections
- Virtual connections

#### IEngine interface now supports the extension of the GetDms method \[ID_25632\]

The IEngine interface now supports the extension of the GetDms method.

## Changes

### Enhancements

#### Miscellaneous Validator enhancements \[ID_25094\]

- If the MinimumRequiredVersion tag of a protocol indicates that C# 7.3 syntax is supported, then C# code analysis will only be performed if the Visual Studio instance that runs the Validator also supports C# 7.3 syntax. Otherwise, the following warning will appear during validation:

    | ID  | Check | Error message |
    |-----|-------|---------------|
    | 3.4.3 | NoCSharpCodeAnalysisPerformed | No C# QAction code analysis was performed due to unsupported C# version '{cSharpVersion}' in Visual Studio version '{visualStudioVersion}'. |

- The Validator will no longer throw an exception if the placeholders used in the dllImport attribute are spelled incorrectly. Instead, it will show a message indicating that the specified DLL file could not be found.
- The Validator will now ignore empty dllImport values (e.g. when the dllImport attribute value ends with “;”).

#### IDE - Table Editor: Scrolling inside selection boxes has been disabled \[ID_25310\]

In order to prevent unwanted selection box updates in the Table Editor, it will no longer be possible to scroll through the values of a closed selection box.

### Fixes

#### IDE: Problem when determining EXE block IDs in Automation scripts \[ID_25402\]

When DIS had to add a new EXE block with generated Class Library code to an Automation script, it would determine its ID by only checking the existing EXE tags in the XML code of the script. As EXE block IDs should be unique across the entire XML code of an Automation script, DIS will now also check the following IDs before assigning an ID to a new EXE block:

- DMSScript.Memory.File@id
- DMSScript.Parameters.ScriptParameter@id
- DMSScript.Protocols.Protocol@id
- DMSScript.Script.Exe@id

#### Class Library - InterApp calls: Problem when checking the mapping dictionary \[ID_25442\]

The InterApp calls allow to provide a dictionary that is a mapping between the Message class and the Executor class. When the Class Library was used as a DLL file, in some cases, the dictionary check would fail.

#### IDE: No QActions listed in DIS Inject window when protocol contained the UTF-8 BOM \[ID_25530\]

When DIS retrieved a protocol containing the UTF-8 byte order mark from a DataMiner Agent, in some cases, it would not process that file correctly. As a result, no QActions would appear in the DIS Inject window, making it impossible to debug them.
