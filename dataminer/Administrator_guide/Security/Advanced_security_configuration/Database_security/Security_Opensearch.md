---
uid: Security_OpenSearch
keywords: updating OpenSearch, upgrading OpenSearch, OpenSearch security
---

# Securing the OpenSearch database

> [!TIP]
> If you do not want the hassle of maintaining the DataMiner storage databases yourself, we recommend using [DataMiner Storage as a Service](xref:STaaS) instead.

## TLS Encryption

For information on how to enable both client-server and inter-node TLS encryption, refer to [TLS configuration](xref:Installing_OpenSearch_database#tls-and-user-configuration)

## Upgrading OpenSearch

DataMiner supports both the 1.X and 2.X version range of OpenSearch; however, for new installations, we recommend installing OpenSearch 2.X.

We also recommend that you keep your OpenSearch installation up to date with the latest version within the range you have chosen.

### Minor upgrade

There are two ways to perform a minor upgrade of an OpenSearch cluster:

- [A cluster restart upgrade](#cluster-restart-upgrade)
- [A rolling upgrade](#rolling-upgrade)

Regardless of which upgrade strategy you choose, you will first need to perform these steps:

1. Download the latest version within your release track: [1.X](https://opensearch.org/lines/1x.html) or [2.X](https://opensearch.org/lines/2x.html).
1. [Back up the configuration files](https://opensearch.org/docs/latest/install-and-configure/upgrade-opensearch/index/#backing-up-configuration-files).
1. [Configure backups](xref:Configuring_OpenSearch_Backups) for your cluster if this was not configured yet.
1. [Take a snapshot](xref:Configuring_OpenSearch_Backups#taking-the-snapshot) to back up the cluster.

#### Cluster restart upgrade

1. Stop OpenSearch and OpenSearch Dashboards on all nodes in the cluster.

1. Install the new version of OpenSearch.

1. Start the nodes again.

   The cluster will now run the new version of OpenSearch.

> [!TIP]
> See also: [Cluster restart upgrade](https://opensearch.org/docs/latest/install-and-configure/upgrade-opensearch/index/#cluster-restart-upgrade) in the OpenSearch documentation.

#### Rolling upgrade

To perform a rolling upgrade, refer to the [rolling upgrade guide](https://docs.opensearch.org/latest/migrate-or-upgrade/rolling-upgrade/) in the OpenSearch documentation.

### Major upgrade

To go from one major release range to another (e.g., 1.X to 2.X), we recommend first upgrading to the latest version in the current range before upgrading to the new range.

It is not possible to use the rolling upgrade strategy for major upgrades, so you will have to perform a [cluster restart upgrade](#cluster-restart-upgrade) for this.
