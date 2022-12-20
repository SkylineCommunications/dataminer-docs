---
uid: Security_Cassandra_TLS
---

# Encryption in Cassandra

## Client-Server Encryption

By default, Cassandra communicates with clients over an insecure channel, which means attackers can set up Man-In-The-Middle (MITM) attacks to steal data or credentials that are sent over the wire. To mitigate this, encryption should be enabled. Cassandra provides this option through its **client_encryption_options**.

Cassandra achieves its encryption by relying on TLS (the successor of SSL). TLS relies on certificates to create a secure communication channel. To enable TLS, you will need to obtain a certificate for each Cassandra node.

There are **two options**: you can create a so-called **self-signed certificate**, or you can purchase one from a **trusted public certification authority** (e.g. Comodo, Digicert, etc.). Self-signed certificates are free of charge but are not automatically trusted by browsers or other clients. Purchased certificates will cost some money but are typically already trusted by most operating systems and browsers. If you decide to deploy purchased certificates, skip the section about generating the certificates below and go directly to [Configuring the client_encryption_options](#configuring-the-client_encryption_options).

## Generating the certificates

> [!TIP]
> To easily generate certificates on Linux machines, you can use our [generate TLS certificates script](https://github.com/SkylineCommunications/generate-tls-certificates), which is available on GitHub.

To generate the certificates, you will need two tools: *openssl* and the *Java keytool*. Both of these can run on Linux and Windows.

1. Create a certificate configuration file. This will make it easier to generate a root CA certificate later.

   In the example below, a certificate configuration file called *rootCA_cert.conf* is created.

   ```txt
   # rootCA_cert.conf
   [ req ]
   distinguished_name = req_distinguished_name
   prompt = no

   # Make sure to set a strong password below
   output_password = <STRONG PASSWORD HERE>
   # Increase default_bits for a stronger encryption key
   default_bits = 4096
   
   [ req_distinguished_name ]
   # Set your country code below
   C = BE
   # Set your organization name below
   O = SkylineCommunications
   # Important! Set your Cassandra Cluster name below
   OU = DMS
   CN = rootCa
   ```

   > [!NOTE]
   > The **OU** is only validated when **internode encryption** is turned on in the *server_encryption_options*. Make sure it matches the *cluster_name* **exactly** or Cassandra will fail to start. You can find the *cluster_name* in the *cassandra.yaml* config file.
   >
   > We also recommend using only ASCII characters in your Cassandra cluster name. The Cassandra documentation is lacking on this front, but we noticed Cassandra failing to start when the *cluster_name* contained certain special/non-ASCII characters.


1. Generate the root CA certificate by executing the following command:

   ```txt
   openssl req -config path/to/rootCa_cert.conf -new -x509 -nodes -keyout rootCa.key -out rootCa.crt -days 365
   ```

   The private key will now be saved to a new file named *rootCa.key*. The public certificate (including its public key) will be saved to *rootCa.crt*. In the example above, the certificate will be valid for **365 days** because this is configured with the *-days* parameter.

1. Generate certificates for the individual Cassandra nodes using the keytool command:

   ```txt
   keytool -genkeypair -keyalg RSA -alias <NODE IP ADDRESS> -keystore <NODE IP>.jks -storepass <STRONG PASSWORD> -keypass <STRONG PASSWORD> -validity 365 -keysize 4096 -dname "CN=<NODE IP>, OU=<CLUSTER NAME>, O=<ORGANIZATION>, C=<COUNTRY CODE>" -ext "san=ip:<NODE IP>"
   ```

   > [!NOTE]
   > It is important to also set the OU to the name of your Cassandra cluster. Also, make sure that the values for `-storepass` and `-keypass` are equal. This is a known limitation in Cassandra. The certificate above will be valid for 365 days, based on the configuration of the `-validity` parameter.

1. Repeat the previous step for **every node** in the Cassandra cluster.

1. Now that you have certificates for every node, digitally sign them with the private key of the root CA certificate. To do so, first create a certificate signing request (CSR).

   ```txt
   keytool -certreq -keystore <NODE IP>.jks -alias <NODE IP> -file <NODE IP>.csr -keypass <STRONG PASSWORD> -storepass <STRONG PASSWORD>
   ```

1. Digitally sign the node certificates with the root certificate authority.

   ```txt
   openssl x509 -req -CA path/to/rootCa.crt -CAkey path/to/rootCa.key -in <NODE IP>.csr -out <NODE IP>.crt_signed -days 365 -CAcreateserial -passin pass:<ROOT CA PASSWORD>
   ```

   Make sure *&lt;ROOT CA PASSWORD&gt;* matches the password used to create the root CA certificate.

1. For every node, import the root certificate into the Java KeyStore (JKS) for that node.

   ```txt
   keytool -keystore <NODE IP>.jks -alias rootca_name -importcert -file path/to/rootCa.crt -keypass <STRONG PASSWORD> -storepass <STRONG PASSWORD> -noprompt
   ```

1. Also import the signed certificate.

   ```txt
   keytool -keystore <NODE IP>.jks -alias rootca_name -importcert -file <NODE IP ADDRESS>.crt_signed -keypass <STRONG PASSWORD> -storepass <STRONG PASSWORD> -noprompt
   ```

Now the certificates are all set, and you can configure the Cassandra cluster to use them. This is explained in the next section.

## Configuring the client_encryption_options

The *client_encryption_options* allow you to encrypt all the traffic between DataMiner and Cassandra.

To enable client-server TLS encryption:

1. Copy the Java KeyStores to the node

1. Open the *cassandra.yaml* file, and locate the *client_encryption_options*.

1. Set *enabled* to **true** to enable TLS.

1. Set *optional* to **false** to make sure TLS encrypted is required.

   > [!NOTE]
   > In order to test your changes without production impact, you can set *optional* to **true** until you have verified whether you can connect using TLS.

1. Set *keystore* to the path to the .jks file containing the certificates. Set *keystore_password* to the *&lt;STRONG PASSWORD&gt;* you used to generate them.

   ```txt
   client_encryption_options:
      enabled: true
      # If enabled and optional is set to true, both encrypted and unencrypted connections are handled.
      optional: false
      keystore: path/to/<NODE IP>.jks
      keystore_password: <STRONG PASSWORD>
   ```

1. Save the changes in the *cassandra.yaml* and **restart** the Cassandra service.

## Configuring the server_encryption_options

The *server_encryption_options* allow you to encrypt all the traffic between the Cassandra nodes, which is often referred to as *inter-node* encryption.

To enable inter-node TLS encryption:

1. Copy the Java KeyStores to the corresponding node

1. Open the *cassandra.yaml* file, and locate the *server_encryption_options*.

1. Set *internode_encryption* to **all** to enable TLS.

1. Set *optional* to **false** to make sure TLS encrypted is required.

   > [!NOTE]
   > In order to test your changes without production impact, you can set *optional* to **true** until you have verified whether you can connect using TLS.

1. Set *keystore* and *truststore* to the path to the .jks file containing the certificates. Set *keystore_password* and *truststore_password* to the *&lt;STRONG PASSWORD&gt;* you used to generate the certificates.

   ```txt
   server_encryption_options:
      internode_encryption: all
      # If enabled and optional is set to true, both encrypted and unencrypted connections are handled.
      optional: false
      keystore: path/to/<NODE IP>.jks
      keystore_password: <YOUR PASSWORD>
      truststore: /path/to/<NODE IP>.jks
      truststore_password: <YOUR PASSWORD>
   ```

1. Save the changes in the *cassandra.yaml* and **restart** the Cassandra service.

## Connecting with DevCenter

In order to connect over TLS with DevCenter, you will have to install the Java Cryptography Extensions (JCE). For more information, see [Connecting DevCenter to SSL/TLS-enabled Cassandra](https://www.datastax.com/blog/connecting-datastax-devcenter-ssl-enabled-apache-cassandra-or-datastax-enterprise).

When you have done so:

1. Start DevCenter by executing `C:\Program Files\Cassandra\DevCenter\Run DevCenter.lnk`.

1. In DevCenter, open your connection properties.

1. Go to *Advanced* and select *This cluster requires SSL*.

1. Point it towards your *rootCA.jks* truststore file and use the password you used to generate it.

## Connecting with DataMiner

1. Ensure TLS encryption is working by connecting to the Cassandra database through DevCenter.

1. Stop the DataMiner agent.

1. In the `C:\Skyline DataMiner` folder, open *DB.xml*.

1. Locate the active *&lt;Database&gt;* tag for Cassandra and add **&lt;TLSEnabled&gt;true&lt;/TLSEnabled&gt;**.

   For example:

   ```xml
   <DataBase active="True" local="true" type="CassandraCluster">
       <ConnectString></ConnectString>
       <DBServer>1.1.1.1,2.2.2.2</DBServer>
       <DSN></DSN>
       <DB>SLDMADB</DB>
       <UID>username</UID>
       <PWD>password</PWD>
       <TLSEnabled>true</TLSEnabled>
   </DataBase>
   ```

1. If you are using self-signed certificates:

   1. Import the *rootCa.crt* in the Windows certificate store.

   1. On your DataMiner Agent, double-click the *rootCa.crt* file and click *Install Certificate*.

   1. Select *Local Machine* and place the certificate in the *Trusted Root Certification Authorities*.

   1. Click *Next* and *Finish* to complete the import.

1. Start the DataMiner Agent. It should now communicate with the database over a TLS-encrypted channel.

> [!NOTE]
> The *Cassandra* and *SLDBConnection* DataMiner log files can help in case you need to troubleshoot issues.
