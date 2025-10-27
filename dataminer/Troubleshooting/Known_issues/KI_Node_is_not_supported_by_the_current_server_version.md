---
uid: KI_Node_is_not_supported_by_the_current_server_version
---

# Node: 'X' is not supported by the current server version

## Affected versions

DataMiner 10.3.2

## Cause

A code change intended to make the web API backwards compatible with older server versions.

## Fix

Install DataMiner 10.3.2 [CU1] or 10.3.3.

## Issue description

When, after a DataMiner restart or a DataMiner upgrade, you opened a low-code app that retrieved ad hoc data using GQI queries, in some cases, an error message similar to the following one could appear:

```txt
Node: 'Custom data' is not supported by the current server version.
```

## Workaround

Restart IIS.
