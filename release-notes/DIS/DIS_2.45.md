---
uid: DIS_2.45
---

# DIS 2.45

## New features

### IDE

#### XML editor: New Automation script tag options [ID 37423]

In the XML editor, you can click a small down arrow in front of certain XML tags to open a shortcut menu. Two new commands have been added.

|Tag   | Command       | Function |
|------|---------------|----------|
| Name | Rename script | Rename the automation script XML and update all linked projects. |
| Exe  | Update Exe ID | Change the ID of the *Exe* code block. |

### Validator

#### New checks and error messages [ID 37259] [ID 37265]

The following checks and error messages have been added.

| Check ID | Error message name | Error message |
|--|--|--|
| 2.73.1 | MissingTag   | The Protocol.Params.Param.Interprete.LengthType tag is missing |
| 2.73.2 | EmptyTag     | The Protocol.Params.Param.Interprete.LengthType tag is empty |
| 2.73.3 | InvalidValue | The Protocol.Params.Param.Interprete.LengthType tag has an invalid value |
| 2.74.1 | MissingTag   | The Protocol.Params.Param.Interprete.Length tag is missing |
| 2.74.2 | EmptyTag     | The Protocol.Params.Param.Interprete.Length tag is empty |
| 2.74.3 | InvalidValue | The Protocol.Params.Param.Interprete.Length tag has an invalid value.<br>Note: Parameters that have Type set to "length" cannot have an Interprete.Length value that is greater than 4. |

Former validator error 2603 (RawType double has no length definition) has been removed.

### XML Schema

#### PackageManifest Schema: DestinationPath for Dashboard is optional [ID 37586]

In the *PackageManifest* schema, the *DestinationPath* tag for Dashboards has now been marked optional.

## Changes

### Enhancements

#### 'Generate driver help' command will now create a Markdown file [ID 37313]

When you click the *Generate driver help* menu command, a Markdown file with extension .md will now be created in the GitHub repository named *dataminer-docs-connectors*.

#### SLDisCSharpAnalysis and SLDisCompiler projects have been replaced by NuGet packages [ID 37536] [ID 37359]

The *SLDisCsharpAnalysis* project has been removed from DIS and NuGet packages have been created and/or extended to replace its functionality:

- New packages:

  - Skyline.DataMiner.CICD.CSharpAnalysis.Common
  - Skyline.DataMiner.CICD.CSharpAnalysis.Protocol
  - Skyline.DataMiner.CICD.Models.Common

- Extended packages:

  - Skyline.DataMiner.CICD.Models.Protocol

The *SLDisCompiler* project has been removed from DIS. Its functionality has been migrated to the existing *Skyline.DataMiner.CICD.Parsers.Protocol* NuGet package and the newly introduced *Skyline.DataMiner.CICD.Assemblers.Protocol* NuGet package.

DIS has also been reworked so that it will now make use of these new/updated NuGet packages.

### Fixes

#### XML editor: Problem when opening a QAction that did not contain the default QAction_{id}.cs file [ID 37358]

An *InvalidOperationException* would be thrown when you tried to open a QAction that did not contain the default *QAction_{id}.cs* file.

From now on, when you open a QAction that does not contain the default *QAction_{id}.cs* file, it will take the next available C# file instead.

#### Validator will no longer generate a minor issue when Param.ArrayOptions@options includes customDatabaseName, databaseName, databaseNameProtocol or sizehint [ID 37276]

From now on, the Validator will no longer generate a minor issue when one of the following options is used in the *options* attribute of the *ArrayOptions* element:

- customDatabaseName
- databaseName
- databaseNameProtocol
- sizeHint

#### Validator will now check for duplicate values case-insensitively [ID 37287]

The Validator will now check for duplicate values (e.g. duplicate parameter names) case-insensitively.
