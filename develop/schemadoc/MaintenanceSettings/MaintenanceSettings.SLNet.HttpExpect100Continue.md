---
uid: MaintenanceSettings.SLNet.HttpExpect100Continue
---

# HttpExpect100Continue element

Defines whether or not to use the HTTP "Expect: 100-Continue" header on requests. This adds an extra roundtrip or maximum 350 ms delay to any HTTP POST request (e.g., .NET Remoting requests or callbacks). Note that this option affects all .NET Framework HTTP connections in the process. Default: false.

## Content Type

boolean

## Parents

[SLNet](xref:MaintenanceSettings.SLNet)
