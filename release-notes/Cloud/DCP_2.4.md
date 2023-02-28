---
uid: DCP_2.4
---

# DataMiner Cloud Pack 2.4

## Installing the DataMiner Cloud Pack

For installation information, see [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Upgrading your DataMiner Cloud Pack installation

To upgrade to DataMiner Cloud Pack version 2.4.0, run the installer (available on the [Downloads](https://community.dataminer.services/downloads/) page) on all DataMiner Agents in the cluster that already have an earlier version of the Cloud Pack installed.

## Component versions

When you install the DataMiner Cloud Pack v2.4.0, the following components are installed. You will be able to find these in the Windows installed programs list.

- DataMiner FieldControl v2.4.0
- DataMiner CoreGateway v2.5.0
- DataMiner CloudGateway v2.4.1
- DataMiner CloudFeed v1.0.0
- DataMiner ArtifactDeployer v1.0.0

## Features

### New CloudFeed DxM

A new CloudFeed DataMiner Extension Module (DxM) is now available. A DataMiner Extension Module is a component that can be installed next to an existing DataMiner installation to enable additional functionality. A DxM can be installed and upgraded independently from the DataMiner version and without any downtime of the core DataMiner software.

The CloudFeed DxM will handle all cloud feed functionality.

### New ArtifactDeployer DxM

A new ArtifactDeployer DxM is now available. Thanks to this DxM, the 2.4.0 cloud pack will allow you to deploy new protocols from the catalog directly to your DMA.

However, note that in order to have access to this feature, you will first need to verify your dataminer.services organization by sending an email to <licensing@skyline.be>.

### Security enhancements

Behind the scenes, new service principals are now used. These allow any DxM to authenticate towards dataminer.services.

### Remote access: Automatic login

Up to now, when using remote access, you had to log in to both dataminer.services and your DataMiner System. Now logging in to dataminer.services will be sufficient, as you will be automatically logged into the DataMiner System with your linked DataMiner account.

## Fixes

With Cloud Pack v2.3.1, some issues were possible with SPIs. These have been fixed.
