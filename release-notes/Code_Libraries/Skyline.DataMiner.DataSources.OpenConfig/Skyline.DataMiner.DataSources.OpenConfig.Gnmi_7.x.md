---
uid: Skyline.DataMiner.DataSources.OpenConfig.Gnmi_7.x
---

# Skyline.DataMiner.DataSources.OpenConfig.Gnmi Range 7.x

## 7.1.0

#### Add support for configurable timeouts to GnmiClient operations [ID 43460]

Previously, the `Get`, `Set`, and `Capabilities` calls on a GnmiClient always used a fixed timeout of 5 seconds. These timeout values can now be configured individually per request. If no custom timeout is specified, the default of 5 seconds still applies.

Alongside this change, The OpenConfig library has been updated to the latest *Skyline.DataMiner.DataSources.CommunicationGatewayMiddleware.OpenConfig* version (i.e. 5.3.0).

## 7.0.0

#### Fix - DataMapper unable to handle responses where type did not match actual value [ID 42762]

In some cases, it could occur that a response was indicated to be of type *Json* or *JsonIetf*, but the actual value was a JSON token instead of a JSON object. The DataMapper was unable to handle this, which caused issues. This has now been resolved.
