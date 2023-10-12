---
uid: DIS_2.42
---

# DIS 2.42

## New features

### IDE

#### DIS now supports SDK-style projects [ID_36409]

DIS now supports SDK-style projects in addition to the legacy-style projects.

At startup, DIS will install new protocol solution and Automation script solution templates that will be used when creating a new protocol or Automation script solution in Visual Studio 2022.

#### Automation script solutions: 'DataMiner DLL Path' property no longer supported [ID_36774]

Due to the introduction of SDK-style projects, the *DataMiner DLL Path* property introduced in [release note 29031](xref:DIS_2.32#automation-script-solutions-dataminer-dll-path-property-id_29031) is no longer supported.

### Validator

#### Validator check 'UnsupportedIDisposable' has become a feature check [ID_36455]

Up to now, DIS Validator check *UnsupportedIDisposable* (ID 3.14.1) checked whether QAction classes implemented the `IDisposable` interface. If they did, a Validator issue would be generated, saying that this is not supported by DataMiner.

As DataMiner has been supporting calling the `Dispose` method of QActions as from version 10.2.9, the *UnsupportedIDisposable* check has now been converted into a feature check. See also [release note 33965](xref:General_Feature_Release_10.2.9#qactions-are-now-idisposable-and-the-slprotocol-object-remains-available-outside-of-the-run-scope-id_33965).

### XML Schema

#### Protocol Schema: 'ColumnOptions' element has been removed [ID_36526]

​The following element has been removed from the protocol schema:

- Protocol.Params.Param.ArrayOptions.ColumnOptions

#### Protocol Schema: 'ExportRule' elements can now have a 'whereAttribute' attribute [ID_36667]

The protocol schema now supports the `whereAttribute` attribute on `ExportRule` elements.

This will allow you to validate the value of an attribute when applying an export rule.

See also [release note 36622](xref:General_Main_Release_10.4.0_new_features#exportrule-elements-can-now-have-a-whereattribute-attribute-id_36622)

#### Protocol Schema: Commas are not allowed in default alarm values [ID_36807]

The protocol schema will now give a warning when commas are used in the default alarm value tags (`CH`, `MaH`, `MiH`, ...).

## Changes

### Enhancements

#### DIS Validator & DIS Comparer: Tooltip added to 'State' column [ID_36598]

When, in the *DIS Validator* and *DIS Comparer* tool windows, you hover over the *State* column, a tooltip will now appear, listing the possible values you can find in that column.

### Fixes

#### Validator: 'Unknown or malformed option' error thrown when 'multipleGet' was added to the SNMP options of an SNMP table [ID_36477]

The Validator would incorrectly throw an `Unknown or malformed option` error when "multipleGet" had been added to the SNMP options of an SNMP table.

For more information on the "multipleGet" option, see [release note 30780](xref:General_Feature_Release_10.1.10#new-polling-scheme-polls-snmp-tables-by-row-id_30780).
