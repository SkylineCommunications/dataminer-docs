---
uid: Pricing_sizing_guide
---

# Sizing guide

This guide will help you estimate the service volumes to enter when you create a new subscription via the Billing page of the [DataMiner Admin app](xref:About_the_Admin_app).

## Categories

The categories of this sizing guide are divided in the following main sections:

- [Services](xref:Pricing_sizing_guide_services): Individual services including Managed Objects, Connectors, Automation, and Storage.
- [Solutions](xref:Pricing_sizing_guide_solutions): DataMiner Solutions that combine different services, such as MediaOps, Ticketing, and InfraOps.
- [Use cases](xref:Pricing_sizing_guide_use_cases): Sample use cases with a combination of services, for example, Starlink, ground station, etc.

## Platform economics: more usage, lower unit cost

DataMiner supports point solutions like MediaOps, Ticketing, and Starlink as standalone deployments. However, its real strength is as a platform, where shared data context amplifies technical value. The economics also improve as more use cases run on the same system. **Usage compounds**.

DataMiner pricing is usage-based and service-centric, not tied to individual solutions. Each individual solution adds up to the same service usage pool. When multiple solutions share the same underlying services, total usage increases and unit cost per service decreases. Volume-based pricing applies across the entire platform, not per solution.

For example, imagine that a user who is already running automation-heavy workflows adds MediaOps. MediaOps does not start at an isolated greenfield cost. It immediately consumes Automation Actions at the lower blended rate already established by existing usage. The second solution does not just add usage, it improves the economics of what was already running.

The same logic applies to headroom. Users often provision usage conservatively up front or size slightly above immediate need. That unused capacity is not locked to any solution. Any new use case that fits within existing headroom adds zero incremental cost. Expansion is free until total usage actually exceeds what is provisioned.

A user running Starlink, MediaOps, and Ticketing on one DataMiner platform pays less per solution than three users running each in isolation, and less than the sum of three standalone estimates.
