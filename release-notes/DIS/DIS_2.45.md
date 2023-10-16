---
uid: DIS_2.45
---

# DIS 2.45

## New features

### IDE

#### Automation Scripts - Rename script & update Exe ID [ID_37423]

A new dropdown is introduced on the Name tag in the Automation script XML with the option to rename the script.

This will update the linked projects and the xml itself to have the new name.

On the dropdown for the Exe tags, a new option to change the ID has been added. This behaves the same as with QActions and necessary updates will be done to the XML and projects.

### Validator

#### VAL NF - Check Length/LengthType of Parameter Type fixed [ID_37259], [ID_37265]

The validator has been extended with the following checks:

- 2.73 (CheckLengthTypeTag)
  - 2.73.1 (MissingTag): The Protocol.Params.Param.Interprete.LengthType tag is missing
  - 2.73.2 (EmptyTag): The Protocol.Params.Param.Interprete.LengthType tag is empty
  - 2.73.3 (InvalidValue): The Protocol.Params.Param.Interprete.LengthType tag has an invalid value
- 2.74 (CheckLengthTag):
  - 2.74.1 (MissingTag): The Protocol.Params.Param.Interprete.Length tag is missing
  - 2.74.2 (EmptyTag): The Protocol.Params.Param.Interprete.Length tag is empty
  - 2.74.3 (InvalidValue): The Protocol.Params.Param.Interprete.Length tag has an invalid value. For parameters that have Type set to "length" it is verified that the value of Interprete.Length is not bigger than 4.

Removed old validator error 2603: RawType double has no length definition.

## Changes

### Enhancements

#### Driver help generator now generates markdown [ID_37313]

The driver help generation in DIS has been updated so that it now generates a markdown file (.md) to be used in the docs repository instead of an HTML page that was used on DCP. The menu item that allowed to open the driver help on DCP will now open the corresponding page on the GitHub repository (if it exists).

An issue was also fixed related to the menu item for opening the OneNote of a driver. Opening the OneNote of a driver should now work again.

#### SLDisCSharpAnalysis and SLDisCompiler replaced by NuGet packages [ID_37536], [ID_37359]

The SLDisCsharpAnalysis project has been extracted from DIS and new NuGet packages have been created/extend to hold this extracted functionality:

New packages:

- Skyline.DataMiner.CICD.CSharpAnalysis.Common
- Skyline.DataMiner.CICD.CSharpAnalysis.Protocol

- Skyline.DataMiner.CICD.Models.Common

Extended packages:

Skyline.DataMiner.CICD.Models.Protocol

The SLDisCompiler project has been extracted from DIS and the functionality from this project has been migrated to the already existing NuGet package "Skyline.DataMiner.CICD.Parsers.Protocol" and the newly introduced NuGet package "Skyline.DataMiner.CICD.Assemblers.Protocol".

DIS has also been reworked so that it now makes use of these updated/new NuGet packages.

### Fixes

#### XSD - PackageManifest - DestinationPath for Dashboard is optional [ID_37586]

The PackageManifest XSD has been adapted so that the DestinationPath tag for Dashboards is optional.

#### Fix open QAction without default QAction_{id}.cs file [ID_37358]

When trying to open a QAction that did not have the default QAction_{id}.cs file in it, it would throw an InvalidOperationException.

This has now been fixed and will take the next available C# file.

#### Val Fix - Param.ArrayOptions - Options - customDatabaseName, sizehint, databaseName, databaseNameProtocol [ID_37276]

The validator has been extended to no longer generate a minor issue when one of the following options is used in the ArrayOptions@options attribute:

- customDatabaseName
- databaseName
- databaseNameProtocol
- sizeHint

#### Val Fix - DuplicateValue error messages now check case-insensitive [ID_37287]

When checking for duplicate values (e.g.: parameter names), the checks will now be case-insensitive.
