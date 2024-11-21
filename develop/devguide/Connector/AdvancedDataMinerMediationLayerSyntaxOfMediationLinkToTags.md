---
uid: AdvancedDataMinerMediationLayerSyntaxOfMediationLinkToTags
---

# Syntax of Mediation.LinkTo tags

In a Mediation tag, you can specify multiple LinkTo tags. Processed top-down, the first match is used.

In a base protocol, you can look up a parameter in a device protocol by specifying either the parameter ID and the name of the protocol or the parameter name.

- Example of a lookup by ID+protocol:

  ```xml
  <LinkTo pid="176" protocol="Philips TCL" />
  ```

- Example of a lookup by name:

  ```xml
  <LinkTo description="Audio Output Level" />
  ```

- In a device protocol, you can look up a parameter in a base protocol by simply specifying the parameter ID.

  Example of a lookup by ID:

  ```xml
  <LinkTo pid="71000" />
  ```

In a description tag, you can use simple wildcards (`*` and `?`). You can also specify multiple descriptions separated by colons (`:`). In case of a read parameter, only read parameters will be checked. In case of a write parameter, only write parameters will be checked.

In an ops attribute, you can specify one or more conversions separated by semicolons (`;`).

Supported operations:

|Operation|Description|
|--- |--- |
|*|Factor|
|/|Division|
|-|Minus|
|+|Offset|
|%|Remainder|

Example of a LinkTo tag containing a conversion:
  
  ```xml
  <LinkTo pid="176" protocol="Philips DVS3810" ops="*:1024;+:5" />
  ```
