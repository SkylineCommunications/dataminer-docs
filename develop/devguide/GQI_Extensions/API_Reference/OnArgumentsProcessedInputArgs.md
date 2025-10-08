---
uid: GQI_OnArgumentsProcessedInputArgs
---

# OnArgumentsProcessedInputArgs class

## Definition

- Namespace: `Skyline.DataMiner.Analytics.GenericInterface`
- Assembly: `SLAnalyticsTypes.dll`

Contains functionality to retrieve values for the provided arguments. An instance is provided through the `OnArgumentsProcessed` lifecycle method of the [IGQIInputArguments building block](xref:GQI_IGQIInputArguments).

> [!TIP]
> For clean code, use [GetArgumentValue](#t-getargumentvaluetgqiargumentt-argument) to retrieve values from required arguments and use [TryGetArgumentValue](#bool-trygetargumentvaluetgqiargumentt-argument-out-t-value) to retrieve values from optional arguments.

> [!TIP]
> We recommend using overloads that take a [GQIArgument](xref:GQI_GQIArgument) object to retrieve argument values. Although a name uniquely identifies an argument, your implementation will be more maintainable if you use object references instead of raw strings.

## Methods

### bool HasArgumentValue(GQIArgument argument)

Checks if a value was specified for the given argument.

#### Parameters

- [GQIArgument](xref:GQI_GQIArgument) `argument`: The argument for which to check if a value was specified.

#### Returns

`true` for all required arguments and optional arguments with a specified value.

`false` for optional arguments without a specified value.

### bool HasArgumentValue(string name)

Checks if a value was specified for the given argument by name.

#### Parameters

- `string` `name`: the name of the argument for which to check if a value was specified.

#### Returns

`true` for all required arguments and optional arguments with a specified value.

`false` for optional arguments without a specified value.

### T GetArgumentValue\<T\>(GQIArgument\<T\> argument)

Retrieves the value of an argument provided in the query.

#### Parameters

- [GQIArgument\<T\>](xref:GQI_GQIArgument) `argument`: the argument to retrieve the value from

#### Returns

The filled in value of type T. This method will return the [DefaultValue](xref:GQI_GQIArgument) of the argument in case the argument is not required and no value was provided by the user.

### T GetArgumentValue\<T\>(string name)

Retrieves the value of an argument provided in the query.

#### Parameters

- `string` `name`: the name of the argument to retrieve the value from

#### Returns

The filled in value of type T. This method will return the [DefaultValue](xref:GQI_GQIArgument) of the argument in case the argument is not required and no value was provided by the user.

### bool TryGetArgumentValue\<T\>(GQIArgument\<T\> argument, out T value)

Tries to retrieve the value of an argument provided in the query.

#### Parameters

- [GQIArgument\<T\>](xref:GQI_GQIArgument) `argument`: The argument to try to retrieve the value from.
- **out** `T` `value`: When this method returns true, it contains the argument value specified in the query. Otherwise it contains the default value of the argument.

#### Returns

`true` for all required arguments and optional arguments with a specified value.  
`false` for optional arguments without specified value.

### bool TryGetArgumentValue\<T\>(string name, out T value)

Tries to retrieve the value of an argument provided in the query by name.

#### Parameters

- `string` `name`: The name of the argument to try to retrieve the value from.
- **out** `T` `value`: When this method returns true, it contains the argument value specified in the query. Otherwise it contains the default value of the argument.

#### Returns

`true` for all required arguments and optional arguments with a specified value.

`false` for optional arguments without specified value.
