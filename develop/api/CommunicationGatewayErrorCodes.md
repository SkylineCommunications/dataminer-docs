---
uid: CommunicationGateway_ErrorCodes
---

# CommunicationGateway error codes

Errors can be returned by the DataMiner CommunicationGateway extension module. In the tables below, an overview is shown of these error codes.

## gRPC error codes

These are the error codes that can be returned when the CommunicationGateway is communicating with a gRPC service. These are usually the errors that are returned by the gRPC service, i.e. the data source that is communicated with.

|Name|Friendly Name|Code|Message|
|--- |--- |--- |--- |
|OK|Okay|0|Returned on success, not an error.|
|Canceled|Canceled|1|The operation was canceled, typically by the caller.|
|Unknown|Unknown|2|Unknown error. The API did not return enough error information to be converted into a specific error.|
|InvalidArgument|Invalid argument|3|The client specified an invalid argument. Note that this is different from FailedPrecondition. InvalidArgument indicates arguments that are problematic regardless of the system state.|
|DeadlineExceeded|Deadline exceeded|4|The deadline expired before the operation could complete. Note that this error may be returned even if the operation has completed successfully. E.g. a successful response could have been delayed long.|
|NotFound|Not found|5|Requested entity (e.g. file) was not found.|
|AlreadyExists|Already exists|6|Attempted to create an entity (e.g. file) that already exists.|
|PermissionDenied|Permission denied|7|The caller does not have permission to execute the specified operation.|
|ResourceExhausted|Resources exhausted|8|Some resource has been exhausted. This could be a per-user quota, or the entire file system could be out of space.|
|FailedPrecondition|Failed precondition|9|The operation was rejected because the system is not in a state required for the operation's execution. E.g. the directory to be deleted is non-empty, an rmdir operation is applied to a non-directory, etc.|
|Aborted|Aborted|10|The operation was aborted, typically because of a concurrency issue such as a sequencer check failure or transaction abort.|
|OutOfRange|Out of range|11|The operation was attempted past the valid range. E.g. seeking or reading past end of file.|
|Unimplemented|Unimplemented|12|The operation is not implemented or is not supported/enabled in this service.|
|Internal|Internal|13|Reserved for serious errors. This means that some invariants expected by the underlying system have been broken. This error could be returned when an HTTPS connection is used and there is something wrong with the certificate (expired, root authority not trusted, etc.). Check the CommunicationGateway logging for more detailed error information.|
|Unavailable|Unavailable|14|The service is currently unavailable. This can most likely be corrected by retrying after waiting a little bit. This error can also be returned when the TCP socket with the data source is not available. Is the IP of the data source reachable or is there a firewall blocking the connection? Check the CommunicationGateway logging for more detailed error information.|
|DataLoss|Data loss|15|Unrecoverable data loss or corruption.|
|Unauthenticated|Unauthenticated|16|The request does not have valid authentication credentials for the operation.|

## Channel management handler error codes

These are the error codes that can be returned when creating/connecting or disconnecting a handler in the CommunicationGateway.

|Name|Friendly Name|Code|Message|
|--- |--- |--- |--- |
|ChannelManagementHandler_ConnectRequest_InvalidChannelInstance|Channel management ConnectRequest has invalid instance GUID|1001001|The ConnectRequest did not provide a usable channel instance GUID, which is needed as a message broker subject token. This should be a hex-string GUID without separators.|
|ChannelManagementHandler_ConnectRequest_CreateChannelFailed|Channel management ConnectRequest's CreateChannel failed|1001002|The ConnectRequest failed to create a channel. Check the CommunicationGateway logging for more detailed error information. There is likely a problem with the provided channel configuration.|
|ChannelManagementHandler_ConnectRequest_FailedToComplete|Channel management ConnectRequest failed to complete|1001003|The ConnectRequest failed to complete when creating the gNMI handler. Check the CommunicationGateway logging for more detailed error information.|
|ChannelManagementHandler_DisconnectRequest_FailedToComplete|Channel management DisconnectRequest failed to complete|1001004|The DisconnectRequest failed to complete when releasing the channel and cleaning up resources. Check the CommunicationGateway logging for more detailed error information.|
|ChannelManagementHandler_ConnectRequest_InvalidMessage|Channel management invalid ConnectRequest|1001005|The ConnectRequest could not be parsed. This topic should send a Request message containing a ConnectRequest.|
|ChannelManagementHandler_DisconnectRequest_InvalidMessage|Channel management invalid DisconnectRequest|1001006|The DisconnectRequest could not be parsed. This topic should send a Request message containing a DisconnectRequest.|
|ChannelManagementHandler_ConnectRequest_AlreadyRegistered|Channel management already registered|1001007|The ConnectRequest did not create a new channel since it has already been registered.|
|ChannelManagementHandler_ConnectRequest_UnknownServiceType|Channel management unknown service type|1001008|The ConnectRequest contains a service type in the ChannelId that is not supported.|

## gNMI handler error codes

These are the error codes that can be returned when asking the gNMI handler in the CommunicationGateway to send something to the gRPC service.

