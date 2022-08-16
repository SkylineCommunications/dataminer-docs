---
uid: DIS_2.32
---

# DIS 2.32

## New features

### IDE

#### Version Editor: Adding references to minor versions \[ID_28829\]

In the *Current version* tab and after selecting a minor version in the *All versions* tab, it is now possible to add a list of references.

You can add two types of references:

- Task references, i.e. references to DataMiner Collaboration tasks, and
- Generic references, i.e. references to other information (e.g. a ticket in a third-party ticketing system).

To add a reference to a DataMiner Collaboration task, do the following:

1. On the right, above the list, click *Add*.
2. In the *Type* column, select “Task Id”.
3. In the *Reference* column, add the (numeric) ID of the Collaboration task.

To add a generic reference, do the following:

1. On the right, above the list, click *Add*.
2. In the *Type* column, select “Reference”.
3. In the *Reference* column, add the ID, address, etc. of the information to which you want to refer.
4. In the *Reference type* column, add the type of information to which you referred in the *Reference* column. For example, if *Reference* contains an ID of a Jira ticket, you could set *Reference type* to “Jira”.

To go to the information referred to by a reference, do the following:

- Click the *Link* button.

To remove a reference, do the following:

- Click the *Remove* button

> [!NOTE]
> In the *Interface* tab of the *DIS Settings* window, you can define the URL format of the two types of references in the following fields:
>
> - *Task URL String Format*
> - *Reference URL String Format*
>
> In both values, you can use the “{ref}” placeholder. When, in the version editor, you click the link button of a particular reference, that placeholder will then be replaced by the contents of the *Reference* column.

#### 'Copy File Content to Clipboard' renamed to 'Copy Code to Clipboard' \[ID_28860\]

The right-click menu option *Copy File Content to Clipboard* has been renamed to *Copy Code to Clipboard*.

Also, from now on, when you use this menu option while working with a protocol solution or an Automation script solution, you will not only copy the current file to the Windows Clipboard, but all files of the entire project combined in a way that is similar to the way in which they are combined when the solution is compiled.

#### Microsoft Azure B2C authentication \[ID_28959\]

DIS now uses Azure B2C authentication. This means, that users will now have to provide their dataminer.services account to sign in to DIS or to have DIS check for updates.

In the *DIS Settings* window, the *DCP* tab has been replaced by the following tabs:

- **Account**:

  - Shows the name of the user who is currently signed in.
  - Has a *Sign out* button that allows you to sign out (and sign in again).
  - Shows the current license status.

- **Updates**:

  - If you select the *Check for plug-in updates* option, DIS will check once every hour whether a more recent version of the DataMinerIntegrationStudio.vsix extension file is available. If so, an update banner will appear at the top of the editor window.
  - If you select the *Get insider builds* option, DIS will not only check for main updates, but also for “insider” updates, i.e. pre-release versions for testing purposes.

> [!NOTE]
> Users who upgrade to DIS version 2.32 will be asked to log in with their dataminer.services account.

#### Debugging of precompiled Automation script EXE blocks \[ID_29030\]

When DIS is connected to a DataMiner Agent running DataMiner version 10.1.3 or higher, it is now also possible to debug precompiled Automation script EXE blocks.

#### Automation script solutions: DataMiner DLL Path property \[ID_29031\]

DLL files in an Automation script solution now have a “DataMiner DLL Path” property. This property can be used to override/specify the location (i.e. full path) of the DLL file on the DataMiner Agent.

> [!NOTE]
> If you leave this property empty, the DLL file will be placed in the default folder (C:\\Skyline DataMiner\\ProtocolScripts).

### Validator

#### New checks and error messages \[ID_28593\]

The following checks and error messages have been added.

| Check ID | Error message name | Error message                                                                                                             |
|----------|--------------------|---------------------------------------------------------------------------------------------------------------------------|
| 1.22.10  | MissingPage_Sub    | Param with ID '{pid}' is positioned on page '{pageName}' which is not ordered via 'Protocol/Display@pageOrder' attribute. |

### XML Schema

#### UOM Schema: New units added \[ID_28592\]\[ID_28926\]

The following units have been added to the UOM Schema:

- Cycles
- Hz/s
- Services

#### Protocol Schema: Miscellaneous updates \[ID_28602\]\[ID_28606\]

The Protocol XML schema has been updated.

- Up to now, the Protocol Schema dictated that the Value and Display subelements of a Discreet element should both have a unique value. However, when using the dependency-Values attribute, it is possible that, in a protocol XML file, duplicate values are defined in Value and Display subelements. Therefore, the unique constraint definitions for the Discreet.Display and Discreet.Value elements have now been updated in order to prevent Schema violations in these kind of situations.
- The type of the MinimumRequiredVersion and MaximumSupportedVersion elements has been updated to a union of a string and a enum listing all the released DataMiner versions. Also, the Protocol Schema will now expect the build number to be mandatory.

#### Protocol Schema: Icons added to EnumIcons \[ID_28845\]

The following icons have been added to the EnumIcons enum:

- LED-Blue
- LED-Cyan
- LED-Lime
- LED-Red
- LED-Silver
- LED-Yellow
- New-Item
- Trash

### Class Library

