---
uid: DataMiner.IP
---

# IP element

Configures IP-related settings.

## Parents

[DataMiner](xref:DataMiner)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [skipMAC](xref:DataMiner.IP-skipMAC) | string |  | Configures DataMiner to ignore certain network adapters so that these will not be considered as a local network interface.<br>Multiple addresses can be specified using ";" separators. |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[VirtualIPFrom](xref:DataMiner.IP.VirtualIPFrom) | [0, 1] | Specifies the start of the IP address range for virtual IP addresses that may be assigned to elements. |
| &#160;&#160;[VirtualIPMask](xref:DataMiner.IP.VirtualIPMask) | [0, 1] | Specifies the virtual IP mask. |
| &#160;&#160;[VirtualIPTo](xref:DataMiner.IP.VirtualIPTo) | [0, 1] | Specifies the end of the IP address range for virtual IP addresses that may be assigned to elements. |
