---
uid: Manifest.Content.Protocols.Protocol
---

# Protocol element

Specifies a protocol to include in the package.

## Parent

[Protocols](xref:Manifest.Content.Protocols)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[RepoPath](xref:Manifest.Content.Protocols.Protocol.RepoPath)||Specifies the repository path of the protocol.|
|&nbsp;&nbsp;[SignDevelopmentVersion](xref:Manifest.Content.Protocols.Protocol.SignDevelopmentVersion)||Specifies whether a signed or unsigned version of this protocol should be included in the package.|
|&nbsp;&nbsp;[Templates](xref:Manifest.Content.Protocols.Protocol.Templates)|[0, 1]|Specifies the templates to include in the package for this protocol.|
|&nbsp;&nbsp;[Version](xref:Manifest.Content.Protocols.Protocol.Version)||Specifies the protocol version. Either specify a specific version (e.g. 1.0.0.1) or a range (e.g. 1.0.0.X).|
