---
uid: IDP_1.1.10_CU2
---

# IDP 1.1.10 CU2

## Enhancements

#### Improvements related to provisioning of virtual protocol types \[ID_27719\]

It is now possible to provision more than one device with a virtual protocol type using the same CI type. In addition, when a device is provisioned with a virtual protocol type, if an IP address is available, it is now shown in the *IP Address* column of the *Managed Elements* table.

### Fixes

#### Incorrect exception when provisioning with incomplete CI type \[ID_28397\]

When a user tried to create an element for which the CI type did not have Provisioning.Configuration content, an incorrect exception was thrown.

#### Not possible to create SNMPv3 element on different DMA in the cluster \[ID_28403\]

Provisioning an element with SNMPv3 credentials did not work if the element was created on a different DMA in the cluster than the one containing the IDP Provisioning Manager.
