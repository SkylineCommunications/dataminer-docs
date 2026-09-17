---
uid: Starting_from_self-managed_cluster
description: "Learn how to expand a self-managed DataMiner cluster into a hybrid setup by adding DaaS nodes and preparing the environment correctly."
---

# Creating a hybrid cluster starting from a self-managed cluster

## Prerequisites

- A cluster consisting of one or more self-managed DataMiner nodes using [Storage as a Service](xref:STaaS).

- A user account with the Admin or Owner role in the dataminer.services organization that owns the DaaS nodes.

## Step-by-step procedure

1. Make sure your self-managed nodes are [upgraded](xref:Upgrading_a_DataMiner_Agent) to a **supported DaaS DataMiner version**.

   In general, all Feature Release versions starting from **10.5.11** and Main Release versions starting from **10.6.0** are supported. For more details on supported versions, contact <daas@dataminer.services>.

1. Make sure [Swarming is enabled](xref:EnableSwarming) in the self-managed cluster.

1. Make sure [BrokerGateway is used](xref:BrokerGateway_Migration) in the self-managed cluster.

1. In DataMiner, create a new user account `HybridAdmin` and configure it as follows:

   - Assign it to the built-in *Administrators* group.

   - Make sure *Password never expires* is selected.

   - Make sure the password meets the complexity requirements of DaaS nodes:

     - It does not contain the user's account name or parts of the user's full name that exceed two consecutive characters

     - It is at least six characters in length

     - It contains characters from three of the following four categories:

       - English uppercase characters (A through Z)

       - English lowercase characters (a through z)

       - Base 10 digits (0 through 9)

       - Non-alphabetic characters (for example, !, $, #, %)

   > [!NOTE]
   > The `HybridAdmin` user account will be used for cluster syncing, which means it needs to have the same password on all Agents in the cluster.

1. Contact <daas@dataminer.services> with a request to complete the setup.

   Make sure your email includes the following information:

   - The desired Azure region for the DaaS nodes.

      Make sure to choose a region close to where your self-managed nodes are deployed to **minimize latency**.

   - The time zone of the on-premises cluster

      > [!IMPORTANT]
      > It is important that the time zone of your DaaS nodes is aligned with that of your self-managed nodes. A mismatch can result in incorrect syncing and data loss when the cluster is created.

   - The organization name where your DataMiner System resides on <https://dataminer.services>.

   - The system name of your DataMiner System on <https://dataminer.services>.

   - The email address of an owner or admin in the provided organization who should become the owner of the new DaaS system.

   - The IP address of the DMA.

   - The password of the `HybridAdmin` user account.

   Skyline's DaaS team will perform the following steps to complete the setup:

   1. Deploy the DaaS nodes.

   1. Establish a VPN connection (see [About the site-to-site VPN connection](xref:Connecting_to_private_data_sources#about-the-site-to-site-vpn-connection)).

   1. Join the DaaS nodes to your self-managed cluster.
