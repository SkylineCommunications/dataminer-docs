---
uid: DIS_2.0.3
---

# DIS 2.0.3

## Features

### Validator

#### RTDisplay check: Additional error messages \[ID_13215\]\[ID_13855\]

The RTDisplay check can now throw a number of additional errors and warnings.

Overview of all possible error and warning messages:

| Result code | Class | Description |
|-------------|-------|-------------|
| 4400 | Information | RTDisplay tags OK. |
| 4401 | Error | Param \[Parameter ID\] has an unexpected RTDisplay=”true” value. |
| 4402 | Error | RTDisplay=”true” required on parameter \[Parameter ID\], which is used as dependency ID in parameter \[Parameter ID\]. |
| 4404 | Error | RTDisplay=”true” required. Parameter is used as dependency value in parameter \[Parameter ID\]. |
| 4405 | Error | RTDisplay=”true” required on write parameter \[Parameter ID\], which has a related read parameter \[Parameter ID\] dependency value in ContextMenu parameter \[Parameter ID\]. |
| 4406 | Error | RTDisplay=”true” is required on parameter \[Parameter ID\], which is used in treecontrol(s) \[comma-separated list of tree control IDs\]. |
| 4408 | Error | RTDisplay=”true” required on parameter \[Parameter ID\], which is used in a tree control ExtraTabs parameter attribute on line \[Line number\]. |
| 4409 | Error | RTDisplay=”true” is required on parameter \[Parameter ID\], which is used in alarm option properties on parameter \[Parameter ID\]. |
| 4410 | Error | RTDisplay=”true” required on parameter \[Parameter ID\], which is used in the pageOrder option Webinterface. |
| 4411 | Error | RTDisplay=”true” is required on parameter \[Parameter ID\], which is used as a context menu. |
| 4412 | Error | RTDisplay=”true” is required on parameter \[Parameter ID\], which is used as QAction feedback. |
| 4413 | Error | RTDisplay=”true” is required on parameter \[Parameter ID\], which has mapAlarm=”true”. |
| 4414 | Error | RTDisplay=”true” is required on parameter \[Parameter ID\], which is used by DMS Spectrum. |
| 4417 | Error | RTDisplay=”true” is required on parameter \[Parameter ID\], which has a virtual source defined. |
| 4418 | Error | RTDisplay=”true” is required on parameter \[Parameter ID\], which is used in Params loadSequence. |
| 4419 | Error | RTDisplay=”true” is required on parameter \[Parameter ID\], which is displayed on table \[Parameter ID\]. |
| 4420 | Error | RTDisplay=”true” required. ColumnOption for table \[Parameter ID\] uses option \[Option\]. |
| 4421 | Error | RTDisplay=”true” is required on parameter \[Parameter ID\], which is used in a relation. |
| 4422 | Error | RTDisplay=”true” is required. Parameter \[Parameter ID\] is an exported table. |

#### Trend/Alarm check: Additional error messages \[ID_13855\]

The Trend/Alarm check can now throw the following additional warnings:

| Result code | Class | Description |
|-------------|-------|-------------|
| 2403 | Warning | Parameter \[Parameter ID\] has trending=”true”, but is not displayed on any page. This is not consistent. Please verify. |
| 2404 | Warning | Parameter \[Parameter ID\] is monitored, but is not displayed on any page. This is not consistent. Please verify. |

#### New check: Check whether all parameter IDs in the \<Measurement> tag of a table have a corresponding \<ColumnOption> tag \[ID_13219\]

A new check has been added that will throw an error whenever the \<Measurement> tag of a table contains a parameter ID that doesn’t have a corresponding \<ColumnOption> tag.

| Result code | Class | Description                                                                                             |
|-------------|-------|---------------------------------------------------------------------------------------------------------|
| 1705        | Error | Parameter \[Column parameter ID\] is included in the table measurement but not in the table definition. |

#### New check: Check whether all table parameters have a correct measurement type \[ID_13220\]

A new check has been added that will throw an error whenever a parameter of type “array” doesn’t have its measurement type set to either “table” or “matrix”.

| Result code | Class | Description                                        |
|-------------|-------|----------------------------------------------------|
| 1706        | Error | Measurement type for array is not table or matrix. |

### XML Schema

#### New units of measure \[ID_13216\]

The XML Schema will now accept the following additional units of measure:

| Unit of measure | Description                                                                                          |
|-----------------|------------------------------------------------------------------------------------------------------|
| IRE             | Unit used in the measurement of composite video signals, derived from “Institute of Radio Engineers” |
| PDU             | Protocol Data Unit                                                                                   |
| MIB objects     | Number of objects in a MIB                                                                           |
| Allocation unit | Unit of disk space allocation for files and directories                                              |
| Messages        | Number of messages                                                                                   |
| Datagrams       | Number of datagrams                                                                                  |
| Failures        | Number of failures                                                                                   |
| Fragments       | Number of fragments                                                                                  |
| Files           | Number of files                                                                                      |
| Peers           | Number of peers                                                                                      |
| KiB             | Kibibyte (1024 bytes)                                                                                |
| MiB             | Mebibyte (1024 kibibytes)                                                                            |
| GiB             | Gibibyte (1024 mebibytes)                                                                            |
| TiB             | Tebibyte (1024 gibibytes)                                                                            |
| Sessions        | Number of sessions                                                                                   |
| Requests        | Number of requests                                                                                   |

## Changes

### Enhancements

#### IDE - MIB browser enhancements \[ID_12972\]

A number of enhancements have been made to the MIB browser:

- Up to now, when you imported an SNMP parameter with base syntax ‘OBJECT IDENTIFIER’, DIS imported a parameter of type “numeric text/double”. From now on, DIS will import a parameter of type “other/string” instead.
- From now on, the MIB browser will allow you to import only files with the following extensions:

  - *.mib*
  - *.smi*
  - *.txt*

- It is now possible to scroll through the list of loaded, pending and missing modules.

Up to now, in some cases, the SNMP type of an imported SNMP parameter was incorrect. This has now also been fixed.

#### Validator - No 'No range defined on numeric parameter' warning for parameters with RTDisplay=false \[ID_13217\]

From now on, the “No range defined on numeric parameter” warning will no longer appear for parameters of which the RTDisplay setting is set to false.

#### Validator - No 'Multiple Table Keys with \[IDX\] in the description' warning if same column is used for both index and display key \[ID_13218\]

From now on, the “Multiple Table Keys with \[IDX\] in the description” warning will no longer appear if the same column is used for both index and display key.

#### Validator - Range of numeric parameters only checked when they are displayed \[ID_13851\]

Up to now, the validator checked the range of all numeric parameters. Now, it will only check the range of numeric parameters that are displayed.

### Fixes

#### IDE - Problem when importing a protocol \[ID_12971\]

In some cases, especially when Microsoft Visio Studio was installed in a language other than English, an error occurred when you tried to import a protocol because the “New XML File” template could not be found.

#### Validator - No 'Unexpected RTDisplay = true' error for trended read parameters without position tag \[ID_13221\]

In some cases, no “Unexpected RTDisplay = true” error was thrown when the RTDisplay setting of a trended read parameter without position tag was set to true.
