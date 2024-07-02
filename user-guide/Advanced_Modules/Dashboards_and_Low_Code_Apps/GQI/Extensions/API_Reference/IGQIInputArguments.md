---
uid: GQI_IGQIInputArguments
---

# IGQIInputArguments interface

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Implement this interface to define input arguments for an ad hoc data source or custom operator.

> [!IMPORTANT]
> The GQI does not validate the input arguments specified by the user. For example, a user can input an SQL query as a string input argument, and the content of the string argument will be forwarded to the ad hoc data source implementation without validation.

## Methods

### GQIArgument[] GetInputArguments()

The GQI will request the arguments.

#### Returns

An array of [GQIArgument](xref:GQI_GQIArgument), which provides all arguments the user can fill in.

### void OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)

GQI has processed the input arguments provided by the user.

#### Parameters

- [OnArgumentsProcessedInputArgs](xref:GQI_OnArgumentsProcessedInputArgs) `args`: An object containing the arguments filled in by the user.
