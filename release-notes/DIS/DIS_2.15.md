---
uid: DIS_2.15
---

# DIS 2.15

## New features

### IDE

#### DIS Tree: New button to open tree node at cursor position \[ID_20677\]

When working in the XML editor or the C# editor, you can press a key combination (default: CTRL+1) to move the cursor to the DIS Tree tool window and select the DIS tree node representing the element you are editing.

From now on, instead of pressing this key combination, you can also click the following button, which is situated in the top-left corner of the DIS Tree tool window:

![Sync arrow button](~/release-notes/images/SyncArrow_16x.jpg)

#### DIS Tree: Pin XML nodes \[ID_20690\]

It is now possible to pin XML nodes to a special pin section at the top of the DIS Tree tool window.

- To pin a node, right-click the node in the DIS Tree, and select *Pin* from the shortcut menu.
- To unpin a pinned node, right-click the node either in the DIS Tree or the pin section, and select *Unpin* from the shortcut menu.
- To unpin all pinned nodes, right-click a random node in the pin section, and select *Unpin All* from the shortcut menu.

When you hover over a pinned node in the pin section, a tooltip will appear, showing you more information about the node in question.

#### XML editor: Shortcut menu option 'Add QAction Reference' renamed to 'DLL Imports' \[ID_20702\]

Up to now, when you clicked the small Down arrow in front of a \<QAction> element, you could select the *Add QAction Reference* menu option to insert references to pre-compiled QActions into the *dllImport* attribute of the \<QAction> element. That *Add QAction Reference* menu option has now been renamed to *DLL Imports*.

When you select the *DLL Imports* menu option, a submenu will now list

- all QActions of which the *options* attribute contains the “precompile” option, as well as
- all commonly used system DLL files:

  - Newtonsoft.Json.dll
  - SLDatabase.dll
  - SLProtocolScripts.dll
  - System.Data.dll
  - System.Runtime.Serialization.dll
  - System.Web.dll
  - System.Web.Extensions.dll
  - System.Xml.dll
  - System.Xml.Linq.dll

> [!NOTE]
> In the submenu, all DLL files already inserted into the *dllimport* attribute of the \<QAction> element will be indicated by a check mark.

#### XML editor: Enhanced protocol comparison \[ID_20971\]

Since DIS v.2.13, it is possible to compare two protocols and have the major changes displayed in the DIS Validator pane. The following additional checks will now be executed when you launch a protocol comparison:

| ID     | Check                       | Error message                     |
|--------|-----------------------------|-----------------------------------|
| 1.8.4  | CheckTypeTag                | UpdatedValue                      |
| 1.9.2  | CheckOptionsAttribute       | UpdatedDveExportProtocolName      |
| 1.9.3  | CheckOptionsAttribute       | RemovedDveExportProtocolName      |
| 1.9.4  | CheckOptionsAttribute       | AddedNoElementPrefix              |
| 1.9.5  | CheckOptionsAttribute       | RemovedNoElementPrefix            |
| 1.11.1 | CheckAdvancedAttribute      | AdvancedConnectionOrderChanged    |
| 1.11.2 | CheckAdvancedAttribute      | AdvancedConnectionTypeChanged     |
| 1.11.3 | CheckAdvancedAttribute      | AdvancedConnectionAdded           |
| 1.12.1 | CheckParameterGroupsTag     | DcfAdded                          |
| 1.13.1 | CheckNameAttribute          | DcfParameterGroupNameChanged      |
| 1.14.1 | CheckTypeAttribute          | DcfParameterGroupTypeChanged      |
| 1.15.1 | CheckGroupTag               | DcfParameterGroupRemoved          |
| 2.12.1 | CheckValueTag               | UpdatedValue                      |
| 2.12.2 | CheckValueTag               | RemovedItem                       |
| 2.13.1 | CheckDisplayTag             | UpdatedValue                      |
| 2.14.1 | CheckDescriptionTag         | UpdatedValue                      |
| 2.14.2 | CheckDescriptionTag         | RemovedItem                       |
| 2.15.1 | CheckArrayOptionsTag        | DisplayColumnChangedToNaming      |
| 2.15.2 | CheckArrayOptionsTag        | DisplayColumnChangeToNamingFormat |
| 2.16.1 | CheckDisplayColumnAttribute | DisplayColumnRemoved              |
| 2.16.2 | CheckDisplayColumnAttribute | DisplayColumnAdded                |
| 2.16.3 | CheckDisplayColumnAttribute | DisplayColumnContentChanged       |
| 2.17.1 | CheckOptionsAttribute       | NamingChanged                     |
| 2.17.4 | CheckOptionsAttribute       | NamingRemoved                     |
| 2.18.1 | CheckNamingFormatTag        | NamingFormatChanged               |
| 2.18.2 | CheckNamingFormatTag        | NamingFormatRemoved               |
| 2.19.1 | CheckDisplayKeyContent      | QACodeBehindChanged               |
| 2.20.1 | CheckTypeTag                | UpdatedValue                      |
| 2.20.2 | CheckTypeTag                | RemovedTag                        |
| 2.20.3 | CheckTypeTag                | AddedTag                          |
| 2.21.2 | CheckOptionsAttribute       | MatrixDimensionsChanged           |
| 2.21.3 | CheckOptionsAttribute       | MatrixDimensionsRemoved           |

