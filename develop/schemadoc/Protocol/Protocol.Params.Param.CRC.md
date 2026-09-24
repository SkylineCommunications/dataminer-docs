---
metadata_version: 1
uid: Protocol.Params.Param.CRC
description: "Learn how to use the CRC element to define the parameters and algorithm used to calculate a command or response CRC in a DataMiner connector protocol."
---

# CRC element

If Protocol.Params.Param.Type is “CRC”, this tag will allow you to define the CRC used in the communication with the device.

## Parent

[Param](xref:Protocol.Params.Param)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Content](xref:Protocol.Params.Param.CRC.Content)||Specifies the parameters of the command/response to be included in the CRC calculation.|
|&nbsp;&nbsp;[Type](xref:Protocol.Params.Param.CRC.Type)||Defines the CRC algorithm to use.|

## Remarks

The information you specify here will be used to calculate the CRC of the command/response.
