---
metadata_version: 1
uid: Protocol.HTTP.Session-userName
description: "Learn how the userName attribute supplies a fixed username or parameter ID for credential-based HTTP authentication in a DataMiner connector protocol."
---

# userName attribute

If you set loginMethod to “credentials”, then use this attribute to specify the user name.

It is possible to specify the ID of a parameter that will contain the user name.

## Content Type

string

## Parent

[Session](xref:Protocol.HTTP.Session)

## Remarks

> [!NOTE]
> In case the parameters referred to by the username and password attributes are not filled in, the resulting behavior will be as if there was no loginMethod specified (i.e., no authentication takes place).
