---
uid: IGQIInputArguments
---

# IGQIInputArguments

The *IGQIInputArguments* interface can be used to have the user specify an argument, for example the CSV file from which data should be parsed, or a filter that should be applied. This interface has the following methods:

| Method | Input arguments | Output arguments | Description |
|--|--|--|--|
| GetInputArguments | - | GQIArgument[] | Asks for additional information from the user when the data source is configured. |
| OnArgumentsProcessed | OnArgumentsProcessedInputArgs | OnArgumentsProcessedOutputArgs | Event to indicate that the arguments have been processed. |

> [!NOTE]
> The GQI does not validate the input arguments specified by the user. For example, a user can input an SQL query as a string input argument, and the content of the string argument will be forwarded to the ad hoc data source implementation without validation.
