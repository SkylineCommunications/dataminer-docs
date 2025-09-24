---
uid: Skyline.DataMiner.DataSources.OpenConfig.Gnmi_7.x
---

# Skyline.DataMiner.DataSources.OpenConfig.Gnmi Range 7.x

## 7.1.0

#### Add support for configurable timeouts to GnmiClient operations [ID 43460]

Previously, the `Get`, `Set`, and `Capabilities` calls on a GnmiClient always used a fixed timeout of 5 seconds. These timeout values can now be configured individually per request. If no custom timeout is specified, the default of 5 seconds still applies.

Minimum required version: [CommunicationGateway 5.3.0](xref:CommunicationGateway_change_log#17-september-2025---enhancement---communicationgateway-530---configurable-grpc-call-timeouts-id-43460).

## 7.0.1

#### Fix - Improved middleware subscription handling in Communication Gateway [ID_42740]

All middleware subscriptions are now disposed of before disposing of the MessageBroker object, ensuring that no threads can get stuck. 

## 7.0.0

#### Fix - DataMapper unable to handle responses where type did not match actual value [ID 42762]

In some cases, it could occur that a response was indicated to be of type *Json* or *JsonIetf*, but the actual value was a JSON token instead of a JSON object. The DataMapper was unable to handle this, which caused issues. This has now been resolved.