### Validator

#### New and updated checks and error messages \[ID_20402\]\[ID_20582\]\[ID_20716\]\[ID_20747\]

The following checks and error messages have been added or updated.

| ID     | Check                     | Error message                  |
|--------|---------------------------|--------------------------------|
| 2.9.2  | Param.CheckUnitsTag       | EmptyTag                       |
| 2.9.3  | Param.CheckUnitsTag       | OutdatedValue                  |
| 2.9.4  | Param.CheckUnitsTag       | InvalidTag                     |
| 2.9.5  | Param.CheckUnitsTag       | UnsupportedTag                 |
| 2.9.6  | Param.CheckUnitsTag       | ExcessiveTag                   |
| 2.10.1 | Param.CheckWidthAttribute | MissingAttribute               |
| 2.10.2 | Param.CheckWidthAttribute | EmptyWidth                     |
| 2.10.3 | Param.CheckWidthAttribute | UntrimmedWidth                 |
| 2.10.4 | Param.CheckWidthAttribute | InvalidWidth                   |
| 2.10.5 | Param.CheckWidthAttribute | InconsistentWidth              |
| 2.10.6 | Param.CheckWidthAttribute | UnsupportedAttribute           |
| 5.1.1  | Trigger.CheckIdAttribute  | MissingAttribute               |
| 5.1.2  | Trigger.CheckIdAttribute  | NotRequiredAttribute           |
| 5.1.3  | Trigger.CheckIdAttribute  | EmptyAttribute                 |
| 5.1.4  | Trigger.CheckIdAttribute  | MultipleIds                    |
| 5.1.5  | Trigger.CheckIdAttribute  | InvalidValue                   |
| 5.1.6  | Trigger.CheckIdAttribute  | NonExistingId                  |
| 5.1.7  | Trigger.CheckIdAttribute  | LeadingZeros                   |
| 5.1.8  | Trigger.CheckIdAttribute  | UntrimmedAttribute             |
| 5.3.1  | Trigger.CheckTimeTag      | MultipleAfterStartup           |
| 5.5.1  | Trigger.CheckConditionTag | ConditionOnTriggerAfterStartup |

The *Param.CheckWidthAttribute* check replaces the legacy Validator return codes 4501 and 4502.

### XML Schema

#### Protocol Schema: Updated element and attribute rules \[ID_20800\]

The syntax rules for the following elements and/or attributes have been updated:

| Element/attribute | Syntax rule |
|-------------------|-------------|
| PingInterval.DefaultValue | \- Range: 1000 - 300,000<br> - Value must be a multiple of 1000. |
| PortSettings.TimeoutTime | Range: 10 - 120,000 |
| PortSettings.TimeoutTimeElement | \- Range: 1000 - 120,000<br> - Value must be a multiple of 1000. |

#### Protocol Schema: New elements and attributes \[ID_20802\]

The Protocol XML schema now supports the following elements and/or element attributes:

| Element                                     | Attribute |
|---------------------------------------------|-----------|
| Protocol.Params.Param.Replication.Element   | dynamic   |
| Protocol.Params.Param.Replication.Parameter | dynamic   |

#### Protocol Schema: Attributes of ArrayOptions element changed/removed \[ID_20975\]\[ID_20976\]

The following changes have been made to attributes of the ArrayOptions element.

| Attribute       | Change                                                                                                                                                                                     |
|-----------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| index           | Type was changed from xs:string to xs:unsignedInteger.                                                                                                                                     |
| displayColumn   | Type was changed from xs:string to xs:unsignedInteger.                                                                                                                                     |
| partial         | Type was changed from xs:string to regex. The regular expression must match either “false” or “true”. “true” can optionally be followed by a semicolon and a number (e.g. “true:200”). |
| processingOrder | Removed. This is an option to be added to the value of the options attribute.                                                                                                              |

#### UOM Schema: New unit added \[ID_20977\]

The following unit has been added to the UOM Schema:

- kWh/d

## Changes

### Enhancements

#### IDE - XML editor: Enhanced analysis rules for QAction projects \[ID_20566\]

