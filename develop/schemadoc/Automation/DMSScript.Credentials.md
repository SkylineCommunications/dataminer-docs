---
uid: DMSScript.Credentials
---

# Credentials element

Contains the credentials defined in the script.

## Parent

[DMSScript](xref:DMSScript)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Credential](xref:DMSScript.Credentials.Credential)|[0, *]|Defines a set of credentials from the [Credentials Library](xref:Credentials_Library) that the script is linked to.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID must be unique within the `Credentials` element. |Credentials |@id |
|Unique |The name must be unique within the `Credentials` element. |Credentials |Name |

> [!NOTE]
> Available from DataMiner 10.7.0/10.6.10 onwards<!-- RN 44282 RN 46229 -->.
