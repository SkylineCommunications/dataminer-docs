---
uid: ConnectionsHttpImplementing
description: To periodically request information from a device via HTTP, the approach is very similar to serial communication.
---

# Implementing HTTP communication

Periodically requesting information from a device via HTTP can be done as follows:

![Implementing HTTP communication](~/develop/images/Connection_Types_-_HTTP_Session_Building_Blocks.svg)

The approach is very similar to serial communication: with HTTP, the content of the group will be a session, whereas with serial communication a pair is used.

> [!NOTE]
> An example protocol "Skyline Example HTTP" is available in the [SkylineCommunications/SLC-C-Example_HTTP](https://github.com/SkylineCommunications/SLC-C-Example_HTTP) GitHub repository.

## Session

Here you can define the login method and login credentials if needed and possible proxy settings using the "loginmethod", "username" and "password" attributes.

In case credentials are specified, the DMA will first try authentication using the Basic Authentication scheme, since that one uses pre-authentication. If a 401 response (unauthorized) is returned, the response header will indicate which authentication schemes are allowed and DataMiner will try to authenticate again by using one of these.

A session contains one or more connections which in turn contain a request and response.

### Request

The following example shows an implementation of an HTTP request:

```xml
<Request verb="POST" url="/EquipmentInventoryRetrieval">
   <Headers>
      <Header key="Content-Type">text/xml;charset=UTF-8</Header>
      <Header key="SOAPAction">getAllEquipment</Header>
      <Header key="Accept-Encoding">gzip,deflate</Header>
   </Headers>
   <Data pid="101"></Data>
</Request>
```

Using the *verb* attribute, the request defines which HTTP method (or verb) is to be used, e.g. "GET", "POST", "PUT", etc.

The *url* attribute defines the path, optionally including a query string and/or fragment string.

> [!NOTE]
>
> - Instead of using the *url* attribute, you can specify the ID of a parameter that holds the request path. This is done using the *pid* attribute:
>
>   ```xml
>   <Request verb="GET" url="/barco-webservice/rest/NetworkWall/alarm">
>   <Request verb="GET" pid="5045"> <!-- content parameter 5045: "barco-webservice/rest/NetworkWall/alarm" -->
>   ```
>
>   - In case the *pid* attribute is used, parameter 5045 does not need a leading slash ("/").
>   - The parameter referred to in the *pid* attribute must be of type `string`.
>   - In case both the *url* and *pid* attributes are specified, the *pid* attribute will be ignored. Typically, only one of these attributes is specified.
>
> - It is also possible to specify an absolute URL (e.g. `http://google.com`), which possibly specifies another host (or IP address/port) than the one specified in the corresponding element connection.

However, this should be used only when there is no other option, because when the specified host becomes unavailable, the element will go into timeout, giving the impression that the host specified in the element wizard is no longer available.

Including a request header (e.g. "Accept", "Content-Type", "Content-Length", etc.) is possible by defining a header. See [Protocol.HTTP.Session.Connection.Request.Headers.Header](xref:Protocol.HTTP.Session.Connection.Request.Headers.Header).

By using either Data or Parameters, you can send data along with the HTTP request. See [Protocol.HTTP.Session.Connection.Request.Data](xref:Protocol.HTTP.Session.Connection.Request.Data) and [Protocol.HTTP.Session.Connection.Request.Parameters](xref:Protocol.HTTP.Session.Connection.Request.Parameters).

> [!IMPORTANT]
> DataMiner does not perform any encoding on the provided data. Therefore, if you are, for example, building a URL for a GET request with a query string or the body of a POST request with content type "application/x-www-form-urlencoded", you must ensure that the data is using [percent-encoding](https://datatracker.ietf.org/doc/html/rfc3986#section-2.1) (also known as URL encoding) to avoid misinterpretation of the provided data. Otherwise, the provided data might be misinterpreted by the server in case the data contains characters from the [reserved character set](https://datatracker.ietf.org/doc/html/rfc3986#section-2.2) (e.g. '&amp;').

> [!NOTE]
> Either *Parameters* or *Data* should be used, not both. If both are used together, only the content of *Parameters* will be included in the request.

The content specified in Data will either be appended unaltered to the URL (in case of GET request) or put in the body (POST request).

For example, consider the following request:

```xml
<Request verb="GET" url="Example.html">
  <Data>This is example data.</Data>
</Request>
```

When GET is specified as the request verb, the resulting request is as follows:

```
GET http://127.0.0.1:8888/Example.htmlThis%20is%20example%20data. HTTP/1.1
Connection: Keep-Alive
User-Agent: DataMiner/1.0
Host: 127.0.0.1:8888
```

When POST is specified as the request verb, the resulting request is as follows:

```
POST http://127.0.0.1:8888/Example.html HTTP/1.1
Connection: Keep-Alive
User-Agent: DataMiner/1.0
Content-Length: 21
Host: 127.0.0.1:8888


This is example data.
```

The content specified in Parameters will either be appended to the URL (in case of GET request) or put in the body (POST request).

For example, consider the following request:

```xml
<Request verb="GET" url="Example.html">
   <Parameters>
      <Parameter key="a">Example value!</Parameter>
      <Parameter key="b">20</Parameter>
   </Parameters>
</Request>
```

The resulting request is:

```
GET http://127.0.0.1:8888/Example.html?b=20&a=Example%20value HTTP/1.1
Connection: Keep-Alive
User-Agent: DataMiner/1.0
Host: 127.0.0.1:80
```

In case the same request is sent, but now specifying POST as verb, the result is the following request:

```
POST http://127.0.0.1:8888/Example.html HTTP/1.1
Connection: Keep-Alive
User-Agent: DataMiner/1.0
Content-Length: 20
Host: 127.0.0.1:8888
 

b=20&a=Example value
```

### Response

In the response, it is possible to capture the status line, headers and body of the response message.

The following example gives an overview of how to capture the different parts of the response:

```xml
<Response statusCode="1001">
  <Headers>
    <Header key="Content-Type" pid="1002"></Header>
  </Headers>
  <Content pid="1000"></Content>
</Response>
```

Using the statusCode attribute, you can specify the ID of the parameter in which the status line (e.g. "HTTP/1.1 200 OK") should be put.

> [!NOTE]
>
> - DataMiner behaves as follows based on the received status code (RN 5132):
>
>   - 2xx (Success): No additional action is performed.
>   - 3xx (Redirection): In case the location response header is present, automatically redirect (301 ""Moved permanently"", 303 "See other", 307 "Temporary redirect", etc.). Note that in case this automatic redirection is not desired, this can be disabled by specifying the [customRedirect](xref:Protocol.Type-communicationOptions#customredirect) communication option. If customRedirect is specified, the protocol implements the redirection logic. In case nothing is done, the element will go into timeout. In case no location response header is returned (300: Multiple choices, 306: Unused), the element will go into timeout.
>   - 4xx (Client error): The element will go into timeout.
>   - 5xx (Server error): The element will go into timeout.
>
> - HTTP communication logging can be enabled by setting information logging to level 3 (RN 14439).
> - A retry mechanism (as configured in the element connection settings) is triggered when an HTTP request times out (i.e. upon reception of the WINHTTP_ERROR_TIMEOUT error) and when the SLPort process is unable to connect to the web server (i.e. upon reception of the ERROR_WINHTTP_CANNOT_CONNECT error).<!-- RN 13111 -->

> [!TIP]
> See also: [Change-based event handling](xref:InnerWorkingsChangeBasedEventHandling)

The value of a header can be captured by defining a header (see [Protocol.HTTP.Session.Connection.Response.Headers.Header](xref:Protocol.HTTP.Session.Connection.Response.Headers.Header)) and specifying the name of the header and the ID of the parameter in which the value should be put.

The message body can be captured by specifying the ID of the parameter in which the body should be put in Content (see [Protocol.HTTP.Session.Connection.Response.Content](xref:Protocol.HTTP.Session.Connection.Response.Content)).

## See also

- [Configuring port settings](xref:Connections#configuring-port-settings) for recommended HTTP(S) port settings
