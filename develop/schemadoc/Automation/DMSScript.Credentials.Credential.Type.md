---
uid: DMSScript.Credentials.Credential.Type
---

# Type element

Specifies the type of the credentials.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|UserNamePassword|A set of credentials holding a user name and a password.|
|&nbsp;&nbsp;Enumeration|Token|A set of credentials holding a single access token.|

## Parent

[Credential](xref:DMSScript.Credentials.Credential)

## Remarks

The type must match the type of the linked credentials in the [Credentials Library](xref:Credentials_Library). If the type is missing or not recognized, the credentials cannot be used.
