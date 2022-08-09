---
uid: DIS_2.23
---

# DIS 2.23

## New features

### IDE

#### File editors: New menu command ‘Copy File Content to Clipboard’ \[ID_23663\]

When you right-click in the XML editor or the C# editor, you can now use the new *Copy File Content to Clipboard* command to copy the entire content of the file you are editing to the Windows clipboard, without needing to select all text first.

Also, from now on, DIS menu items that are not available will no longer appear grayed out. They will now be hidden instead.

> [!NOTE]
> The *Copy File Content to Clipboard* command is not available when you are editing a Protocol.xml file. To copy the content of a protocol file, use the *Copy Protocol to Clipboard* command instead.

#### DIS Macros: New example macro ‘Basic UI’ \[ID_23667\]

In the *DIS Macros* tool window, a new ‘Basic UI’ example macro can now be found in the *DIS Macros \> Examples* folder.

This macro shows you how to create a basic user interface using WPF code.

#### DIS now supports C# version 6 and above \[ID_23745\]

Up to now, DIS only supported C# version 4. From now on, it also supports C# version 6 and above.

When you open a Protocol.xml file of which the DMA version specified in the *Protocol.Compliancies.MinimumRequired* tag is equal to or higher than “9.6.11”, DIS will now set the language version of the C# projects to one of the following versions:

- C# 6.0 (when using Visual Studio 2015)
- C# 7.3 (when using Visual Studio 2017 or above)

> [!NOTE]
> When no minimum required DMA version is specified in the protocol, then by default DIS will set the language version of the C# projects to 4.0.

#### ‘Check for updates...’ command in DIS menu \[ID_23883\]

The *Check for updates...* command has now been moved from the *Settings* window to the DIS menu.

Also, in the *Info* tab page of the *Settings* window, you can now click *Release notes...* to open the release notes document of the DIS version you are using.

#### DIS Settings - Class Library: New ‘Enable Class Library feature’ option \[ID_23791\]

In the *Class Library* tab page of the *DIS Settings* window, it is now possible to either enable or disable the Class Library feature.

#### Table Editor: Table columns can now be deleted by pressing the DELETE key \[ID_23957\]

When configuring a table in the table editor, it is now possible to delete columns by pressing the DELETE key.

To delete one or more columns from a table, do the following:

1. In the *All Columns* section, select the column(s) you want to delete.
2. In the confirmation box, click *Yes*.

### Validator

#### New and updated checks and error messages \[ID_23509\]

The following checks and error messages have been added or updated.

