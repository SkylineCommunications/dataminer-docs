---
uid: DIS_2.9
---

# DIS 2.9

## New features

### IDE

#### Automation script editor \[ID_17482\]

DIS can now also be used to create and edit Automation script XML files.

To create a new Automation script XML file, do the following:

1. Open the *File* menu, and select *New \> File ...*
2. Select *DataMiner Automation Script Template*, and click *Open*.

When editing an Automation script, the editor allows you to insert a number of basic snippets, edit the C# code blocks in the script, include DLL files, and add namespace references.

At the top of the editor window, you can find a *Publish* button. Click that button if you want to publish the Automation script XML file you are currently editing to the DMA specified in the *DMA* tab of the *DIS Settings* dialog box.

If, in the *DIS* menu, you select *DMA \> Import Automation Script…*, the *Import Automation Script…* dialog box will allow you to import a copy of an existing Automation script XML file found on the DMA specified in the *DMA* tab of the *DIS Settings* window. In most cases, this will be your local DMA.

#### DIS MIB Browser: SNMP trap information \[ID_17601\]

When, in the DIS MIB Browser tool window, you select an SNMP trap, the information pane at the bottom will now display all available information about that SNMP trap.

Also, the DIS MIB Browser tool window will now display units and value ranges where appropriate.

#### Table editor now supports ColumnOption type ‘viewTableKey’ \[ID_17667\]

The table editor now also supports the ColumnOption type ‘viewTableKey’.

In the *All Columns* section, the selection boxes in the *Type* column now also contain the ‘View Table Key’ value.

#### New snippets \[ID_17713\]\[ID_17854\]

When editing a protocol XML file or an Automation script XML file, you can now insert the following new snippets:

##### Protocol snippets

- Protocol Copyright

##### Automation script snippets

- Automation Root
- Automation Copyright
- Dummy Protocol
- Memory File
- Script Exe
- ScriptParameter

### Validator

#### New ‘DIS Validator’ tool window \[ID_14566\]

Up to now, when you clicked *Validate* in the header of a protocol editor tab, the results of the protocol validation were displayed in the Visual Studio error list. From now on, those results will be displayed in a dedicated *DIS Validator* tool window.

The new *DIS Validator* tool window lists the results of the latest protocol validation in a tree structure, grouped by severity and category.

At the top of the tool window, you can find two buttons:

- Click *Validate* to launch a new protocol validation.
- Click *Export* to export the results of the latest validation to a CSV file.

### XML Schema

#### New tags and attributes \[ID_17649\]\[ID_17650\]\[ID_17651\]\[ID_17653\]\[ID_17657\]\[ID_17661\]\[ID_17663\]

The Protocol XML schema now supports the following tags and/or tag attributes:

| Tag                                             | Attribute          |
|-------------------------------------------------|--------------------|
| Protocol.Display.Pages (and all subtags)        | \-                 |
| Protocol.GeneralParameters (and all subtags)    | \-                 |
| Protocol.Groups.Group.Content.Session           | connection         |
| Protocol.Http.Session                           | keepAlive          |
| Protocol.Http.Session.Connection                | ignoreTimeout      |
| Protocol.Params.Param                           | confirmPopup       |
| Protocol.Params.Param.ArrayOptions              | deleteRow          |
| Protocol.Params.Param.ArrayOptions.ColumnOption | cpeAlignment       |
| Protocol.Params.Param.Dependencies.ID           | postSet            |
| Protocol.Params.Param.Measurement.Type          | scientificNotation |

#### Unit ‘THz’ added to UOM schema \[ID_17658\]

The unit ‘THz’ has now been added to the UOM schema.

#### Protocol.Params.Param.ArrayOptions.ColumnOption: ‘viewTableKey’ type \[ID_17659\]

The Protocol XML schema now supports the ColumnOption type ‘viewTableKey’.

#### Protocol.Actions.Action.Type: ‘reschedule’ value & ‘reschedule’ attribute \[ID_17660\]

The Protocol XML schema now supports both the Action.Type attribute ‘reschedule’ (in combination with Action.Type ‘restart timer’) and the Action.Type value ‘reschedule’.

