---
uid: BPA_NATS_Migration_Prerequisites
---

# Verify NATS Migration Prerequisites

This BPA test will verify that DataMiner is ready to [migrate](xref:BrokerGateway_Migration) the NATS management to the BrokerGateway DxM.

It will verify that:

- All DxMs installed on the system that use DataMinerMessageBroker are using at least version 3.0.0. This version is capable of setting up connections using BrokerGateway and can automatically switch its connection configuration at run-time.
- Check that C:\\Skyline DataMiner\\Configurations\\ClusterEndpoints.json exists and has IgnitionValues filled in for every entry.

This BPA test is available on demand. You can [run it in System Center](xref:Running_BPA_tests) (on the *Agents > BPA* tab). From DataMiner 10.5.0 onwards, it is available by default.

## Metadata

- Name: Verify NATS Migration Prerequisites
- Description: Verifies several parameters on the system to determine if the system is ready to migrate to using BrokerGateway.
- Author: Skyline Communications
- Default Schedule: None

## Results

### Success

- No issues detected

### Error

- Unable to find existing services in Windows Registry
- Service \<servicename\> v\<version\> uses \<dll name\> file version \<dll version\>. It must be at least version 3.0.0. Please update this DxM to the latest version.
- ClusterEndpoints.json file does not exist at C:\\Skyline DataMiner\\Configurations\\ClusterEndpoints.json
- Unable to find IgnitionValue for endpoint \<endpoint\>
- IgnitionValue for endpoint \<endpoint\> is null.
- Exception while reading C:\\Skyline DataMiner\\Configurations\\ClusterEndpoints.json. \<exception\>

### Warning

- Unable to find Registry key for \<servicename\>. Skipping this service.
- Unable to find ImagePath value for service \<servicename\>. Skipping this service.
- Found service \<servicename\> but unable to find root directory of the service. Skipping prerequisite check on this service.
- Unable to find version for service \<servicename\>.

## Impact when issues detected

This system is not ready to [migrate](xref:BrokerGateway_Migration) to using the BrokerGateway DxM.