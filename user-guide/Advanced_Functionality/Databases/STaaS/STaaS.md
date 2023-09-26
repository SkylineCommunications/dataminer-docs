---
uid: STaaS
---

# Storage as a Service (STaaS)

With our upcoming **cloud-native storage platform**, you will be able to connect your DataMiner System to a scalable and easy-to-use storage platform, without the effort of setting up and managing your own Cassandra and Elasticsearch cluster.

Currently, you can only use STaaS by contacting a Skyline representative or sending an email to <hi@skyline.be>.

> [!TIP]
> See also: [DataMiner Storage as a Service (STaaS) is live](https://community.dataminer.services/dataminer-storage-as-a-service-staas-is-live/).

![STaaS](~/user-guide/images/STaaS_Coming_Soon.png)

Advantages of DataMiner Storage as a Service (STaaS) include:

- Fast, secure, and reliable storage

- Easy and flexible configuration

- Outstanding performance, scalability, and redundancy

- Compatibility with all data types

- Cost-effectiveness

- Safe and secure data

> [!TIP]
>
> - To read more about Storage as a Service and its advantages, see [DataMiner STaaS: a game-changer for your storage needs](https://community.dataminer.services/dataminer-staas-a-game-changer-for-your-storage-needs/).
> - As Storage as a Service is **scheduled for production in Q3 of 2023**, we are working on adding more information to this section. Check back for updates frequently!

## Setup

> [!IMPORTANT]
>
> Storage as a Service can be used from DataMiner version 10.3.10 (CU1) onwards.

  1. Make your system **Cloud Connected** and note down the organization and coordination ids. These can be found here: ClientTestTool>Advanced>CcaGateway>Get Global State. More information about getting cloud connected can be found [here](https://docs.dataminer.services/user-guide/Cloud_Platform/Connecting_to_cloud/Connecting_your_DataMiner_System_to_the_cloud.html).
  1. Make sure you have at least **DataMiner CloudGateway 2.8.0** installed on the system. You can check this in the [Admin App](https://admin.dataminer.services) in the *nodes* section of your DMS. If this isn't the case, you can immediately update it from that page. You can find more information about this [here](https://docs.dataminer.services/user-guide/Cloud_Platform/CloudAdminApp/Managing_cloud-connected_nodes.html)
  1. Contact a Skyline representative to register you system to STaaS 
  1. **Optional**: Migrate data to Cloud Storage. To migrate your current data to STaaS please contact your Skyline representative to do so.
  1. Edit the DB.xml, present in the Skyline DataMiner root folder, to look like this:

      ```xml
      <?xml version="1.0"?>
      <DataBases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/config/db">
        <DataBase active="true" local="true" search="true" cloud="true" type="CloudStorage"/>
      </DataBases>
      ```

  1. Restart your DMA and STaaS will be used.

> [!IMPORTANT]
>
> Steps 4., 5. and 6. can only be done after registration is completed (Step 3.)

> [!NOTE]
>
> If you experience any issues during setup or while using Storage as a Service do not hesitate to contact Cloud Ecosystem.

## Migration
Migration to STaaS is supported for all datatypes with the exception of Logger Tables. Migration of Logger Tables will be supported in future versions. 

> [!NOTE]
>
> Data stored in Cassandra and Elastic can only be migrated to STaaS if the databases are defined in the `DB.xml` configuration file.

## Limitations

- Jobs and Ticketing datatypes are not supported
- No indexing engine functionality such as search and suggestions
- Cube direct queries to the database are not supported
- SLReset tool is not supported
- DELT export for trend data is not supported
- API Deployment is not supported

## Known issues

### Losing Cloud Connection

Under normal circumstances, CloudGateway refreshes the cloud session automatically. If CloudGateway would be down for longer than 3 days or the server would be down, the cloud session will be invalid which causes DataMiner to not start up anymore. The following workaround can be used to fix this issue:

  1. Go to *Client Test --> Offline Tools --> CcaGateway (offline) --> Renew cloud session* and complete the renew process
  1. Restart your DMS, the issue should be resolved now

> [!NOTE]
>
> As the renewal of the Service Principal (SP) token is managed by a cloud service, it can take a few minutes before the renewal is fully synced.

### Buggy drivers

Some drivers have a bug where a lot of parameter sets are being saved to the databases. In the interest of saving cost and reducing load, we recommend using the latest version available for most drivers.

Known buggy drivers:

- Microsoft Platform: 1.1.2.X, 1.2.0.x