| ID       | Check                          | Error message                                                                                                                  |
|----------|--------------------------------|--------------------------------------------------------------------------------------------------------------------------------|
| 18.1.1   | CheckParameterIdAttribute      | Missing attribute 'TreeControl@parameterId'.                                                                                   |
| 18.1.2   | CheckParameterIdAttribute      | Empty attribute 'TreeControl@parameterId'.                                                                                     |
| 18.1.3   | CheckParameterIdAttribute      | Untrimmed attribute 'TreeControl@parameterId'. Current value '{currentValue}'.                                                 |
| 18.1.4   | CheckParameterIdAttribute      | Invalid value '{invalidValue}' in attribute 'TreeControl@parameterId'.                                                         |
| 18.1.5   | CheckParameterIdAttribute      | Attribute 'TreeControl@parameterId' references a non-existing 'Param' with ID '{paramId}'.                                     |
| 18.2.1   | CheckPathAttribute             | Empty attribute 'Hierarchy@path' in TreeControl '{treeControlPid}'.                                                            |
| 18.2.2   | CheckPathAttribute             | Untrimmed attribute 'Hierarchy@path' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.                      |
| 18.2.3   | CheckPathAttribute             | Invalid value '{pathValue}' in attribute 'Hierarchy@path'. TreeControl ID '{treeControlPid}'.                                  |
| 18.2.4   | CheckPathAttribute             | Attribute 'Hierarchy@path' references non-existing IDs. TreeControl ID '{treeControlPid}'.                                     |
| 18.2.5   | CheckPathAttribute             | Attribute 'Hierarchy@path' references a non-existing 'Table' with PID '{paramId}'. TreeControl ID '{treeControlPid}'.          |
| 18.2.6   | CheckPathAttribute             | Duplicate ID '{duplicateId}' in 'Hierarchy@path'. TreeControl ID '{treeControlPid}'.                                           |
| 18.2.7   | CheckPathAttribute             | Untrimmed value '{untrimmedValue}' in attribute 'Hierarchy@path'.                                                              |
| 18.2.8   | CheckPathAttribute             | Invalid value '{invalidPart}' in attribute 'Hierarchy@path'.                                                                   |
| 18.3.1   | CheckIdAttribute               | Missing attribute 'Table@id' in TreeControl '{treeControlPid}'.                                                                |
| 18.3.2   | CheckIdAttribute               | Empty attribute 'Table@id' in TreeControl '{treeControlPid}'.                                                                  |
| 18.3.3   | CheckIdAttribute               | Untrimmed attribute 'Table@id' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.                            |
| 18.3.4   | CheckIdAttribute               | Invalid value '{tableId}' in attribute 'Table@id'. TreeControl ID '{treeControlPid}'.                                          |
| 18.3.5   | CheckIdAttribute               | Attribute 'Hierarchy/Table@id' references a non-existing 'Table' with PID '{tablePid}'.                                        |
| 18.4.1   | CheckParentAttribute           | Missing attribute 'Table@parent' in TreeControl '{treeControlPid}'.                                                            |
| 18.4.2   | CheckParentAttribute           | Excessive attribute 'Table@parent' in TreeControl '{treeControlPid}'.                                                          |
| 18.4.3   | CheckParentAttribute           | Empty attribute 'Table@parent' in TreeControl '{treeControlPid}'.                                                              |
| 18.4.4   | CheckParentAttribute           | Untrimmed attribute 'Table@parent' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.                        |
| 18.4.5   | CheckParentAttribute           | Invalid value '{attributeValue}' in attribute 'Table@parent'. TreeControl ID '{treeControlPid}'.                               |
| 18.4.6   | CheckParentAttribute           | Attribute 'Hierarchy/Table@parent' references a non-existing 'Table' with PID '{tablePid}'.                                    |
| 18.5.1   | CheckConditionAttribute        | Empty attribute 'Table@condition' in TreeControl '{treeControlPid}'.                                                           |
| 18.5.2   | CheckConditionAttribute        | Untrimmed value '{untrimmedColumnPid}' in attribute 'Table@condition' in TreeControl '{treeControlId}'.                        |
| 18.5.3   | CheckConditionAttribute        | Invalid value '{attributeValue}' in attribute 'Table@condition'. TreeControl ID '{treeControlPid}'.                            |
| 18.5.4   | CheckConditionAttribute        | Attribute 'Hierarchy/Table@condition' references a non-existing 'Column' with PID '{columnPid}'.                               |
| 18.5.5   | CheckConditionAttribute        | Invalid option '{optionName}' in attribute 'Table@condition'. TreeControl ID '{treeControlId}'. Current Value '{optionValue}'. |
| 18.5.6   | CheckConditionAttribute        | Missing value '{valueName}' in attribute 'Table@condition'. TreeControl ID '{treeControlId}'.                                  |
| 18.6.1   | CheckDetailsTableIdAttribute   | Missing attribute 'LinkedDetails@detailsTableId' in TreeControl '{treeControlPid}'.                                            |
| 18.6.2   | CheckDetailsTableIdAttribute   | Empty attribute 'LinkedDetails@detailsTableId' in TreeControl '{treeControlPid}'.                                              |
| 18.6.3   | CheckDetailsTableIdAttribute   | Untrimmed attribute 'LinkedDetails@detailsTableId' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.        |
| 18.6.4   | CheckDetailsTableIdAttribute   | Invalid value '{attributeValue}' in attribute 'LinkedDetails@detailsTableId'. TreeControl ID '{treeControlPid}'.               |
| 18.6.5   | CheckDetailsTableIdAttribute   | Attribute 'ExtraDetails/LinkedDetails@detailsTableId' references a non-existing 'Table' with PID '{tablePid}'.                 |
| 18.7.1   | CheckDiscreetColumnIdAttribute | Missing attribute 'LinkedDetails@discreetColumnId' in TreeControl '{treeControlPid}'.                                          |
| 18.7.2   | CheckDiscreetColumnIdAttribute | Empty attribute 'LinkedDetails@discreetColumnId' in TreeControl '{treeControlPid}'.                                            |
| 18.7.3   | CheckDiscreetColumnIdAttribute | Untrimmed attribute 'LinkedDetails@discreetColumnId' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.      |
| 18.7.4   | CheckDiscreetColumnIdAttribute | Invalid value '{attributeValue}' in attribute 'LinkedDetails@discreetColumnId'. TreeControl ID '{treeControlPid}'.             |
| 18.7.5   | CheckDiscreetColumnIdAttribute | Attribute 'ExtraDetails/LinkedDetails@discreetColumnId' references a non-existing 'Column' with PID '{columnPid}'.             |
| 18.8.1   | CheckParameterAttribute        | Missing attribute 'Tab@parameter' in TreeControl '{treeControlPid}'.                                                           |
| 18.8.2   | CheckParameterAttribute        | Empty attribute 'Tab@parameter' in TreeControl '{treeControlPid}'.                                                             |
| 18.8.3   | CheckParameterAttribute        | Untrimmed attribute 'Tab@parameter' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.                       |
| 18.8.4   | CheckParameterAttribute        | Invalid value '{attributeValue}' in attribute 'Tab@parameter'. TreeControl ID '{treeControlPid}'.                              |
| 18.8.5   | CheckParameterAttribute        | Attribute 'ExtraTabs/Tab@parameter' references a non-existing 'Column' with PID '{columnPid}'.                                 |
| 18.9.1   | CheckTableIdAttribute          | Missing attribute 'Tab@tableId' in TreeControl '{treeControlPid}'.                                                             |
| 18.9.2   | CheckTableIdAttribute          | Empty attribute 'Tab@tableId' in TreeControl '{treeControlPid}'.                                                               |
| 18.9.3   | CheckTableIdAttribute          | Untrimmed attribute 'Tab@tableId' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.                         |
| 18.9.4   | CheckTableIdAttribute          | Invalid value '{attributeValue}' in attribute 'Tab@tableId'. TreeControl ID '{treeControlPid}'.                                |
| 18.9.5   | CheckTableIdAttribute          | Attribute 'ExtraTabs/Tab@tableId' references a non-existing 'Table' with PID '{tablePid}'.                                     |
| 18.10.1  | CheckHiddenColumnsTag          | Empty tag 'HiddenColumns' in TreeControl '{treeControlPid}'.                                                                   |
| 18.10.2  | CheckHiddenColumnsTag          | Untrimmed tag 'HiddenColumns' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.                             |
| 18.10.3  | CheckHiddenColumnsTag          | Invalid value '{hiddenColumnsValue}' in tag 'HiddenColumns'. TreeControl ID '{treeControlPid}'.                                |
| 18.10.4  | CheckHiddenColumnsTag          | Tag 'HiddenColumns' references non-existing IDs. TreeControl ID '{treeControlPid}'.                                            |
| 18.10.5  | CheckHiddenColumnsTag          | Tag 'HiddenColumns' references a non-existing 'Column' with PID '{columnPid}'. TreeControl ID '{treeControlPid}'.              |
| 18.10.6  | CheckHiddenColumnsTag          | Duplicate ID '{duplicateId}' in 'HiddenColumns'. TreeControl ID '{treeControlPid}'.                                            |
| 18.10.7  | CheckHiddenColumnsTag          | Invalid value '{invalidPart}' in tag 'HiddenColumns'.                                                                          |
| 18.10.8  | CheckHiddenColumnsTag          | Untrimmed value '{untrimmedValue}' in tag 'HiddenColumns'.                                                                     |
| 18.11.1  | CheckOverrideDisplayColumnsTag | Empty tag 'OverrideDisplayColumns' in TreeControl '{treeControlPid}'.                                                          |
| 18.11.2  | CheckOverrideDisplayColumnsTag | Untrimmed tag 'OverrideDisplayColumns' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.                    |
| 18.11.3  | CheckOverrideDisplayColumnsTag | Invalid value '{attributeValue}' in tag 'OverrideDisplayColumns'. TreeControl ID '{treeControlPid}'.                           |
| 18.11.4  | CheckOverrideDisplayColumnsTag | Tag 'OverrideDisplayColumns' references non-existing IDs. TreeControl ID '{treeControlPid}'.                                   |
| 18.11.5  | CheckOverrideDisplayColumnsTag | Tag 'OverrideDisplayColumns' references a non-existing 'Column' with PID '{columnPid}'. TreeControl ID '{treeControlPid}'.     |
| 18.11.6  | CheckOverrideDisplayColumnsTag | Duplicate ID '{duplicateId}' in 'OverrideDisplayColumns'. TreeControl ID '{treeControlPid}'.                                   |
| 18.11.7  | CheckOverrideDisplayColumnsTag | Duplicate OverrideDisplayColumns IDs for Table '{tablePid}'. TreeControl ID '{treeControlPid}'.                                |
| 18.11.8  | CheckOverrideDisplayColumnsTag | Untrimmed value '{untrimmedValue}' in tag 'OverrideDisplayColumns'.                                                            |
| 18.11.9  | CheckOverrideDisplayColumnsTag | Invalid value '{invalidPart}' in tag 'OverrideDisplayColumns'.                                                                 |
| 18.11.10 | CheckOverrideDisplayColumnsTag | Duplicate OverrideDisplayColumns ID '{duplicateId}'.                                                                           |
| 18.12.1  | CheckOverrideIconColumnsTag    | Empty tag 'OverrideIconColumns' in TreeControl '{treeControlPid}'.                                                             |
| 18.12.2  | CheckOverrideIconColumnsTag    | Untrimmed tag 'OverrideIconColumns' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.                       |
| 18.12.3  | CheckOverrideIconColumnsTag    | Invalid value '{overrideIconColumnsValue}' in tag 'OverrideIconColumns'. TreeControl ID '{treeControlPid}'.                    |
| 18.12.4  | CheckOverrideIconColumnsTag    | Tag 'OverrideIconColumns' references non-existing IDs. TreeControl ID '{treeControlPid}'.                                      |
| 18.12.5  | CheckOverrideIconColumnsTag    | Tag 'OverrideIconColumns' references a non-existing 'Column' with PID '{columnPid}'. TreeControl ID '{treeControlPid}'.        |
| 18.12.6  | CheckOverrideIconColumnsTag    | Duplicate ID '{duplicateId}' in 'OverrideIconColumns'. TreeControl ID '{treeControlPid}'.                                      |
| 18.12.7  | CheckOverrideIconColumnsTag    | Duplicate OverrideIconColumns IDs for Table '{tablePid}'. TreeControl ID '{treeControlPid}'.                                   |
| 18.12.8  | CheckOverrideIconColumnsTag    | Untrimmed value '{untrimmedValue}' in tag 'OverrideIconColumns'.                                                               |
| 18.12.9  | CheckOverrideIconColumnsTag    | Invalid value '{invalidPart}' in tag 'OverrideIconColumns'.                                                                    |
| 18.12.10 | CheckOverrideIconColumnsTag    | Duplicate OverrideIconColumns ID '{duplicateId}'.                                                                              |
| 18.13.1  | CheckReadonlyColumnsTag        | Empty tag 'ReadonlyColumns' in TreeControl '{treeControlPid}'.                                                                 |
| 18.13.2  | CheckReadonlyColumnsTag        | Untrimmed tag 'ReadonlyColumns' in TreeControl '{treeControlPid}'. Current value '{untrimmedValue}'.                           |
| 18.13.3  | CheckReadonlyColumnsTag        | Invalid value '{readonlyColumnsValue}' in tag 'ReadonlyColumns'. TreeControl ID '{treeControlPid}'.                            |
| 18.13.4  | CheckReadonlyColumnsTag        | Tag 'ReadonlyColumns' references non-existing IDs. TreeControl ID '{treeControlPid}'.                                          |
| 18.13.5  | CheckReadonlyColumnsTag        | Tag 'ReadonlyColumns' references a non-existing 'Column' with PID '{columnPid}'. TreeControl ID '{treeControlPid}'.            |
| 18.13.6  | CheckReadonlyColumnsTag        | Duplicate ID '{duplicateId}' in 'ReadonlyColumns'. TreeControl ID '{treeControlPid}'.                                          |
| 18.13.7  | CheckReadonlyColumnsTag        | Untrimmed value '{untrimmedValue}' in tag 'ReadonlyColumns'.                                                                   |
| 18.13.8  | CheckReadonlyColumnsTag        | Invalid value '{invalidPart}' in tag 'ReadonlyColumns'.                                                                        |

