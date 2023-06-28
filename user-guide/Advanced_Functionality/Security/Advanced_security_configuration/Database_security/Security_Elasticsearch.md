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

   Elasticsearch comes with the `elasticsearch-certutil` tool installed, which can be used to generate certificates. However, we recommend that you **use our [scripts for generating TLS certificates](https://github.com/SkylineCommunications/generate-tls-certificates)**, available on GitHub. There is a version of the script for Linux and Windows machines. The script requires two tools: *openssl* and the *Java keytool*. Both of these can run on Linux and Windows.

1. Add the following lines to the *elasticsearch.yml* file:

   ```
   xpack.security.http.ssl.enabled: true
   xpack.security.http.ssl.keystore.path: path/to/your/<NODE CERT STORE>
   xpack.security.http.ssl.truststore.path: path/to/your/<NODE CERT STORE>
   ```

   If you are using a `.PEM` certificate generated using `openssl` utility, add the following lines to the *elasticsearch.yml* file instead:

   ```
    xpack.security.http.ssl.enabled: true
    xpack.security.http.ssl.verification_mode: full
    xpack.security.http.ssl.key: path/to/your/PrivateKey/used/to/generatet/the/certificate
    xpack.security.http.ssl.certificate: path/to/your/certificate
    xpack.security.http.ssl.certificate_authorities: path/to/certificate/authority
    #In case of a self-signed certificates replace `path/to/certificate/authority` with path to certificate
    of each node in cluster.
    ```

1. **For cert stores generated with the script or password-protected certificates**, execute the following commands **as Administrator** and enter the password when prompted:

   ```
   bin\elasticsearch-keystore add xpack.security.http.ssl.keystore.secure_password
   bin\elasticsearch-keystore add xpack.security.http.ssl.truststore.secure_password
   ```

1. Start the *elasticsearch-service-x64* service and verify that you can connect with a browser to <https://FQDN:9200>.

1. Stop the DataMiner Agent.

1. Add the full *https://* URL (including the port) in the \<DBServer> element in the *DB.xml* file. For example:
   `<DBServer>https://elastic.dataminer:9200</DBServer>`

1. Import the certificate in the *Trusted Root Certification Authorities* store of the Windows Certificate Store.

1. Save the changes and start the DataMiner Agent.

> [!TIP]
> To troubleshoot problems after enabling TLS encryption, consult the *SLSearch.txt* log file.

### Troubleshooting: executing the generate-certificates.sh script

#### Syntax error

**Situation**: You have cloned the "Generate-TLS-Certificates" GitHub repository on a Windows machine, and have transferred the *generate-certificates.sh* file to a Linux machine using SCP. You have executed the following command:

```bash
sudo generate-certificates.sh
```

**Symptom**: Bash indicates that there are syntax errors in the script.

**Resolution**: Convert the .sh file to Unix format.

1. Begin by installing *dos2unix* with the following command:

   ```bash
   sudo apt install dos2unix
   ```

1. Next, run the following command:

   ```bash
   dos2unix generate-certificates.sh
   ```

   Once the conversion is complete, you can execute the script again.

#### Keytool: command not found

**Situation**: You have tried executing the *generate-certificates.sh* script.

**Symptom**: `Keytool: command not found.`

**Resolution**: Add the location of the keytool to the PATH system variable.

1. Run the following command:

   ```bash
   sudo nano /etc/environment
   ```

1. Next, add `:/usr/share/opensearch/jdk/bin` to the end of the line.

   The modified line should look like this:

   ```text
   PATH="/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin:/usr/games:/usr/local/games:/usr/share/opensearch/jdk/bin"
   ```

1. Save the changes by pressing *Ctrl+O* in nano, then exit the editor by pressing *Ctrl+X* in nano.

1. To apply the changes, either reboot your server, or reload the PATH variable by running the following command:

   ```bash
   source /etc/environment
   ```

1. Verify that the directory has been successfully added to the system PATH variable by executing:

   ```bash
   echo $PATH
   ```

1. In case the keytool still cannot be located, try modifying the *generate-certificates.sh* script with the Nano editor:

   1. Use the following command to modify the script:

      ```bash
      sudo nano generate-certificates.sh
      ```

   1. Add the following line on top of the .sh file:

      ```text
      PATH+=:/usr/share/opensearch/jdk/bin/
      ```

   1. To save your changes, enter CTRL+O followed by CTRL+X to close the .sh file and return to the terminal.

The *generate-certificates.sh* script should now be able to execute without encountering the `Keytool:command not found` error.

> [!TIP]
> The example above is specific to the keytool located in `/usr/share/opensearch/jdk/bin`. For Elasticsearch, the same procedure applies.

## Inter-node TLS encryption

By default inter-node communication in Elasticsearch is unencrypted.

To configure TLS encryption for inter-node communication:

1. Request or generate a TLS certificate (the certificates should be in the PKCS#12 format). Make sure the IP address of the node is included in the *Subject Alternative Names* of the certificate.

1. Add the following to the *elasticsearch.yml* file on each node:

   ```
   xpack.security.transport.ssl.enabled: true
   xpack.security.transport.ssl.verification_mode: full 
   xpack.security.transport.ssl.keystore.path: elastic-certificates.p12 
   xpack.security.transport.ssl.truststore.path: elastic-certificates.p12
   ```

   If you are using a `.PEM` certificate generated using `openssl` utility, add the following lines to *elasticsearch.yml* file instead.

   ```
    xpack.security.transport.ssl.enabled: true
    xpack.security.transport.ssl.verification_mode: full 
    xpack.security.transport.ssl.key: path/to/your/PrivateKey/used/to/generatet/the/certificate
    xpack.security.transport.ssl.certificate: path/to/your/certificate
    xpack.security.transport.ssl.certificate_authorities: path/to/certificate/authority
    #In case of a self-signed certificates replace `path/to/certificate/authority` with path to certificate
    of each node in cluster.
    ```

1. For cert stores generated with the script or if you secured the node's certificate with a password, add the password to your Elasticsearch keystore by executing the following commands:

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
