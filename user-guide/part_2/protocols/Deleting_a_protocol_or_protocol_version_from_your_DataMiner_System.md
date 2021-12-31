## Deleting a protocol or protocol version from your DataMiner System

If you are absolutely sure that a protocol or a protocol version is no longer used in your DataMiner System, you can choose to delete it.

> [!CAUTION]
> When you delete a protocol, all its information templates will be deleted as well.

To do so:

1. Go to *Apps* >* Protocols & Templates*.

2. Under *Protocols* or *Versions*, right-click the protocol or protocol version you want to delete and select *Delete*.

    - Select a protocol name if you want to delete all versions of that protocol.

    - Select a protocol version if you want to delete only that specific protocol version.

    > [!CAUTION]
    > Carefully read the contents of the confirmation box as it explains the overall system impact of the delete operation you are about to execute.

3. In the confirmation box, click *Yes* to proceed or click *No* to cancel.

> [!NOTE]
> -  A production version of a protocol cannot be deleted. If you want to delete a protocol version that is marked “Production”, first promote another version of that same protocol to production version and then try again.
> -  When you delete a DVE main protocol, all the DVE child protocols are deleted as well. It is not possible to delete a DVE child protocol on its own.
>
