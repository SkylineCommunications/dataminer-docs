---
uid: UD_APIs_Triggering_an_API
---

# Triggering a user-defined API

To trigger an API, you can send an HTTP or HTTPS request to the *UserDefinableApiEndpoint* DxM.

> [!NOTE]
>
> - You can also trigger a user-defined API through the [SLNetClientTest Tool](xref:SLNetClientTest_triggering_api) for testing. This will bypass the endpoint DxM and go directly to the API manager in SLNet, which can be useful to efficiently test and verify API scripts without the need to send an HTTP request. However, note that you should always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
> - API triggers are handled in parallel. To protect DataMiner, there is a limit to the number of concurrent triggers. As soon as that limit is reached, new triggers are added to a queue, to be handled as soon as another trigger is finished. It is not possible to adjust this limit, as it is automatically set based on the number of logical processors in the system (with a minimal concurrency of 4). The exact limit is logged in the file `C:\Skyline DataMiner\Logging\SLUserDefinableApiManager.txt`. Apart from this limit implemented by DataMiner, IIS for Windows 10 also has a concurrency limit of 10. IIS for Windows Server has no limits.

## Building the HTTP request

To test sending a request, you can use a tool like Postman.

### URL

To send a request to *UserDefinableApiEndpoint*, use a URL in the format `http(s)://{hostname}/api/custom/{route}`. (See [Route](xref:UD_APIs_Define_New_API#route).)

Examples:

```
http://staging-agent-b3/api/custom/switchers/status
https://production-agent-a1/api/custom/encoder/main/status
```

### HTTP methods

The following HTTP methods are supported: GET, PUT, POST, DELETE.

> [!NOTE]
> You are free to choose which of these methods your API will support.

### Authentication

To authenticate yourself to the API, add a `Bearer` authorization header to your request containing the secret.

Example of the header:

```
Bearer 24te8bRBOhrDj6TkXkim4qh9GpDXsdGudib57j7C/CU=
```

### Content-Type

In case the API needs input from the user using the HTTP body, you need to specify a Content-Type header.

The endpoint supports the following content types:

- application/json
- application/xml
- text/xml
- text/plain

> [!NOTE]
> Adding no Content-Type header to a request is also supported. In this case, the body is expected to be empty.

### Content-Length

The Content-Length header is calculated and filled in automatically depending on how you send the request. It contains the length of the body in bytes. *UserDefinableApiEndpoint* will only read the number of bytes of the body specified in the Content-Length header.

> [!IMPORTANT]
> The endpoint limits the size of requests to 30 MB.

### Body

An API can expect input. This input is passed in the body. The format of the input is defined in the definition of the API. If the API definition is set to accept parameters, these are expected to be passed as JSON in a key-value format. See [User input data](xref:UD_APIs_Define_New_API#user-input-data).

The body is expected to be encoded in UTF-8.

## The response

The API returns an HTTP status code indicating the status of the request and a body.

In case some input from the user is missing, or the user sends a request with a wrong HTTP method, the API can return an HTTP status code indicating the error and a JSON body with more information, depending on how the script is designed.

The endpoint itself can also return [errors](#errors) with corresponding status code to indicate something went wrong before the script was executed.

The API will always return responses encoded in UTF-8.

### CORS

User-defined APIs will not return any CORS headers<!-- RN 36727 -->. It will therefore not be possible to trigger a user-defined API directly from a web client. It is not safe to trigger user-defined APIs from a web client using e.g. AJAX calls in JavaScript, because there is no way to safely save and use the API tokens there.

### Errors

The endpoint can return an error if something goes wrong. An error will be returned in the following format, with an HTTP response code indicating that something went wrong:

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
> We recommend that API maintainers return errors in the same format for the sake of consistency (but without *errorCode*). To know what HTTP status code to return, take a look [here](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status).

#### detail

The *detail* field of an error contains a client-safe message explaining what went wrong.

#### errorCode

The *errorCode* field of an error contains an error code that can be used by the API maintainer to find out what went wrong:

| ErrorCode | Integer value | HTTP Status Code | Description |
|--|--|--|--|
| EmptyRoute | 1 | 400 | The passed request route is empty. |
| InvalidRequestMethod | 3 | 405 | The HTTP method is not valid. For the valid methods, see [HTTP methods](#http-methods). |
| DefinitionNotFound | 5 | 404 | A definition with the passed route could not be found. |
| ManagerNotInitialized | 7 | 503 | The *UserDefinableApiManager* in DataMiner has not been initialized yet. To see what went wrong, check the log file `C:\Skyline DataMiner\Logging\SLUserDefinableApiManager.txt`. |
| UnexpectedException | 8 | 500 | An unexpected exception occurred. To see what went wrong, check the log file `C:\Skyline DataMiner\Logging\SLUserDefinableApiManager.txt`. |
| InvalidActionMeta | 9 | 500 | The `ActionMeta` object does not match the specified `ActionType` in the API definition. |
| BodyToParametersConversionFailed | 10 | 400 | Something went wrong while trying to convert the body to a collection of key value parameters. See [User input data](xref:UD_APIs_Define_New_API#user-input-data). |
| InvalidActionType | 11 | 500 | The `ActionType` that is specified in the API definition is not valid. |
| AutomationActionError | 12 | 500 | An error occurred while trying to execute an Automation script action. |
| InvalidAutomationActionResult | 13 | 500 | The result returned by the Automation script was null or invalid. |
| FailedToGetScriptInfo | 15 | 500 | Could not get the script info required to execute the script. |
| MissingScriptParameters | 16 | 400 | There are missing script parameters in the request body. The "error" JSON object will contain the missing script parameters as a `missingScriptParameters` array. |
| NatsRequestFailed | 1001 | 500 | Failed to send the NATS request to the DataMiner Agent. |
| UnknownStatusCode | 1002 | 500 | The response code returned by the Automation script was invalid. |
| InvalidContentType | 1003 | 415 | The [Content-Type](#content-type) HTTP header is not supported. |
| UnspecifiedErrorReason | 1004 | 500 | DataMiner returned an "unspecified" error code. |
| UnknownErrorReason | 1005 | 500 | DataMiner returned an "unknown" error code. |
| MessageBrokerNotInitialized | 1006 | 503 | The message broker and session used to connect to NATS have not been initialized yet. |
| FailedToReadBody | 1007 | 500 | An exception was thrown while reading the request body. |
| AuthenticationHeaderInvalid | 1008 | 401 | The HTTP [authentication](#authentication) header is not valid. Make sure the token is passed as a `Bearer` token. |
| BodyTooLarge | 1009 | 413 | The body size is limited to 30 MB. This error will be thrown if the size is larger than that. |
| AuthenticationFailed | 1010 | 401 | The passed secret is empty, is invalid, is disabled, cannot be found, or is not allowed for this API definition. |

> [!NOTE]
> For some of these errors, more information will also be logged in the *UserDefinableApiEndpoint.txt* log file. The location of this log file depends on the [UserDefinableApiEndpoint configuration](xref:UD_APIs_UserDefinableApiEndpoint#consulting-logging-for-the-dxm).

#### faultingNode

Some errors will mention an ID in the *faultingNode* field. This is the DataMiner ID of the DMA that executed the trigger. This can be used to know on which Agent the logging should be checked when something goes wrong.

#### missingScriptParameters

If an error with reason *MissingScriptParameters* is returned, the *missingScriptParameters* array will contain the names of the missing script parameters.
