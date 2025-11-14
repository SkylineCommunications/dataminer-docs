---
uid: BPA_NATS_Migration_Prerequisites
---

# Verify NATS Migration Prerequisites

This BPA test is only available prior to DataMiner 10.6.0/10.6.1. It will verify whether DataMiner is ready to [migrate the NATS management to the BrokerGateway DxM](xref:BrokerGateway_Migration). This migration must be done before an upgrade to 10.6.0/10.6.1 is possible.<!-- RN 44035 -->

The BPA test will verify that:

- All DxMs installed on the system that use DataMiner MessageBroker are using at least version 3.0.0. This version is capable of setting up connections using BrokerGateway and can automatically switch its connection configuration at runtime.
- `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` exists and has *IgnitionValues* filled in for every entry.

This BPA test is available on demand. You can [run it in System Center](xref:Running_BPA_tests) (on the *Agents > BPA* tab). It is also available by default in all DataMiner 10.5.x versions starting from DataMiner 10.5.0/10.5.2.<!-- RN 40906 -->

## Metadata

- Name: Verify NATS Migration Prerequisites
- Description: Verifies several parameters on the system to determine if the system is ready to migrate to using BrokerGateway.
- Author: Skyline Communications
- Default Schedule: None

## Results

### Success

- No issues detected.

### Error

- **Unable to find existing services in Windows Registry:**

  The NAS/NATS services could not be located.

  Verify that the NAS/NATS services are installed. If they are missing, install them via the [SLEndpointTool](xref:Investigating_Legacy_NATS_Issues#remaining-steps).

- **Service \<servicename\> v\<version\> uses \<dll name\> file version \<dll version\>. It must be at least version 3.0.0. Please update this DxM to the latest version:**

  The service is running with an outdated DLL. A minimum version of 3.0.0 is required.

  Upgrade the affected DxMs to the latest version via the [Admin app](xref:Managing_cloud-connected_nodes#upgrading-nodes-to-the-latest-dxm-versions).

- **ClusterEndpoints.json file does not exist at C:\\Skyline DataMiner\\Configurations\\ClusterEndpoints.json:**

  The file `C:\Skyline DataMiner\Configurations\ClusterEndpoints.json` is missing.

  Restart the entire DMS to regenerate the file on each DMA.

- **Unable to find IgnitionValue for endpoint \<endpoint\>/IgnitionValue for endpoint \<endpoint\> is null:**

  The *ClusterEndpoints.json* file does not contain the required *IgnitionValue* data.

  Delete the existing *ClusterEndpoints.json* file and restart the DMS to recreate it.

- **Exception while reading C:\\Skyline DataMiner\\Configurations\\ClusterEndpoints.json:**

  Check if another process has placed a lock on the file and release it if necessary.

### Warning

- Unable to find Registry key for \<servicename\>. Skipping this service.
- Unable to find ImagePath value for service \<servicename\>. Skipping this service.
- Found service \<servicename\> but unable to find root directory of the service. Skipping prerequisite check on this service.
- Unable to find version for service \<servicename\>.

## Impact when issues detected

This system is not ready to migrate to using the BrokerGateway DxM.
