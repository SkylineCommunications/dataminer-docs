---
uid: Protocol.HTTP.Session-proxyUser
description: "Use the proxyUser attribute in a DataMiner protocol to specify a fixed proxy username or parameter ID for HTTP proxy authentication."
---

# proxyUser attribute

If, in the proxyServer attribute, you specified a proxy server that requires authentication, then use this attribute to specify the user name.

## Content Type

string

## Parent

[Session](xref:Protocol.HTTP.Session)

## Remarks

This can be either a hard-coded string or a parameter ID referring to a parameter (with Interprete/Type set to "string") that holds the value (the latter option is preferred).
