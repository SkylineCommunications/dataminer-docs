---
uid: GQIArgument
---

# GQIArgument

The *GQIArgument* object is an abstract class with the following properties:

| Property   | Type    | Required | Description                                 |
| ---------- | ------- | -------- | ------------------------------------------- |
| Name       | String  | Yes      | The name of the input argument.             |
| IsRequired | Boolean | No       | Indicates whether the argument is required. |

The following derived types are supported from DataMiner 10.3.0/10.2.4 onwards:

- `GQIStringArgument`

- `GQIDoubleArgument`

In addition, the following derived types are supported from DataMiner 10.3.0/10.2.7 onwards:

- `GQIBooleanArgument`

- `GQIDateTimeArgument`

- `GQIIntArgument`

- `GQIStringDropdownArgument`

- `GQIStringListArgument`
