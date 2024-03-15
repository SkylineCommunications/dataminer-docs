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

## Changes

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### Verizon iDirect Evolution Platform Collector: Error related to circuit availability on startup [ID_39064]

When an element using the Verizon iDirect Evolution Platform Collector connector was started, errors could be thrown related to the circuit availability logic. These were caused by the *GetParameterIndexByKey* method returning null because the IDs had not yet been assigned to the circuit table.
