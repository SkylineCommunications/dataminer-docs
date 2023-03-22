---
uid: Connecting_your_DataMiner_System_to_the_cloud
---

# Connecting your DataMiner System to dataminer.services

You can [connect a DataMiner Agent to dataminer.services](#connecting-to-dataminerservices-in-system-center) by installing a DataMiner Cloud Gateway on that DMA. DataMiner will communicate using HTTPS via the Gateway. By default, this requires the use of the standard HTTPS port 443. The connection passes through the Windows firewall to reach the endpoint of the connection, which also uses the port 443.

![Cloud Gateway](~/user-guide/images/Cloud_Gateway.png)

Optionally, you can also connect multiple DataMiner Agents to dataminer.services. This can be done for the sake of redundancy as multiple Cloud Gateway nodes run independently from each other and will each maintain a tunnel connection to dataminer.services. This means that when the connection is lost for one DMA, you will still be connected through the other Cloud Gateway node(s).

Additionally, connecting more than one DMA to dataminer.services positively affects load balancing. Every time you open a shared dashboard or relay to your DMS, a random Cloud Gateway node is chosen to process your session. This means that the opening of multiple shares is distributed over the various Cloud Gateways. As a Cloud Gateway always forwards the traffic to the same web API service, this also distributes the load across different web API services in the cluster.

> [!NOTE]
> At this time, we recommend running 1 to 3 Cloud Gateway nodes in a cluster. Running more Cloud Gateway nodes than that in a cluster would only add an unnecessary extra load on dataminer.services.

![Multiple_Gateways](~/user-guide/images/Multiple_DMAs_Connected.png)

Connecting your DataMiner System to dataminer.services will allow you to benefit from a host of additional services.

> [!TIP]
>
> - For an overview of all available dataminer.services features, see [dataminer.services](xref:Overview_DCP).
> - For more information about cloud connectivity and security, see [Cloud connectivity and security](xref:Cloud_connectivity_and_security#connecting-to-dataminerservices).

## Requirements

Before connecting your DataMiner System to dataminer.services, verify that the following **requirements** are met:

- All DataMiner Agents in the DataMiner System are running DataMiner version 10.1.12 or higher.

  > [!Note]
  > We recommend that you upgrade to **DataMiner 10.2.0 or higher** to optimally benefit from all dataminer.services features and capabilities. You can find the installer on [DataMiner Dojo](https://community.dataminer.services/downloads/).

- Each DMA that will be connected to dataminer.services can reach the following endpoints:

  - ``https://*.dataminer.services/``

  - ``wss://tunnel.dataminer.services/``

  > [!NOTE]
  > At least one DMA in the DMS must be able to reach these endpoints. If you install the Cloud Pack on additional DMAs that **do not allow network traffic** towards `*.dataminer.services`, after the installation, **uninstall DataMiner CloudGateway** on those DMAs. See [uninstalling a program in Windows](https://support.microsoft.com/en-us/windows/uninstall-or-remove-apps-and-programs-in-windows-4b55f974-2cc6-2d2b-d092-5905080eaf98).

- From [DataMiner CloudGateway](xref:DataMinerExtensionModules#cloudgateway) version 2.10.0 onwards, the internal network must allow [HTTP(S) traffic via port TCP 5100](xref:Configuring_the_IP_network_ports#overview-of-ip-ports-used-in-a-dms). For more information about configuring this endpoint, see [Custom dataminer.services endpoint configuration](xref:Custom_cloud_endpoint_configuration).

  > [!NOTE]
  >
  > - From Cloud Pack version 2.7.0 onwards, [connecting using a DMZ](xref:Connect_to_cloud_with_DMZ) and [connecting via proxy server](xref:Connect_to_cloud_via_proxy) are supported.
  > - If [DataMiner CloudGateway](xref:DataMinerExtensionModules#cloudgateway) 2.9.4 or higher is installed, you can check whether your network complies with the requirements for dataminer.services using the *ConnectionTester.exe* tool from the folder `Program files\Skyline Communications\Dataminer CloudGateway\`.

## Connecting to dataminer.services in System Center

You can connect your DataMiner System to dataminer.services in System Center.

For detailed steps, go to [Connecting to dataminer.services in System Center](xref:Connect_to_cloud_in_System_Center).

## Connecting to dataminer.services via proxy server

From Cloud Pack version 2.7.0, CloudFeed 1.0.6, and ArtifactDeployer 1.4.1 onwards, connecting to dataminer.services via proxy server is supported. Enabling a proxy server will ensure that all outgoing traffic towards the public internet will pass through that proxy server. You will need a proxy server that supports both HTTP and WebSocket traffic.

For detailed steps, go to [Connecting to dataminer.services via proxy server](xref:Connect_to_cloud_via_proxy).

## Connecting to dataminer.services with a DMZ setup

From Cloud Pack version 2.7.0 onwards, connecting to dataminer.services using a DMZ is supported. This way, the DMS can be connected to dataminer.services without exposing the entire DMS network to the public internet.

For detailed steps, go to [Connecting to dataminer.services with a DMZ setup](xref:Connect_to_cloud_with_DMZ).

## Connecting with older DataMiner versions

Although we do not recommend this, it is possible to connect your DMS to dataminer.services while using a DataMiner version between 10.1.1 and 10.1.12.

> [!NOTE]
> To optimally benefit from all dataminer.services features and capabilities, we advise you upgrade your DMS to DataMiner 10.2.0 or higher.

For detailed steps, go to [Connecting with DataMiner versions between 10.1.1 and 10.1.12](xref:Connecting_with_older_DataMiner_versions).
