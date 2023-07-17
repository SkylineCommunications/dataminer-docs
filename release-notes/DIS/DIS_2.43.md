---
uid: DIS_2.43
---

# DIS 2.43

## New features

### IDE

#### Export Protocol generation - Support for 'whereAttribute' on 'ExportRule' elements [ID_36787]

With the release of DataMiner 10.3.8, the `whereAttribute` is now supported in DIS and will be taken in account during export protocol generation which is used for Display Editor and Validator.

### Validator

#### New checks and error messages [ID_36787]

The following checks and error messages have been added.

| Check ID | Error message name | Error message |
|--|--|--|
| 17.2.1 | MissingAttribute | Missing attribute 'ExportRule@whereValue'. |
| 17.3.1 | EmptyAttribute | Empty attribute 'ExportRule@whereAttribute'. |
| 17.3.2 | UntrimmedAttribute | Untrimmed attribute 'ExportRule@whereAttribute'. Current value '{untrimmedValue}'. |
| 17.4.1 | MissingAttribute | Missing attribute 'ExportRule@whereTag'. |
| 17.4.2 | EmptyAttribute | Empty attribute 'ExportRule@whereTag'. |
| 17.4.3 | UntrimmedAttribute | Untrimmed attribute 'ExportRule@whereTag'. Current value '{untrimmedValue}'. |

#### New feature check: Usage of 'whereAttribute' [ID_36787]

A new feature check now verifies whether the `whereAttribute` is being used.

This check can return the following error messages:

| Check ID | Error message name | Error message |
|--|--|--|
| 1.25.1 | MinVersionTooLow | Minimum required version '{currentMinDmVersion}' too low. Expected value '{expectedMinDmVersion}'. |
| 1.25.2 | MinVersionTooLow_Sub | '{requiredDmVersion}' : '{usedFeature}' |
| 1.25.3 | MinVersionFeatureUsedInItemWithId_Sub | Feature used in '{itemKind}' with '{identifierType}' '{itemId}'. |

## Changes

### Enhancements

#### Connect & Publish: Improved performance [ID_36899]

When connecting, or first time publishing, to an agent that has a lot of scripts it could take several minutes. This has been drastically been improved and takes now a couple of seconds.

#### DIS Validator: Disable specific check for exported protocols [ID_36921]

The check on the `element` option in the `options` attribute on the `ColumnOption` tag will now be ignored during the validation of the exported protocol.

### Fixes

#### Info bar: 'Outdated code analysis files' ignores now different line endings  [ID_36771]

The info bar, that checks if the code analysis files are up to date, ignores the different line endings between Unix and Windows.
