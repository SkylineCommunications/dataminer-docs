# Frequently asked questions about DMA Failover

This section consists of the following topics:

- [What happens if one of the DMAs is stopped in a Failover setup?](#what-happens-if-one-of-the-dmas-is-stopped-in-a-failover-setup)

- [What happens if one of the DMAs is restarted in a Failover setup?](#what-happens-if-one-of-the-dmas-is-restarted-in-a-failover-setup)

- [What happens when the database server on one of the DMAs stops working?](#what-happens-when-the-database-server-on-one-of-the-dmas-stops-working)

- [What happens if a network cable is pulled out of one of the DMA network cards?](#what-happens-if-a-network-cable-is-pulled-out-of-one-of-the-dma-network-cards)

- [How do I upgrade a pair of DMAs in a Failover setup?](#how-do-i-upgrade-a-pair-of-dmas-in-a-failover-setup)

- [How do I prevent DMAs in a Failover setup from registering the same virtual IP address?](#how-do-i-prevent-dmas-in-a-failover-setup-from-registering-the-same-virtual-ip-address)

- [What if I have connection issues after a Failover switch?](#what-if-i-have-connection-issues-after-a-failover-switch)

- [What should I do if one of the Agents in a Failover pair cannot be started or restarted?](#what-should-i-do-if-one-of-the-agents-in-a-failover-pair-cannot-be-started-or-restarted)

### What happens if one of the DMAs is stopped in a Failover setup?

#### If the online DMA is stopped

- The other, offline DMA will detect heartbeat path failures and will go online.

- In the Alarm Console of the other DMA a notice will appear, indicating that heartbeat paths and sync connection are failing.

- In the *Status* dialog box, you will see that the DMA is *Unreachable*, and that Heartbeat and DB Sync are *Failing*.

#### If the offline DMA is stopped

- The online DMA will keep working as normal.

- In the Alarm Console of the online DMA a notice will appear, indicating that heartbeat paths and sync connection are failing.

- In the *Status* dialog box, you will see that the offline DMA is *Unreachable*, and that Heartbeat and DB Sync are *Failing*.

> [!NOTE]
> This is also what happens when a DMA shuts down unexpectedly, for instance because of a power failure.

> [!TIP]
> See also:
> [Viewing Failover information](Viewing_Failover_information.md)

### What happens if one of the DMAs is restarted in a Failover setup?

#### If the offline DMA is restarted

- In the Alarm Console of the online DMA, a “Failing Heartbeat Path” notice will appear during the restart.

#### If the online DMA is restarted

- If the offline DMA detects several failing heartbeats because the restart takes a long time, an automatic switchover will occur.

    This depends on the duration of the restart and on the heartbeat settings.     For more information on the heartbeat settings, see [Heartbeats](Advanced_Failover_options.md#heartbeats).

- After the restart, if the online DMA cannot connect to the other DMA, it will go back online automatically.

### What happens when the database server on one of the DMAs stops working?

#### If the database server on the online DMA stops working

- There will be no automatic switchover to the offline DMA.

- Runtime errors or notices might show up on the online DMA, indicating a database problem.

- In the *Status* dialog box, the database will get the status *Failing*.

- Database data will still be gathered, and will be inserted into the database once it becomes available again.

#### If the database server on the offline DMA stops working

- This problem will not immediately be visible from the online DMA.

- The *Failover* dialog box will indicate that the offline DMA is in an error state (red LED).

- In the *Status* dialog box, the database of the offline DMA will get the status *Failing*.

- Database data will still be forwarded, but the data will only be inserted into the database of the offline DMA when that database is accessible again.

> [!TIP]
> See also:
> [Viewing Failover information](Viewing_Failover_information.md)

### What happens if a network cable is pulled out of one of the DMA network cards?

Different scenarios are possible:

- [If the network cable connecting to the switch or router is pulled out of the online DMA](#if-the-network-cable-connecting-to-the-switch-or-router-is-pulled-out-of-the-online-dma)

- [If the network cable used for synchronization is pulled out of the online DMA](#if-the-network-cable-used-for-synchronization-is-pulled-out-of-the-online-dma)

- [If both network cables are pulled out of the online DMA](#if-both-network-cables-are-pulled-out-of-the-online-dma)

- [If the network cable connecting to the switch or router is pulled out of the offline DMA](#if-the-network-cable-connecting-to-the-switch-or-router-is-pulled-out-of-the-offline-dma)

- [If the network cable used for synchronization is pulled out of the offline DMA](#if-the-network-cable-used-for-synchronization-is-pulled-out-of-the-offline-dma)

- [If both network cables are pulled out of the offline DMA](#if-both-network-cables-are-pulled-out-of-the-offline-dma)

#### If the network cable connecting to the switch or router is pulled out of the online DMA

- The offline DMA will detect a failing heartbeat path toward the online DMA, and will go online after a number of heartbeat failures.

- In the Alarm Console, a notice will appear indicating a failing heartbeat path.

- The *Status* dialog box will indicate that the DMA is unreachable, and that the heartbeat to the DMA is failing.

- The DMA will go offline because of the failing heartbeat, and because the other DMA, which has now taken over, will have sent a notification over the sync connection.

- Both DataMiner sync and database sync will go on as the sync connection is still available.

- Once the cable is reconnected, the other DMA will stay online.

> [!TIP]
> See also:
> -  [Viewing Failover information](Viewing_Failover_information.md)
> -  [Heartbeats](Advanced_Failover_options.md#heartbeats) 

#### If the network cable used for synchronization is pulled out of the online DMA

- In the Alarm Console, notices will appear, indicating that:

    - an NIC has been unplugged,

    - the sync connection is failing,

    - DB forwarding is failing.

- In the *Status* dialog box, you will see the same errors:

    - *Sync Connection* will get the status *Not Available.*

    - *DB Sync* will get the status *Failing*.

    - The NIC in question will get the status *Unavailable*.

- Once the cable is reconnected, synchronization will again be OK.

> [!TIP]
> See also:
> [Viewing Failover information](Viewing_Failover_information.md)

#### If both network cables are pulled out of the online DMA

- The offline DMA will detect that the DMA is unreachable, and will go online.

- The DMA of which the cables have been pulled out will detect that the ping to the switch or router is failing, and will go offline.

- In the Alarm Console of the other DMA, which is now online, notices will appear, indicating that both the sync connection and the database data forwarding are failing.

- In the *Status* dialog box:

    - The Agent status will be *Unreachable*.

    - The Heartbeat will get the status *Failing*.

    - *Sync Connection* will get the status *Not Available*.

    - *DB Sync* will get the status *Failing*.

- Once the cables are reconnected, synchronization will again be OK, and the other DMA will stay online.

> [!TIP]
> See also:
> -  [Viewing Failover information](Viewing_Failover_information.md)
> -  [Heartbeats](Advanced_Failover_options.md#heartbeats) 

#### If the network cable connecting to the switch or router is pulled out of the offline DMA

- The online DMA remains online.

- In the Alarm Console, a notice will appear, indicating that the heartbeat path is failing.

- In the *Status* dialog box, the status of the Heartbeat will be *Failing*, and the Agent status for the offline Agent will be *Unreachable*.

- Both DataMiner sync and database sync will go on as the sync connection is still available.

> [!TIP]
> See also:
> -  [Viewing Failover information](Viewing_Failover_information.md)
> -  [Heartbeats](Advanced_Failover_options.md#heartbeats) 

#### If the network cable used for synchronization is pulled out of the offline DMA

- The online DMA remains online.

- In the Alarm Console, there will be a timeout alarm due to the lost connection, and notices will appear, indicating that:

    - an NIC has been unplugged,

    - the sync connection is failing,

    - DB forwarding is failing.

- In the *Status* dialog box, you will see the same errors:

    - *Sync Connection* will get the status *Not Available*.

    - *DB Sync* will get the status *Failing*.

    - The NIC in question will get the status *Unavailable*.

- Once the cable is reconnected, synchronization will again be OK.

> [!TIP]
> See also:
> [Viewing Failover information](Viewing_Failover_information.md)

#### If both network cables are pulled out of the offline DMA

- The online DMA remains online.

- In the Alarm Console, notices will appear, indicating that heartbeat paths and sync connection are failing.

- In the *Status* dialog box:

    - The Agent status will be *Unreachable*.

    - The Heartbeat will get the status *Failing*.

    - *Sync Connection* will get the status *Not Available*.

    - *DB Sync* will get the status *Failing*.

- Once the cables are reconnected, synchronization will again be OK.

> [!TIP]
> See also:
> -  [Viewing Failover information](Viewing_Failover_information.md)
> -  [Heartbeats](Advanced_Failover_options.md#heartbeats) 

### How do I upgrade a pair of DMAs in a Failover setup?

To upgrade a pair of DataMiner Agents in a Failover setup, you can use the DataMiner Taskbar Utility or the *System Center* module in DataMiner Cube.

- For more info on how to do this using the DataMiner Taskbar Utility, see [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](../DataminerAgents/Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility.md).

- For more info on how to do this in DataMiner Cube, see [Upgrading a DataMiner Agent in System Center](../DataminerAgents/Upgrading_a_DataMiner_Agent_in_System_Center.md).

### How do I prevent DMAs in a Failover setup from registering the same virtual IP address?

It is standard behavior for a DMA to register its IP addresses on the DNS/Domain. However, in a Failover setup using virtual IP addresses, this standard behavior can cause problems.

After a Failover switch, the virtual IP address, which was initially assigned to and registered by the primary DMA, will now be assigned to the backup DMA. The latter will then also register that same address. As a result, the DNS table will end up having duplicate entries.

#### Situation

Suppose you have a Failover setup with two DMAs:

- DMA-MAIN, with IP address 10.10.10.1

- DMA-BACKUP, with IP address 10.10.10.2

##### Initially

Initially, DMA-MAIN is the online Agent with virtual IP address 10.10.10.5.

Both Agents register their IP addresses with DNS and, as a result, the DNS table will contain the following data:

| Hostname          | IP address(es)            |
|-------------------|---------------------------|
| DMA-MAIN (online) | 10.10.10.1<br> 10.10.10.5 |
| DMA-BACKUP        | 10.10.10.2                |

##### After a Failover switch

After a Failover switch, the virtual IP address 10.10.10.5 is assigned to DMA-BACKUP, which then also registers this address with DNS. DMA-MAIN, however, does not unregister it from DNS.

As a result, the DNS table will contain the following data:

| Hostname            | IP address(es)            |
|---------------------|---------------------------|
| DMA-MAIN            | 10.10.10.1<br> 10.10.10.5 |
| DMA-BACKUP (online) | 10.10.10.2<br> 10.10.10.5 |

#### Possible issues

The fact that, after a Failover switch, the same virtual IP address has been registered by both the primary and the backup DMA causes a number of problems:

- A DNS lookup for DMA-MAIN will sometimes return 10.10.10.5 (i.e. the virtual IP address assigned to DMA-BACKUP). This will cause requests to end up on the backup Agent.

- A reverse DNS lookup for 10.10.10.5 will return DMA-MAIN at one occasion and DMA-BACKUP at another occasion.

- ...

#### Suggested configuration

From DataMiner 10.2.0/10.1.8 onwards, configure the Failover pair to use a shared hostname instead of virtual IP addresses.

In older DataMiner Systems, one way of preventing both Agents from registering the virtual IP address, is the following:

1. In the *Advanced TCP/IP Settings* of the network interfaces that will use virtual IP addresses, go to the *DNS* tab and clear the option *Register this connection’s addresses in DNS*.

![](../../images/advanced_tcpip_settings.png)

 

2. On the DNS server, add fixed records for both the main and the backup DMA. Also add an extra entry for the virtual IP address.

    Example (referring to the situation described above):

    | Hostname  | IP address(es) |
    |-------------|----------------|
    | DMA-MAIN    | 10.10.10.1     |
    | DMA-BACKUP  | 10.10.10.2     |
    | DMA-VIRTUAL | 10.10.10.5     |

### What if I have connection issues after a Failover switch?

It is possible that, after a Failover switch, you run into connection issues because the servers’ routing tables have been altered. This problem is caused by the way persistent routes have been defined.

To fix the problem, you need to recreate the routes and explicitly specify an interface for them to bind to.

> [!NOTE]
> It is best to do this from a remote desktop session on the other Agent, as deleting the routes could otherwise kill your session.

1. In a command prompt window, execute the following command:

    ```txt
    route print
    ```

    This will produce a list like the following one:

    ```txt
    Interface List                                              
    23...b8 ac 6f 15 15 1a ......BASP Virtual Adapter #4        
    20...b8 ac 6f 15 15 1a ......BASP Virtual Adapter #2        
    21...b8 ac 6f 15 15 1a ......BASP Virtual Adapter #3        
    24...b8 ac 6f 15 15 1e ......BASP Virtual Adapter #6        
     1...........................Software Loopback Interface 1  
    22...00 00 00 00 00 00 00 e0 Microsoft ISATAP Adapter #2    
    17...00 00 00 00 00 00 00 e0 Microsoft ISATAP Adapter #4    
    ```

    Also, there will be a list of persistent routes for IPv4:

    ```txt
    Persistent routes:  Network Address         Netmask   Gateway Address   Metric          1.2.3.4   255.255.255.0           5.6.7.8        1
    ```

2. In another command prompt window, execute the following commands for each of the listed persistent routes.

    In the lines below, replace the IP addresses and masks by the ones in the list above, and replace “X” by the correct interface ID. In the list above, “23”, “20”, “21” and “24” are correct interface IDs.

    ```txt
    route delete 1.2.3.4  route add 1.2.3.4 mask 255.255.255.0 5.6.7.8 IF X -p
    ```

    > [!NOTE]
    > Make sure that you use the correct interface ID for the route to go through. In the example above, this should be the interface through which the 5.6.7.8 gateway address can be reached. “Ipconfig /all” might help for you to select the correct interface. If an interface exists for which the route gateway address falls within the subnet for that interface, that interface should be used (e.g. a local interface having IP address 5.6.0.1 and mask 255.255.0.0).

Once the routes have been recreated with an interface number assigned, they will no longer disappear from the list of active routes when the virtual IP address is removed because the DMA is stopped or goes offline.

### What should I do if one of the Agents in a Failover pair cannot be started or restarted?

When a Failover configuration is set up, one of the Cassandra instances is automatically designated as the master seed node. When the master seed node is not available, it is not possible to restart or start the database of the other DMA.

Therefore, if starting or restarting one of the Agents in a Failover pair fails, first make sure the other Agent is online and available.

 
