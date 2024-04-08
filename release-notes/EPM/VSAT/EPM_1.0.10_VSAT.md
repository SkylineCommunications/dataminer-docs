---
uid: EPM_1.0.10_VSAT
---

# EPM 1.0.10 VSAT - preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

#### Intelsat Flex Platform VSAT: New KPIs in Terminals table [ID_39065]

The following parameters have been added to the Terminals table in the Intelsat Flex Platform VSAT connector:

- From REST API:

  - Fwd OTA Traffic

  - Rtn OTA Traffic

- Converted from Kafka:

  - Downstream Total kbps

  - Upstream Total kbps

#### Intelsat Flex Platform VSAT: New KPIs in Terminals table [ID_39179] [ID_39180]

The following parameters have been added to the Terminals table of the Intelsat Flex Platform VSAT connector:

- Aggregated State
- Fan Status
- Operational State
- Power Adjustment
- Packet Delivery
- SLA Site Status
- SLA Latency
- SLA Packet Delivery
- Terminal Operational State
- Terminal Board Temperature

#### Intelsat Flex Platform VSAT: Additional hidden KPIs in Terminals table [ID_39218]

The following parameters from the REST API have been added to the Terminals table of the Intelsat Flex Platform VSAT connector:

- Free Time Slots Allocated
- Time Slots Allocated
- Time Slots Allocated (Nom Carrier)
- Temperature

However, note that these are currently still hidden, because no data is returned for these from the NMS.

## Changes

### Enhancements

#### Verizon ETMS Platform: Activity log adjusted [ID_39342]

The activity log of the Verizon ETMS Platform connector has been updated to reflect new possible entities under a higher entity based on information received from a ticket request.

#### Verizon WM Ticketing adjusted to handle new entities [ID_39343]

The Verizon WM Ticketing connector has been adjusted to handle multiple HETs subscriptions with the same high entity as well as to handle more types of entities and higher entities.

#### Verizon WM Ticketing: Active HETs table adjusted [ID_39345]

The Active HETs table has been adjusted to keep all higher entities with their breach percentage, event count, and state, instead of deleting the row when HETs is no longer active for the entity. It is now also possible to activate trending for these parameters.

### Fixes

#### Verizon iDirect Evolution Platform Collector: Error related to circuit availability on startup [ID_39064]

When an element using the Verizon iDirect Evolution Platform Collector connector was started, errors could be thrown related to the circuit availability logic. These were caused by the *GetParameterIndexByKey* method returning null because the IDs had not yet been assigned to the circuit table.

#### Newtec Dialog Platform VSAT: Incorrect Hub Forward and Return Count KPIs [ID_39191]

On the *General* page of Newtec Dialog Platform VSAT elements, the Hub Forward and Return Count KPIs did not match the total count of rows found in the Hub Forward and Hub Return tables, respectively. Instead these were incorrectly based on the total count of rows from the Forward/Return Links tables.
