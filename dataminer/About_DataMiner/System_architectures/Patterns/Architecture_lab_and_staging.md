---
uid: Architecture_lab_and_staging
description: Learn how to set up lab, staging, and proof-of-concept DataMiner Systems, and how they relate to the architecture of your production system.
keywords: architecture, staging, lab, test, development, proof of concept, PoC
---

# Lab, staging, and proof-of-concept systems

Besides a production system, most organizations use one or more additional DataMiner Systems to develop, test, and evaluate changes without affecting operations. These systems usually have a smaller and simpler architecture than the production system.

## Types of non-production systems

| Type | Purpose | Typical architecture |
|--|--|--|
| Proof of concept or evaluation | Try out DataMiner or a new solution | A single [DaaS](xref:Creating_a_DMS_on_dataminer_services) node, or a single self-managed node with STaaS |
| Development | Develop connectors, Automation scripts, and low-code apps | A single node per developer or team |
| Staging or pre-production | Validate upgrades, new connectors, and configuration changes before production | Same architecture as production, at a smaller scale |
| Training | Train operators and administrators | A single node with simulated data |

## Proofs of concept and evaluations

A [cloud-hosted system](xref:Architecture_cloud_hosted) on DataMiner as a Service requires no hardware and can be created and removed again quickly, which makes it convenient for short evaluations. If the proof of concept needs access to equipment in a private network, use [DataMiner Edge](xref:DataMiner_Edge), or install a self-managed node with [STaaS](xref:STaaS) in that network. A self-managed node lets you evaluate DataMiner in your own environment, but you need to provide and maintain a Windows server or virtual machine for it.

To estimate the costs, see the [sizing guide for DataMiner as a Service](xref:Pricing_sizing_guide_services_DaaS) and [Commercial and deploy models summary](xref:Pricing_Commercial_Models).

## Development systems

For development, a single DataMiner node is usually sufficient. With STaaS, a single node only needs the resources for DataMiner itself.

If a system without internet access is required, DataMiner, Cassandra, and OpenSearch can be installed on one machine for development purposes with limited load. This is not recommended for production systems, and the [compute requirements](xref:DataMiner_Compute_Requirements) of the three components must be added up. See [Dedicated clustered storage](xref:Dedicated_clustered_storage#single-dma-setups).

## Staging systems

A staging system is most useful when it resembles the production system closely:

- **Use the same storage architecture as production.** For example, if production uses STaaS, also use STaaS for staging. If production uses self-managed Cassandra and OpenSearch clusters, use a (smaller) cluster for staging too. Differences in storage architecture can hide issues that only appear in production.
- **Use the same redundancy model.** If production uses Failover or Swarming, configure the same in staging so you can test upgrades and procedures that depend on it.
- **Use the same DataMiner version and connector versions** as production, and upgrade staging first.
- **Use representative data.** Simulated elements or a subset of production devices help to validate performance and behavior.

## Pros and cons

| Pros | Cons |
|--|--|
| Changes can be tested without operational impact | Each additional system needs to be maintained |
| Upgrades and procedures can be rehearsed | A staging system that differs too much from production gives a false sense of security |
| Cloud-hosted systems can be created and removed on demand | Data and configuration need to be kept in sync with production |

## Commonly used in

Staging systems are common in all market segments, and especially in larger deployments and deployments with orchestration, booking, or provisioning workflows, where changes need to be validated thoroughly before they reach production.
