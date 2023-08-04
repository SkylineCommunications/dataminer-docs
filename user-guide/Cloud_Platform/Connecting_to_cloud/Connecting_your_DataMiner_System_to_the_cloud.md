---
uid: Connecting_your_DataMiner_System_to_the_cloud
---

# Connecting your DataMiner System to dataminer.services

You can [connect a DataMiner Agent to dataminer.services](xref:Connect_to_dataminer_services) (i.e. connect to the cloud) by installing a DataMiner Cloud Gateway on that DMA. DataMiner will communicate using HTTPS via the Gateway. By default, this requires the use of the standard HTTPS port 443. The connection passes through the Windows firewall to reach the endpoint, which also uses port 443.

![Cloud Gateway](~/user-guide/images/Cloud_Gateway.png)

Optionally, you can connect multiple DataMiner Agents to dataminer.services. This has [several advantages](xref:FAQ_DCP#do-all-agents-in-a-dms-have-to-be-connected-to-dataminerservices).

However, at this time we recommend running only 1 to 3 Cloud Gateway nodes in a cluster. Running more Cloud Gateway nodes than that in a cluster would only add an unnecessary extra load on dataminer.services.

![Multiple_Gateways](~/user-guide/images/Multiple_DMAs_Connected.png)

It is also possible to connect to dataminer.services [via proxy server](xref:Connect_to_cloud_via_proxy) or [with a DMZ setup](xref:Connect_to_cloud_with_DMZ).

![DMZ](~/user-guide/images/DMZ_CloudGateway.png)

Connecting your DataMiner System to dataminer.services will allow you to benefit from a host of additional features. You are free to choose which features you enable or disable in your system.

> [!TIP]
>
> - For an overview of all available dataminer.services features, see [dataminer.services](xref:Overview_DCP).
> - For more information about cloud connectivity and security, see [Cloud connectivity and security](xref:Cloud_connectivity_and_security#connecting-to-dataminerservices).
