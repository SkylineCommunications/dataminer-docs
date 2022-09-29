---
uid: DIS_2.39
---

# DIS 2.39

## New features

### IDE



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

