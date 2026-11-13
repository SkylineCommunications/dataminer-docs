---
uid: Protocol.HTTP.Session-userName
description: "Use the userName attribute in a DataMiner protocol to specify a fixed username or parameter ID for credentials-based HTTP authentication."
---

# userName attribute

If you set loginMethod to “credentials”, then use this attribute to specify the username.

It is possible to specify the ID of a parameter that will contain the username.

## Content Type

string

## Parent

[Session](xref:Protocol.HTTP.Session)

## Remarks

> [!NOTE]
> In case the parameters referred to by the username and password attributes are not filled in, the resulting behavior will be as if there was no loginMethod specified (i.e., no authentication takes place).
