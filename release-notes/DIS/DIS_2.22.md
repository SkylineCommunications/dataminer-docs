---
uid: DIS_2.22
---

# DIS 2.22

## New features

### IDE

#### DIS MIB Browser: Obsolete or deprecated MIB nodes will now be indicated by a special icon \[ID_23348\]

In the *DIS MIB Browser* tool window, obsolete or deprecated MIB nodes will now be indicated by a special icon.

Also, obsolete or deprecated MIB nodes will no longer be imported when you generate parameters based on MIB data.

#### Function editor \[ID_23365\]

When you open a protocol XML file as well as its associated function XML file, in the file tab of the latter, you can now click the *Function editor* button to turn the XML editor you are working in into a graphical function interface editor.

Using this new function editor, you can

- manage the functions defined in the function XML file you are editing, and
- design function pages using simple drag-and-drop operations.

When you click *Publish*, the function XML file you are currently editing will be published to the DMA that was set as default DMA in the *DMA* tab of the *DIS Settings* dialog box. To publish a function XML file to another, non-default DMA, click the drop-down button at the right of the *Publish* button, and click the DMA to which you want the file to be published.

### XML Schema

#### UOM Schema: New units added \[ID_23438\]

The following units have been added to the UOM Schema:

- ps/nm (picosecond per nanometer)
- ps/(nm.km) (picosecond per nanometer per kilometer)
- slots/frame (slots per frame)

## Changes

### Enhancements

#### IDE: Macros now stored in %ProgramData% instead of %LocalAppData% \[ID_23423\]

Up to now, all DIS macros were stored in a subfolder of the *%LocalAppData%* folder. As this folder is removed each time you repair Microsoft Visual Studio, from now on, all DIS macros will be stored in a subfolder of the *%ProgramData%* folder instead.

Former macro folder:

- *%LocalAppData%\\Microsoft\\VisualStudio\\\<Visual Studio version>\\Skyline\\DataMinerIntegrationStudio\\Macros\\*

New macro folder:

- *%ProgramData%\\Skyline Communications\\DataMinerIntegrationStudio\\Macros\\*

> [!NOTE]
> The first time you start DIS v.2.22, all macros in the old folder will automatically be copied to the new folder.

#### Class Library QAction will now be skipped when performing a code analysis \[ID_23528\]

DIS defines a default set of analysis rules for QAction projects. These rules, which can be used by Visual Studio extensions like e.g. SonarLint or StyleCop to analyze the code, have now been adapted so that the code in the automatically generated Class Library QAction (ID 63000) will be skipped when performing a code analysis.

### Fixes

#### IDE: Problem with 'Automatically generate Class Library code' setting \[ID_23527\]

When, in *DIS Settings \> Class Library*, you had selected the *Automatically generate Class Library code* checkbox, in some cases, the Class Library code would only be regenerated after other code in the protocol was changed.

#### Validator: Checks verifying parameter IDs in enhanced service protocols and SLA protocols would return false positives \[ID_23542\]

When validating an enhanced service protocol or an SLA protocol, DIS will check whether any custom parameters were incorrectly added within the parameter range reserved for predefined parameters.

- If, in an enhanced service protocol, custom parameters are found in reserved range 1-999, DIS will throw an “Invalid use of Enhanced Service ID range for Param with ID '{paramId}'.” error (ID 2.1.9).
- If, in an SLA protocol, custom parameters are found in reserved range 1-2999, DIS will throw an “Invalid use of SLA ID range for Param with ID '{paramId}'.” error (ID 2.1.10).

In some cases, those checks would return false positives.
