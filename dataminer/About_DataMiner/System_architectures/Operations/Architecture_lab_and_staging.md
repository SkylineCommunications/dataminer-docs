---
uid: Architecture_lab_and_staging
description: Learn how to set up lab, staging, and proof-of-concept DataMiner Systems, and how they relate to the architecture of your production system.
keywords: architecture, staging, lab, test, development, proof of concept, PoC
---

# Lab, staging, and proof-of-concept environments

Lab, staging, and proof-of-concept describe the purpose of an environment, not its topology. You can apply a single-agent, centralized, distributed, or geo-redundant design to an environment according to what it needs to demonstrate.

Separate environments let you evaluate changes without affecting production. Each still needs maintenance and suitable data, and staging that differs too much from production may fail to reveal production-specific issues.

## Types of non-production systems

| Type | Purpose | Topology considerations |
|--|--|--|
| Proof of concept or evaluation | Try out DataMiner or a new solution | A single [DaaS](xref:Creating_a_DMS_on_dataminer_services) node, or a single self-managed node with STaaS |
| Development | Develop connectors, Automation scripts, and low-code apps | A single node per developer or team |
| Staging or pre-production | Validate upgrades, new connectors, and configuration changes before production | Same architecture as production, at a smaller scale |
| Training | Train operators and administrators | A single node with simulated data |

## Proofs of concept and evaluations

A [single-agent system](xref:Architecture_single_agent) is often enough to evaluate integrations and basic workflows. A DaaS node can reach private equipment through a VPN or DataMiner Edge; a self-managed node lets you evaluate within your own server environment. If the evaluation is about availability, distributed operations, or recovery, use the topology needed to demonstrate that behavior rather than the smallest possible setup.

To estimate the costs, see the [sizing guide for DataMiner as a Service](xref:Pricing_sizing_guide_services_DaaS) and [Commercial and deploy models summary](xref:Pricing_Commercial_Models).

## Development systems

For development, a single DataMiner node is usually sufficient. With STaaS, a single node only needs the resources for DataMiner itself.

For limited non-production use without STaaS, the [single-agent WSL variation](xref:Architecture_single_agent#deployment-variations) hosts DataMiner and local Cassandra and OpenSearch on one machine. Account for the combined resources and follow the VHD platform restrictions.

## Staging systems

A staging system is most useful when it resembles the production system closely:

- **Use the same storage architecture as production.** For example, if production uses STaaS, also use STaaS for staging. If production uses self-managed Cassandra and OpenSearch clusters, use a (smaller) cluster for staging too. Differences in storage architecture can hide issues that only appear in production.
- **Use the same redundancy model.** If production uses Failover or Swarming, configure the same in staging so you can test upgrades and procedures that depend on it.
- **Use the same DataMiner version and connector versions** as production, and upgrade staging first.
- **Use representative data.** Simulated elements or a subset of production devices help to validate performance and behavior.

## Commonly used in

Staging systems are common in all market segments, and especially in larger deployments and deployments with orchestration, booking, or provisioning workflows, where changes need to be validated thoroughly before they reach production.
