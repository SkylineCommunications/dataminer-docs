---
uid: ChangeDisplayKey
---

# Change display key

Changing the display key of a table is considered a major change.

## Impact

This has the same impact as changing a parameter description. The following DataMiner features can be impacted if used:

- Filters
- automation scripts
- Visio files
- Reports
- Dashboards
- Web API

*DIS MCC*

|            | Error message | Description                                                                                                        |
|------------|---------------|--------------------------------------------------------------------------------------------------------------------|
| **2.39.4** | FormatChanged | Table display key was changed from {oldSyntax} '{oldFormat}' to {newSyntax} '{newFormat}'. Table PID '{tablePid}'. |
| **2.39.5** | FormatRemoved | Table display key previously defined via '{oldSyntax}' was removed. Table PID '{tablePid}'.                        |

## Workarounds

### Display key column exists

If a display key already exists, and you want to change its format:

- Use a read/write (standalone) discreet parameter to allow the user to select the naming format.

- The default value should be the original format (no impact for existing users).

- Refer to *SLC SDF Naming Format Compatibility* [on SVN](https://svn.skyline.be/svn/SystemDevelopmentFeature/Protocols/), version PE.0.0.1. (This link is only accessible for Skyline users.)

> [!NOTE]
> It is possible to implement a workflow to change the display key format on element creation (when the default display key is not the desired one). This will avoid a manual action after every element creation. You can implement this with a correlation rule and an automation script.

### Display key column does not exist (primary key is the current display key)

- Copy the description of the primary key column to the new display key column.

- Give the primary key column a new description and hide this column (set width to 0).

- Display the new display key column in the original position of the primary key column.

- The rest of workaround stays the same (see *SLC SDF Naming Format Compatibility* [on SVN](https://svn.skyline.be/svn/SystemDevelopmentFeature/Protocols/)):

  - Use a read/write (standalone) discreet parameter to allow the user to select the naming format.

  - The default value should be the original format (no impact for existing users).

## Common use cases

### Use case 1

[IDX] is located in a column that is intended to be the display key but is not actually the display key (someone forgot the tag naming, for example).

A new range is needed.

This is a mistake. The display key is not correct, and it should be fixed.

### Use case 2

The primary key is the display key and does not have [IDX] in the description. A new display key is wanted.

A new range is needed.

Use the workaround, but **do not** copy the description of the primary key column to the new display key column. Instead a new column should be created with a new name/description to hold the display key.

### Use case 3

The display key is an SNMP column, and it is necessary to have a more customized display key.

A new range is needed.

Use the workaround, but **do not** copy the description of the primary key column to the new display key column. Instead a new column should be created with a more generic name (like "Display Key") to hold the display key. The default value of that column should be the existing display key.

### Use case 4

The naming tag exists, and the display key is composed of multiple columns. There is no column displaying the composite display key.

A new range is needed.

Move [IDX] (from the PK column) to the description of the new column.

Hide the old primary key and move the display key column to the front of the table (UI).