### XML Schema

#### Protocol Schema: New elements \[ID_23608\]\[ID_23611\]

The Protocol XML schema now supports the following elements:

- Protocol.Params.Param.Dashboard
- Protocol.Params.Param.Measurement.Discreets.Discreet.Tooltip

#### Protocol Schema: ArrayOptions.ColumnOption now preferred above ArrayOptions.ColumnOptions.ColumnOption \[ID_23741\]

When defining a table in a *Protocol.xml* file, there are two ways to specify *\<ColumnOption>* elements:

- Directly under the *\<ArrayOptions>* element. Example:

    ```xml
    <ArrayOptions ...>
      <ColumnOption ... />
      <ColumnOption ... />
      ...
    </ArrayOptions>
    ```

- Grouped under a *\<ColumnOptions>* element. Example:

    ```xml
    <ArrayOptions ...>
      <ColumnOptions>
        <ColumnOption ... />
        <ColumnOption ... />
        ...
      </ColumnOptions>
    </ArrayOptions>
    ```

In Visual Studio, up to now, when you used the AutoComplete feature after entering part of an *\<ArrayOptions>* element, it would automatically produce a structure with a *\<ColumnOptions>* group element. From now on, it will produce a structure without a *\<ColumnOptions>* group element.

## Changes

### Enhancements

#### Class Library: Element properties will only be retrieved when needed \[ID_23514\]

From now on, element properties will only be retrieved when needed.

#### Class Library: Exception thrown after detecting an element with duplicate properties will now also contain the name of the ID of the element \[ID_23515\]

The exception that is thrown when an element with duplicate properties is detected will now also contain the name and the ID of the element in question.

### Fixes

#### Class Library: View name would be retrieved when it was already known \[ID_22303\]

Up to now, in some cases, the name of a view would be retrieved when it was already known. From now on, when the name of a view is already known, it will no longer be retrieved a second time.
