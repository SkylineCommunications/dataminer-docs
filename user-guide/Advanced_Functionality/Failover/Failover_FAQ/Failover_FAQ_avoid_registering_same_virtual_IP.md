---
uid: Failover_FAQ_avoid_registering_same_virtual_IP
---

# How do I prevent DMAs in a Failover setup from registering the same virtual IP address?

It is standard behavior for a DMA to register its IP addresses on the DNS/domain. However, in a Failover setup using virtual IP addresses, this standard behavior can cause problems.

After a Failover switch, the virtual IP address, which was initially assigned to and registered by the primary DMA, will now be assigned to the backup DMA. The latter will then also register that same address. As a result, the DNS table will end up having duplicate entries.

## Situation

Suppose you have a Failover setup with two DMAs:

- DMA-MAIN, with IP address 10.10.10.1

- DMA-BACKUP, with IP address 10.10.10.2

### Initially

Initially, DMA-MAIN is the online Agent with virtual IP address 10.10.10.5.

Both Agents register their IP addresses with DNS and, as a result, the DNS table will contain the following data:

| Hostname          | IP address(es)            |
|-------------------|---------------------------|
| DMA-MAIN (online) | 10.10.10.1<br> 10.10.10.5 |
| DMA-BACKUP        | 10.10.10.2                |

### After a Failover switch

After a Failover switch, the virtual IP address 10.10.10.5 is assigned to DMA-BACKUP, which then also registers this address with DNS. DMA-MAIN, however, does not unregister it from DNS.

As a result, the DNS table will contain the following data:

| Hostname            | IP address(es)            |
|---------------------|---------------------------|
| DMA-MAIN            | 10.10.10.1<br> 10.10.10.5 |
| DMA-BACKUP (online) | 10.10.10.2<br> 10.10.10.5 |

## Possible issues

The fact that, after a Failover switch, the same virtual IP address has been registered by both the primary and the backup DMA causes a number of problems:

- A DNS lookup for DMA-MAIN will sometimes return 10.10.10.5 (i.e. the virtual IP address assigned to DMA-BACKUP). This will cause requests to end up on the backup Agent.

- A reverse DNS lookup for 10.10.10.5 will return DMA-MAIN at one occasion and DMA-BACKUP at another occasion.

- ...

## Suggested configuration

From DataMiner 10.2.0/10.1.8 onwards, configure the Failover pair to use a shared hostname instead of virtual IP addresses.

In older DataMiner Systems, one way of preventing both Agents from registering the virtual IP address, is the following:

1. In the *Advanced TCP/IP Settings* of the network interfaces that will use virtual IP addresses, go to the *DNS* tab and clear the option *Register this connection’s addresses in DNS*.

   ![Advanced TCP/IP Settings window](~/user-guide/images/advanced_tcpip_settings.png)

1. On the DNS server, add fixed records for both the main and the backup DMA. Also add an extra entry for the virtual IP address.

   Example (referring to the situation described above):

   | Hostname  | IP address(es) |
   |-------------|----------------|
   | DMA-MAIN    | 10.10.10.1     |
   | DMA-BACKUP  | 10.10.10.2     |
   | DMA-VIRTUAL | 10.10.10.5     |
