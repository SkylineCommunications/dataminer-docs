---
uid: GQI_GQIArgument
---

# GQIArgument class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Provides the base class of an argument for a user-defined data source or operator.

## Derived types

The following derived types are supported from DataMiner 10.3.0/10.2.4 onwards:

- `GQIStringArgument`

- `GQIDoubleArgument`

In addition, the following derived types are supported from DataMiner 10.3.0/10.2.7 onwards:

- `GQIBooleanArgument`

- `GQIDateTimeArgument`

- `GQIIntArgument`

- `GQIStringDropdownArgument`

- `GQIStringListArgument`

For custom operators, you can also use the following arguments to select existing columns:

- `GQIColumnDropdownArgument`

- `GQIColumnListArgument`

> [!NOTE]
> Each argument inherits from its typed base class, e.g. `GQIIntArgument` inherits from `GQIArgument<int>`

## Properties

| Property   | Type    | Required | Description                                 |
| ---------- | ------- | -------- | ------------------------------------------- |
| Name       | String  | Yes      | The name of the input argument.             |
| IsRequired | Boolean | No       | Indicates whether the argument is required. |
