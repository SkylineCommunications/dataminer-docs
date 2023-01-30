---
uid: DIS_2.39
---

# DIS 2.39

## New features

### IDE

#### Enhanced NuGet support [ID_33544] [ID_34113] [ID_34115] [ID_34117]

Up to now, in QAction and EXE projects, DIS would add references to the DataMiner DLL files of the locally installed DataMiner Agent or, if no DataMiner Agent was installed on the local machine, to copies of those files shipped with the DIS installation package. Instead, DIS will now add a reference to a DataMiner DevPack, i.e. a NuGet package that contains the core DataMiner DLL files of a specific DataMiner version. As a separate DataMiner DevPack is available for every released DataMiner version, adapting a solution to a specific DataMiner version is now merely a question of making sure the solution links to the DevPack of that version.

The DataMiner DevPacks can be found on the [official NuGet store](https://www.nuget.org/packages?q=skylinecommunications).

When you open a protocol solution or an Automation script solution in which the QAction and EXE projects still contain references to separate DataMiner DLL files instead of a DataMiner DevPack, a banner will appear, giving you the opportunity to replace those references by references to the required DevPacks.

##### Changing the default package management format

To be able to work with the new DataMiner DevPacks, you will have to change the default package management format in Microsoft Visual Studio.

1. Go to *Tools > Options -> NuGet Package Manager > General*.
1. Set *Default package management format* to "PackageReference".

If any of your existing solutions are using NuGet packages the old way (i.e. using the package management format "packages.config"), you will have to make every project in those solutions use the package management format "PackageReference".

1. In Microsoft Visual Studio, open a solution and go to the Solution Explorer.
1. Navigate to a project, right-click *References*, and select *Migrate packages.config to PackageReference...*.
1. Repeat for every project in the current solution.

> [!NOTE]
> The DataMiner DevPacks can also be used in solutions other than protocol and Automation script solutions, for example in custom solutions such as the Class Library Community Packages, which are meant to be used as an API within protocol or Automation script solutions. If you have any custom solutions, make sure to the projects in those solutions also use the new DataMiner DevPacks.

##### Enhanced publishing of protocols and Automation scripts

Up to now, when you clicked the *Publish* button to publish a protocol or an Automation script on a DataMiner Agent, only the protocol or Automation script XML file would get published on that DataMiner Agent.

From now on, when you publish a protocol or an Automation script, DIS will create either a *.dmprotocol* package (in case of a protocol) or a *.dmapp* package (in case of an Automation script) in the background, install that package on the DataMiner Agent, and then automatically remove it again. This way, it will no longer be needed to manually copy all required DLL files on the DataMiner Agent in question.

##### Enhanced saving of protocols and Automation scripts

Up to now, it was only possible to save a protocol or an Automation script as an XML file.

From now on, a protocol can be saved either as an XML file or as a *.dmprotocol* package and an Automation script can be saved either as an XML file or a .dmapp package.

If you choose to save a protocol or an Automation script as a package, the package will contain the protocol or Automation script as well as all required DLL files (e.g. DLL files of NuGet packages that are used in the protocol or Automation script).

#### Display editor: Enhanced DVE support [ID_33545]

Up to now, when you opened a protocol in which DVE elements were defined and clicked *Display Editor* in the file tab header, the pages of the main protocol and the pages of the DVE protocols would be displayed in the same list.

From now on, when DVE elements are defined in the protocol, a drop-down box in the top-left corner of the display editor will allow you to select either the main protocol or one of the DVE elements. The editor will then only display the pages and parameters of the item you selected.

Also, export rules will now be created automatically.

#### DIS menu: Additional checks when importing protocols and Automation scripts [ID_33902]

When you try to import a protocol or an Automation script, additional checks will now be performed.

- When, in the DIS menu, you select *DMA > Import Protocol* while an Automation script solution is open, a pop-up window will now appear, saying that it is impossible to import a protocol while an Automation script solution is open.

- When, in the DIS menu, you select *DMA > Import Automation Script* while a protocol solution is open, a pop-up window will now appear, saying that it is impossible to import an Automation script while a protocol solution is open.

- When, in the DIS menu, you select *DMA > Import Automation Script* while an Automation script solution is open, a pop-up window will now appear, asking you whether you want the script to be imported into the open Automation script solution.

#### DIS now by default contains most common IANA and IETF MIB files [ID_34304]

DIS now by default contains most common IANA and IETF MIB files. These MIB files contain common definitions that are often used in MIB files supplied by equipment vendor.

### Validator

#### New checks and error messages [ID_33808] [ID_33840] [ID_34262] [ID_34283] [ID_34286] [ID_34288] [ID_34292] [ID_34312]

The following checks and error messages have been added.

| Check ID | Error message name | Error message |
|--|--|--|
| 1.27.1 | MissingAttribute | Missing attribute 'Page.Visibility@overridePID' in Page '{pageName}'. |
| 1.27.2 | EmptyAttribute | Empty attribute 'Page.Visibility@overridePID' in Page '{pageName}'. |
| 1.27.3 | UntrimmedAttribute | Untrimmed attribute 'Page.Visibility@overridePID' in Page '{pageName}'. Current value '{untrimmedValue}'. |
| 1.27.4 | NonExistingParam | Attribute 'Page.Visibility@overridePID' references a non-existing 'Param' with ID '{pid}'. Page Name '{pageName}'. |
| 1.27.5 | ReferencedParamExpectingRTDisplay | RTDisplay(true) expected on Param '{pid}' used as page visibility condition. Page name '{pageName}'. |
| 1.28.1 | MissingTag | Missing tag 'Protocol/Display'. |
| 1.29.2 | UntrimmedAttribute | Untrimmed attribute 'wideColumnsPages'. Current value '{untrimmedValue}'. |
| 1.29.3 | UnexistingPage | The page '{pageName}' specified in 'Protocol/Display@wideColumnPages' does not exist. |
| 2.11.3 | EmptyTag | Empty tag 'Display/Range' in Param '{pid}'. |
| 2.11.4 | LowShouldBeSmallerThanHigh | Range/Low '{rangeLow}' should be smaller than Range/High '{rangeHigh}'. Param ID '{paramId}'. |
| 2.32.3 | EmptyTag | Empty tag 'Range/Low' in Param '{paramId}'. |
| 2.32.4 | InvalidValue | Invalid value '{tagValue}' in tag 'Range/Low'. Param ID '{paramId}'. |
| 2.32.5 | UntrimmedValue | Untrimmed tag 'Range/Low' in Param '{paramId}'. Current value '{untrimmedValue}'. |
| 2.32.6 | LogarithmicLowerOrEqualToZero | Range/Low '{rangeLow}' should be bigger than zero due to Trending@logarithmic 'true'. Param ID '{paramId}'. |
| 2.32.7 | WriteDifferentThanRead | Range/Low on write Param '{rangeLowOnWrite}' is different than the one on read Param '{rangeLowOnRead}'. Write PID '{writePid}'. |
| 2.33.3 | EmptyTag | Empty tag 'Range/High' in Param '{paramId}'. |
| 2.33.4 | InvalidValue | Invalid value '{tagValue}' in tag 'Range/High'. Param ID '{paramId}'. |
| 2.33.5 | UntrimmedValue | Untrimmed tag 'Range/High' in Param '{paramId}'. Current value '{untrimmedValue}'. |
| 2.33.6 | LogarithmicLowerOrEqualToZero | Range/High '{rangeHigh}' should be bigger than zero due to Trending@logarithmic 'true'. Param ID '{paramId}'. |
| 2.33.7 | WriteDifferentThanRead | Range/High on write Param '{rangeHighOnWrite}' is different than the one on read Param '{rangeHighOnRead}'. Write PID '{writePid}'. |
| 2.68.1 | UnsupportedTag | Unsupported tag 'DefaultValue' in Param '{paramId}'. |
| 2.68.2 | NotYetSupportedTag | Unsupported tag 'DefaultValue' in Column '{columnPid}'. |
| 2.68.3 | ValueIncompatibleWithInterpreteType | Interprete/DefaultValue '{defaultValue}' is incompatible with Interprete/Type '{interpreteType}'. Param ID '{pid}'. |
| 2.69.1 | MissingAttribute | Missing attribute 'Interprete/LengthType@id' due to 'LengthType' 'other param'. Param ID '{paramId}'. |
| 2.69.2 | EmptyAttribute | Empty attribute 'Interprete/LengthType@id' in Param '{paramId}'. |
| 2.69.3 | UntrimmedAttribute | Untrimmed attribute 'id' in Param '{paramId}'. Current value '{untrimmedValue}'. |
| 2.69.4 | NonExistingId | Attribute 'Interprete/LengthType@id' references a non-existing 'Param' with ID '{nonExistingParamId}'. Param ID '{paramId}'. |
| 2.69.5 | ReferencedParamWrongInterpreteType | Invalid Interprete/Type '{interpreteType}' on Param referenced by Interprete/LengthType@id. Expected value 'double'. Param ID '{paramId}'. |
| 2.70.1 | MissingTag | Missing attribute 'Exception@value' in Param '{pid}'. |
| 2.70.2 | ValueIncompatibleWithInterpreteType | Incompatible 'Exception@value' value '{exceptionValue}' with 'Interprete/Type' value '{interpreteType}'. Param ID '{pid}'. |
| 2.71.1 | MissingTag | Missing tag 'Exception/Value' in Param '{pid}'. |
| 2.71.2 | UntrimmedTag | Untrimmed tag 'Exception/Value' in Param '{pid}'. Current value '{untrimmedValue}'. |
| 2.71.3 | ValueIncompatibleWithInterpreteType | Incompatible 'Exception/Value' value '{exceptionValue}' with 'Interprete/Type' value '{interpreteType}'. Param ID '{pid}'. |
| 4.10.1 | IncompatibleContentWithGroupType | Incompatible 'Group/Content' child '{contentChildTagName}' with 'Group/Type' '{groupType}'. Group ID '{groupId}'. |
| 4.10.2 | MixedTypes | Unsupported mixed group content '{contentTypes}'. Group ID '{groupId}'. |
| 4.10.3 | MaxItemsMultipleGet | Group with 'multipleGet' true contains more than 20 content elements. Group ID '{groupId}'. |
| 4.10.4 | MaxItems | Group contains more than 10 content elements. Group ID '{groupId}'. |
| 4.10.5 | MissingTag | Missing tag 'Content' in Group '{groupId}'. |
| 13.2.9 | DuplicateValue | Duplicated Relation path '{duplicateValue}'. |

### XML Schema

#### Content model of <Units> element is now less strict [ID_33975]

The content model of the <Units> element has been made less strict. It is now a union of the non-empty string type and the UOM enum type.

This will allow to use units that have not yet been added to the UOM Schema without causing an XML issue detected by said Schema.

#### Protocol Schema: New elements [ID_34333]

The following element has been added to the protocol schema:

- Protocol.Params.Param.CrossDriverOptions
- Protocol.Params.Param.CrossDriverOptions.CrossDriverOption

## Changes

### Fixes

#### MIB Browser would incorrectly display "Integer" when selecting an OID containing discreet values [185915]

When you selected an OID that contained a series of discreet values, in the *Syntax* box, the *MIB Browser* would incorrectly display "Integer" instead of the actual values.
