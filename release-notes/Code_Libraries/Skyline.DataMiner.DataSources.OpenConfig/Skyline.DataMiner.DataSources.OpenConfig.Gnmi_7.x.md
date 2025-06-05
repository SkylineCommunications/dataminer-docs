---
uid: Skyline.DataMiner.DataSources.OpenConfig.Gnmi_7.x
---

# Skyline.DataMiner.DataSources.OpenConfig.Gnmi Range 7.x

## 7.0.0

#### Fix - DataMapper unable to handle responses where type did not match actual value [ID 42762]

In some cases, it could occur that a response was indicated to be of type *Json* or *JsonIetf*, but the actual value was JSON token instead of a JSON object. The DataMapper was unable to handle this, which caused issues. This has now been resolved.
