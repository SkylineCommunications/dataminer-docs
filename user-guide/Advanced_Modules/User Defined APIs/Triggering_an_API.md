---
uid: UD_APIs_Triggering_an_API
---

# Triggering a user defined API

> [!WARNING]
> The current feature is in preview and is not fully released yet. This feature should not be used in any staging or production environment.

## HTTP trigger

> [!NOTE]
> API triggers are handled asynchronously. To protect DataMiner, a limit of concurrent triggers is set. As soon as that limit is reached, new triggers are added to a queue and will be handled when a previous running trigger is finished. This limit is not configurable, it is set according to the amount of logical processors of the system (with a minimal concurrency of 4). The exact limit is logged in the `C:\Skyline DataMiner\Logging\SLUserDefinableApiManager.txt` file. Apart from this limit, IIS for Windows 10 also has a concurrency limit of 10. IIS for Windows Server has no limits.

To trigger an API, you can send an HTTP or HTTPS request to the UserDefinableApiEndpoint.

### Building the HTTP request

To test sending a request, you can use a tool like Postman.

#### URL

To send a request to UserDefinableApiEndpoint, use the following URL: `http(s)://<HOSTNAME>/api/custom/ROUTE_HERE`.
Examples:

```
http://staging-agent-b3/api/custom/switchers/status
https://production-agent-a1/api/custom/encoder/main/status
```

#### HTTP Methods

 The following HTTP methods are supported: GET, PUT, POST, DELETE.

 > [!NOTE]
 > An API is free to choose if it supports one or more of the aforementioned methods.

#### Authentication

