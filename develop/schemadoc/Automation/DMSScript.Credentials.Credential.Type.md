---
uid: DMSScript.Credentials.Credential.Type
---

# Type element

Specifies the type of the credential.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|UserNamePassword|A credential holding a user name and a password.|
|&nbsp;&nbsp;Enumeration|Token|A credential holding a single access token.|

## Parent

[Credential](xref:DMSScript.Credentials.Credential)

## Remarks

The type must match the type of the linked credential in the Credentials Library. If the type is missing or not recognized, the credential cannot be used.
