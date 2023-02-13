---
uid: Connect_to_cloud_with_DMZ
---

# Connecting to dataminer.services with a DMZ setup

From version 2.7.0 of the CloudGateway DxM onwards, you can connect a DMS to dataminer.services using a DMZ. This way, the DMS can be connected to dataminer.services without exposing the entire DMS network to the public internet.

To create such a DMZ:

1. Configure the firewall of the DMZ:

   - Make sure it allows access to the endpoints mentioned in [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

   - Make sure the DMZ can communicate with the DMS through port 80, or through port 443 for a secure connection.

   - Make sure the DMZ can communicate with the DMS through NATS on port 4222.

1. Install the DxMs that need to be in the DMZ. At present, these are *CloudGateway*, *CloudFeed*, *ArtifactDeployer*, and *Orchestrator*.

   > [!NOTE]
   > Currently it is not yet possible to download each DxM individually. As a workaround, you can install the complete Cloud Pack in the DMZ and then uninstall the irrelevant DxMs. For the DMZ, these are *CoreGateway* and *FieldControl*. You can uninstall these like any other program in Windows.

1. On the DataMiner nodes, install the DxMs that need to connect with the DMA or do not require internet access. At present, these are *CoreGateway*, *FieldControl*, *SupportAssistant*, and *Orchestrator*. For a Failover setup, you should install these DxMs on both Agents in the Failover pair.

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

> [!CAUTION]
> Make sure the *NAS* &amp; *NATS* firewall rules (on the DataMiner Agents) apply to the *Public* profile. DataMiner versions prior to 10.2.0 and 10.2.3 incorrectly applied these firewall rules to the *Domain* profile, and this is not automatically adjusted during updates.
