---
uid: Enabling_the_virtual_SNMP_agent_of_an_element
---

# Enabling the virtual SNMP agent of an element

Every element in a DataMiner System incorporates a virtual SNMP agent. If you assign a virtual IP address to an element and you enable its virtual SNMP agent, whenever an alarm occurs on that element, it will forward an SNMP trap toward every activated SNMP manager defined in the DataMiner System.

To do so:

1. In the Surveyor, right-click the element, and select *Edit*.

1. In the *Edit* tab, open *Advanced element settings*.

1. Select *Enable SNMP agent*, and enter a virtual IP address and a subnet mask.

1. Click *Apply*.

> [!NOTE]
> If the virtual SNMP agent of an element is disabled (e.g. because the element has not been assigned a virtual IP address), then all SNMP notifications associated with that element will be sent from the primary IP address of either the DataMiner Agent hosting the element or the DataMiner Agent assigned to send all northbound SNMP notifications. See the *Send all notifications via one DMA* setting in [Configuring an SNMP manager in DataMiner Cube](xref:Configuring_an_SNMP_manager_in_DataMiner_Cube).
