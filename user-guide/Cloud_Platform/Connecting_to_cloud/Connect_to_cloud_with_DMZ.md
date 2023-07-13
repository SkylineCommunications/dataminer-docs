---
uid: Connect_to_cloud_with_DMZ
---

# Connecting to dataminer.services with a DMZ setup

From version 2.7.0 of the CloudGateway DxM onwards, you can connect a DMS to dataminer.services using a DMZ (i.e. a perimeter network acting as an intermediate between the DMS and the internet). This way, the DMS can be connected to dataminer.services without exposing the entire DMS network to the public internet.

![DMZ](~/user-guide/images/DMZ_CloudGateway.png)

1. Verify that your DataMiner System meets all [requirements](xref:Connect_to_cloud_requirements).

1. Configure the firewall of the DMZ:

   - Make sure it allows access to the endpoints mentioned in [Connecting your DataMiner System to dataminer.services](xref:Connect_to_cloud_requirements).

   - Make sure the DMZ can communicate with the DMS through port 80, or through port 443 for a secure connection.

   - Make sure the DMZ can communicate with the DMS through NATS on port 4222.

   - Make sure the [DxMs](xref:DataMinerExtensionModules) on all servers can communicate towards dataminer.services thought the DMZ CloudGateway on port 5100.

     > [!NOTE]
     > If communication through port 5100 is not possible, it is possible to configure a different port. See [Customizing the dataminer.services endpoint configuration](xref:Custom_cloud_endpoint_configuration).

1. Install the [DMZ Cloud Pack](https://community.dataminer.services/dataminer-cloud-pack/) on the DMZ server.

1. On the DataMiner nodes, install the DxMs that need to connect with the DMA or do not require internet access. At present, these are *CoreGateway*, *FieldControl*, *SupportAssistant*, *ArtifactDeployer* and *Orchestrator*. For a Failover setup, you should install these DxMs on both Agents in the Failover pair.

   > [!IMPORTANT]
   > From DataMiner 10.3.7/10.4.0 onwards<!-- RN 36085 -->, a Cloud Pack containing these DxMs (but not DataMiner CloudGateway) is automatically installed when you upgrade or install DataMiner.

   > [!NOTE]
   > For all DxMs, it is advised to have multiple instances running at the same time. This will create redundancy in case something goes wrong and allows for upgrades without any downtime.

1. On the DMZ server, in the folder `C:\Program Files\Skyline Communications\DataMiner CloudGateway`, create an override *appsettings.custom.json* with the following contents:

   ```json
   {
     "DmzOptions": {
       "IsHttpsEnabled": <true/false>,
       "Domain": <IIS>,
       "DataMinerAgentName":  <name of the dataminer agent the DMZ is connected to>
     }
   }
   ```

   - **IsHttpsEnabled**: Indicates whether the communication between the DMZ and the DMA is encrypted. This can only be the case if the IIS is configured to support TLS.

   - **Domain**: The domain name of your DataMiner System, configured through the IIS settings.

   - **DataMinerAgentName**: The name of the DataMiner Agent you are connecting to. This should be the same DMA as the one used for the domain setting.

   > [!NOTE]
   > If you want to point the DMZ to a Failover pair, you will need to set up two DMZ servers, each pointing to one of the two Agents in the pair.

1. On a DataMiner node, copy `C:\Skyline DataMiner\SLCloud.xml` and `C:\Skyline DataMiner\NATS\nsc\.nkeys\creds\DataMinerOperator\DataMinerAccount\DataMinerUser.creds`, and paste these in the `C:\Skyline DataMiner\` folder of the DMZ. Make sure that the credentials entry in *SLCloud.xml* points to the credentials file you copied over.

1. Restart all DxMs in the DMZ so that they use the new settings.

1. [Connect to dataminer.services in System Center](xref:Connect_to_dataminer_services#connecting-to-dataminerservices-in-system-center).

> [!CAUTION]
> Make sure the *NAS* &amp; *NATS* firewall rules (on the DataMiner Agents) apply to the *Public* profile. DataMiner versions prior to 10.2.0 and 10.2.3 incorrectly applied these firewall rules to the *Domain* profile, and this is not automatically adjusted during updates.