A number of enhancements have been made to the default set of analysis rules for QAction projects. These rules can be used by Visual Studio extensions like e.g. SonarLint to analyze the code.

#### IDE - XML editor: When an imported XML/JSON node does not contain any value, a parameter of type ‘string’ is now created \[ID_20674\]

Up to now, when parameters were created by importing XML/JSON code, no parameter was created when a node did not contain a value. From now on, when an XML/JSON node does not contain a value, a parameter of type ‘string’ will be created, and a warning icon will appear next to the node in the XML/JSON source file.

#### IDE - XML editor: Enhanced item linking, additional virtual comments and more information in DIS Tree \[ID_20776\]

A number of improvements have been made with regard to item linking, virtual comments and DIS Tree information.

##### Item linking

Next to certain XML elements or attributes, you will find a “jump to linked items” button in the shape of a paper clip. When you hover over this paper clip, a list box will appear, listing all items that are in some way linked to the element in question. From now on, you will also find a paper clip button next to the following elements or attributes:

| Item                              | Items in “jump to” list                                    |
|-----------------------------------|------------------------------------------------------------|
| Pair.Content.ResponseOnBadCommand | Response referred to in ResponseOnBadCommand element       |
| Param.ArrayOptions@options        | Parameters in ‘options’ attribute                          |
| QAction@dllImport                 | Pre-compiled QActions referred to in ‘dllImport’ attribute |
| Params.Param.Dependencies.Id      | Parameter referred to in ‘Id’ element                      |
| ParameterGroups.Group@dynamicId   | Table parameter referred to in dynamicId attribute         |
| SeverityBubbleUp.Path             | Table parameters referred to in ‘Path’ element             |
| Trigger.On                        | Sessions referred to in ‘On’ element                       |

When you hover over a paper clip icon, the linked items are grouped by category (e.g. *Incoming*, *Outgoing*,...). A new category has now been added: *Conditions*. This new category will group all parameters referred to in the \<Condition> element contained within the element with the paper clip icon.

If, for example, an \<Action> element contains the following \<Condition> element, the *Conditions* section of the linked item list will contain a reference to the parameter used in that condition (in this case the parameter with ID 10).

```xml
<Condition><![CDATA[id:10 == 1]]></Condition>
```

##### Virtual comments

The following elements and/or attributes now also have virtual comments:

- Protocol.Pairs.Pair.Content.ResponseOnBadCommand
- Protocol.ParameterGroups.Group
- Protocol.ParameterGroups.Group.Params.Param
- Protocol.Params.Param.Dependencies.Id

##### More information in DIS Tree tool window

From now on, the DIS Tree will show more information on the following elements:

- Protocol.Ownership
- Protocol.SeverityBubbleUp
- Protocol.VersionHistory

#### Automation script schema: Enhanced ID constraints \[ID_20799\]

Up to now, the Automation script schema contained ID uniqueness constraints for each element type. All those ID constraints have now been replaced by a single constraint that forces an ID in an id attribute to be unique regardless of the type of XML element in which it is used.

Also, the type of the Exe@id attribute has been changed to “xs:positiveInteger”.

#### XML editor: Enhanced 'Title Begin' snippet \[ID_20967\]

The ‘Title Begin’ snippet now contains two placeholders:

- TitleName
- TitleDescription

See the following example:

```xml
<Param id="ID">
  <Name>Title_Begin_TitleName</Name>
  <Description>TitleDescription</Description>
  <Type>fixed</Type>
  <Display>
    <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
    <Type options="begin;connect">title</Type>
  </Measurement>
</Param>
```

#### XML editor: Enhanced import of table parameters when dragging from the DIS MIB Browser tool window \[ID_21021\]

From now on, when you drag a table parameter from the DIS MIB Browser tool window onto a protocol.xml file, the table name will only be added in front of the name of the column parameter when it is not already included in the latter. Also, when the SNMP name of a table contains “Table”, this string will be excluded from column parameters names and descriptions.

This will prevent table names from being included twice in column parameter names.

### Fixes

#### IDE - Grid view: Horizontal scrollbar was missing when grid was empty \[ID_20629\]

When no rows were shown in the *DIS Grid View* tool window, in some cases, the horizontal scrollbar would be missing. As a result, users were unable to adapt filters defined on columns that were not visible.

#### IDE - XML editor: IntelliSense listed session names incorrectly \[ID_20779\]

When adding a new \<Session> element inside a group’s \<Content> element, IntelliSense lists all the sessions you can add to that particular group. Up to now, all listed sessions would incorrectly be named “Session”.

#### IDE - Display editor: Units selection box did not correctly list the units defined in the UOM Schema \[ID_20928\]

When you configured a parameter in the Display editor, in some cases, the *Units* selection box would not correctly list the units defined in the UOM Schema.
