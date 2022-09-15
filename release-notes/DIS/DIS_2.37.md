---
uid: DIS_2.37
---

# DIS 2.37

## New features

### IDE

#### Function editor: Enhanced linking of profile definitions to functions and function interfaces \[ID_32633\]

When, in the Function editor, you wanted to link a profile definition to a function, up to now, you had to fetch the profiles.xml file from the DataMiner Agent and open it next to the function.xml file in Visual Studio. From now on, when editing a function or one of its interfaces in the Function editor, you will be able to select a profile definition from a selection box listing all profile definitions found on the connected DataMiner Agent.

#### DIS now partially supports the use of NuGet packages in protocols and Automation scripts \[ID_32962\]

DIS now partially supports the use of NuGet packages in protocols and Automation scripts.

- Apart from saving the protocol.xml file, the *File \> Save Compiled Protocol As…* command will now also extract the necessary DLL files from the configured/used NuGet packages and place them in a DLLs folder.

- Apart from saving the automation.xml file, the *File \> Save (All) Compiled Script As…* command will now also extract the necessary DLL files from the configured/used NuGet packages and place them in a DLLs folder.

Currently, the “Publish” command will only publish the XML file, not the NuGet DLL files.

#### DIS Comparer tool window: Comparison will now start automatically after selecting both protocols \[ID_33045\]

Up to now, in the *DIS Comparer* tool window, you had to click the *Compare* button after selecting the two protocols you wanted to compare. From now on, the comparison will start automatically after you selected the two protocols to be compared.

### Validator

#### New checks and error messages \[ID_32528\] \[ID_32529\]

The following checks and error messages have been added.

| Check ID | Error message name  | Error message                                                                                 |
|----------|---------------------|-----------------------------------------------------------------------------------------------|
| 1.25.6   | MinVersionIncreased | Minimum DataMiner required version increased from '{oldMinDmVersion}' to '{newMinDmVersion}'. |

### XML Schema

#### TypeDataMinerVersion now also allows 5-digit build numbers \[ID_32682\]

The type “TypeDataMinerVersion”, which is used by the following elements, now also allows 5-digit build numbers (e.g. 10.1.0.0 - 10600).

- Compliancies.MinimumRequiredDataMinerVersion
- Compliancies.MaximumSupportedVersion

#### Protocol Schema: New element \[ID_32739\]

The following element has been added to the protocol schema:

- Protocol.Params.Param.Database.Connection.Type

## Changes

### Enhancements

#### IDE: Custom-made information bars replaced by standard Visual Studio information bars \[ID_32483\]

In the UI, the following custom-made information bars have now been replaced by standard Visual Studio information bars:

- Class Library package contains errors
- DIS update available
- Incorrect BOM or XML header
- Incorrect project references
- Incorrect target framework

#### IDE: StyleCop plugin for Visual Studio replaced by StyleCop.Analyzers NuGet package \[ID_32508\]

From now on, DIS will use the StyleCop.Analyzers NuGet package instead of the StyleCop plugin for Visual Studio.

When DIS detects that a solution needs to be updated, a banner will be displayed, asking to update the solution. During the update, the StyleCop.Analyzers NuGet package will be added to all C# projects, except helper and library projects. After the update, the new StyleCop analyzers will use the stylecop.json file instead of the Settings.StyleCop file.

#### Derived classes now included in generated Class Library code \[ID_32770\]

Derived classes are now also included in generated Class Library code.

### Fixes

#### IDE - Function editor: Removing a table from a page did not remove the column parameters from the function file \[ID_33099\]

When, in the Function editor, you removed a table from a page, the column parameters would incorrectly not be removed from the function file. From now on, when you remove a table from a page, the table parameter as well as the column parameters will be removed from the function file.

#### Text of connection errors in DMA connection window would incorrectly be cut off

When, in an *Edit DMA connection* window, an error occurred when you clicked the *Test connection* button, in some cases, the text of the error message would incorrectly be cut off. From now, long error messages will automatically wrap to the next line.
