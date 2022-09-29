---
uid: DIS_2.39
---

# DIS 2.39

## New features

### IDE



### Validator

#### New checks and error messages

The following checks and error messages have been added.

| Check ID | Error message name | Error message |
|--|--|--|
|  |  |  |
|  |  |  |

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

