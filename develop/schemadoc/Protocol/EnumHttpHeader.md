---
uid: Protocol-EnumHttpHeader
---

# EnumHttpHeader simple type

List of headers that can both appear in HTTP requests and responses.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|C-PEP|Hop-by-Hop Extension Declaration (http://www.w3.org/TR/WD-http-pep).|
|&nbsp;&nbsp;Enumeration|C-PEP-Info|Hop-by-Hop Policy (http://www.w3.org/TR/WD-http-pep).|
|&nbsp;&nbsp;Enumeration|Close||
|&nbsp;&nbsp;Enumeration|Content-ID|The content identifier. Used with the HTTP Distribution and Replication Protocol (https://www.w3.org/TR/NOTE-drp-19970825).|
|&nbsp;&nbsp;Enumeration|Content-Style-Type||
|&nbsp;&nbsp;Enumeration|Content-Version|The Content-Version entity-header field defines the version tag associated with a rendition of an evolving entity. Together with the Derived-From field described in section 19.6.2.3, it allows a group of people to work simultaneously on the creation of a work as an iterative process. The field should be used to allow evolution of a particular work along a single path rather than derived works or renditions in different representations. (RFC 2068).|
|&nbsp;&nbsp;Enumeration|Cost|The cost of retrieving the object is given. This is the cost of access of a copyright work, with a specification of the payment system accepted. Format to be specified. Currently refers to an unspecified charging scheme to be agreed out of band between parties (https://www.w3.org/Protocols/HTTP/Object_Headers.html#cost).|
|&nbsp;&nbsp;Enumeration|DAV|When appearing in the response indicates that the resource supports the DAV schema and protocol as specified. As a request header, this header allows the client to advertise compliance with named features when the server needs that information (RFC 4918).|
|&nbsp;&nbsp;Enumeration|Default-Style||
|&nbsp;&nbsp;Enumeration|Delta-Base|The Delta-Base entity-header field is used in a delta-encoded response to specify the entity tag of the base instance (RFC 3229).|
|&nbsp;&nbsp;Enumeration|Derived-From|The Derived-From entity-header field can be used to indicate the version tag of the resource from which the enclosed entity was derived before modifications were made by the sender. This field is used to help manage the process of merging successive changes to a resource, particularly when such changes are being made in parallel and from multiple sources (RFC 2068).|
|&nbsp;&nbsp;Enumeration|Differential-ID|Used with the HTTP Distribution and Replication Protocol (https://www.w3.org/TR/NOTE-drp-19970825).|
|&nbsp;&nbsp;Enumeration|Digest|The Digest message header field provides a message digest of the instance described by the message (RFC 3230).|
|&nbsp;&nbsp;Enumeration|Want-Digest|The Want-Digest message header field indicates the sender's desire to receive an instance digest on messages associated with the Request-URI (RFC 3230).|
|&nbsp;&nbsp;Enumeration|EDIINT-Features|The EDIINT-Features header indicates the capability of the user agent to support the listed feature with its trading partner without out-of-band communication and agreement (RFC 6017).|
|&nbsp;&nbsp;Enumeration|Hobareg|HTTP Origin-Bound Auth (HOBA) (RFC 7486).|
|&nbsp;&nbsp;Enumeration|Link|The Link entity-header field provides a means for serializing one or more links in HTTP headers (RFC 5988).|
|&nbsp;&nbsp;Enumeration|Message-ID||
|&nbsp;&nbsp;Enumeration|Meter|The Meter header is used to carry zero or more directives (RFC 2227).|
|&nbsp;&nbsp;Enumeration|MIME-Version|Messages MAY include a single MIME-Version general-header field to indicate what version of the MIME protocol was used to construct the message (RFC 2616).|
|&nbsp;&nbsp;Enumeration|PEP|Hop-by-Hop Extension Declaration (http://www.w3.org/TR/WD-http-pep).|
|&nbsp;&nbsp;Enumeration|PEP-Info|Hop-by-Hop Policy (http://www.w3.org/TR/WD-http-pep).|
|&nbsp;&nbsp;Enumeration|PICS-Label||
|&nbsp;&nbsp;Enumeration|Protocol|PICS 1.1 Label Distribution -- Label Syntax and Communication Protocols (https://www.w3.org/standards/history/REC-PICS-labels).|
|&nbsp;&nbsp;Enumeration|Protocol-Info|Joint Electronic Payment Initiative (https://www.w3.org/ECommerce/white-paper).|
|&nbsp;&nbsp;Enumeration|Protocol-Query|Joint Electronic Payment Initiative (https://www.w3.org/ECommerce/white-paper).|
|&nbsp;&nbsp;Enumeration|Security-Scheme|All S-HTTP compliant agents must generate the Security-Scheme header in the headers of all HTTP messages they generate. This header permits other agents to detect that they are communicating with an S-HTTP compliant agent and generate the appropriate cryptographic options header (RFC 2660).|
|&nbsp;&nbsp;Enumeration|Sec-WebSocket-Extensions|The |Sec-WebSocket-Extensions| header field is used in the WebSocket opening handshake. It is initially sent from the client to the server, and then subsequently sent from the server to the client, to agree on a set of protocol-level extensions to use for the duration of the connection (RFC 6455).|
|&nbsp;&nbsp;Enumeration|Sec-WebSocket-Protocol|The Sec-WebSocket-Protocol header field is used in the WebSocket opening handshake. It is sent from the client to the server and back from the server to the client to confirm the subprotocol of the connection. This enables scripts to both select a subprotocol and be sure that the server agreed to serve that subprotocol (RFC 6455).|
|&nbsp;&nbsp;Enumeration|Sec-WebSocket-Version|The Sec-WebSocket-Version header field is used in the WebSocket opening handshake. It is sent from the client to the server to indicate the protocol version of the connection. This enables servers to correctly interpret the opening handshake and subsequent data being sent from the data, and close the connection if the server cannot interpret that data in a safe manner. The Sec-WebSocket-Version header field is also sent from the server to the client on WebSocket handshake error, when the version received from the client does not match a version understood by the server. In such a case, the header field includes the protocol version(s) supported by the server (RFC 6455).|
|&nbsp;&nbsp;Enumeration|SLUG|Slug is an HTTP entity-header whose presence in a POST to a Collection constitutes a request by the client to use the header’s value as part of any URIs that would normally be used to retrieve the to-be-created Entry or Media Resources. Servers MAY use the value of the Slug header when creating the Member URI of the newly created Resource, for instance, by using some or all of the words in the value for the last URI segment (RFC 5023).|
|&nbsp;&nbsp;Enumeration|Title|The title of the document (https://www.w3.org/Protocols/HTTP/Object_Headers.html#title).|
|&nbsp;&nbsp;Enumeration|TSV||
|&nbsp;&nbsp;Enumeration|UA-Color|https://tools.ietf.org/html/draft-mutz-http-attributes-00|
|&nbsp;&nbsp;Enumeration|UA-Media|https://tools.ietf.org/html/draft-mutz-http-attributes-00|
|&nbsp;&nbsp;Enumeration|UA-Pixels|https://tools.ietf.org/html/draft-mutz-http-attributes-00|
|&nbsp;&nbsp;Enumeration|UA-Resolution|https://tools.ietf.org/html/draft-mutz-http-attributes-00|
|&nbsp;&nbsp;Enumeration|UA-Windowpixels|https://tools.ietf.org/html/draft-mutz-http-attributes-00|
|&nbsp;&nbsp;Enumeration|URI| The URI header field has, in past versions of this specification, been used as a combination of the existing Location, Content-Location, and Vary header fields as well as the future Alternates field (above). Its primary purpose has been to include a list of additional URIs for the resource, including names and mirror locations. However, it has become clear that the combination of many different functions within this single field has been a barrier to consistently and correctly implementing any of those functions. Furthermore, we believe that the identification of names and mirror locations would be better performed via the Link header field. The URI header field is therefore deprecated in favor of those other fields (RFC 2068). |
|&nbsp;&nbsp;Enumeration|Version|This is a string defining the version of an evolving object (https://www.w3.org/Protocols/HTTP/Object_Headers.html#z13).|
|&nbsp;&nbsp;Enumeration|X-Device-Accept||
|&nbsp;&nbsp;Enumeration|X-Device-Accept-Charset||
|&nbsp;&nbsp;Enumeration|X-Device-Accept-Encoding||
|&nbsp;&nbsp;Enumeration|X-Device-Accept-Language||
|&nbsp;&nbsp;Enumeration|X-Device-User-Agent||
