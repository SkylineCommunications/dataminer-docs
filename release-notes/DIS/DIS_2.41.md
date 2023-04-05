---
uid: DIS_2.41
---

# DIS 2.41

## New features

### IDE

#### XML editor: New snippet [ID_35991]

In the C# editor, the following snippet allows you to generate the `OnApiTrigger` entrypoint method in an Automation script. This entrypoint method will be used to create an API from an Automation script.

<!-- - DIS \> Protocol \> Param \> SNMP System Params -->

### Validator

#### New checks and error messages [ID_35384] [ID_35558]

The following checks and error messages have been added.

| Check ID | Error message name | Error message |
|--|--|--|
| 2.72.1 | EmptyAttribute | Empty attribute 'Monitored@disabledIf' in Param '{pid}'. |
| 2.72.2 | UntrimmedAttribute | Untrimmed attribute 'Monitored@disabledIf' in Param '{pid}'. Current value '{untrimmedValue}'. |
| 2.72.3 | InvalidValue | Invalid value '{attributeValue}' in attribute 'Monitored@disabledIf'. Param ID '{pid}'. |
| 2.72.4 | NonExistingId | Attribute 'Monitored@disabledIf' references a non-existing 'Param' with ID '{referencedPid}'. Param ID '{pid}'. |
| 2.72.5 | ReferencedParamWrongType | Invalid Param Type '{referencedParamType}' on Param referenced by a 'Monitored@disabledIf' attribute. Param ID '{referencedPid}'. |
| 2.72.6 | ReferencedParamRTDisplayExpected | RTDisplay(true) expected on Param '{referencedPid}' referenced by a 'Monitored@disabledIf' attribute. Param ID '{referencingPid}'. |
| 3.36.1 | UnrecommendedXmlSerializerConstructor | Constructor '{typeUnrecommendedConstructor}' ('{constructorNamespace}') is unrecommended. QAction ID {qactionId}. |

### XML Schema

#### Protocol Schema: New element & new element value [ID_35350]

The following element has been added to the protocol schema:

- New element: `Protocol.Params.Param.Matrix`
- New `Protocol.Params.Param.Type` value: "Matrix"

#### UOM Schema: New units added [ID_36032]

The following units have been added to the UOM Schema:

- cd/m^2 (Candela per square meter)
- nt (Nit, the non-SI name for cd/m<sup>2</sup>)

## Changes

### Enhancements

### Fixes

#### Validator: False positive thrown when a column was added to a table that contained a column of type displayKey [ID_35266]

When a column was added to a table that contained a column of type *displayKey*, the *CheckOptionsAttribute* (2.31) check would thrown a false positive *ColumnOrderChanged* (2.31.1) error.

> [!NOTE]
> From now on, error messages related to table columns will refer to column parameter IDs instead of column indices.
