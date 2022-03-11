---
uid: Protocol.HTTP.Session.Connection.Request-verb
---

# verb attribute

Specifies the verb to be used in the HTTP request.

## Content Type

[EnumHttpRequestVerb](xref:Protocol-EnumHttpRequestVerb)

## Parent

[Request](xref:Protocol.HTTP.Session.Connection.Request)

## Remarks

Default: GET.

Contains a string consisting of alphabetic characters ([a-zA-Z]).

> [!NOTE]
>
> - A verb containing any other characters (i.e. characters other than [a-zA-Z]), e.g. spaces or punctuation, will result in a fallback to GET. For example, P-UT will result in GET being used in the request (RN 16728).
> - For verbs that consist exclusively of alphabetic characters ([a-zA-Z]), a fallback to GET will not be performed. For example, when GETT is specified, this will result in GETT being used in the request. (RN 16728).
> - CONNECT is not supported.
> - In versions prior to DataMiner 9.5.7, only the verbs GET, POST, PUT and DELETE are supported. If any other verb is specified, a GET is performed.
> - From DataMiner 9.5.8 (RN 17252) onwards, all HTTP verbs except GET support adding data to the message body.