|Name|Friendly Name|Code|Message|
|--- |--- |--- |--- |
|GnmiHandler_SubscribeRequest_MissingSubscriptionName|gNMI handler SubscribeRequest is missing subscription name|1002001|The SubscribeRequest did not find a token in the request subject that it could use to identify the subscription with. Make sure the subject is properly formatted. The token after the SubscribeRequestCommandToken should not be an empty nor a whitespace string.|
|GnmiHandler_SubscribeRequest_ActiveHandlerNotFound|gNMI handler SubscribeRequest's active handler not found|1002002|The SubscribeRequest's subscription ID (name) could not be found amongst the active subscription handlers. Has the subscription been registered before the gNMI details were sent through a SubscribeRequest?|
|GnmiHandler_RegisterSubscriptionRequest_InvalidSubscriptionName|gNMI handler Register subscription received invalid subscription name|1002003|The RegisterSubscriptionRequest contained a SubscriptionId with a SubscriptionName that can not be used as a message broker subject token.|
|GnmiHandler_RegisterSubscriptionRequest_DuplicateSubscriptionId|gNMI handler Register subscription received duplicate subscription ID|1002004|The RegisterSubscriptionRequest contained a SubscriptionId that is already registered. No further actions were taken. Sending a SubscribeRequest for this SubscriptionId may interfere with an existing subscription.|
|GnmiHandler_UnregisterSubscriptionRequest_UnknownSubscriptionId|gNMI handler Register subscription received an unknown subscription ID|1002005|The UnregisterSubscriptionRequest contained a SubscriptionId that is not known. Either it was already unregistered, or the wrong SubscriptionId was provided.|
|GnmiHandler_GetRequest_InvalidMessage|gNMI handler invalid GetRequest|1002006|The GetRequest could not be parsed, this topic should send a Request message containing a GetRequest.|
|GnmiHandler_GetRequest_UnexpectedFail|gNMI handler Get failed without status code|1002007|The GetAsync call threw an exception from which an error code could not be extracted. Check the CommunicationGateway logging for more information.|
|GnmiHandler_SetRequest_InvalidMessage|gNMI handler invalid SetRequest|1002008|The SetRequest could not be parsed, this topic should send a Request message containing a SetRequest.|
|GnmiHandler_SetRequest_UnexpectedFail|gNMI handler Set failed without status code|1002009|The SetAsync call threw an exception from which an error code could not be extracted. Check the CommunicationGateway logging for more information.|
|GnmiHandler_CapabilityRequest_InvalidMessage|gNMI handler invalid CapabilityRequest|1002010|The SetRequest could not be parsed, this topic should send a Request message containing a CapabilityRequest.|
|GnmiHandler_CapabilityRequest_UnexpectedFail|gNMI handler Capabilities failed without status code|1002011|The CapabilitiesAsync call threw an exception from which an error code could not be extracted. Check the CommunicationGateway logging for more information.|
|GnmiHandler_RegisterSubscriptionRequest_InvalidMessage     |gNMI handler invalid RegisterSubscriptionRequest|1002012|The RegisterSubscriptionRequest could not be parsed, this topic should send a Request message containing a RegisterSubscriptionRequest.|
|GnmiHandler_RegisterSubscriptionRequest_TryAddFailed|gNMI handler Register subscription TryAdd failed|1002013|The RegisterSubscriptionRequest contained a SubscriptionId that could not be added after checking for duplicate IDs. This can happen when the same request is sent in parallel.|
|GnmiHandler_UnregisterSubscriptionRequest_InvalidMessage|gNMI handler invalid UnregisterSubscriptionRequest|1002014|The UnregisterSubscriptionRequest could not be parsed. This topic should send a Request message containing a GetRequest.|
|GnmiHandler_SubscriptionRequest_InvalidMessage|gNMI handler invalid SubscriptionRequest|1002015|The SubscriptionRequest could not be parsed. This topic should send a Request message containing a SubscriptionRequest.|
|GnmiHandler_RegisterSubscriptionRequest_MissingSubscriptionId|gNMI handler Register subscription did not receive a subscription ID|1002016|The RegisterSubscriptionRequest contained a SubscriptionId that was null or empty.|

## gNMI client error codes

These are the error codes that can be returned from the OpenConfig Library middleware that is communicating with the CommunicationGateway.

|Name|Friendly Name|Code|Message|
|--- |--- |--- |--- |
|GnmiClient_RegisterSubscriptionRequest_UnexpectedFail|gNMI client RegisterSubscriptionRequest failed|1003001|The RegisterSubscriptionRequest returned a null, the registration failed, or the channel was closed.|
|GnmiClient_SubscribeRequest_UnexpectedFail|gNMI client SubscribeRequest failed|1003002|The SubscribeRequest returned a null, the registration failed, or the channel was closed.|
|GnmiClient_ConnectRequest_Timeout|gNMI client ConnectRequest timed out|1003003|The ConnectRequest timed out. No response was received from the CommunicationGateway.|
|GnmiClient_ConnectRequest_NullResponse|gNMI client ConnectRequest returned a null response|1003004|The ConnectRequest returned a null response.|
|GnmiClient_ConnectRequest_NullParsing|gNMI client ConnectRequest returned a response that could not be parsed|1003005|The ConnectRequest returned a response, and when that was parsed, it resulted in a null.|
|GnmiClient_CapabilityRequest_NullResponse|gNMI client CapabilityRequest returned a null response|1003006|The CapabilityRequest returned a null response.|
|GnmiClient_GetRequest_NullResponse|gNMI client GetRequest returned a null response|1003007|The GetRequest returned a null response.|
|GnmiClient_SetRequest_NullResponse|gNMI client SetRequest returned a null response|1003008|The SetRequest returned a null response.|
|GnmiClient_MessageBrokerSubscribe_UnexpectedFail|gNMI client could not subscribe to the message broker|1003009|Failed to subscribe to a response subject on the message broker.|
