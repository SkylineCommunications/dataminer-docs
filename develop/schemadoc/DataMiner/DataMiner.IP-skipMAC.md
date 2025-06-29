---
uid: DataMiner.IP-skipMAC
---

# skipMAC attribute

Configures DataMiner to ignore certain network adapters, so that these will not be considered as a local network interface. Multiple addresses can be specified by using a ";" separator.

## Content Type

string

## Parents

[IP](xref:DataMiner.IP)

## Remarks

This can be necessary in case special VPN connections end up in front of the normal adapters in the order of the network adapters, and changing the order of the adapters does not work. In this case, DataMiner could see the primary IP address as 127.0.0.1, and the secondary IP address would then have the value from the actual first NIC.

## Example

```xml
<DataMiner>
  <IP skipMAC="12-34-56-78-90-AB;F1-F2-F3-F4-F5-F6">
  ...
  </IP>
</DataMiner>
```
