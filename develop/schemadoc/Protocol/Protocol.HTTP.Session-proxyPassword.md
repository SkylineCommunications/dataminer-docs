---
uid: Protocol.HTTP.Session-proxyPassword
description: "Use the proxyPassword attribute in a DataMiner protocol to specify a fixed proxy password or parameter ID for HTTP proxy authentication."
---

# proxyPassword attribute

If, in the proxyServer attribute, you specified a proxy server that requires authentication, then use this attribute to specify the password.

## Content Type

string

## Parent

[Session](xref:Protocol.HTTP.Session)

## Remarks

This can be either a hard-coded string or a parameter ID referring to a parameter (with Interprete/Type set to "string") that holds the value (the latter option is preferred).
