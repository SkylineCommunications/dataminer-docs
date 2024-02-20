---
uid: Security_NATS
---

# Securing NATS

## Enable TLS in cluster

By default, NATS does **not** implement TLS encryption, which means anyone can eavesdrop the communication passing over the wire. We therefore **highly recommend that you enable TLS encryption** on your NATS cluster.

> [!NOTE]
> This only applicable if you have a DMS cluster or external DxMs. In case of a single agent setup, all communication occurs within the localhost, since there is only a singular NATS node.

To enable authentication:

1. Update **nats-server.config** file in order to add the  

1. Stop your NATS Service.

1. Stop the NAS Service.

1. Add the following lines to the *elasticsearch.yml* file (typically located in *C:\Program Files\Elasticsearch\config*):

   `xpack.security.enabled: true`

   `discovery.type: single-node`

   > [!NOTE]
   > For a multi-node cluster, "discovery.type" is not required.

1. Start the *elasticsearch-service-x64* service.

1. Execute the **elasticsearch-setup-passwords.bat** script (as superuser) with the *interactive* argument.

   - On a **Windows** server, this is located in `C:\Program Files\Elasticsearch\bin\elasticsearch-setup-passwords.bat interactive`

   - On a **Linux** server, this is located in `/usr/share/elasticsearch/bin/elasticsearch-setup-passwords interactive`

1. When the script prompts you to do so, enter the new credentials for several users. Ideally these are random-generated, strong passwords.

1. When the script is finished, add the credentials for the *elastic* user to the *db.xml* file. This file is located on every DataMiner Agent in *C:\Skyline DataMiner\db.xml*.

   ```xml
   <DataBase active="true" search="true" type="Elasticsearch">
      <DBServer>[ELASTIC URL]</DBServer>
      <UID>[YOUR ELASTIC USER]</UID>
      <PWD>[YOUR STRONG PASSWORD]</PWD>
   </DataBase>
   ```

1. Start your DataMiner Agent.
