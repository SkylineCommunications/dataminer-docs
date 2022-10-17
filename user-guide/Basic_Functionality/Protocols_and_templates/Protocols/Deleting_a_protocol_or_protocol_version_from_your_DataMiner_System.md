---
uid: Deleting_a_protocol_or_protocol_version_from_your_DataMiner_System
---

# Deleting a protocol or protocol version from your DataMiner System

If you are absolutely sure that a protocol or a protocol version is no longer used in your DataMiner System, you can choose to delete it.

> [!CAUTION]
> When you delete a protocol, all its information templates will be deleted as well.

To do so:

1. Go to *Apps* > *Protocols & Templates*.

1. Under *Protocols* or *Versions*, right-click the protocol or protocol version you want to delete and select *Delete*.

   - Select a protocol name if you want to delete all versions of that protocol.

   - Select a protocol version if you want to delete only that specific protocol version.

   > [!CAUTION]
   > Carefully read the contents of the confirmation box as it explains the overall system impact of the delete operation you are about to execute.

1. In the confirmation box, click *Yes* to proceed or click *No* to cancel.

> [!NOTE]
>
> - The "Production" entry itself cannot be deleted, but you can delete the protocol version that was promoted to "Production". However, we recommend that you first promote another version of the protocol to "Production".
> - When you delete a DVE main protocol, all the DVE child protocols are deleted as well. It is not possible to delete a DVE child protocol on its own.
> - When you delete a protocol for which a function is active, from DataMiner 10.1.0 \[CU18]/10.2.0 \[CU6]/10.2.9 onwards, the corresponding function DVE protocol is also removed from the system.
