---
uid: DIS_2.40
---

# DIS 2.40

## New features

### IDE

#### [ID_34598]



### Validator

#### New feature check: Usage of NuGet packages [ID_34527]

A new feature check now verifies whether the QAction projects in the protocol are using NuGet packages.

This check can return the following error messages:

| Check ID | Error message name | Error message |
|--|--|--|
| 1.25.1 | MinVersionTooLow | Minimum required version '{currentMinDmVersion}' too low. Expected value '{expectedMinDmVersion}'. |
| 1.25.2 | MinVersionTooLow_Sub | '{requiredDmVersion}' : '{usedFeature}' |
| 1.25.3 | MinVersionFeatureUsedInItemWithId_Sub | Feature used in '{itemKind}' with '{identifierType}' '{itemId}'. |

### XML Schema

## Changes

### Enhancements

### Fixes

#### Protocol Schema: Casing of calculateAlarmState attribute was incorrect [ID_34430]

In the `Protocol.xsd` file, the casing of the `calculateAlarmState` attribute has been changed from "calculateALarmState" to "calculateAlarmState".

#### Package manifest Schema: Files and Folders elements removed from packageManifest.xsd file [ID_35006]

The `<Files>` and `<Folders>` elements have been removed from the `packageManifest.xsd` file.
