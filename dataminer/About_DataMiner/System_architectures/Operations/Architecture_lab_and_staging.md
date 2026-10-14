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
| Proof of concept or evaluation | Try out DataMiner or a new solution | A [one-box DMS](xref:Architecture_single_agent), hosted through DaaS or self-managed with STaaS |
| Development | Develop connectors, Automation scripts, and low-code apps | A single node per developer or team |
| Staging or pre-production | Validate upgrades, new connectors, and configuration changes before production | Same architecture as production, at a smaller scale |
| Training | Train operators and administrators | A single node with simulated data |

## Proofs of concept and evaluations

A [one-box DMS](xref:Architecture_single_agent) is often enough to evaluate integrations and basic workflows. A DaaS system can reach private equipment through a VPN or DataMiner Edge; see [Connecting to private data sources with DaaS](xref:Connecting_to_private_data_sources). A self-managed DMS lets you evaluate within your own server environment. If the evaluation is about availability, distributed operations, or recovery, use the topology needed to demonstrate that behavior rather than the smallest possible setup.

To estimate the costs, see the [sizing guide for DataMiner as a Service](xref:Pricing_sizing_guide_services_DaaS) and [Commercial and deploy models summary](xref:Pricing_Commercial_Models).

## Development systems

For development, a single DataMiner node is usually sufficient. With STaaS, a single node only needs the resources for DataMiner itself.

For limited non-production use without STaaS, the [one-box WSL variation](xref:Architecture_single_agent#deployment-variations) hosts DataMiner and local Linux-based Cassandra and OpenSearch on one machine. Account for the combined resources and follow the VHD platform restrictions.

## Staging systems

A staging system is most useful when it resembles the production system closely:

- **Use the same storage architecture as production.** For example, if production uses STaaS, also use STaaS for staging. If production uses self-managed Cassandra and OpenSearch clusters, use a (smaller) cluster for staging too. Differences in storage architecture can hide issues that only appear in production.
- **Use the same redundancy model.** Configure Swarming and recovery in staging to match production so you can test workload movement and recovery procedures.
- **Use the same DataMiner version and connector versions** as production, and upgrade staging first.
- **Use representative data.** Simulated elements or a subset of production devices help to validate performance and behavior.

## Promoting changes to production

### Recommended: versioned Catalog packages and code

Manage deployable solution content and installation logic as code in source control, then build versioned packages for the [Catalog](xref:About_the_Catalog_app). This gives lab, staging, and production the same reproducible deployment artifact rather than separately edited copies. Application packages can combine connectors, Automation scripts, and other solution components; see [Application packages](xref:ApplicationPackages).

1. Develop solution artifacts and deployment logic in source control.

   Keep environment-specific settings, such as device addresses and credentials, separate from reusable solution content. Do not publish secrets in source code or packages.

1. Build a versioned package and deploy it to the lab DMS.

   Use [CI/CD](xref:CICD) to build and validate the package. The [multi-artifact package tutorial](xref:CICD_Tutorial_For_Other_Items_Multi-Artifact_DataMiner_Package_VisualStudio_And_GitHub) shows how to develop and register package versions in the Catalog.

1. Deploy the same package version to staging and validate it.

   Test installation, changes to existing content, integrations, representative workflows, and recovery. Keep the intended production configuration and platform versions in mind.

1. Promote the validated package version to production.

   Deploy the tested version rather than rebuilding different content for production. Use your release approval process and record the deployed version and recovery plan. The Catalog supports [private organization items and semantic versioning](xref:About_the_Catalog_app); private packages let you reuse your solution across your organization's systems.

This is a solution release process, not a replacement for DaaS platform maintenance, which Skyline manages. Package deployment should not copy live production data or secrets from a lab environment.

### Alternative: DataMiner export and import

For a one-off transfer, use [DataMiner export/import packages](xref:Exporting_and_importing_packages_on_a_DMA). You can [export elements, services, views, and other supported content](xref:Exporting_elements_services_etc_to_a_dmimport_file), then [import it into the target DMS](xref:Importing_elements_services_etc_from_a_dmimport_file).

This is useful for transferring supported configuration, but it does not provide the same code-reviewed deployment definitions, reproducible build process, or clean package-version history as the Catalog approach. Check the documented version compatibility and dependency limitations, and validate the import in staging before using it in production.

## Commonly used in

Staging systems are common in all market segments, and especially in larger deployments and deployments with orchestration, booking, or provisioning workflows, where changes need to be validated thoroughly before they reach production.