To authenticate yourself to the API, you add a `Bearer` Authorization header to your request that contains the [secret](xref:UD_APIs_Objects_ApiToken#secret). See an example of how the header should look like below:

```
Bearer 24te8bRBOhrDj6TkXkim4qh9GpDXsdGudib57j7C/CU=
```

#### Content-Type

In case the API needs input from the user using the HTTP body, you need to specify a content-type.
The endpoint supports the following content-types:

- application/json
- application/xml
- text/xml
- text/plain

> [!NOTE]
> Note that it is also supported to add no Content-Type header to your request, in this case, it is expected that the body is empty.

#### Content-Length

The Content-Length header should be calculated and filled in automatically depending on how you send the request. It contains the length of your body in bytes. It is important that this is correct, as UserDefinableApiEndpoint will only read the amount of bytes of the body that are specified in the Content-Length header.

> [!IMPORTANT]
> The endpoint limits request sizes up to 30 MB.

#### Body

An API can expect input. This input is passed in the body. The format of the input is defined in the definition of the API. If the `ApiDefinition` is set to accept parameters, you are expected to pass them as a JSON in a key-value format. More info about that can be found [here](xref:UD_APIs_Define_API#parameters). The body is expected to be encoded in UTF-8.

### The response

The API returns an HTTP status code indicating the status of the request and a body. In case some input from the user is missing, or the user sends a request with a wrong HTTP method. The API can return an HTTP status code indicating the error and a body with more information. The endpoint itself can also return errors with corresponding status code to indicate something went wrong. See below.

The API will always return responses encoded in UTF-8.

#### Errors

UserDefinableApiEndpoint can return an error if something goes wrong. An error will be returned in the following format, with an HTTP response code indicating that something went wrong:

```json
{
    "errors": [
        {
            "title": "Error occurred while handling the request, contact your admin with the provided errorCode and faultingNode ID.",
            "detail": "Invalid json body received.",
            "errorCode": 10,
            "faultingNode": 123
        }
    ]
}
```

For now, the `errors` object will always contain only one error, but this can change in the future.

> [!NOTE]
> We suggest API maintainers to return errors in the same format for consistency (but without errorCode). To know what HTTP status code to return, take a look [here](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status).

##### Detail

Contains a client-safe message explaining what went wrong.

##### ErrorCode

Contains an error code that can be used by the API maintainer to find out what went wrong:

> [!IMPORTANT]
> Do not share the explanation of these ErrorCodes with the API consumers. These are for internal use only.

|ErrorCode                       |Integer value|HTTP Status Code|Explanation|
|--------------------------------|-------------|----------------|-----------|
|EmptyRoute                      |1            |400             |The passed request route is empty.|
|InvalidRequestMethod            |3            |405             |The HTTP method is not valid, valid ones are [here](#http-methods).|
|DefinitionNotFound              |5            |404             |A definition with the passed route could not be found.|
|ManagerNotInitialized           |7            |503             |The UserDefinableApiManager in DataMiner is not initialized yet (check the C:\Skyline DataMiner\Logging\SLUserDefinableApiManager.txt log file, to see what went wrong).|
|UnexpectedException             |8            |500             |An unexpected exception occurred (check the C:\Skyline DataMiner\Logging\SLUserDefinableApiManager.txt log file, to see what went wrong).|
|InvalidActionMeta               |9            |500             |The [ActionMeta](xref:UD_APIs_Objects_ApiDefinition#actions) object does not match the specified `ActionType` in the ApiDefinition.|
|BodyToParametersConversionFailed|10           |400             |Something went wrong while trying to convert the body to a collection of key value parameters. [More info](xref:UD_APIs_Define_API#parameters)|
|InvalidActionType               |11           |500             |The `ActionType` that is specified in the [ApiDefinition](xref:UD_APIs_Objects_ApiDefinition) is not valid.|
|AutomationActionError           |12           |500             |An error occurred while trying to execute an automation script action.|
|InvalidAutomationActionResult   |13           |500             |The result returned by the automation script was null or invalid.|
|FailedToGetScriptInfo           |15           |500             |Could not get the script info required to execute the script.|
|MissingScriptParameters         |16           |400             |There are missing script parameters in the request body. The 'error' JSON object will contain the missing script parameters as an array in the `missingScriptParameters`.|
|NatsRequestFailed               |1001         |500             |Failed to send the NATS request to the DataMiner agent.|
|UnknownStatusCode               |1002         |500             |The ResponseCode returned by the automation script was invalid.|
|InvalidContentType              |1003         |415             |The [Content-Type](#content-type) HTTP header is not supported.|
|UnspecifiedErrorReason          |1004         |500             |DataMiner returned an 'unspecified' error code.|
|UnknownErrorReason              |1005         |500             |DataMiner returned an 'unknown' error code.|
|MessageBrokerNotInitialized     |1006         |503             |The MessageBroker and Session used to connect to NATS are not initialized yet.|
|FailedToReadBody                |1007         |500             |An exception was thrown while reading the request body.|
|AuthenticationHeaderInvalid     |1008         |401             |The HTTP [authentication](#authentication) header is not valid, make sure the token is passed as a Bearer Token.|
|BodyTooLarge                    |1009         |413             |The body size is limited to 30MB, this error will be thrown if the size is larger than that.|
|AuthenticationFailed            |1010         |401             |The passed secret is empty, invalid, disabled, cannot be found or is not allowed for this `ApiDefinition`.|

For some of these errors, more information will also be logged in the UserDefinableApiEndpoint.txt logfile. The location of this logfile is configurable, more info [here](xref:UD_APIs_UserDefinableApiEndpoint#logging).

##### FaultingNode

With some errors, a `faultingNode` will be passed. This is the DataMiner ID of the agent that executed the trigger. This can be used to know on what agent the logging should be checked if something went wrong.

##### MissingScriptParameters

If an error with reason `MissingScriptParameters` is returned, this array will contain the names of the missing script parameters.

## Client Test Tool

It is possible to trigger an API through the User Definable API UI in the Client Test Tool. It can be found under `Advanced > Apps > User Definable APIs...` on the `Trigger` tab.

![Client Test Tool Trigger Screenshot](~/user-guide/images/UDAPIS_ClientTestToolTrigger.jpg)

To trigger an API, simply select the API Definition in the dropdown. This will automatically fill in the route in the textbox below. Choose the `RequestMethod` from the dropdown and enter your secret in the Secret textbox. Optionally, you can fill in a request body in the large textbox on the bottom. When clicking 'Trigger', your request is sent and the response will appear along with some stats and info about your request. This is a great way to test your API while developing it, as it is easy to trigger.

## SLNet Message

You can trigger a user defined API by sending the `TriggerUserDefinableApiRequestMessage` SLNet message. This message returns a `TriggerUserDefinableApiResponseMessage`. This way could be useful for easily testing the API without having to send the actual HTTP request.

### TriggerUserDefinableApiRequestMessage

The request message contains the following properties:

|Property     |Type         |Explanation|
|-------------|-------------|-----------|
|RequestMethod|RequestMethod|Contains the HTTP request method. See [defining an API](xref:UD_APIs_Define_API#requestmethod).|
|Route        |string       |The route where the API is available on.|
|Secret       |string       |The secret that is needed to access the API. See [ApiToken](xref:UD_APIs_Objects_ApiToken#secret).|
|RawBody      |string       |Contains the request body as a string.|

### TriggerUserDefinableApiResponseMessage

Sending the `TriggerUserDefinableApiRequestMessage` returns the `TriggerUserDefinableApiResponseMessage`. This message contains the following properties:

|Property    |Type          |Explanation|
|------------|--------------|-----------|
|TraceData   |TraceData     |Contains `UserDefinableApiTriggerErrorData` in case something goes wrong. It can contain one of the following [reasons](#error-reasons).|
|ActionResult|IActionResult |Contains an `ActionResult`, for now, this will always be an [AutomationScriptActionResult](#automationscriptactionresult).|

#### Error Reasons

In case something goes wrong, the response will return `TraceData` in the form of `UserDefinableApiTriggerErrorData`. This will contain one of the following reasons:

|Reason                          |Description                                                                                                       |
|--------------------------------|------------------------------------------------------------------------------------------------------------------|
|EmptyRoute                      |The request route is empty.                                                                                       |
|InvalidSecret                   |Request secret is invalid.                                                                                        |
|InvalidRequestMethod            |Request method is invalid.                                                                                        |
|TokenNotFound                   |A token with the request secret could not be found.                                                               |
|DefinitionNotFound              |A definition linked to the passed route could not be found.                                                       |
|TokenNotAllowed                 |The token that is used is not allowed to be used for the definition.                                              |
|ManagerNotInitialized           |The UserDefinableApiManager is not initialized yet.                                                               |
|UnexpectedException             |An unexpected exception occurred. Check the logging for more info.                                                |
|InvalidActionMeta               |The `ApiDefinition.ActionMeta` property does not match the specified `ActionType`.                                |
|BodyToParametersConversionFailed|Something went wrong while trying to convert the body to a collection of key value parameters.                    |
|InvalidActionType               |The `ActionType` that is specified is not valid.                                                                  |
|AutomationActionError           |An error occurred while trying to execute an automation script action.                                            |
|InvalidAutomationActionResult   |The result returned by the automation script was null or invalid.                                                 |
|TokenDisabled                   |The token is disabled (IsDisabled is set to true) and is therefore not usable.                                    |
|GetScriptInfoFailed             |Could not get the script info required to execute the script. Does the script exist?                              |
|MissingScriptParameters         |There are missing script parameters in the request body, check the 'Parameters' property to check which are missing.|

#### AutomationScriptActionResult

The `AutomationScriptActionResult` contains the following properties:

|Property    |Type       |Explanation|
|------------|-----------|-----------|
|ResponseCode|int        |Contains the HTTP response code. See [defining an API](xref:UD_APIs_Define_API#responsecode) for more info.|
|ResponseBody|string     |Contains the response body returned by the automation script as a string.|
