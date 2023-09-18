---
uid: Connector_help_ServiceHeroes_ServiceHighway
---

# ServiceHeroes ServiceHighway

This connector supports different controls for the **ServiceHighway ticketing system**.

## About

The ServiceHighway uses **SOAP** calls to retrieve the device information. Minimum required framework: .NET 4.5

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Certificate installation

Install the generated certificate on the Local Personal store, as described below.

Communication with the consumer-ws interface is secured by the use of x509 authentication. Before a client (supplier) can be connected to the web service, the client must generate a certificate, which must be distributed to the server (consumer). The use of these certificates ensures that the client system will never send a plain (or hashed) password, thereby making the web service more secure.

The client must generate a certificate. The **private key** can be generated with the following command:

> keytool -genkey -alias \<alias\> -keyalg RSA -keystore \<keystore filename\> -dname \<a distinguished name\> -keypass \<key password\> -storepass \<store password\>

For example:

> keytool -genkey -alias clientcert -keyalg RSA -keystore clientstore.jks -dname "CN=myClientApplication,OU=Dev,O=ServiceHeroes,L=DenHaag,S=ZuidHolland,C=NL" -keypass xxx -storepass xxx

> Note: This will create a key with name (alias) myClientApplication in a keystore with filename *keystore.jks*. The specified dname (distinguished name) is just an example. Furthermore, you need to specify your own password for the keystore (instead of 'xxx').

Next, create a **certificate signing request** (CSR). The server (consumer) can then sign the CSR, thereby validating that requests signed by the certificate from the client (supplier) are properly authenticated

> keytool -certreq -v -alias \<alias\> -file \<output.csr\> -keypass \<key password\> -storepass \<store password\> -keystore \<keystore filename\>

For example:

> keytool -certreq -v -alias clientcert -file myClientApplication.csr -keypass xxx -storepass xxx -keystore clientstore.jks

Then, send the CSR file to the consumer **CA administrator**.

After the signed certificate has been received, it must be converted to 'der' format before it can be imported with keytool.

> openssl x509 -outform der -in demoCA/cacert.pem -out demoCA/cacert.der

To complete the process, the **CA certificate** and the **signed client certificate** must be **imported** back into the clients keystore. Note, however, that the same alias must be used for the signed certificate when it is imported back into the keystore.

> keytool -import -v -alias \<cacertalias\> -file \<ca cert file (der)\> -keystore clientstore.jks -keypass xxx -storepass xxx
> keytool -import -v -alias \<clientcertalias\> -file \<signed cert file (der)\> -keystore clientstore.jks -keypass xxx -storepass xxx

At this point, the client keystore contains everything a client needs to create a signed request for the consumer web service. If a custom-built client is used, and it is built in java, the keystore can be used as is. However, if you implement a client in another language or tool, the client certificate and private key may need to be translated into a suitable format.

A consumer web service can be implemented as a supplier resource. A resource bundle of type **wsBundle** can be created for this purpose. Such a resource bundle consists of a single unpackaged XML file, which should conform to the schema **wsdescriptor** (see <http://docs.servicehighway.com/docs/single/installationGuide.html#wsdescriptorSchema>). When this is loaded into the supplier it will be expanded into a bundle of resources. For every **ws** service that is available to the **system user** created in the consumer, a resource will be automatically created (see <http://docs.servicehighway.com/docs/single/installationGuide.html#wsClientUser>).

For the web service descriptor, both private key and public certificate are needed as base64 encoded text. To export the generated private key to a readable format for the supplier, the following steps need to be executed.

- Convert the keystore containing the private key to pkcs12 format. This command will prompt for a number of passwords.

> mbremijn:consumer-ws remijnm\$ keytool -importkeystore -srckeystore clientstore.jks -destkeystore clientstore.p12 -deststoretype PKCS12
> Enter destination keystore password:
> Re-enter new password:
> Enter source keystore password:
> Enter key password for \<clientcert\>

- Destination keystore password to set (twice)
  - Source keystore password
  - Password for private key (as created on the following page: <http://docs.servicehighway.com/docs/single/installationGuide.html#consumerWsCreatePrivateKey>)

> Note: Due to a limitation in `openssl (`it only prompts for one password in the next step), you must set the destination keystore password to the same value as that of the client private key. Otherwise, the `openssl` command in the next step will fail.
>
> keytool -importkeystore -srckeystore clientstore.jks -destkeystore clientstore.p12 -deststoretype PKCS12

- Export the private key from the pkcs12 formatted keystore to a separate file.

> openssl pkcs12 -in clientstore.p12 -out clientstore.pem -nodes

### Certificate configuration

On the **Configuration** page, you need to set the name of the certificate (defined in the keytool -genkey under "CN=", marked in red in the examples above) used to sign the SOAP messages.

## Usage

### Saved Scripts

This page can be used to **add saved scripts**, which can then easily be executed without any need to configure them again.

### General

This page contains an overview of all organizations and their services.

### Logging

This page contains an overview of all **responses for the 'execute' command** distributed over the different services. You can send the 'execute' command by right-clicking on a specific service.

### Logging \[ALL\]

This page contains an overview of all logs. With the **Log Max Number** parameter, you can configure the maximum number of log entries.

### Data

This page contains the tables that are used to build the tree control on the General page. If you right-click one of the services in the **Service Table**, you can execute the Automation script to execute the selected service.

### Data - Log

This page contains the tables where all information is saved after a request is executed. These tables are used for the tree controls on the Logging and Logging \[ALL\] page.

### Configuration

This page can be used to configure the certificate (see Certificate configuration section above). It's also possible to configure the debug logging and automatic deletion of entries that are empty.

### Webpage

This page displays the webpage of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
