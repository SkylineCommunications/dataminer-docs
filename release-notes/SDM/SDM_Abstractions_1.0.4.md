---
uid: SDM_Abstractions_1.0.4
description: "Find out about the SDM Abstractions 1.0.4 update, including a fix for dynamic filters on collections of object references."
---

# SDM Abstractions 1.0.4

## Fixes

### Dynamic filters on collections of references could throw exceptions [ID 46138]

Previously, dynamic filters could fail when built for collections of `SdmObjectReference<T>` fields.

Dynamic filter creation now correctly resolves the required comparison logic for these fields.
