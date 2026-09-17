---
metadata_version: 1
uid: AdvancedDcfHelper
description: "Use the DataMiner Connectivity Framework helper package when implementing DCF behavior in a connector."
area: develop
content_type: conceptual
authority: reference
authority_source: AdvancedDcf
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# DCF Helper Class

When implementing DCF, the DCF helper class should be used. The latest version of this helper class can be found on [the public NuGet store](https://www.nuget.org/packages/Skyline.DataMiner.Core.ConnectivityFramework.Protocol).

## Audience and prerequisites

This page is for connector developers implementing DataMiner Connectivity Framework (DCF) interfaces and connections. Before using the helper, review the DCF concepts and add the package reference required by the connector project.

## Scope

The helper class provides reusable DCF functionality for a connector. It is distributed through the `Skyline.DataMiner.Core.ConnectivityFramework.Protocol` NuGet package; it is not a replacement for the generated protocol interfaces or the DCF configuration in *Protocol.xml*.

## Expected result

After referencing a compatible package version, the connector can use the helper APIs while implementing its DCF behavior.

## Failure and edge cases

A package version that does not match the connector's target SDK can cause compile or runtime incompatibilities. Keep the package reference explicit and verify the package version when upgrading the connector.

## Related concepts

- [Advanced DCF](xref:AdvancedDcf)
- [Defining DCF interfaces](xref:AdvancedDcfDefiningInterfaces)
- [DCF interfaces and connections](xref:AdvancedDcfInterfacesAndConnections)

## Authoritative references

- [Skyline.DataMiner.Core.ConnectivityFramework.Protocol on NuGet](https://www.nuget.org/packages/Skyline.DataMiner.Core.ConnectivityFramework.Protocol)
- [Advanced DCF](xref:AdvancedDcf)
