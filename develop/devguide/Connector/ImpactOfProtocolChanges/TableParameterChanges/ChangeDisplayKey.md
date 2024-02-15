---
uid: ChangeDisplayKey
---

# Change display key

Changing the display key of a table is considered a major change.

## Impact

Same impact as changing a parameter description. Can impact the following (when used):

- DMS Filters
- DMS Automation scripts
- DMS Visio files
- DMS Reports
- DMS WebAPI
- Dashboards

*DIS MCC*

| Full ID | Error message | Description |
|---------|---------------|-------------|
| 2.39.4  | FormatChanged | Table display key was changed from {oldSyntax} '{oldFormat}' to {newSyntax} '{newFormat}'. Table PID '{tablePid}'. |
| 2.39.5  | FormatRemoved | Table display key previously defined via '{oldSyntax}' was removed. Table PID '{tablePid}'. |

## Workarounds

### Display key column exists

If a display key already exists and we want to change its format, the following routine should be implemented to avoid impact by default:

- Read/Write (standalone) discreet parameter allowing user to select the naming format
- Default value should be the original format (no impact to existing customers)
- Ref. SLC SDF Naming Format Compatibility

  - Version PE.0.0.1
  - Located on SVN: <https://svn.skyline.be/svn/SystemDevelopmentFeature/SLC SDF Naming Format Compatibility/>

> [!NOTE]
> It is possible to implement a workflow for your customer in order for the display key format to be changed on element creation (when the default display key is not the desired one), this will avoid a manual action after every element creation.
> With a correlation rule and an Automation script you can make that happen.

### Display key column does not exist (primary key is the current display key)

- Copy the description of the primary key column to the new display key column
- Give the primary key column a new description and hide this column (set width to 0)
- Display the new display key column in the original position of the primary key column
- Rest of workaround stays the same (see SLC SDF Naming Format Compatibility)

  - Read/Write (standalone) discreet parameter allowing user to select the naming format
  - Default value should be the original format (no impact to existing customers)

## Common use cases

### Use case 1

[IDX] is located in a column that is intended to be the display key but is not actually the display key (someone forgot the tag naming for example).

A new range is needed.

This is a mistake and the display key is not correct and it should be fixed.

### Use case 2

The primary key is the display key and does not have [IDX] in the description. We want a new display key.

A new range is needed.

We should use the workaround but the following **does not apply**:

- Copy the description of the primary key column to the new display key column

Instead a new columns should be created with a new name/description to hold the display key.

### Use case 3

The display key is an SNMP column, and it is necessary to have a more custom display key.

A new range is needed.

We should use the workaround but the following **does not apply**:

- Copy the description of the primary key column to the new display key column

Instead a a new column should be created with a more generic name (like "Display Key") to hold the display key. The default value of that column should be the existent display key.

### Use case 4

The naming tag exists, and the display key consists of multiple columns. There is no column displaying the composite display key.

A new range is needed.

Move [IDX] (from the PK column) to the description of the new column.

Hide the old primary key and move the display key column to the front of the table (UI).
