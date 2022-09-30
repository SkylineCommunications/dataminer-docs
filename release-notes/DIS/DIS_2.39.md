---
uid: DIS_2.39
---

# DIS 2.39

## New features

### IDE

#### [ID_33544] [ID_34113] [ID_34115] [ID_34117]

Up to now, in QActions and EXE blocks, DIS would add references to DataMiner DLL files stored on the local DataMiner Agent or to copies of those files shipped with the DIS installation package. Instead, DIS will now add a reference to the DataMinerDevPack NuGet package, which contains all core DataMiner DLL files.

34113

Up to now, when pressing the publish button in DIS, it would take the protocol/Automation script XML and publish this on the DataMiner Agent.

As a protocol/Automation script could make use of custom DLLs (e.g. through NuGet packages that are being used), the publishing has now been updated so that in the background a .dmprotocol package (for protocols) or .dmapp package (for Automation scripts) is created. This package is then installed on the agent automatically during publishing, alleviating the need to manually put the required DLLs on the Agent. The .dmapp also gets removed again automatically.

34115

Up to now, it was only possible to save a protocol/Automation script as an XML file. Now for protocols, you can choose to either save it as an XML or as a .dmprotocol package.

For an Automation script, you can choose to save it as XML or a .dmapp package.

The .dmprotocol/..dmapp package contains the protocol/Automation script together with the required DLLs (e.g. DLLs of NuGet packages that are used in the protocol/Automation script.)

34117

When opening a protocol or Automation script solution, DIS will from now on verify whether the dev pack nugets are used (these are NuGet packages that contain core DataMiner DLLs typicallly used for develop protocols, Automation scripts, etc.). If it detects that projects of the solulion not using the Dev packs but do use such core DLLs, a banner will be shown informing the user about this. The user is then able to click the Fix link which will replace the references with a reference to the required Dev pack NuGet packages.




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

### Enhancements




### Fixes