#### Protocol.Timers.Timer.Time: Maximum timer time is now 24 days \[ID_17662\]

From now on, the protocol XML schema will enforce a maximum timer time of 24 days (2,073,600 seconds).

#### Automation script XML schema \[ID_17702\]

DIS is now able to validate Automation script XML files against an Automation script XML schema.

## Changes

### Enhancements

#### IDE: DIS tool windows now compatible with all built-in Visual Studio themes \[ID_14440\]

The following DIS tool windows are now compatible with all built-in Visual Studio themes:

- DIS Tree
- DIS Mappings
- DIS Inject
- DIS MIB Browser
- DIS Grid
- DIS Validator

#### XSD: ArrayOptions tag no longer has an autoAdd attribute \[ID_17733\]

The *ArrayOptions* tag no longer has an *autoAdd* attribute.

#### IDE: More consistent naming of the DIS tool windows \[ID_17483\]

The names of the DIS tool windows have been made more consistent:

| Old name          | New name        |
|-------------------|-----------------|
| Protocol Tree     | DIS Tree        |
| Protocol Mappings | DIS Mappings    |
| DIS Inject        | DIS Inject      |
| MIB Browser       | DIS MIB Browser |
| Protocol Grid     | DIS Grid        |
| \-                | DIS Validator   |

#### XSD: Protocol.Actions.Action.On tag no longer supports 'action' value \[ID_17654\]

The Protocol.Actions.Action.On tag no longer supports its value to be set to "action".

#### XSD: Protocol.HTTP.Session.Connection.Response.Headers.Header tags no longer accept any content \[ID_17655\]

Protocol.HTTP.Session.Connection.Response.Headers.Header tags no longer accept any content.

#### XSD: Protocol.Groups.Group.Content tags can no longer contain both actions and triggers \[ID_17656\]

Up to now, it was allowed to specify both \<Action> and \<Trigger> tags inside a Protocol.Groups.Group.Content tag. From now on, a Protocol.Groups.Group.Content tag can contain only actions or only triggers. Mixing actions and triggers is no longer allowed.

#### XSD: General review of the schema file \[ID_17663\]

The Protocol XML schema file has been reviewed.

##### Tag changes

| Tag                                                          | Change                                                           |
|--------------------------------------------------------------|------------------------------------------------------------------|
| Protocol.DeviceOID                                           | Type changed from xs:string to xs:unsignedInt                    |
| Protocol.Http.Session.Connection.Request                     | This tag can no longer contain both a Parameters and a Data tag. |
| Protocol.Http.Session.Connection.Response.Headers.Header | pid attribute is now required                                    |
| Protocol.Params.Param.ArrayOptions.ColumnOption          | pid, idx and type attributes are now required                    |
| Protocol.Params.Param.Snmp.Oid                               | type attribute now also accepts “auto” and “composed”            |
| Protocol.Params.Param.Snmp.Type                              | Additional type: “Counter64String”                           |
| Protocol.PortSettings.Ipport.DefaultValue                    | Type changed from xs:string to TypePortNumber                    |
| Protocol.PortSettings.LocalIPPort.DefaultValue               | Type changed from xs:string to TypePortNumber                    |
| Protocol.Timers.Timer                                        | id attribute is now required                                     |

##### ENUM changes

| ENUM                 | Change                                            |
|----------------------|---------------------------------------------------|
| EnumColumnOptionType | “element”, “linkelement” and “setontable” removed |
| EnumHttpLoginMethod  | “https” removed                                   |
| EnumParamCRCType     | “codan” added                                     |

##### Other changes

- Parameter IDs can no longer start with “0”.
- A number of parameter ID ranges have been updated.
- xs:documentation tags were added/updated where needed.

### Fixes

#### IDE - Protocol editor: Problem with ‘Add New Column’ option in shortcut menu of \<Param> tag \[ID_17720\]

When you opened the shortcut menu in front of a \<Param> tag of the table parameter, and selected *Add New Column*, in some cases, you needed to click inside the proposed text string before you were able to type. This problem has now been fixed.
