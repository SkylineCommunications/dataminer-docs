---
uid: DIS_2.31
---

# DIS 2.31

## New features

### IDE

#### Automation script debugging \[ID_28062\]

From now on, you can also use the DIS Inject tool window to debug Automation scripts.

To debug an Automation script, do the following:

1. In the *DIS* menu, go to *DMA \> Connect*, and select the DataMiner Agent to which you want DIS to connect.
1. Import the Automation script. In the *DIS* menu, select *DMA \> Import Automation script*, select an Automation script, and click *Import*.
1. In the XML editor, go to the Exe block that you want to debug, and click the *Edit C#* button in front of it to open the Exe block in a C# editor.
1. In the C# editor, set the necessary breakpoints.
1. In the *DIS* menu, select *Tool Windows \> DIS Inject* to open the DIS Inject window.
1. Select the *Automation script* tab.
1. Open the large selection box at the top of the window, and select the Automation script that you want to debug.
1. In the *Exe blocks* list:

   - Go to the row of which the Exe ID matches that of the Exe block you have opened.
   - If necessary, in the *Project* column, select another temporary Exe block project.

1. In the *Script parameters* list, assign a value to each of the script parameters in the list.
1. In the *Script dummies* list, link a DataMiner element to each of the script dummies in the list.
1. Click the *Attach* button to build all temporary Exe block projects and attach the Microsoft Visual Studio Debugger to the DataMiner SLAutomation process.
1. In the *DIS Inject* window, click *Execute* to manually trigger the Automation script.

> [!NOTE]
>
> - Automation script debugging only works in conjunction with DataMiner Agents running at least DataMiner Main Release Version 10.1.0 or Feature Release Version 10.0.6.
> - Automation script debugging currently does not yet support memory files and precompiled Exe blocks.

#### Solution-based Automation script development \[ID_28231\]

Similar to protocols, it is now also possible to develop Automation scripts as Visual Studio solutions. However, an Automation script solution can contain multiple scripts, while a protocol solution can only contain one single protocol.

- C# projects that contain the code for the Exe blocks of an Automation script can contain multiple .cs files. At compilation, the contents of those files will be combined into one Exe block.
- DLL imports need to be configured on the C# project itself by adding references to the external components. These can be external DLL files (located in C:\\DataMiner\\ProtocolScripts or C:\\DataMiner\\Files) or other scripts in the same solution.

##### Creating an Automation Script solution

To create a new Automation script solution containing one dummy Automation script, do the following:

1. Select *File \> New \> DataMiner Automation Script Solution...*
2. Enter the name of the solution.
3. Select the target folder.

    > [!NOTE]
    > The default protocol solution folder and the default Automation script folder can both be specified in *DIS Settings \> Solutions*.

4. Select *Create initial Automation script* if you want to solution to contain a basic script with one Exe block.
5. Click *OK*.

> [!NOTE]
> If another solution is open when you perform step 1, you will be asked whether you want to save unsaved changes.

##### Creating a new script in a solution

To create a new script in an Automation script solution, do the following:

1. Open the Automation script solution.
2. Select *File \> New \> New DataMiner Automation Script...* or right-click a solution folder in the Solution Explorer and select *Add \> New DataMiner Automation Script...*
3. Enter the name of the new script.
4. Click *OK*.

##### Adding an existing script to a solution

To add an existing Automation script to an Automation script solution, do the following:

1. Right-click a solution folder in the Solution Explorer.
2. Select *Add \> Existing DataMiner Automation Script*.
3. Select a least one Automation script file.
4. Click *Open*.

> [!NOTE]
> When you add existing scripts to an Automation script solution, they are automatically converted to the correct format. For each Exe block, a C# project is created, and the code in that Exe block is transferred to the newly created C# project.

##### Saving a compiled script

