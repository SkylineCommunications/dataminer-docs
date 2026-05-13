---
uid: Pricing_sizing_guide_services_DaaS
---

# Sizing guide: DataMiner as a Service

DataMiner as a Service covers the hosting of DataMiner nodes and Managed Objects by Skyline.

Hosted **Managed Objects** are billed by **total metric count** across your entire hosted system, not by object count. A **minimum of 1,000,000** metrics always applies when this service is active, regardless of actual usage. For systems running only solutions with negligible Managed Object count (e.g. MediaOps, Ticketing), this minimum is the entire DaaS cost.

**Self-hosted** deployments (on-premises or private cloud) do **not** incur these charges.

## Service volumes

| Category | Service | Metering unit | Estimation method |
|----------|---------|:-------------:|---------------------|
| DataMiner as a Service | Hosted Managed Objects | `Sum of all metrics across hosted Managed Objects` | **Greenfield systems**: Estimate each Managed Object at **10,000 metrics**, then multiply by the expected number of Managed Objects.  <br>**Existing (brownfield) systems**: Review the total number of metrics across all Managed Objects in the system and sum them. <br>If the total is below **1,000,000 metrics**, the minimum of 1,000,000 metrics applies.|
| DataMiner as a Service | Hosted Nodes | `Number of additional hosted nodes beyond the default` | One DataMiner node is included by default per 1,000,000 hosted metrics. Additional nodes are only required for resiliency or availability beyond the default configuration. |

## Examples

- A hosted system with 500 Managed Objects at 2,000 metrics each, plus 1,000 Managed Objects at 80 metrics each = (500 × 2,000) + (1,000 × 80) = 1,080,000 metrics = **1,080,000** Hosted Managed Objects
- A hosted MediaOps deployment with no managed objects = **1,000,000** metrics (minimum applies)

## What does not affect this estimate

- **Number of users on the hosted system**: This is not metered.
- **Hosted node count within the default**: The first node per 1,000,000 metrics is included. Additional nodes are only billed when you explicitly provision them for resiliency.
- **Stopped Managed Objects**: Stopped or deleted objects are not included.
