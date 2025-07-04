---
uid: DataMiner.NetworkAdapters
---

# NetworkAdapters element

Overrides the order of the network adapters on a DataMiner Agent.

This can be useful to prevent issues in case the order in Windows changes for some reason (e.g. because there is a new network adapter).

## Parents

[DataMiner](xref:DataMiner)

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [MAC](xref:DataMiner.NetworkAdapters.MAC) | [1, *] | Specifies the MAC address of the network adapter. |

## Remarks

Specify a number of `<MAC>` subtags, each containing a MAC address.

To determine its primary IP address, the DataMiner Agent will place the adapters with matching MAC addresses first in its list. In other words, the primary IP address of the DataMiner Agent will be the one for which the first valid MAC address is found in this tag.

## Example

```xml
<NetworkAdapters>
  <MAC>B0-83-FE-B3-F8-0B</MAC>
  <MAC>E8-EE-7A-CA-97-B0</MAC>
</NetworkAdapters>
```
