---
uid: Connect_to_cloud_requirements
---

# Requirements for connection to dataminer.services

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
