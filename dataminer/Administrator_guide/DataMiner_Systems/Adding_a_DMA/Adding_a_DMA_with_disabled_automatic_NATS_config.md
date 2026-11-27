---
uid: Adding_a_DMA_with_disabled_automatic_NATS_config
description: "Learn how to add a DataMiner Agent to a DataMiner System when BrokerGateway-managed NATS uses disabled automatic configuration."
---

# Adding a DMA with disabled automatic NATS configuration

Only when BrokerGateway-managed NATS automatic configuration is disabled, you must add the new Agent's NATS node to the manual NATS configuration before adding the Agent to the DataMiner System. For background, see [Disabling automatic NATS configuration](xref:Disabling_automatic_NATS_config#brokergateway-managed-nats).

> [!CAUTION]
> ApplyManualConfig applies the full architecture you submit. If you omit existing nodes, they can be removed from their current NATS cluster. Review the complete architecture before applying it.

## Prerequisites

- The existing DataMiner Agents and the new Agent use BrokerGateway-managed NATS.
- The new Agent's BrokerGateway endpoint is reachable from the existing Agents.
- The manual-config flag is not already enabled on the new Agent.
- On the new Agent, locate the API key with the `BrokerGateway` role in `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`. You will use this key for the node's `bgw_api_key` value.
- On an existing Agent, locate the API key with the `Administrator` role in the same `appsettings.runtime.json` path. You will use this key to authorize the ApplyManualConfig request in Swagger.
- Manual BrokerGateway configuration is supported from DataMiner 10.5.0 [CU1]/10.5.4 onwards.

## Procedure

1. On an existing Agent, back up `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.custom.json`.

1. Copy the value of the `ClusterArchitecture` property into a separate JSON document.

   Copy the full architecture object, without the enclosing `ClusterArchitecture` property.

1. Add the new Agent to the appropriate region in the architecture.

   Use the new Agent's BrokerGateway endpoint and the key with the `BrokerGateway` role from that Agent's `appsettings.runtime.json` for `bgw_api_key`. Preserve every existing node and its configuration. For Failover, include the Failover VIP or shared hostname in `additional_endpoints` when required. For more information about the fields, see the [manual config example](xref:Disabling_automatic_NATS_config#manual-config-example).

1. On an existing Agent, open [BrokerGateway Swagger](https://localhost/BrokerGateway/swagger/index.html).

1. Select *Authorize* and enter the key with the `Administrator` role from that Agent's `appsettings.runtime.json`.

1. Open `POST /api/clusteringapi/applymanualconfig`.

1. Paste the complete architecture object into the request body and execute the call once.

   Do not include the enclosing `ClusterArchitecture` property or invoke `SetManualConfig` separately.

1. Check the API response for errors.

1. Check the BrokerGateway logs on the affected Agents and verify that the generated NATS configuration includes the new node.

1. After the NATS configuration has been applied successfully, add the Agent to the DataMiner System by following [Adding a regular DataMiner Agent as a node in a cluster](xref:Adding_a_regular_DataMiner_Agent).

   To commission a Failover pair, first add the primary Agent as a regular node, then configure Failover. See [Preparing the two DataMiner Agents](xref:Preparing_the_two_DataMiner_Agents).
