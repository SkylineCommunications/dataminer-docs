---
uid: DataMiner.LDAP.QueryTimeout
---

# QueryTimeout element

Specifies the number of seconds after which an individual LDAP request will time out.

Default: 300.

## Content Type

integer

## Parents

[LDAP](xref:DataMiner.LDAP)

## Remarks

> [!NOTE]
> This timeout applies to every individual LDAP query. As a result, a request to refresh all groups (which consists of multiple requests) could have a total timeout that is much larger than the configured value.
