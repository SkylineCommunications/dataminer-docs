---
uid: Failover_FAQ_cable_pulled_out
---

# What happens if a network cable is pulled out of one of the DMA network cards?

Different scenarios are possible:

- [If the network cable connecting to the switch or router is pulled out of the online DMA](#if-the-network-cable-connecting-to-the-switch-or-router-is-pulled-out-of-the-online-dma)

- [If the network cable used for synchronization is pulled out of the online DMA](#if-the-network-cable-used-for-synchronization-is-pulled-out-of-the-online-dma)

- [If both network cables are pulled out of the online DMA](#if-both-network-cables-are-pulled-out-of-the-online-dma)

- [If the network cable connecting to the switch or router is pulled out of the offline DMA](#if-the-network-cable-connecting-to-the-switch-or-router-is-pulled-out-of-the-offline-dma)

- [If the network cable used for synchronization is pulled out of the offline DMA](#if-the-network-cable-used-for-synchronization-is-pulled-out-of-the-offline-dma)

- [If both network cables are pulled out of the offline DMA](#if-both-network-cables-are-pulled-out-of-the-offline-dma)

## If the network cable connecting to the switch or router is pulled out of the online DMA

- The offline DMA will detect a failing heartbeat path toward the online DMA, and will go online after a number of heartbeat failures.

- In the Alarm Console, a notice will appear indicating a failing heartbeat path.

- The *Status* dialog box will indicate that the DMA is unreachable, and that the heartbeat to the DMA is failing.

- The DMA will go offline because of the failing heartbeat, and because the other DMA, which has now taken over, will have sent a notification over the sync connection.

- Both DataMiner sync and database sync will go on as the sync connection is still available.

- Once the cable is reconnected, the other DMA will stay online.

> [!TIP]
> See also:
>
> - [Viewing Failover information](xref:Viewing_Failover_information)
> - [Heartbeats](xref:Advanced_Failover_options#heartbeats)

## If the network cable used for synchronization is pulled out of the online DMA

- In the Alarm Console, notices will appear, indicating that:

  - an NIC has been unplugged,

  - the sync connection is failing,

  - DB forwarding is failing.

- In the *Status* dialog box, you will see the same errors:

  - *Sync Connection* will get the status *Not Available.*

  - *DB Sync* will get the status *Failing*.

  - The NIC in question will get the status *Unavailable*.

- Once the cable is reconnected, synchronization will again be OK.

> [!TIP]
> See also: [Viewing Failover information](xref:Viewing_Failover_information)

## If both network cables are pulled out of the online DMA

- The offline DMA will detect that the DMA is unreachable, and will go online.

- The DMA of which the cables have been pulled out will detect that the ping to the switch or router is failing, and will go offline.

- In the Alarm Console of the other DMA, which is now online, notices will appear, indicating that both the sync connection and the database data forwarding are failing.

- In the *Status* dialog box:

  - The Agent status will be *Unreachable*.

  - The Heartbeat will get the status *Failing*.

  - *Sync Connection* will get the status *Not Available*.

  - *DB Sync* will get the status *Failing*.

- Once the cables are reconnected, synchronization will again be OK, and the other DMA will stay online.

> [!TIP]
> See also:
>
> - [Viewing Failover information](xref:Viewing_Failover_information)
> - [Heartbeats](xref:Advanced_Failover_options#heartbeats)

## If the network cable connecting to the switch or router is pulled out of the offline DMA

- The online DMA remains online.

- In the Alarm Console, a notice will appear, indicating that the heartbeat path is failing.

- In the *Status* dialog box, the status of the Heartbeat will be *Failing*, and the Agent status for the offline Agent will be *Unreachable*.

- Both DataMiner sync and database sync will go on as the sync connection is still available.

> [!TIP]
> See also:
>
> - [Viewing Failover information](xref:Viewing_Failover_information)
> - [Heartbeats](xref:Advanced_Failover_options#heartbeats)

## If the network cable used for synchronization is pulled out of the offline DMA

- The online DMA remains online.

- In the Alarm Console, there will be a timeout alarm due to the lost connection, and notices will appear, indicating that:

  - an NIC has been unplugged,

  - the sync connection is failing,

  - DB forwarding is failing.

- In the *Status* dialog box, you will see the same errors:

  - *Sync Connection* will get the status *Not Available*.

  - *DB Sync* will get the status *Failing*.

  - The NIC in question will get the status *Unavailable*.

- Once the cable is reconnected, synchronization will again be OK.

> [!TIP]
> See also: [Viewing Failover information](xref:Viewing_Failover_information)

## If both network cables are pulled out of the offline DMA

- The online DMA remains online.

- In the Alarm Console, notices will appear, indicating that heartbeat paths and sync connection are failing.

- In the *Status* dialog box:

  - The Agent status will be *Unreachable*.

  - The Heartbeat will get the status *Failing*.

  - *Sync Connection* will get the status *Not Available*.

  - *DB Sync* will get the status *Failing*.

- Once the cables are reconnected, synchronization will again be OK.

> [!TIP]
> See also:
>
> - [Viewing Failover information](xref:Viewing_Failover_information)
> - [Heartbeats](xref:Advanced_Failover_options#heartbeats)
