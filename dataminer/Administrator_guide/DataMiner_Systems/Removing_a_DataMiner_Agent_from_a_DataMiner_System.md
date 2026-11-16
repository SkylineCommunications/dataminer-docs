---
uid: Removing_a_DataMiner_Agent_from_a_DataMiner_System
description: "Learn how to remove a regular node from a DataMiner cluster and how to remove a node that is part of a Failover pair."
---

# Removing a node from a DataMiner cluster

Depending on whether the node is part of a Failover pair or not, a different procedure must be used.

> [!IMPORTANT]
> Only if [automatic NATS configuration is disabled](xref:Disabling_automatic_NATS_config), remove the Agent from the NATS cluster before you start the removal procedure below. For BrokerGateway-managed NATS, follow the steps in [Updating BrokerGateway-managed NATS before removal](#updating-brokergateway-managed-nats-before-removal). This also applies when decommissioning a Failover Agent.

## Updating BrokerGateway-managed NATS before removal

### Updating the DataMiner System's BrokerGateway-managed NATS

Complete this procedure before removing the Agent from the DataMiner System. It applies when BrokerGateway-managed NATS automatic configuration is disabled.

> [!CAUTION]
> ApplyManualConfig applies the full architecture you submit. If you omit other Agents, they can be removed from their current NATS cluster. Review the complete architecture before applying it.

1. On an Agent that will remain in the DataMiner System, back up `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.custom.json`.

1. Copy the value of the `ClusterArchitecture` property into a separate JSON document.

   Copy the full architecture object, without the enclosing `ClusterArchitecture` property.

1. Remove the Agent you are decommissioning from the appropriate region in the architecture.

   Preserve every other node and its configuration. If you need to verify a remaining node's `bgw_api_key`, locate the key with the `BrokerGateway` role in that node's `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`. If the Agent is part of a Failover pair, update `additional_endpoints` to retain only the endpoints required by the Agents that will remain.

1. On an Agent that will remain in the DataMiner System, open [BrokerGateway Swagger](https://localhost/BrokerGateway/swagger/index.html).

1. Select *Authorize* and enter the key with the `Administrator` role from that Agent's `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`.

1. Open `POST /api/clusteringapi/applymanualconfig`.

1. Paste the complete architecture object into the request body and execute the call once.

   Do not include the enclosing `ClusterArchitecture` property or invoke `SetManualConfig` separately.

1. Check the API response for errors.

1. Check the BrokerGateway logs on the remaining Agents and verify that the generated NATS configuration no longer includes the Agent you are removing.

1. After the NATS configuration has been applied successfully, continue with the applicable removal procedure below.

### Restoring BrokerGateway configuration on the removed Agent

If you used the preceding procedure to remove a node from a manually configured BrokerGateway NATS cluster, reset the removed Agent's BrokerGateway configuration after removing it from the DataMiner System:

1. On the removed Agent only, rename `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.custom.json` and `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`.

   Keep the renamed files as backups; do not delete them.

1. Restart the BrokerGateway service on the removed Agent.

   BrokerGateway will start with a local, automatic configuration.

## Removing a node that is not part of a Failover pair

1. On a node in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the list of nodes in the *Manage* section, select the node you want to remove.

1. Click the *Remove* button.

1. In the confirmation box, click *Yes*.

1. Stop the DataMiner Agent you have removed.

   This Agent should no longer be used, so you should decommission it.

1. If your system is connected to dataminer.services, remove the corresponding node on dataminer.services:

   1. Open the [Admin app](https://admin.dataminer.services/) and go to the DxMs page.

      This page shows an overview of all nodes, with the option to remove a node from the system.

   1. Click the garbage can icon next to the node you have just removed and confirm.

1. Restart DataMiner Cube to make sure the removed node is no longer displayed anywhere.

## Removing a Failover node

1. [End the Failover configuration](xref:Ending_a_Failover_configuration).

   > [!NOTE]
   > This first step is especially important if you are using Failover based on hostname. For Failover setups based on virtual IP, this step can be skipped.

1. On a node in the cluster, go to the *System Center* module and select the *Agents* page.

1. In the list of nodes in the *Manage* section, select the node you want to remove.

1. Click the *Remove* button.

1. In the confirmation box, click *Yes*.

1. Stop both Agents of the Failover pair.

1. Open the [DMS.xml](xref:DMS_xml) file on both Agents.

1. Remove all `<DMA />` and `<Redirect />` tags in *DMS.xml* that contain IP addresses from the previous cluster, and save the file.

1. Restart the Agent you want to keep as a node in the cluster.

   The other Agent should no longer be used and should be decommissioned.

1. If your system is connected to dataminer.services, remove the corresponding node on dataminer.services:

   1. Open the [Admin app](https://admin.dataminer.services/) and go to the DxMs page.

      This page shows an overview of all nodes, with the option to remove a node from the system.

   1. Click the garbage can icon next to the node you have just removed and confirm.

1. Restart DataMiner Cube to make sure the removed node is no longer displayed anywhere.
