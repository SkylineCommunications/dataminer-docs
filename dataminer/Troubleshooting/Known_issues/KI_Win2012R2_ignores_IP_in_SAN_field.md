---
uid: KI_Win2012R2_ignores_IP_in_SAN_field
---

# IP address in SAN field of TLS certificate ignored in Windows 2012 R2

## Affected versions

Systems using the Windows 2012 R2 operating system.

## Cause

An issue in Windows 2012 R2 causes the IP address defined in the SAN field of a TLS certificate to be ignored.

## Fix

No fix is available yet.

> [!NOTE]
> Support for Windows 2012 R2 [ends in October 2023](https://learn.microsoft.com/en-us/lifecycle/announcements/windows-server-2012-r2-end-of-support).

## Description

When a TLS certificate is used with an IP address in its Subject Alternative Name (SAN) field, there may be errors of type "trust not granted" when you use this IP address.

For example, when you connect to Elasticsearch using TLS, the following error can be displayed:

```
2023/03/15 17:01:16.785|SLDBConnection|RawCommunication|ERR|0|1|URL: https://10.11.63.58:9200/_cluster/settings
Elasticsearch.Net.ElasticsearchClientException: Failed sniffing cluster state.. Call: unknown resource --->........

 ...... System.Net.WebException: The underlying connection was closed: Could not establish trust relationship for the SSL/TLS secure channel. ---> System.Security.Authentication.AuthenticationException: The remote certificate is invalid according to the validation procedure.
```

Note that it depends on the browser you use whether you get this error: You will get this error in Internet Explorer, but not in Google Chrome.
