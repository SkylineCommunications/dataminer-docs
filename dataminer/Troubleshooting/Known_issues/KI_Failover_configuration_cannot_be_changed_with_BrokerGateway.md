---
uid: KI_Failover_configuration_cannot_be_changed_with_BrokerGateway
description: Learn why Failover manual/automatic mode changes can fail in BrokerGateway-managed DataMiner Systems with specific DataMiner versions and how to fix this.
---

# Not possible to change Failover configuration after migration to BrokerGateway

## Affected versions

DataMiner Systems using [BrokerGateway-managed NATS](xref:BrokerGateway_Migration) from DataMiner 10.5.0 [CU4]/10.5.7<!-- RN 42494 --> up to 10.6.0 [CU4]/10.6.7.

## Cause

Starting from DataMiner 10.5.0 [CU4]/10.5.7, in systems that have been migrated to BrokerGateway, a change in NATS behavior can cause inconsistent cluster routing and authority resolution between Failover Agents. As a result, redirects can loop, and no clear authoritative Agent is selected, so Failover configuration updates can be intercepted or aborted.

## Fix

Install DataMiner 10.6.0 [CU5]/10.6.8.<!-- RN 45613 -->

## Description

In DataMiner Systems that have been [migrated to BrokerGateway](xref:BrokerGateway_Migration), switching from a manual to an automatic Failover configuration or vice versa can fail.
