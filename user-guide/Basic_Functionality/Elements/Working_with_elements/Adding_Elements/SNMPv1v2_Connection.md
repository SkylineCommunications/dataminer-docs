---
uid: SNMPv1v2_Connection
---

# SNMPv1/v2 connections

For SNMPv1/v2 connections, you can specify the following connection settings while creating or editing an element:

- **SNMP version**: Allows you to select a different SNMP version than the version configured in the protocol. With an SNMPv1 type protocol, you can select SNMPv1, SNMPv2 or SNMPv3. With an SNMPv2 type protocol, you can select SNMPv2 or SNMPv3.

- **IP address/host**: The polling IP or URL of the destination.

- **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

- **Port number**: By default 161.

- **Use credentials**: If predefined credentials have been made available for your user account, you can select this checkbox to select a set of predefined SNMP credentials. See also: [Managing predefined sets of credentials for SNMP authentication](xref:Managing_predefined_sets_of_credentials_for_SNMP_authentication).

- **Get community string**: The community string used when reading values from the device. The default value, unless overridden in the protocol, is *public*.

- **Set community string**: The community string used when setting values on the device. The default value, unless overridden in the protocol, is *private*.

> [!NOTE]
> If a hostname instead of an IP is used in the polling IP address of an element's SNMP connection(s), the traps received from the hostname will not be captured. This is because DNS resolution does not occur when traps are received, causing the element's trap receivers to not know which IP to listen to.
