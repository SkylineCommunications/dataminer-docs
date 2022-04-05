---
uid: Security_Elasticsearch
---

# Securing the Elasticsearch database

<!-- TODO: enable TLS encryption -->

## Authentication

By default, Elasticsearch does **not** require authentication, which means anyone can access or alter the data. We therefore **highly recommend that you enable authentication** on your Elasticsearch cluster.

To enable authentication:

1. Stop your DataMiner Agent.

1. Stop the *elasticsearch-service-x64* service.

1. Add the following lines to the *elasticsearch.yml* file (typically located in *C:\Program Files\Elasticsearch\config*):

    `xpack.security.enabled: true`

    `xpack.security.transport.ssl.enabled: true`

1. Execute the **elasticsearch-setup-passwords.bat** script (as Administrator) with the *interactive* argument.

   `C:\Program Files\Elasticsearch\bin\elasticsearch-setup-passwords.bat interactive`

1. When the script prompts you to do so, enter the new credentials for several users. Ideally these are random-generated, strong passwords.

1. When the script is finished, add the credentials for the *elastic* user to the *db.xml* file. This file is located on every DataMiner Agent in *C:\Skyline DataMiner\db.xml*.

   ```xml
   <DataBase active="true" search="true" type="Elasticsearch">
      <DBServer>[ELASTIC IP]</DBServer>
      <UID>[YOUR ELASTIC USER]</UID>
      <PWD>[YOUR STRONG PASSWORD]</PWD>
   </DataBase>
   ```

1. Start the *elasticsearch-service-x64* service.

1. Start your DataMiner Agent.

> [!NOTE]
> To keep using Kibana, also set the credentials in the *elasticsearch.username* and *elasticsearch.password* fields of the *kibana.yml* (typically located in *C:\Program Files\Elasticsearch\Kibana\config*).

## Updating Elasticsearch

By default, DataMiner installs Elasticsearch 6.8.23. For more information about how you can upgrade your Elasticsearch version, refer to [Upgrading Elasticsearch](https://community.dataminer.services/documentation/upgrading-elasticsearch-from-one-minor-version-to-another/) on DataMiner Dojo.

## Updating Java

By default, DataMiner installs Elasticsearch with its own Java installation. This is typically located in the folder *C:\Program Files\Elasticsearch\Java\bin*. DataMiner deploys Elasticsearch with **Java 1.8.0_121**.

To update the Java version:

1. Download the latest Java binaries from the official website.

1. Stop your DataMiner Agent.

1. Stop the *elasticsearch-service-x64* service.

1. Update the binaries in *C:\Program Files\Elasticsearch\Java*.

1. Start the *elasticsearch-service-x64* service.

1. Start your DataMiner Agent.