To save a compiled version of an Automation script to a file (with all C# code in its Exe block), do the following:

1. Open the XML file containing the Automation script that you want to compile.
2. Select *File \> Save Compiled Automation Script...*
3. Enter a file name and a folder.
4. Click *Save*.

##### Uploading a script to a DataMiner Agent

To upload an Automation script to a DataMiner Agent, do the following:

1. Open the XML file containing the Automation script.
2. Click *Publish* to compile the script and publish it to the DataMiner Agent that was set as default DMA in the *DMA* tab of the *DIS Settings* dialog box.

> [!NOTE]
> If you want to publish the script to another, non-default DMA, click the drop-down button at the right of the *Publish* button, and click the DMA to which you want the file to be published.

### Validator

#### New checks and error messages \[ID_28368\]\[ID_28490\]\[ID_28497\]\[ID_28500\]\[ID_28502\]

The following checks and error messages have been added.

| Check ID | Error message name               | Error message                                                                                                                        |
|----------|----------------------------------|--------------------------------------------------------------------------------------------------------------------------------------|
| 2.5.1    | MissingDefaultThreshold          | Missing default thresholds on monitored parameter. Param ID '{pid}'.                                                                 |
| 2.25.2   | UpdatedIdxValue_Parent           | Some columns have their SLProtocol position changed. Table PID '{tablePid}'.                                                         |
| 4.2.5    | ObsoleteSuffixTable              | Suffix 'table' in 'Group/Content/Param' element is considered obsolete. Group ID '{groupId}'.                                        |
| 4.2.6    | SuffixRequiresMultiThreadedTimer | Suffix '{suffix}' in'Group/Content/Param' element requires the group to be called from a multi-threaded timer. Group ID '{groupId}'. |
| 16.5.3   | IncompatibleParamReferences      | Incompatible links to parameters via 'Group@dynamicId' attribute and 'Group/Params' element. ParameterGroup ID '{parameterGroupId}'. |
| 16.8.1   | MissingDynamicIdAttribute        | Filtering via 'Group@dynamicIndex' attribute requires a 'Group@dynamicId' attribute. ParameterGroup ID '{parameterGroupId}'.         |
| 18.10.9  | IrrelevantColumn                 | Irrelevant column with PID '{columnPid}' in 'TreeControl/HiddenColumns'. TreeControl ID '{treeControlId}'.                           |
| 18.11.11 | IrrelevantColumn                 | Irrelevant column with PID '{columnPid}' in 'TreeControl/OverrideDisplayColumns'. TreeControl ID '{treeControlId}'.                  |
| 18.12.11 | IrrelevantColumn                 | Irrelevant column with PID '{columnPid}' in 'TreeControl/OverrideIconColumns'. TreeControl ID '{treeControlId}'.                     |
| 18.13.9  | IrrelevantColumn                 | Irrelevant column with PID '{columnPid}' in 'TreeControl/ReadonlyColumns'. TreeControl ID '{treeControlId}'.                         |

### XML Schema

#### Protocol Schema: Miscellaneous updates \[ID_28396\]\[ID_28399\]\[ID_28465\]

The Protocol XML schema has been updated.

- The Protocol.Display.Pages.Page.Visibility@default attribute is now a required attribute.
- The Protocol.Triggers.Trigger.Time element now allows any content of type “string”.
- The Protocol.ElementType element has been updated from a string to a union of a string and an enum listing all the known element types.

#### UOM Schema: New unit added \[ID_28402\]

The following unit have been added to the UOM Schema:

- Hops

## Changes

### Enhancements

#### Validator: Endless loop check will now also indicate whether actions of type 'aggregate' are likely to cause endless loops \[ID_27640\]

From now on, the endless loop check will also indicate whether actions of type “aggregate” are likely to cause endless loops.

#### Validator: Enhancements \[ID_28322\]

The following checks and error messages have been enhanced:

- Error message 1.23.1 (MismatchingNames) now reads “Connection {connectionId} has mismatching names: {names}.”
- Check 5.7 (CheckAfterStartupFlow) will now also allow the action types “execute one now” and “execute one top” next to “execute” and “execute next”.
- Check 7.3 (CheckOptionsAttribute) has been refactored.
- Error message 8.3.1 renamed from “InvalidHeaderKey” to “UnknownHeaderKey”,

#### IDE - 'DIS Validator' window: After having an error fixed, the next error in the list will get selected instead of the first error in the list \[ID_28418\]

In the DIS Validator window, when you had an error automatically fixed (e.g. by right-clicking the error and selecting Fix \> This error), up to now, the first error in the list would get selected. From now on, after having an error automatically fixed, the next error in the list will now get selected instead.

#### Validator: Grouping of error messages \[ID_28432\]

From now on, when the validator throws a series of the following errors, they will be grouped in subResults.

| Check ID | Error message name | Error message                                                                             |
|----------|--------------------|-------------------------------------------------------------------------------------------|
| 2.2.7    | UnrecommendedChars | Unrecommended chars '{invalidCharacters}' in tag '{tagName}'. Current value '{tagValue}'. |
| 2.4.1    | MissingTag         | Missing tag 'Subtext' in Param '{pid}'.                                                   |
| 2.9.7    | MissingTag         | Missing 'Units' tag for '{paramDisplayType}' Param with ID '{paramPid}'.                  |
| 2.11.1   | MissingTag         | Missing 'Range' tag for '{paramDisplayType}' Param with ID '{paramPid}'.                  |

### Fixes

#### Validator: False positives when the values of a newly added exception were outside the range of possible parameter values \[ID_28273\]

Up to now, the validator would incorrectly throw an error when the values of a newly added exception were outside the range of possible parameter values.

#### Validator: Incorrect suggestion to replace a write parameter of type discrete by a toggle button \[ID_28367\]

Up to now, when the validator found a write parameter of type discrete with only two discrete values, in some cases, it would suggest replacing the parameter by a toggle button even when the write parameter in question did not have a corresponding read parameter.

#### Validator: False positives when Group.Content.Param elements contained parameter ID suffixes \[ID_28368\]

Up to now, in some cases, the validator would incorrectly throw an InvalidParamTag error when a Group.Content.Param element contained a parameter ID suffix.

See also: [New checks and error messages \[ID_28368\]\[ID_28490\]\[ID_28497\]\[ID_28500\]\[ID_28502\]](#new-checks-and-error-messages-id_28368id_28490id_28497id_28500id_28502)

#### Validator: False positives when connection IDs other than 0 were specified in Pair@options attributes \[ID_28430\]

Up to now, the validator would incorrectly throw an error when an connection ID other than 0 was specified in the Pair@options attribute.

#### Validator: False positives when partialSNMP was used in Param.SNMP.OID@options attributes \[ID_28431\]

Up to now, the validator would incorrectly throw an error when partialSNMP was used in a Param.SNMP.OID@options attribute.

#### Validator: DuplicateValue error (2.2.6) would not always be returned \[ID_28454\]

When, after checking parameter names, the validator returned an UnrecommendedChars (2.2.7) error or an UnrecommendedStartChars (2.2.8) error, in some cases, it would not be able to also return a DuplicatedValue (2.2.6) error.

From now on, the validator will be able to return any of those errors independently from each other.

#### Validator: MissingTableNameAsPrefix errors would incorrectly only be returned for read columns \[ID_28455\]

Up to now, the validator would incorrectly only return MissingTableNameAsPrefix (2.53.2) errors for read columns, not for write columns.

Also, it would propose an automatic fix that would only fix the read column, which would cause the write column to stop working as, after the fix, the read and write columns would have different names.

#### Validator: False positives when indices of display key columns were changed \[ID_28490\]

Up to now, the validator would incorrectly throw an UpdatedIdxValue error (2.25.1) when the index of a display key column had been changed.

Also, UpdatedIdxValue errors (2.25.1) will now be grouped by table via the new UpdatedIdxValue_Parent error (2.25.2)

See also: [New checks and error messages \[ID_28368\]\[ID_28490\]\[ID_28497\]\[ID_28500\]\[ID_28502\]](#new-checks-and-error-messages-id_28368id_28490id_28497id_28500id_28502)

#### Validator: False positives when using ParameterGroups.Group.Params.Param \[ID_28497\]

Up to now, when ParameterGroups.Group.Params.Param was used to link DCF groups to parameters, the validator would incorrectly throw an error stating that dynamicId could not be used with Param tags, even though dynamicId was not used.

Also, when neither Group@dynamicId nor Group.Params were used, the validator would throw an error in spite of this being allowed in order to create standalone DCF interfaces.

See also: [New checks and error messages \[ID_28368\]\[ID_28490\]\[ID_28497\]\[ID_28500\]\[ID_28502\]](#new-checks-and-error-messages-id_28368id_28490id_28497id_28500id_28502)

#### Validator: Generic MissingDefaultThreshold error did not allow users to pinpoint the parameters that did not have default thresholds defined \[ID_28500\]

Up to now, the validator would throw the generic legacy error 1401 when monitored parameters did not have default threshold defined.

As this error did not allow users to pinpoint the parameters in question, this error has now been replaced by error 2.5.1 (MissingDefaultThreshold), which will be thrown each time a monitored parameter does not have default threshold defined.

See also: [New checks and error messages \[ID_28368\]\[ID_28490\]\[ID_28497\]\[ID_28500\]\[ID_28502\]](#new-checks-and-error-messages-id_28368id_28490id_28497id_28500id_28502)

#### Validator: False positives when tree control elements referred to view table columns \[ID_28502\]

Up to now, the validator would incorrectly throw an InvalidValueInTag error when the OverrideDisplay-Columns or OverrideIconColumns element of a tree control referred to view table columns.

See also: [New checks and error messages \[ID_28368\]\[ID_28490\]\[ID_28497\]\[ID_28500\]\[ID_28502\]](#new-checks-and-error-messages-id_28368id_28490id_28497id_28500id_28502)

#### Validator: False positives on return options of aggregate actions were provided a comma-separated list of parameter IDs instead of a single parameter ID \[ID_28506\]

Up to now, the validator would incorrectly throw an error when a comma-separated list of parameter IDs were provided to the return option of an aggregate action.

From now on, this option will support a single parameter ID as well as a comma-separated list of parameter IDs.
