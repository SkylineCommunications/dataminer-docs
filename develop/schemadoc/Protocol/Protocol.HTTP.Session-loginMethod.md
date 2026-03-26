---
uid: Protocol.HTTP.Session-loginMethod
---

# loginMethod attribute

Specifies the authentication method to use.

## Content Type

[EnumHttpLoginMethod](xref:Protocol-EnumHttpLoginMethod)

## Parent

[Session](xref:Protocol.HTTP.Session)

## Remarks

The currently supported values for this attribute are:.

### credentials

For credential-based authentication the supported authentication methods are:


|Method|Description
|--- |--- |
|Basic (plain text)|HTTP Basic Authentication scheme (RFC 7617). Uses a base64 encoded string that contains the username and password.|
|Digest|HTTP Digest Authentication scheme (RFC 2617). Based on a simple challenge-response paradigm. The Digest scheme challenges using a nonce value and might indicate that username hashing is supported. A valid response contains an unkeyed digest of the username, the password, the given nonce value, the HTTP method, and the requested URI. The additions to HTTP Digest Authentication described in RFC 7616 (e.g., support for SHA2-256 as the hashing algorithm) are not supported in DataMiner.|
|NTLM|NT Lan Manager. Requires the authentication data to be transformed with the user credentials to prove identity. For NTLM authentication to function correctly, several exchanges must take place on the same connection. Therefore, NTLM authentication cannot be used if an intervening proxy does not support keep-alive connections.|
|Negotiate|If both the server and client are running Windows 2000 or later, Kerberos authentication is used. Otherwise NTLM authentication is used. Kerberos is available as from Windows 2000 and is considered to be more secure than NTLM authentication. For Negotiate authentication to function correctly, several exchanges must take place on the same connection. Therefore, Negotiate authentication cannot be used if an intervening proxy does not support keep-alive connections.|

HTTP Basic Authentication is the default scheme used. In case the server does not accept this type of authentication, it will provide the authentication scheme it expects (e.g., Digest). DataMiner will then use the authentication scheme as described by the server (if it is one of the supported types).

### certificate

Supported from DataMiner 10.0.5 (RN 25243) onwards

When configuring an HTTPS session in a DataMiner protocol, you can specify that authentication should be performed using a client certificate. To do so, in the `<Session>` tag, set the loginMethod attribute to "certificate".

```xml
<Session loginMethod="certificate">
    ...
</Session>
```

If, for a particular session, loginMethod is set to "certificate", DataMiner will look for the Skyline DataMiner certificate in the Windows personal certificate store of the local machine and use that certificate to authenticate all requests within that session.

> [!NOTE]
> As some web servers accept certificates even when they do not require them, DataMiner will not send a client certificate by default. It will send an empty certificate list instead. This will prevent any ERROR_WINHTTP_CLIENT_AUTH_CERT_NEEDED errors being thrown.
