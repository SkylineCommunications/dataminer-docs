---
uid: Security_OpenSearch
---

# Securing the OpenSearch database

> [!TIP]
> If you do not want the hassle of maintaining the DataMiner storage databases yourself, we recommend using [DataMiner Storage as a Service](xref:STaaS) instead.

## TLS Encryption

For information on how to enable both client-server and inter-node TLS encryption, refer to [TLS configuration](xref:Installing_OpenSearch_database#tls-configuration)

## Upgrading OpenSearch

DataMiner supports both the 1.X and 2.X version range of OpenSearch, however, for new installations we recommend installing OpenSearch 2.X. We also recommend to keep your OpenSearch installation up to date with the latest version withing your release line.

## Minor upgrade

There are 2 posibilities when performing a minor upgrade of your OpenSearch cluster:

1. [A cluster restart upgrade](https://opensearch.org/docs/latest/install-and-configure/upgrade-opensearch/index/#cluster-restart-upgrade)
1. [A roling upgrade](https://opensearch.org/docs/latest/install-and-configure/upgrade-opensearch/rolling-upgrade/)

Regardless of which upgrade strategy you choose, the first few steps remain the same:

1. Download the latest version within your release track: [1.X](https://opensearch.org/lines/1x.html), [2.X](https://opensearch.org/lines/2x.html).
1. [Back up the configuration files](https://opensearch.org/docs/latest/install-and-configure/upgrade-opensearch/index/#backing-up-configuration-files).
1. Back up the cluster by [taking a snapshot](https://opensearch.org/docs/latest/tuning-your-cluster/availability-and-recovery/snapshots/snapshot-restore/).

## Cluster restart upgrade

To perform a cluster restoart upgrade:

1. Stop OpenSearch and OpenSearch Dashboards on all nodes in the cluster.
1. Once the nodes are stopped, you can install a new version of OpenSearch.
1. After installing the new version on every node, start the nodes again.
1. The cluster is now running the new version of OpenSearch.

### Roling upgrade

To perform a rolling upgrade, refer to the [roling upgrade guide](https://opensearch.org/docs/latest/install-and-configure/upgrade-opensearch/rolling-upgrade/) in the OpenSearch documentation.

## Major upgrade

When going from one major release line to another (e.g. 1.X to 2.X), we recommend to first upgrade to the latest version in the current range before upgrading to the new range. It is also not possible to use the roling upgrade strategy for major upgrades, so you will have to perform a cluster restart upgrade as described [above](#cluster-restart-upgrade).
