---
metadata_version: 1
uid: ConnectionsHttpElementConfiguration
description: "Describe the DataMiner connector development topic Element configuration, including its purpose, behavior, implementation guidance, and relevant constrain."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Element configuration

In the IP address field, you can enter the IP address or host name of the server.

Specify `ByPassProxy` in the Bus address field if you need to bypass the proxy server in the network.

## ByPassProxy and proxyServer attribute

In a protocol, it is possible to specify a proxy to be used via the proxyServer attribute.

Suppose the proxyServer attribute references parameter 1. The following behavior is observed:

`ByPassProxy` is set in bus address port setting:

- Parameter 1 denotes a proxy: requests will go through that proxy.
- Parameter 1 is empty or Not Initialized: requests will bypass any proxy.

`ByPassProxy` is not set in bus address port setting:

- Parameter 1 denotes a proxy: requests will go through that proxy.
- Parameter 1 is empty or Not Initialized: requests will go through the default proxy (auto-discovery).

### See also

- [Protocol.HTTP.Session@proxyServer](xref:Protocol.HTTP.Session-proxyServer)
- [HTTP(S) connections](xref:HTTPS_Connection)
