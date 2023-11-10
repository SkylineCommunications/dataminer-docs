---
uid: GQI_IGQIInputArguments
---

# IGQIInputArguments Interface

## Definition

Namespace: `Skyline.DataMiner.Analytics.GenericInterface`  
Assembly: `SLAnalyticsTypes.dll`

Implementing this interface makes it possible to retrieve input from the user through arguments.

> [!IMPORTANT]
> The GQI does not validate the input arguments specified by the user. For example, a user can input an SQL query as a string input argument, and the content of the string argument will be forwarded to the ad hoc data source implementation without validation.

## Methods

### GQIArgument[] GetInputArguments()

The GQI will request the arguments.

#### Returns

An array of [GQIArgument](xref:GQI_GQIArgument), which provides all arguments the user can fill in.

### void OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)

The user has filled in the arguments.

#### Parameters

- [OnArgumentsProcessedInputArgs](xref:GQI_OnArgumentsProcessedInputArgs) `args`: an object containing the arguments filled in by the user.