---
uid: ConnectionsHttp
---

# HTTP

IETF defines the Hypertext Transfer Protocol (HTTP) as follows: "HTTP is a stateless application-level request/response protocol that uses extensible semantics and self-descriptive message payloads for flexible interaction with network-based hypertext information systems".

Many devices support HTTP communication (e.g., returning XML data as a response to a specific GET request or allowing XML or JSON data to be sent to configure the device).

DataMiner supports HTTP communication, allowing protocols to define one or more connections of type "http". DataMiner runs a process called "SLPort" which takes care of all communication from and to devices connected to either a serial port or an IP port.

When multiple elements are polling the same URL, they all create their own connection. Also, when an element has two HTTP interfaces that point to the same URL, this results in two connections.

A connection to the data source is created before each "Session" and closed again after the last request within that "Session".

> [!NOTE]
> For more information about HTTP, refer to:
>
> - HTTP/1.1: RFC 7230, RFC 7231, RFC 7232, RFC 7233, RFC 7234, RFC 7235
> - HTTP/2: RFC 7540

## See also

- [Slow poll mode ping group](xref:ConnectionsPingGroup)

DataMiner Protocol Markup Language:

- [Protocol.HTTP](xref:Protocol.HTTP)
- [Protocol.Params.Param.Type@options](xref:Protocol.Params.Param.Type-options):
  - [ssh pwd](xref:Protocol.Params.Param.Type-options#ssh-pwd)
  - [ssh username](xref:Protocol.Params.Param.Type-options#ssh-username)
