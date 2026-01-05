---
uid: Connecting_your_DataMiner_System_to_the_cloud
description: To connect a DataMiner Agent to dataminer.services (i.e. to the cloud), install a Cloud Gateway on that DMA and make sure port 443 is available.
keywords: cloud connection, connect to the cloud, connecting to the cloud
reviewer: Alexander Verkest
---

# Connecting your DataMiner System to dataminer.services

> [!TIP]
> See also: [Kata #9: How to make your DataMiner Agent cloud connected](https://community.dataminer.services/courses/kata-9/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

You can [connect a DataMiner Agent to dataminer.services](xref:Connect_to_dataminer_services) (i.e. connect to the cloud) by installing a DataMiner Cloud Gateway on that DMA using the [DataMiner Cloud Pack](https://community.dataminer.services/dataminer-cloud-pack/). DataMiner will communicate using HTTPS via the Gateway. By default, this requires the use of the standard HTTPS port 443. The connection passes through the Windows firewall to reach the endpoint, which also uses port 443.

![Cloud Gateway](~/dataminer/images/Cloud_Gateway.svg)

Optionally, you can connect multiple DataMiner Agents to dataminer.services. This has [several advantages](xref:FAQ_dataminer_services#do-all-agents-in-a-dms-have-to-be-connected-to-dataminerservices).

![Multiple_Gateways](~/dataminer/images/Multiple_DMAs_Connected.svg)

It is also possible to connect to dataminer.services [via proxy server](xref:Connect_to_cloud_via_proxy) or [with a DMZ setup](xref:Connect_to_cloud_with_DMZ).

![DMZ](~/dataminer/images/DMZ_CloudGateway.svg)

Connecting your DataMiner System to dataminer.services will allow you to benefit from a host of additional features. You are free to choose which features you enable or disable in your system.

> [!TIP]
>
> - For an overview of all available dataminer.services features, see [dataminer.services](xref:Overview_dataminer_services).
> - For more information about cloud connectivity and security, see [Cloud connectivity and security](xref:Cloud_connectivity_and_security#connecting-to-dataminerservices).
