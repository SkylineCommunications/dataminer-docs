---
uid: NuGetStages-EnumScope
---

# EnumScope simple type

Defines the scope of the configuration.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|all|The configuration will always be applied.|
|&nbsp;&nbsp;Enumeration|development|The configuration will only apply for development push to Git.|
|&nbsp;&nbsp;Enumeration|release|The configuration will only apply for release push to Git (tagged versions).|
