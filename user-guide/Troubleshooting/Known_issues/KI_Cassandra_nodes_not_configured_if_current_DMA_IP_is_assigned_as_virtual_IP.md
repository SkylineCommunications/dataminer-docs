---
uid: KI_Cassandra_nodes_not_configured_if_current_DMA_IP_is_assigned_as_virtual_IP
---

# Cassandra nodes not configured if current DMA IP is assigned as virtual IP

## Affected versions

10.1.x

## Cause

Unknown

## Fix

None yet.

## Issue description

In the *Failover configuration* window, by default the current IP of the primary DMA is set as the virtual IP of the Failover pair. However, if you keep this default configuration and assign a new IP for the primary DMA, the Cassandra nodes will not be joined into a Failover cluster. You can confirm this by running `nodetool status` on both DMAs after you have configured Failover. You will see two independent nodes, unaware of each other.

## Workaround

Keep the current DMA IP as the physical IP, and assign a new virtual IP.
