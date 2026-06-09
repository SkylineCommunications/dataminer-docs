---
uid: Starting_from_self-managed_cluster
description: Learn how to expand a self-managed DataMiner cluster into a hybrid setup by adding DaaS nodes and preparing the environment correctly.
---

# Creating a hybrid cluster starting from a self-managed cluster

## Prerequisites

- A cluster consisting of one or more self-managed DataMiner nodes using [Storage as a Service](xref:STaaS).

## Step-by-step procedure

1. [Create the DaaS nodes](xref:Creating_a_DMS_on_dataminer_services) you want to add to the cluster.

   Make sure to deploy the nodes in a region close to where your self-managed nodes are deployed to minimize latency.

1. Make sure your self-managed nodes are [upgraded](xref:Upgrading_a_DataMiner_Agent) to the **same DataMiner version** as the DaaS nodes.

1. Make sure [Swarming is enabled](xref:EnableSwarming) in the self-managed cluster.

1. In your existing cluster, create a user account `DataMinerAdmin` with the password defined for the Admin account of the DaaS nodes, and give it administrator permissions.

1. Ensure that the following files on self-hosted Agents only contain IP addresses and not hostnames:

   - `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json`

   - `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`

   - `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\nats-server\nats-server.config`

1. Contact <daas@dataminer.services> to complete the setup. They will:

   - Ensure that the time zone of your DaaS nodes is aligned with that of your self-managed nodes.
   - Ensure that the correct DaaS address space is used.
   - Establish a VPN connection (see [About the site-to-site VPN connection](xref:Connecting_to_private_data_sources#about-the-site-to-site-vpn-connection)).
   - Join the DaaS nodes to your self-managed cluster.
