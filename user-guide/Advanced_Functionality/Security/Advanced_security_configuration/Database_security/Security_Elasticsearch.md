---
uid: Security_Elasticsearch
---

# Securing the Elasticsearch database

## Authentication

By default, Elasticsearch does **not** require authentication, which means anyone can access or alter the data. We therefore **highly recommend that you enable authentication** on your Elasticsearch cluster.

To enable authentication in Elasticsearch 6.8.X:

1. Stop your DataMiner Agent.

1. Stop the *elasticsearch-service-x64* service.

1. Add the following lines to the *elasticsearch.yml* file (typically located in *C:\Program Files\Elasticsearch\config*):

    `xpack.security.enabled: true`
    
    `discovery.type: single-node`
    
1. Start the *elasticsearch-service-x64* service.

1. Execute the **elasticsearch-setup-passwords.bat** script (as Administrator) with the *interactive* argument.

   `C:\Program Files\Elasticsearch\bin\elasticsearch-setup-passwords.bat interactive`

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

> [!NOTE]
> To keep using Kibana, also set the credentials in the *elasticsearch.username* and *elasticsearch.password* fields of the *kibana.yml* (typically located in *C:\Program Files\Elasticsearch\Kibana\config*).

## Updating passwords

The *elasticsearch-setup-passwords.bat* script can only *create* the passwords. 

To **update** an existing password:

1. Send the following request to your Elasticsearch database, where **&lt;USERNAME&gt;** is the name of the user you want to update:

   ```
   POST /_security/user/<USERNAME>/_password
   {
      "password" : "new-strong-password"
   }
   ```

1. Update the password in the *DB.xml* file on every DataMiner Agent and restart the DataMiner System.

## SSL/TLS Encryption

By default all client-server communication with Elasticsearch is unencrypted.

To configure SSL/TLS encryption in Elasticsearch:

1. Request or generate a TLS certificate. Make sure the IP address of the node is included in the *Subject Alternative Names* of the certificate.

1. Add the following lines to the *elasticsearch.yml* file:

   ```
   xpack.security.http.ssl.enabled: true
   xpack.security.http.ssl.keystore.path: path/to/your/certificate
   xpack.security.http.ssl.truststore.path: path/to/your/certificate
   ```

1. Optionally, **for password-protected certificates**, execute the following commands **as Administrator** and enter the password when prompted:

   ```
   bin\elasticsearch-keystore add xpack.security.http.ssl.keystore.secure_password
   bin\elasticsearch-keystore add xpack.security.http.ssl.truststore.secure_password
   ```

1. Start the *elasticsearch-service-x64* service and verify that you can connect with a browser to <https://FQDN:9200>.

1. Stop the DataMiner Agent.

1. Add the full *https://* URL (including the port) in the \<DBServer> element in the *DB.xml* file. For example:
   `<DBServer>https://elastic.dataminer:9200</DBServer>`

1. Save the changes and start the DataMiner Agent.

> [!TIP]
> To troubleshoot problems after enabling TLS encryption, consult the *SLSearch.txt* log file.

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
