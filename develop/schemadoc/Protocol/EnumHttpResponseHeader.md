---
uid: Protocol-EnumHttpResponseHeader
---

# EnumHttpResponseHeader simple type

List of headers that can only appear in HTTP responses.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|Accept-Patch|Specifies the patch document formats accepted by the server (RFC 5789).|
|&nbsp;&nbsp;Enumeration|Accept-Ranges|Advertises its support of partial requests.|
|&nbsp;&nbsp;Enumeration|Access-Control-Allow-Credentials|Indicates whether response to the request can be exposed to the page.|
|&nbsp;&nbsp;Enumeration|Access-Control-Allow-Headers|Used in response to a preflight request to indicate which HTTP headers can be used during the actual request.|
|&nbsp;&nbsp;Enumeration|Access-Control-Allow-Methods|Specifies the method or methods allowed when accessing the resource in response to a preflight request.|
|&nbsp;&nbsp;Enumeration|Access-Control-Allow-Origin|Indicates whether the response can be shared with resources with the given origin.|
|&nbsp;&nbsp;Enumeration|Access-Control-Expose-Headers|Indicates which headers can be exposed as part of the response by listing their names.|
|&nbsp;&nbsp;Enumeration|Access-Control-Max-Age|Indicates how long the results of a preflight request (that is the information contained in the Access-Control-Allow-Methods and Access-Control-Allow-Headers headers) can be cached.|
|&nbsp;&nbsp;Enumeration|Age|Contains the time in seconds the object has been in a proxy cache.|
|&nbsp;&nbsp;Enumeration|Allow|Lists the set of methods support by a resource.|
|&nbsp;&nbsp;Enumeration|Alternates|Used to convey the list of variants bound to a negotiable resource (RFC 2295).|
|&nbsp;&nbsp;Enumeration|Authentication-Info|The Authentication-Info header field can be used in any HTTP response, independently of request method and status code. Its semantics are defined by the authentication scheme indicated by the Authorization header field ([RFC7235], Section 4.2) of the corresponding request (RFC 7615).|
|&nbsp;&nbsp;Enumeration|C-Man|(RFC 2774).|
|&nbsp;&nbsp;Enumeration|C-Ext|Used to indicate that all hop-by-hop mandatory extension declarations in the request were fulfilled (RFC 2774).|
|&nbsp;&nbsp;Enumeration|Cache-Control|Specifies directives for caching mechanisms in both requests and responses. Caching directives are unidirectional, meaning that a given directive in a request is not implying that the same directive is to be given in the response.|
|&nbsp;&nbsp;Enumeration|Compliance|Allows a client to specify exactly what options it is asking about, and which allows a server to specify exactly what subset of those options are supported.|
|&nbsp;&nbsp;Enumeration|Connection|Controls whether or not the network connection stays open after the current transaction finishes. If the value sent is keep-alive, the connection is persistent and not closed, allowing for subsequent requests to the same server to be done.|
|&nbsp;&nbsp;Enumeration|Content-Base|The Content-Base entity-header field may be used to specify the base URI for resolving relative URLs within the entity. This header field is described as Base in RFC 1808, which is expected to be revised (RFC 2068).|
|&nbsp;&nbsp;Enumeration|Content-Disposition|In a regular HTTP response, the Content-Disposition response header is a header indicating if the content is expected to be displayed inline in the browser, that is, as a Web page or as part of a Web page, or as an attachment, that is downloaded and saved locally. In a multipart/form-data body, the HTTP Content-Disposition general header is a header that can be used on the subpart of a multipart body to give information about the field it applies to.|
|&nbsp;&nbsp;Enumeration|Content-Encoding|Used to compress the media-type. When present, its value indicates which encodings were applied to the entity-body.|
|&nbsp;&nbsp;Enumeration|Content-MD5|An MD5 digest of the entity-body for the purpose of providing an end-to-end message integrity check (MIC) of the entity-body (RFC 2616).|
|&nbsp;&nbsp;Enumeration|Content-Language|Used to describe the language(s) intended for the audience, so that it allows a user to differentiate according to the users' own preferred language.|
|&nbsp;&nbsp;Enumeration|Content-Length|Indicates the size of the entity-body, in bytes, sent to the recipient.|
|&nbsp;&nbsp;Enumeration|Content-Location|Indicates an alternate location for the returned data.|
|&nbsp;&nbsp;Enumeration|Content-Range|Indicates where in a full body message a partial message belongs.|
|&nbsp;&nbsp;Enumeration|Content-Script-Type|Specifies the default scripting language.|
|&nbsp;&nbsp;Enumeration|Content-Security-Policy|Allows web site administrators to control resources the user agent is allowed to load for a given page.|
|&nbsp;&nbsp;Enumeration|Content-Security-Policy-Report-Only|Allows web developers to experiment with policies by monitoring (but not enforcing) their effects.|
|&nbsp;&nbsp;Enumeration|Content-Transfer-Encoding|A single token specifying the type of encoding (RFC 2045).|
|&nbsp;&nbsp;Enumeration|Content-Type|Indicates the media type of the resource.|
|&nbsp;&nbsp;Enumeration|DASL|The DASL response header indicates server support for a query grammar in the OPTIONS method. The value is a URI that indicates the type of grammar. This header MAY be repeated (draft-ietf-dasl-protocol-00.txt).|
|&nbsp;&nbsp;Enumeration|Date|Contains the date and time at which the message was originated.|
|&nbsp;&nbsp;Enumeration|ETag|Identifies a specific version of a resource.|
|&nbsp;&nbsp;Enumeration|Expires|Contains the date/time after which the response is considered stale.|
|&nbsp;&nbsp;Enumeration|Ext|Used to indicate that all end-to-end mandatory extension declarations in the request were fulfilled (RFC 2774).|
|&nbsp;&nbsp;Enumeration|GetProfile|Used with implementation of OPS Over HTTP.|
|&nbsp;&nbsp;Enumeration|IM|The IM response-header field is used to indicate the instance-manipulations, if any, that have been applied to the instance represented by the response. Typical instance manipulations include delta encoding and compression (RFC 3229).|
|&nbsp;&nbsp;Enumeration|Keep-Alive|Allows the sender to hint about how the connection and may be used to set a timeout and a maximum amount of requests.|
|&nbsp;&nbsp;Enumeration|Large-Allocation|Tells the browser that the page being loaded is going to want to perform a large allocation.|
|&nbsp;&nbsp;Enumeration|Last-Modified|Contains the date and time at which the origin server believes the resource was last modified. It is used to determine if a resource received or stored is the same.|
|&nbsp;&nbsp;Enumeration|Location|Indicates the URL to redirect a page to. It only provides a meaning when served with a 3xx (redirection) or 201 (created) status response.|
|&nbsp;&nbsp;Enumeration|Lock-Token|The Lock-Token response header is used with the LOCK method to indicate the lock token created as a result of a successful LOCK request to create a new lock. (RFC 4918).|
|&nbsp;&nbsp;Enumeration|Man|RFC 2774|
|&nbsp;&nbsp;Enumeration|Memento-Datetime|The "Memento-Datetime" response header is used by a server to indicate that a response reflects a prior state of an Original Resource. Its value expresses the datetime of that state (RFC 7089).|
|&nbsp;&nbsp;Enumeration|Non-Compliance|A non-compliance-option listed in a Non-Compliance response-header field indicates that the proxy server named by the proxy-host value does not support the listed compliance-option. The set of non-compliance options SHOULD be a subset of the compliance-options listed in a Compliance header field of the forwarded message.|
|&nbsp;&nbsp;Enumeration|Opt|RFC 2774|
|&nbsp;&nbsp;Enumeration|P3P|The P3P header gives one or more comma-separated directives (https://www.w3.org/2002/04/P3Pv1-header.txt).|
|&nbsp;&nbsp;Enumeration|Pragma|An implementation-specific header that may have various effects along the request-response chain.|
|&nbsp;&nbsp;Enumeration|Preference-Applied|The Preference-Applied response header MAY be included within a response message as an indication as to which Prefer tokens were honored by the server and applied to the processing of a request (RFC 7240).|
|&nbsp;&nbsp;Enumeration|Proxy-Authenticate|Defines the authentication method that should be used to gain access to a resource behind a proxy server.|
|&nbsp;&nbsp;Enumeration|Proxy-Authentication-Info|The Proxy-Authentication-Info response header field is equivalent to Authentication-Info, except that it applies to proxy authentication ([RFC7235], Section 2) and its semantics are defined by the authentication scheme indicated by the Proxy-Authorization header field ([RFC7235], Section 4.4) of the corresponding request (RFC 7614).|
|&nbsp;&nbsp;Enumeration|Proxy-Instruction|The proxy instruction header is used to reply to a proxy features header. It should only be present when a Proxy-Features header was present in the corresponding request (https://www.w3.org/TR/WD-proxy).|
|&nbsp;&nbsp;Enumeration|Public|The Public response-header field lists the set of methods supported by the server. The purpose of this field is strictly to inform the recipient of the capabilities of the server regarding unusual methods (RFC 2068).|
|&nbsp;&nbsp;Enumeration|Public-Key-Pins|Associates a specific cryptographic public key with a certain web server to decrease the risk of MITM attacks with forged certificates.|
|&nbsp;&nbsp;Enumeration|Public-Key-Pins-Report-Only|Sends reports of pinning violation to the report-uri specified in the header but, unlike Public-Key-Pins still allows browsers to connect to the server if the pinning is violated.|
|&nbsp;&nbsp;Enumeration|Redirect-Ref|The Redirect-Ref header is used in all 3xx responses from redirect reference resources. The value is the link target as specified during redirect reference resource creation (RFC 4437).|
|&nbsp;&nbsp;Enumeration|Referrer-Policy|Governs which referrer information, sent in the Referer header, should be included with requests made.|
|&nbsp;&nbsp;Enumeration|Resolver-Location|The Resolver-Location header in a 350 response encodes this comma delimited set of bindings (https://tools.ietf.org/html/draft-girod-w3-id-res-ext-00).|
|&nbsp;&nbsp;Enumeration|Retry-After|Indicates how long the user agent should wait before making a follow-up request. There are three main cases this header is used:|
|&nbsp;&nbsp;Enumeration|Safe|The Safe response header field is used by origin servers to indicate whether repeating the received HTTP request is safe in the sense of Section 9.1.1 (Safe Methods) of the HTTP/1.1 specification [1] (RFC 2310).|
|&nbsp;&nbsp;Enumeration|Schedule-Tag|The Schedule-Tag response header provides the current value of the CALDAV:schedule-tag property value (RFC 6638).|
|&nbsp;&nbsp;Enumeration|Server|Contains information about the software used by the origin server to handle the request.|
|&nbsp;&nbsp;Enumeration|Sec-WebSocket-Accept|The Sec-WebSocket-Accept header field is used in the WebSocket opening handshake. It is sent from the server to the client to confirm that the server is willing to initiate the WebSocket connection (RFC 6455).|
|&nbsp;&nbsp;Enumeration|Set-Cookie|Used to send cookies from the server to the user agent.|
|&nbsp;&nbsp;Enumeration|Set-Cookie2|(Obsolete) Used to send cookies from the server to the user agent.|
|&nbsp;&nbsp;Enumeration|SetProfile|Used with implementation of OPS Over HTTP (https://www.w3.org/TR/NOTE-OPS-OverHTTP).|
|&nbsp;&nbsp;Enumeration|SourceMap|Links generated code to a source map, enabling the browser to reconstruct the original source and present the reconstructed original in the debugger.|
|&nbsp;&nbsp;Enumeration|Status|The Status header field contains a 3-digit integer result code that indicates the level of success of the script's attempt to handle the request. (RFC 3875).|
|&nbsp;&nbsp;Enumeration|Status-URI|The Status-URI response header may be used with the 102 (Processing) status code to inform the client as to the status of a method (RFC 2518).|
|&nbsp;&nbsp;Enumeration|Strict-Transport-Security||
|&nbsp;&nbsp;Enumeration|Subst|The Subst response-header field MUST be used by a proxy to supply the URI of the original source of an entity-body, if the source is different from the client's Request-URI, and if the client's request included the ``inform'' directive in a SubOK request header field. Otherwise, a proxy MAY send a Subst response-header field, if it makes a substitution based on the information in a SubOK request header field (https://tools.ietf.org/html/draft-mogul-http-dupsup-00).|
|&nbsp;&nbsp;Enumeration|Surrogate-Control|The Surrogate-Control response header allows origin servers to dictate how surrogates should handle response entities, with control directives (https://www.w3.org/TR/edge-arch/).|
|&nbsp;&nbsp;Enumeration|TCN|The TCN response header is used by a server to signal that the resource is transparently negotiated (RFC 2295).|
|&nbsp;&nbsp;Enumeration|Timing-Allow-Origin|Specifies origins that are allowed to see values of attributes retrieved via features of the Resource Timing API, which would otherwise be reported as zero due to cross-origin restrictions.|
|&nbsp;&nbsp;Enumeration|Tk|Indicates the tracking status that applied to the corresponding request.|
|&nbsp;&nbsp;Enumeration|Trailer|Allows the sender to include additional fields at the end of chunked messages in order to supply metadata that might be dynamically generated while the message body is sent, such as a message integrity check, digital signature, or post-processing status.|
|&nbsp;&nbsp;Enumeration|Transfer-Encoding|Specifies the form of encoding used to safely transfer the entity to the user.|
|&nbsp;&nbsp;Enumeration|Variant-Vary|The Variant-Vary response header can be used in a choice response to record any vary information which applies to the variant data (the entity body combined with some of the entity headers) contained in the response, rather than to the response as a whole (RFC 2295).|
|&nbsp;&nbsp;Enumeration|Vary|Determines how to match future request headers to decide whether a cached response can be used rather than requesting a fresh one from the origin server.|
|&nbsp;&nbsp;Enumeration|Via|Gets added by proxies, both forward and reverse proxies, and can appear in the request headers and the response headers.|
|&nbsp;&nbsp;Enumeration|WWW-Authenticate|Defines the authentication method that should be used to gain access to a resource.|
|&nbsp;&nbsp;Enumeration|Warning|Contains information about possible problems with the status of the message. More than one Warning header may appear in a response.|
|&nbsp;&nbsp;Enumeration|X-Content-Duration|Provides the duration of the audio or video in seconds.|
|&nbsp;&nbsp;Enumeration|X-Content-Security-Policy|Content Security Policy definition.|
|&nbsp;&nbsp;Enumeration|X-Content-Type-Options|Marker used by the server to indicate that the MIME types advertised in the Content-Type headers should not be changed and be followed.|
|&nbsp;&nbsp;Enumeration|X-DNS-Prefetch-Control|Controls DNS prefetching, a feature by which browsers pro actively perform domain name resolution on both links that the user may choose to follow as well as URLs for items referenced by the document, including images, CSS, etc.|
|&nbsp;&nbsp;Enumeration|X-Frame-Options|Can be used to indicate whether or not a browser should be allowed to render a page in a \<frame\>, \<iframe\> or \<object\>.|
|&nbsp;&nbsp;Enumeration|X-Powered-By|Specifies the technology (e.g., ASP.NET, PHP, JBoss) supporting the web application (version details are often in X-Runtime, X-Version, or X-AspNet-Version).|
|&nbsp;&nbsp;Enumeration|X-UA-Compatible|Recommends the preferred rendering engine (often a backward-compatibility mode) to use to display the content.|
|&nbsp;&nbsp;Enumeration|X-WebKit-CSP|Content Security Policy definition.|
|&nbsp;&nbsp;Enumeration|X-XSS-Protection|A feature of Internet Explorer, Chrome and Safari that stops pages from loading when they detect reflected cross-site scripting (XSS) attacks.|
