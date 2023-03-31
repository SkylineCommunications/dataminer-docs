---
uid: DCP_2.5
---

# DataMiner Cloud Pack 2.5

> [!NOTE]
> If you are using an IP-based firewall, you will need to add `20.31.240.20` to the allowed IP addresses to be able to connect to dataminer.services.

## Installing the DataMiner Cloud Pack

For installation information, see [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Upgrading your DataMiner Cloud Pack installation

To upgrade to DataMiner Cloud Pack version 2.5.0, run the installer (available on the [Downloads](https://community.dataminer.services/downloads/) page) on all DataMiner Agents in the cluster that already have an earlier version of the Cloud Pack installed.

## Component versions

When you install the DataMiner Cloud Pack v2.5.0, the following components are installed. You will be able to find these in the Windows installed programs list.

- DataMiner FieldControl v2.6.0
- DataMiner CoreGateway v2.7.0
- DataMiner CloudGateway v2.5.2
- DataMiner CloudFeed v1.0.1
- DataMiner ArtifactDeployer v1.2.1
- DataMiner Orchestrator v1.2.1

## Features

### New Orchestrator DxM

A new Orchestrator DxM (DataMiner Extension Module) is now available. This DxM integrates with dataminer.services to allow easy updating of any DxMs.

### Admin app: DxM Overview

The Admin app now contains a page where you can view all DxMs installed in your DataMiner System. The page also allows you to update the DxMs to the latest version with one single click. For more information, see [Managing the nodes of a DMS connected to dataminer.services](xref:Managing_cloud-connected_nodes).

> [!NOTE]
> As this means that you can now install DxMs on the fly from the Admin app, you no longer need a Cloud Pack to update your setup. Because of this, from now on the different DxM release notes will be added to the [dataminer.services change log](xref:DCP_change_log) instead of to separate Cloud Pack documents.

## Fixes

Errors could occur when an artifact was deployed in a cluster environment. This has now been fixed.
