---
uid: Security_Cassandra_TLS
---

# Encryption in Cassandra

## Client-Server Encryption

By default Cassandra communicates with clients over an insecure channel, meaning attackers can set up  Man-In-The-Middle (MITM) attacks to steal data or credentials being sent over the wire. To mitigate this, users should enable encryption. Cassandra provides this option through its **client_encryption_options**.

Cassandra achieves its encryption by relying on TLS (the successor of SSL). TLS relies on certificates to create a secure communication channel. To enable TLS we will need to obtain a certificate for every Cassandra node.

Now there are basically **two options**, you can create a so-called **self-signed certificate** or you can purchase one from a **trusted public certification authority** (e.g. Comodo, Digicert, ...). Self-signed certificates are free of charge but are not automatically trusted by browsers or other clients. Purchased certificates will cost some money, but are typically already trusted by most Operating Systems and browsers. When you decide to deploy purchased certificates, please skip the section about Generating the certificates and go directly to Configuring **client_encryption_options**.

## Generating the certificates

To generate the certificates, we will use two tools: *openssl* and the *Java keytool*. Both of these can be run on Linux and Windows.

First, we need to generate a root CA certificate. This root CA certificate will then be used to sign the certificates for each Cassandra node.

To make it easier to generate a root CA certificate, create a certificate configuration file. In this example, we created a certificate configuration file called *rootCA_cert.conf*.

```
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

> [!CAUTION]
> Make sure the OU is set to the **name** of your Cassandra cluster, **typically 'DMS'**. You can find this *cluster_name* tag in the *cassandra.yaml*.

Now we can actually generate the certificate by executing the following command:

`openssl req -config path/to/rootCa_cert.conf -new -x509 -nodes -keyout rootCa.key -out rootCa.crt -days 365`

The private key will now be saved to a new file named *rootCa.key*. The public certificate (including its public key), will be saved to *rootCa.crt*. In the example above, the certificate will be valid for **365 days** because we specified the *-days* parameter.

Now that we have our root CA certificate, we need to generate certificates for the individual Cassandra nodes. We can use the keytool command for this.

`keytool -genkeypair -keyalg RSA -alias <NODE IP ADDRESS> -keystore <NODE IP>.jks -storepass <STRONG PASSWORD> -keypass <STRONG PASSWORD> -validity 365 -keysize 4096 -dname "CN=<NODE IP>, OU=<CLUSTER NAME>, O=<ORGANIZATION>, C=<COUNTRY CODE>" -ext "san=ip:<NODE IP>"`

> [!NOTE]
> It's important to also set the OU to the name of your Cassandra cluster here. Also, make sure the values for -storepass and -keypass are equal, this is a known limitation in Cassandra. The certificate above will be valid for 365 days, this is configurable with the -validity parameter.

Do this for *every* node in the Cassandra cluster.

Now that we have certificates for every node, we need to digitally sign them with the private key of the root CA certificate. To do this, we need to create a certificate signing request (CSR) first.

`keytool -certreq -keystore <NODE IP>.jks -alias <NODE IP> -file <NODE IP>.csr -keypass <STRONG PASSWORD> -storepass <STRONG PASSWORD>`

Now we need to digitally sign the node certificate with the root certificate authority.

`openssl x509 -req -CA path/to/rootCa.crt -CAkey path/to/rootCa.key -in <NODE IP>.csr -out <NODE IP>.crt_signed -days 365 -CAcreateserial -passin pass:<ROOT CA PASSWORD>`

Make sure *&lt;ROOT CA PASSWORD&gt;* matches the one used to create the root CA certificate.

For every node, import the root certificate into the Java KeyStore (JKS) for that node.

`keytool -keystore <NODE IP>.jks -alias rootca_name -importcert -file path/to/rootCa.crt -keypass <STRONG PASSWORD> -storepass <STRONG PASSWORD> -noprompt`

Also import the signed certificate.

`keytool -keystore <NODE IP>.jks -alias rootca_name -importcert -file <NODE IP ADDRESS>.crt_signed -keypass <STRONG PASSWORD> -storepass <STRONG PASSWORD> -noprompt`

Now our certificates should be all set! Time to configure our Cassandra cluster to use them.

## Configuring the client_encryption_options

Now copy the Java KeyStores to the corresponding node, open your cassandra.yaml file, and locate the client_encryption_options.

Set *enabled* to **true** to enable TLS.

Set *optional* to **false** to **require** TLS encrypted.

> [!NOTE]
> In order to test your changes without production impact, set *optional* to **true** until you've verified you can connect using TLS.

Set keystore to the path to your .jks file containing the certificates. Set keystore_password to the *&lt;STRONG PASSWORD&gt;* you used to generate them.

```
client_encryption_options:
   enabled: true
   # If enabled and optional is set to true, both encrypted and unencrypted connections are handled.
   optional: false
   keystore: path/to/<NODE IP>.jks
   keystore_password: <STRONG PASSWORD>
```

Now save the changes in the *cassandra.yaml* and **restart** the Cassandra service.

## Connecting with DevCenter

In order to connect over TLS with DevCenter, you'll have to install the Java Cryptography Extensions (JCE). For more information see: [Connecting DevCenter to SSL/TLS enabled Cassandra](https://www.datastax.com/blog/connecting-datastax-devcenter-ssl-enabled-apache-cassandra-or-datastax-enterprise).

Now open DevCenter and open your connection properties, go to Advanced and select **This cluster requires SSL**. Point it towards your **rootCA.jks** truststore file and use the password you used to generate it.

> [!NOTE]
> Start DevCenter by executing C:\Program Files\Cassandra\DevCenter\Run DevCenter.lnk

## Connecting with DataMiner

In your DB.xml (found in C:\Skyline DataMiner), locate the active *&lt;Database&gt;* tag for Cassandra and add **&lt;TLSEnabled&gt;true&lt;/TLSEnabled&gt;**. For example:

```
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

Next, you'll need to import the *rootCa.crt* in the Windows certificate store (only when you're using self-signed certificates). On your DataMiner agent, double-click the rootCa.crt file and click Install Certificate. Now select Local Machine and place the certificate in the Trusted Root Certification Authorities. Now click *next* and *finish* to complete the import.

Now after restarting your DataMiner agent, it should be communicating with the database over a TLS secured channel.

The *Cassandra*  and *SLDBConnection* (DataMiner log file) can help with troubleshooting issues.