#### Creating, updating and retrieving HTTP connections of elements \[ID_29070\]

IDms classes now support creating, updating and retrieving HTTP connections of elements.

#### Retrieving CI type information from connections \[ID_29071\]

In IDP environments, extension methods now allow you to retrieve CI type information from connections.

#### Creating and deleting properties in a DataMiner System \[ID_29072\]

IDms classes now support creating and deleting properties in a DataMiner System.

#### New SLNet wrapper methods to communicate with SLScheduler and SLSpectrum \[ID_29074\]

SLNet wrapper methods now allow you to safely communicate with the SLScheduler and SLSpectrum modules. Up to now, Scheduler and Spectrum Interop classes had to be used to communicate with those modules.

## Changes

### Enhancements

#### Version Editor: Various enhancements \[ID_28604\]

A number of enhancements have been made to the version editor.

##### Current Version tab and All Versions tab

- On the *Current Version* tab and the *All Versions* tab, the *Based On* selection box no longer contains the current version. Also, when editing version 1.0.0.1, the *Based On* selection box is now disabled.
- On the *Current Version* tab and the *All Versions* tab, the label “Modified date” has now been replaced by “Date”, and the date selector button has been right-aligned.
- On the *Current Version* tab and the *All Versions* tab, all four parts of a version number (branch, system, major and minor) are now editable. When you change one of those four numbers of a particular version, its entire version tree will be adapted.

##### Current Version tab

- On the *Current Version* tab, you can now click *Go to this version in All Versions tree* to open the *All Versions* tab and select the current version in the version tree.

##### All Versions tab

- When, on the *All Versions* tab, you select a version that is not the current version, then you can click the *Set this version as current* button to make that version the current version. Also, in the version tree on the left, you can right-click a version and select *Set as current version*.
- In the tree view on the *All Versions* tab, the current version and all its parent versions are now marked in bold.
- When, In the *All Versions* tab, you add a minor version, this new version will now automatically inherit all data from the current version and become itself the new current version.
- If, on the *All Versions* tab, you add a requirement to a system version, you can optionally specify a minimum and a maximum version. Up to now, when you did not specify a minimum or a maximum version, in the protocol XML file, an empty min or max attribute was added to the Version element in question. From now on, when you do not specify a minimum or a maximum version, no min or max attribute will be added.
- On the *All Versions* tab, when you select a version in the version tree, that version is highlighted. Up to now, in some cases, when you right-clicked a version other than the one that was highlighted, the version you right-clicked would incorrectly not get highlighted.

##### Other changes

- When, in the protocol XML, you had changed the system version or major version number of the version specified in the Protocol.Version element to a system or major version that did not exist in the Protocol.VersionHistory element tree, in some cases, an exception could be thrown when you opened the version editor. From now on, the version you specified in the protocol XML file will be added to the Protocol.VersionHistory element tree and set as the new current version. Also, the entire tree will be adapted where needed.
- In all text boxes of the version editor, it is now possible to copy/paste text.

#### Enhanced validation of IDs and references \[ID_28655\]

The Validator now fully validates the id attribute of the following items:

- Action
- Command
- Group
- HTTP Connection
- HTTP Session
- Pair
- Param
- ParameterGroup
- QAction
- Response
- Timer
- Trigger

In case of problems regarding IDs, the following error messages can be returned:

- DuplicateId
- EmptyAttribute
- InvalidValue
- MissingAttribute
- UntrimmedAttribute

Also, the Validator now validates referring IDs specified in the following items:

- Action.On@id
- Pair.Content.Command
- Pair.Content.Response
- Pair.Content.ResponseOnBadCommand
- Trigger.Content.Id

In case of problems regarding those referring IDs, the following error messages can be returned:

- Empty
- Invalid
- Missing
- NonExisting
- Untrimmed

### Fixes

#### Validator: False positive MissingPage error while validating a Protocol.Display@pageOrder attribute in a protocol that generates DVE elements \[ID_28593\]

While validating a Protocol.Display@pageOrder attribute in a protocol that generates DVE elements, in some cases, a false positive MissingPage (1.22.5) error could be thrown.

> [!NOTE]
> When a MissingPage (1.22.5) error is thrown, from now on, an additional MissingPage_Sub (1.22.10) error will list the parameter(s) responsible.
>
> See also [New checks and error messages \[ID_28593\]](#new-checks-and-error-messages-id_28593).

#### IDE: Problem caused by removing header options of view table columns \[ID_28724\]

When a table column is not monitored, by default, DIS automatically removes all header options specified for that column (e.g. histogram, heatmap, average, sum, etc.). However, in some cases, this could cause problems, especially in case of view table columns.

From now on, DIS will no longer automatically remove header options specified for view table columns.

#### IDE - Table Editor: A Measurement element with an incorrectly set 'lines' option would be added to a table without a Measurement element \[ID_28844\]

When, in the table editor, you opened a table that did not have a Measurement element, DIS would add a Measurement element with the “lines” option incorrectly set to 0 instead of 20.

When, afterwards, you opened that table in DataMiner Cube, an error could occur.

#### IDE: Problem when debugging referenced precompiled QActions \[ID_28849\]

In some cases, it would no longer be possible to debug referenced precompiled QActions.
