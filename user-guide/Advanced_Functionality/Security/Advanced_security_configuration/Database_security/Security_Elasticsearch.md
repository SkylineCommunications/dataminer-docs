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

## Client-server TLS encryption

By default all client-server communication with Elasticsearch is unencrypted.

To configure TLS encryption for client-server communication:

1. Request or generate a TLS certificate (the certificates should be in the PKCS#12 format). Make sure the IP address of the node is included in the *Subject Alternative Names* of the certificate.

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

## Inter-node TLS encryption

By default inter-node communication in Elasticsearch is unencrypted.

To configure TLS encryption for inter-node communication:

1. Request or generate a TLS certificate (the certificates should be in the PKCS#12 format). Make sure the IP address of the node is included in the *Subject Alternative Names* of the certificate.

1. Add the following to the *elasticsearch.yml* on each node:

   ```
   xpack.security.transport.ssl.enabled: true
   xpack.security.transport.ssl.verification_mode: full 
   xpack.security.transport.ssl.keystore.path: elastic-certificates.p12 
   xpack.security.transport.ssl.truststore.path: elastic-certificates.p12
   ```

1. If you secured the node's certificate with a password, add the password to your Elasticsearch keystore by executing the following commands:

   ```
   bin/elasticsearch-keystore add xpack.security.transport.ssl.keystore.secure_password
   bin/elasticsearch-keystore add xpack.security.transport.ssl.truststore.secure_password
   ```

1. Restart the Elasticsearch cluster (all nodes).

> [!NOTE]
> DataMiner does **not** require a restart when enabling *inter-node* TLS encryption.

## Updating Elasticsearch

By default, DataMiner installs Elasticsearch 6.8.23. For more information about how you can upgrade your Elasticsearch version, refer to [Upgrading Elasticsearch from one minor version to another](xref:MOP_Upgrading_Elasticsearch_from_one_minor_version_to_another).

## Updating Java

By default, DataMiner installs Elasticsearch with its own Java installation. This is typically located in the folder *C:\Program Files\Elasticsearch\Java\bin*. DataMiner deploys Elasticsearch with **Java 1.8.0_121**.

To update the Java version:

1. Download the latest Java binaries from the official website.

1. Stop your DataMiner Agent.

1. Stop the *elasticsearch-service-x64* service.

1. Update the binaries in *C:\Program Files\Elasticsearch\Java*.

1. Start the *elasticsearch-service-x64* service.

1. Start your DataMiner Agent.
