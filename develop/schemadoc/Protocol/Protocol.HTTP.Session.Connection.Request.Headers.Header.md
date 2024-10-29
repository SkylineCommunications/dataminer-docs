---
uid: Protocol.HTTP.Session.Connection.Request.Headers.Header
---

# Header element

Specifies a parameter of which the contents will be put in one of the headers of the HTTP request.<!-- RN 5509 -->

## Type

string

## Parent

[Headers](xref:Protocol.HTTP.Session.Connection.Request.Headers)

## Attributes

|Name|Type|Required|Description|
|--- |--- |--- |--- |
|[key](xref:Protocol.HTTP.Session.Connection.Request.Headers.Header-key)|[HttpRequestHeader](xref:Protocol-HttpRequestHeader)|Yes|Specifies the key of the key/value pair.|
|[pid](xref:Protocol.HTTP.Session.Connection.Request.Headers.Header-pid)|unsignedInt||Specifies the ID of the parameter that contains the value to be put in the header.|

## Remarks

- Via HTTP, this has to be done by means of key/value pairs.

- A value of type string that specifies the value of the header.

- By default, when a DataMiner protocol uses `<Parameters>` or `<Data>` tags to send data to an HTTP server via an HTTP connection, the SLPort process converts the data to UTF-8. However, you can also specify a character set in the Content-Type request header and encode the data sent using `<Data pid="x" />`.<!-- RN 17214 -->

  For example, if you specify the following request header, the data to be sent will have to be encoded using ISO-8859-1 encoding. The SLPort process will not do any encoding.

  ```xml
  <Header key="Content-Type">text/plain; charset=ISO-8859-1</Header>
  ```

- HTTP requests executed from DataMiner protocols via SLPort will automatically include the following header to support gzip and deflate compression:<!-- RN 20462 -->

  `Accept-Encoding: gzip, deflate`

- For requests using the POST or PUT verb, the content length is set by DataMiner. Therefore, the Content-Length header must not be specified in the protocol.

- DataMiner automatically includes the "User-Agent: DataMiner/1.0" and the "Connection: Keep-Alive" headers in the requests. Therefore, these headers should not be provided in the protocol unless another header value is desired.

## Examples

If you specify ...

```xml
<Header key="Content-Type">application/soap+xml; charset=utf-8</Header>
<Header key="SOAPAction">http://www.skyline.be/api/v1/ConnectApp</Header>
```

... this will send a SOAP envelope and parse it into the following header:

```xml
<ConnectApp xmlns="http://www.skyline.be/api/v1/">
...
</ConnectApp>
```
