---
uid: DIS_2.43
---

# DIS 2.43

## New features

### IDE

#### DIS now fully supports the 'whereAttribute' attribute of 'ExportRule' elements [ID_36787]

DIS now fully support the `whereAttribute` attribute of `ExportRule` elements when exporting protocols. The Display Editor and Validator have been adapted accordingly.

See also [release note 36622](xref:General_Main_Release_10.4.0_new_features#exportrule-elements-can-now-have-a-whereattribute-attribute-id_36622)

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

A new feature check now verifies whether the `whereAttribute` attribute is being used.

This check can return the following error messages:

| Check ID | Error message name | Error message |
|--|--|--|
| 1.25.1 | MinVersionTooLow | Minimum required version '{currentMinDmVersion}' too low. Expected value '{expectedMinDmVersion}'. |
| 1.25.2 | MinVersionTooLow_Sub | '{requiredDmVersion}' : '{usedFeature}' |
| 1.25.3 | MinVersionFeatureUsedInItemWithId_Sub | Feature used in '{itemKind}' with '{identifierType}' '{itemId}'. |

## Changes

### Enhancements

#### Enhanced performance when connecting to a DMA with a large number of Automation scripts [ID_36899]

Because of a number of enhancements, overall performance has increased when connecting to a DataMiner Agent with a large number of Automation scripts.

#### DIS Validator: 'DveColumnOptionElement' check will no longer be performed when validating an exported protocol [ID_36921]

The *DveColumnOptionElement* check will no longer be performed when validating an exported protocol.

### Fixes

#### DIS would incorrectly consider code analysis files outdated when it did not have the correct line endings [ID_36771]

Up to now, when DIS checked whether the code analysis files were up to date, it would incorrectly consider a file outdated when it did not have the correct line endings (e.g. Unix line endings vs. Windows line endings). From now on, DIS will ignore the line endings when checking whether the code analysis files are up to date.

#### Snippets would not be available or would not be updated [ID_36950]

When DIS was installed on top of a newly installed copy of Microsoft Visual Studio, it would incorrectly not include any snippets.

Also, after DIS had been upgraded to a newer version, the snippets would incorrectly not be updated.
