---
uid: Protocol-EnumHttpRequestHeader
---

# EnumHttpRequestHeader simple type

List of headers that can only appear in HTTP responses.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|A-IM|The A-IM request-header field is similar to Accept, but restricts the instance-manipulations (section 10.1) that are acceptable in the response. As specified in section 10.5.2, a response may be the result of applying multiple instance-manipulations (RFC 3229).|
|&nbsp;&nbsp;Enumeration|Accept|Indicates which content types (expressed as MIME types) the client is able to understand.|
|&nbsp;&nbsp;Enumeration|Accept-Charset|Indicates which character set the client is able to understand.|
|&nbsp;&nbsp;Enumeration|Accept-Datetime|Indicates that the user agent wants to access a past state of an Original Resource.|
|&nbsp;&nbsp;Enumeration|Accept-Encoding|Indicates which content encoding, usually a compression algorithm, the client is able to understand.|
|&nbsp;&nbsp;Enumeration|Accept-Features|Can be used by a user agent to give information about the presence or absence of certain features in the feature set of the current request. Servers can use this information when running a remote variant selection algorithm (RFC 2295).|
|&nbsp;&nbsp;Enumeration|Accept-Language|Indicates which languages the client is able to understand, and which locale variant is preferred.|
|&nbsp;&nbsp;Enumeration|Access-Control-Request-Headers|Used when issuing a preflight request to let the server know which HTTP headers will be used when the actual request is made.|
|&nbsp;&nbsp;Enumeration|Access-Control-Request-Method|Used when issuing a preflight request to let the server know which HTTP method will be used when the actual request is made. This header is necessary as the preflight request is always an OPTIONS and doesn't use the same method as the actual request.|
|&nbsp;&nbsp;Enumeration|Allow|Lists the set of methods support by a resource.|
|&nbsp;&nbsp;Enumeration|ALPN|Clients include the ALPN header field in an HTTP CONNECT request to indicate the application-layer protocol that a client intends to use within the tunnel, or a set of protocols that might be used within the tunnel (RFC 7639).|
|&nbsp;&nbsp;Enumeration|Apply-To-Redirect-Ref|The optional Apply-To-Redirect-Ref header can be used on any request to a redirect reference resource. When it is present and set to "T", the request MUST be applied to the reference resource itself, and a 3xx response MUST NOT be returned (RFC 4437).|
|&nbsp;&nbsp;Enumeration|Authorization|Contains the credentials to authenticate a user agent with a server, usually after the server has responded with a 401 Unauthorized status and the WWW-Authenticate header.|
|&nbsp;&nbsp;Enumeration|C-Man|(RFC 2774).|
|&nbsp;&nbsp;Enumeration|Cache-Control|Specifies directives for caching mechanisms in both requests and responses. Caching directives are unidirectional, meaning that a given directive in a request is not implying that the same directive is to be given in the response.|
|&nbsp;&nbsp;Enumeration|CalDAV-Timezones|The "CalDAV-Timezones" request header field provides a way for a client to indicate to the server whether it wants "VTIMEZONE" components returned in any iCalendar data that is part of the HTTP response. The value "T" indicates that the client wants time zone data returned; the value "F" indicates that it does not.(RFC 7809).|
|&nbsp;&nbsp;Enumeration|Compliance|Allows a client to specify exactly what options it is asking about, and which allows a server to specify exactly what subset of those options are supported.|
|&nbsp;&nbsp;Enumeration|Connection|Controls whether or not the network connection stays open after the current transaction finishes. If the value sent is keep-alive, the connection is persistent and not closed, allowing for subsequent requests to the same server to be done.|
|&nbsp;&nbsp;Enumeration|Content-Base|The Content-Base entity-header field may be used to specify the base URI for resolving relative URLs within the entity. This header field is described as Base in RFC 1808, which is expected to be revised (RFC 2068).|
|&nbsp;&nbsp;Enumeration|Content-Disposition|In a regular HTTP response, the Content-Disposition response header is a header indicating if the content is expected to be displayed inline in the browser, that is, as a Web page or as part of a Web page, or as an attachment, that is downloaded and saved locally. In a multipart/form-data body, the HTTP Content-Disposition general header is a header that can be used on the subpart of a multipart body to give information about the field it applies to.|
|&nbsp;&nbsp;Enumeration|Content-Encoding|Used to compress the media-type. When present, its value indicates which encodings were applied to the entity-body.|
|&nbsp;&nbsp;Enumeration|Content-Language|Used to describe the language(s) intended for the audience, so that it allows a user to differentiate according to the users' own preferred language.|
|&nbsp;&nbsp;Enumeration|Content-Length|Indicates the size of the entity-body, in bytes, sent to the recipient.|
|&nbsp;&nbsp;Enumeration|Content-Location|Indicates an alternate location for the returned data.|
|&nbsp;&nbsp;Enumeration|Content-MD5|An MD5 digest of the entity-body for the purpose of providing an end-to-end message integrity check (MIC) of the entity-body (RFC 2616).|
|&nbsp;&nbsp;Enumeration|Content-Type|Indicates the media type of the resource.|
|&nbsp;&nbsp;Enumeration|Cookie|Contains stored HTTP cookies previously sent by the server with the Set-Cookie header.|
|&nbsp;&nbsp;Enumeration|Cookie2|(obsolete) Advises the server that the user agent understands "new-style" cookies.|
|&nbsp;&nbsp;Enumeration|Date|Contains the date and time at which the message was originated.|
|&nbsp;&nbsp;Enumeration|Depth|The Depth request header is used with methods executed on resources that could potentially have internal members to indicate whether the method is to be applied only to the resource ("Depth: 0"), to the resource and its internal members only ("Depth: 1"), or the resource and all its members ("Depth: infinity") (RFC 4918).|
|&nbsp;&nbsp;Enumeration|Destination|The Destination request header specifies the URI that identifies a destination resource for methods such as COPY and MOVE, which take two URIs as parameters (RFC 4918).|
|&nbsp;&nbsp;Enumeration|Expect|Indicates expectations that need to be fulfilled by the server in order to properly handle the request.|
|&nbsp;&nbsp;Enumeration|Forwarded|Contains information from the client-facing side of proxy servers that is altered or lost when a proxy is involved in the path of the request.|
|&nbsp;&nbsp;Enumeration|From|Contains an Internet email address for a human user who controls the requesting user agent.|
|&nbsp;&nbsp;Enumeration|Front-End-Https|Non-standard header field used by Microsoft applications and load-balancers|
|&nbsp;&nbsp;Enumeration|Host|Specifies the domain name of the server (for virtual hosting), and (optionally) the TCP port number on which the server is listening.|
|&nbsp;&nbsp;Enumeration|HTTP2-Settings|A request that upgrades from HTTP/1.1 to HTTP/2 MUST include exactly one HTTP2-Settings header field. The HTTP2-Settings header field is a connection-specific header field that includes parameters that govern the HTTP/2 connection, provided in anticipation of the server accepting the request to upgrade. A server MUST NOT upgrade the connection to HTTP/2 if this header field is not present or if more than one is present. A server MUST NOT send this header field (RFC 7540).|
|&nbsp;&nbsp;Enumeration|If|The If request header is intended to have similar functionality to the If-Match header defined in Section 14.24 of [RFC2616]. However, the If header handles any state token as well as ETags. A typical example of a state token is a lock token, and lock tokens are the only state tokens defined in this specification. (RFC 4918)|
|&nbsp;&nbsp;Enumeration|If-Match|For GET and HEAD methods, the server will send back the requested resource only if it matches one of the listed ETags. For PUT and other non-safe methods, it will only upload the resource in this case.|
|&nbsp;&nbsp;Enumeration|If-Modified-Since|The server will send back the requested resource, with a 200 status, only if it has been last modified after the given date.|
|&nbsp;&nbsp;Enumeration|If-None-Match|For GET and HEAD methods, the server will send back the requested resource, with a 200 status, only if it doesn't have an ETag matching the given ones. For other methods, the request will be processed only if the eventually existing resource's ETag doesn't match any of the values listed.|
|&nbsp;&nbsp;Enumeration|If-Range|If the condition is fulfilled, the range request will be issued and the server sends back a 206 Partial Content answer with the appropriate body. If the condition is not fulfilled, the full resource is sent back, with a 200 OK status.|
|&nbsp;&nbsp;Enumeration|If-Schedule-Tag-Match|The If-Schedule-Tag-Match request header field is used with a method to make it conditional. Clients can set this header to the value returned in the Schedule-Tag response header, or the CALDAV:schedule-tag property, of a scheduling object resource previously retrieved from the server to avoid overwriting "consequential" changes to the scheduling object resource (RFC 6638).|
|&nbsp;&nbsp;Enumeration|If-Unmodified-Since|The server will send back the requested resource, or accept it in the case of a POST or another non-safe method, only if it has not been last modified after the given date. If the request has been modified after the given date, the response will be a 412 (Precondition Failed) error.|
|&nbsp;&nbsp;Enumeration|Keep-Alive|Allows the sender to hint about how the connection may be used and to set a timeout and a maximum amount of requests.|
|&nbsp;&nbsp;Enumeration|Label|For certain methods (e.g., GET, PROPFIND), if the request-URL identifies a version-controlled resource, a label can be specified in a Label request header to cause the method to be applied to the version selected by that label from the version history of that version-controlled resource (RFC 3253).|
|&nbsp;&nbsp;Enumeration|Lock-Token|The Lock-Token request header is used with the UNLOCK method to identify the lock to be removed. The lock token in the Lock-Token request header MUST identify a lock that contains the resource identified by Request-URI as a member (RFC 4918).|
|&nbsp;&nbsp;Enumeration|Man|RFC 2774|
|&nbsp;&nbsp;Enumeration|Max-Forwards|The Max-Forwards request-header field may be used with the TRACE method (section 14.31) to limit the number of proxies or gateways that can forward the request to the next inbound server. This can be useful when the client is attempting to trace a request chain which appears to be failing or looping in mid-chain (RFC 2068).|
|&nbsp;&nbsp;Enumeration|Negotiate|Can contain directives for any content negotiation process initiated by the request. (RFC 2295).|
|&nbsp;&nbsp;Enumeration|Non-Compliance|A non-compliance-option listed in a Non-Compliance response-header field indicates that the proxy server named by the proxy-host value does not support the listed compliance-option. The set of non-compliance options SHOULD be a subset of the compliance-options listed in a Compliance header field of the forwarded message.|
|&nbsp;&nbsp;Enumeration|Opt|RFC 2774|
|&nbsp;&nbsp;Enumeration|Optional|The Optional request-header allows a client to declare itself to support WIRE (https://tools.ietf.org/html/draft-girod-w3-id-res-ext-00).|
|&nbsp;&nbsp;Enumeration|Ordering-Type|When a collection is created, the client MAY request that it be ordered and specify the semantics of the ordering by using the new Ordering-Type header (defined below) with a MKCOL request (RFC 3648).|
|&nbsp;&nbsp;Enumeration|Origin|Indicates where a fetch originates from.|
|&nbsp;&nbsp;Enumeration|Overwrite|The Overwrite request header specifies whether the server should overwrite a resource mapped to the destination URL during a COPY or MOVE (RFC 4918).|
|&nbsp;&nbsp;Enumeration|Position|When a new member is added to a collection with a client-maintained ordering (for example, with PUT, COPY, or MKCOL), its position in the ordering can be set with the new Position header (RFC 3648).|
|&nbsp;&nbsp;Enumeration|Pragma|An implementation-specific header that may have various effects along the request-response chain.|
|&nbsp;&nbsp;Enumeration|Prefer|The Prefer request header field is used to indicate that particular server behaviors are preferred by the client but are not required for successful completion of the request (RFC 7240).|
|&nbsp;&nbsp;Enumeration|ProfileObject|Used in implementation of OPS Over HTTP (https://www.w3.org/TR/NOTE-OPS-OverHTTP).|
|&nbsp;&nbsp;Enumeration|Protocol-Request|PICS 1.1 Label Distribution - Label Syntax and Communication Protocols (https://www.w3.org/standards/history/REC-PICS-labels).|
|&nbsp;&nbsp;Enumeration|Proxy-Authorization|Contains the credentials to authenticate a user agent to a proxy server, usually after the server has responded with a 407 Proxy Authentication Required status and the Proxy-Authenticate header.|
|&nbsp;&nbsp;Enumeration|Proxy-Features|The proxy features header is used by a proxy sending data to a server. It specifies the features supported by the specified proxy. (https://www.w3.org/TR/WD-proxy).|
|&nbsp;&nbsp;Enumeration|Range|Indicates the part of a document that the server should return.|
|&nbsp;&nbsp;Enumeration|Referer|Contains the address of the previous web page from which a link to the currently requested page was followed.|
|&nbsp;&nbsp;Enumeration|Resolution-Hint|The Resolution-Hint request-header can be used by a client to supply a resolution hint to the resolver (https://tools.ietf.org/html/draft-girod-w3-id-res-ext-00).|
|&nbsp;&nbsp;Enumeration|Schedule-Reply|The Schedule-Reply request header is used by a client to indicate to a server whether or not a scheduling operation ought to occur when an "Attendee" deletes a scheduling object resource. In particular, it controls whether a reply scheduling message is sent to the "Organizer" as a result of the removal (RFC 6638).|
|&nbsp;&nbsp;Enumeration|Sec-WebSocket-Key|The Sec-WebSocket-Key header field is used in the WebSocket opening handshake. It is sent from the client to the server to provide part of the information used by the server to prove that it received a valid WebSocket opening handshake. This helps ensure that the server does not accept connections from non-WebSocket clients (e.g., HTTP clients) that are being abused to send data to unsuspecting WebSocket servers (RFC 6455).|
|&nbsp;&nbsp;Enumeration|SoapAction|The SOAPAction HTTP request header field can be used to indicate the intent of the SOAP HTTP request. The value is a URI identifying the intent. SOAP places no restrictions on the format or specificity of the URI or that it is resolvable. An HTTP client MUST use this header field when issuing a SOAP HTTP Request (Simple Object Access Protocol (SOAP) 1.1).|
|&nbsp;&nbsp;Enumeration|SubOK|The SubOK request header field is used to provide directives from an end-client to a proxy cache regarding the possible substitution of an instance body from a cached response for one resource instance for the instance body of the resource instance specified by the client's request (https://tools.ietf.org/html/draft-mogul-http-dupsup-00).|
|&nbsp;&nbsp;Enumeration|Surrogate-Capability|The Surrogate-Capabilities request header allows surrogates to advertise their capabilities with capability tokens. Capability tokens indicate sets of operations (e.g., caching, processing) that a surrogate is willing to perform (https://www.w3.org/TR/edge-arch/).|
|&nbsp;&nbsp;Enumeration|TE|Specifies the transfer encodings the user agent is willing to accept.|
|&nbsp;&nbsp;Enumeration|Timeout|Used with WebDAV. Clients may include Timeout headers in their LOCK requests. However, the server is not required to honor or even consider these requests. Clients MUST NOT submit a Timeout request header with any method other than a LOCK method (RFC 4918).|
|&nbsp;&nbsp;Enumeration|Transfer-Encoding|Specifies the form of encoding used to safely transfer the entity to the user.|
|&nbsp;&nbsp;Enumeration|Upgrade-Insecure-Requests|Sends a signal to the server expressing the client’s preference for an encrypted and authenticated response, and that it can successfully handle the upgrade-insecure-requests CSP directive.|
|&nbsp;&nbsp;Enumeration|User-Agent|Contains a characteristic string that allows the network protocol peers to identify the application type, operating system, software vendor or software version of the requesting software user agent.|
|&nbsp;&nbsp;Enumeration|Via|Gets added by proxies, both forward and reverse proxies, and can appear in the request headers and the response headers.|
|&nbsp;&nbsp;Enumeration|Warning|Contains information about possible problems with the status of the message. More than one Warning header may appear in a response.|
|&nbsp;&nbsp;Enumeration|X-ATT-DevcieId|Allows easier parsing of the MakeModel/Firmware that is usually found in the User-Agent String of AT&T Devices|
|&nbsp;&nbsp;Enumeration|X-Forwarded-For|Header for identifying the originating IP address of a client connecting to a web server through an HTTP proxy or a load balancer.|
|&nbsp;&nbsp;Enumeration|X-Forwarded-Host|Header for identifying the original host requested by the client in the Host HTTP request header.|
|&nbsp;&nbsp;Enumeration|X-Forwarded-Proto|Header for identifying the protocol (HTTP or HTTPS) that a client used to connect to your proxy or load balancer.|
|&nbsp;&nbsp;Enumeration|X-Wap-Profile|Links to an XML file on the Internet with a full description and details about the device currently connecting.|
