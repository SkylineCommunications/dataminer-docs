---
uid: ConnectionsHttpElementConfiguration
---

# Element configuration

In the IP address field, you can enter the IP address or host name of the server.

Specify "bypassProxy" in the Bus address field if you need to bypass the proxy server in the network.

## bypassProxy and proxyServer attribute

In a protocol, it is possible to specify a proxy to be used via the proxyServer attribute.

Suppose the proxyServer attribute references parameter 1. The following behavior is observed:

"bypassProxy" is set in bus address port setting:

- Parameter 1 denotes a proxy: requests will go through that proxy.
- Parameter 1 is empty or Not Initialized: requests will bypass any proxy.

"bypassProxy" is not set in bus address port setting:

- Parameter 1 denotes a proxy: requests will go through that proxy.
- Parameter 1 is empty or Not Initialized: requests will go through the default proxy (auto-discovery).

### See also

- [Protocol.HTTP.Session@proxyServer](xref:Protocol.HTTP.Session-proxyServer)
- [HTTP(S) connections](xref:HTTPS_Connection)
