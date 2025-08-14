---
uid: Connect_to_cloud_with_DMZ
keywords: cloud connection, cloud dmz
---

# Connecting to dataminer.services with a DMZ setup

From version 2.7.0 of the CloudGateway DxM onwards, you can connect a DMS to dataminer.services using a DMZ (i.e. a perimeter network acting as an intermediate between the DMS and the internet). This way, the DMS can be connected to dataminer.services without exposing the entire DMS network to the public internet.

![DMZ](~/dataminer/images/DMZ_CloudGateway.png)

1. Verify that your DataMiner System meets all [requirements](xref:Connect_to_cloud_requirements).

1. Configure the firewall of the DMZ:

   - Make sure outbound communication is allowed to the endpoints mentioned in [Connecting your DataMiner System to dataminer.services](xref:Connect_to_cloud_requirements).

   - Make sure bidirectional communication between the DMZ and the DMS is possible over port 80, or through port 443 for a secure connection.

   - Make sure bidirectional communication between the DMZ and the DMS is possible through NATS on port 4222.

   - Make sure bidirectional communication between the [DxMs](xref:DataMinerExtensionModules) on all servers and the DMZ is possible over TCP on port 5100.

     > [!NOTE]
     > If communication through port 5100 is not possible, it is possible to configure a different port. See [Customizing the dataminer.services endpoint configuration](xref:Custom_cloud_endpoint_configuration).

1. Install the [DMZ Cloud Pack](https://community.dataminer.services/dataminer-cloud-pack/) on the DMZ server.

1. On the DataMiner nodes, install the DxMs that need to connect with the DMA or do not require internet access. At present, these are *CoreGateway*, *FieldControl*, *SupportAssistant*, *ArtifactDeployer* and *Orchestrator*. For a Failover setup, you should install these DxMs on both Agents in the Failover pair.

   > [!IMPORTANT]
   > From DataMiner 10.3.7/10.4.0 onwards<!-- RN 36085 -->, a Cloud Pack containing these DxMs (but not DataMiner CloudGateway) is automatically installed when you upgrade or install DataMiner.

   > [!NOTE]
   > For all DxMs (except the Cloud Gateway), it is advised to have an instance running on every node. This will create redundancy in case something goes wrong and allows for upgrades without any downtime.

1. On the DMZ server, in the folder `C:\Program Files\Skyline Communications\DataMiner CloudGateway`, edit or create the file *appsettings.custom.json* with the following contents:

   ```json
   {
     "DmzOptions": {
       "IsHttpsEnabled": <true/false>,
       "Domain": <IIS>,
       "DataMinerAgentName":  <name of the DataMiner Agent the DMZ is connected to>
     }
   }
   ```

   - **IsHttpsEnabled**: Indicates whether the communication between the DMZ and the DMA is encrypted. This can only be the case if the IIS is configured to support TLS.

   - **Domain**: The FQDN domain name of your DataMiner System, configured through the IIS settings. Example: `dma1.example.com`.

   - **DataMinerAgentName**: The name of the DataMiner Agent you are connecting to. This should be the same DMA as the one used for the domain setting. Example: `dma1`.

   > [!NOTE]
   > If you want to point the DMZ to a Failover pair, you will need to set up two DMZ servers, each pointing to one of the two Agents in the pair.

1. Copy the necessary configuration from node to DMZ:

   1. Check which NATS solution your system uses:

      For DataMiner versions prior to DataMiner 10.6.0, open the file `C:\ProgramData\Skyline Communications\DataMiner\MessagebrokerConfig.json`:

      - If it contains `"BrokerGatewayConfig"`, you are using the **[BrokerGateway-managed NATS](xref:BrokerGateway_Migration)** solution.
      - If it contains `"SLCloudConfig"`, you are using the legacy **SLNet-managed** solution.

      From DataMiner 10.6.0 onwards, the BrokerGateway-managed solution is enabled by default.

      > [!IMPORTANT]
      > For this configuration, it is also important that **automatic NATS configuration** is turned off. If automatic configuration is enabled, credentials may change over time, breaking communication with the DMZ. For instructions, see [Disabling automatic NATS configuration](xref:SLNetClientTest_disabling_automatic_nats_config).

   1. If you are using the **BrokerGateway-managed** NATS solution:

      1. Copy a `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json` file from a DataMiner node to the same location on the DMZ.

      1. On the DMZ, open `C:\ProgramData\Skyline Communications\DataMiner\MessagebrokerConfig.json`.

      1. Update the file so it follows the **BrokerGatewayConfig** format:

         ```json
         {
           "BrokerGatewayConfig": {
             "CredentialsUrl": "https://SERVER/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
             "APIKeyPath": "C:\\Program Files\\Skyline Communications\\DataMiner BrokerGateway\\appsettings.runtime.json"
           }
         }
         ```

      1. Set the `CredentialsUrl` to point to one of the servers in the **internal network**.

      1. Ensure the `APIKeyPath` points to the destination location of the copied `appsettings.runtime.json` file.

   1. If you are using the **SLNet-managed** NATS solution:

      1. From a DataMiner node in the internal network, copy `C:\Skyline DataMiner\SLCloud.xml` to the same folder on the DMZ.

      1. Also copy `C:\Skyline DataMiner\NATS\nsc\.nkeys\creds\DataMinerOperator\DataMinerAccount\DataMinerUser.creds` from the node to the DMZ.

      1. On the DMZ, open `SLCloud.xml` and verify that the `Credentials` path matches the destination location of the copied `.creds` file.

1. Restart all DxMs in the DMZ so that they use the new settings.

1. [Connect to dataminer.services in System Center](xref:Connect_to_dataminer_services#connecting-to-dataminerservices-in-system-center).

> [!CAUTION]
> Make sure the *NAS* &amp; *NATS* firewall rules (on the DataMiner Agents) apply to the *Public* profile. DataMiner versions prior to 10.2.0 and 10.2.3 incorrectly applied these firewall rules to the *Domain* profile, and this is not automatically adjusted during updates.
