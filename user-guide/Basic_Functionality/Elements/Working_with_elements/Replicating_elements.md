---
uid: Replicating_elements
---

# Replicating elements

If you want an element to act as a replica of an element managed in another DMS, you can either create a new element for this, or edit an existing element.

While creating a new element or editing an existing element:

1. Select the *Replicate* checkbox.

1. Enter the IP address or hostname of the remote DMA hosting the element to be replicated.

1. Enter the username and the password the local DMA can use to log on to the remote DMS in order to retrieve the parameter values from the remote element.

   > [!NOTE]
   > External authentication credentials cannot be used when replicating elements. This is for instance the case when users are authenticated against an Atlassian Crowd server.

1. Click *Retrieve elements*.

1. Select the element to be replicated from the retrieved elements.

1. Continue the creation or editing as normal.

> [!NOTE]
>
> - The source and replication DMA must use the same DataMiner version. In addition, the replication DMA has to be able to set up a connection towards the source DMA.
> - The input and output interfaces of the element will also be replicated; however, any element connections that have been configured for the original element will not be replicated.
> - If the element uses the Production version of the protocol, and this version is different on the other DMA, only the statuses of the common parameters will be transferred.
> - Security is defined on the remote DMS. Access to the remote element will therefore depend on the rights granted to the credentials you entered to log on to the remote DMS. In other words, you cannot replicate an element if you do not have access to the view containing that element.
> - Replicating a [partial table](xref:Table_parameters#partial-tables) is not supported. Only the data of the first page will be present in the replicated element. The table rows that are present on the other pages will not be replicated.
> - While you configure element replication, the client machine running DataMiner Cube requires direct access to the remote DMA hosting the element to be replicated. Cube will make a direct connection to this DMA to retrieve the list of elements.

> [!TIP]
> See also:
>
> - [Replicated elements](xref:Replicated_elements)
> - [Element properties](xref:Element_properties)
> - [Updating elements](xref:Updating_elements)
