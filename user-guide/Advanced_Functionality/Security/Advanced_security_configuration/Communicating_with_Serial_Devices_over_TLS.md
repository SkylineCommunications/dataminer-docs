---
uid: Communicating_with_Serial_Devices_over_TLS
---

# Communicating with Serial Devices over TLS

From DataMiner 10.0.2 onwards, it is possible to enable TLS on elements that behave as a server (e.g. Smart Serial). When this is enabled, SSL/TLS encryption can be enabled when a TCP/IP element is created or edited.

To enable TLS encryption, do the following on every DMA in the DMS that is to contain such elements:

1. In the folder *C:\\Skyline DataMiner\\Certificates*, place a PKCS12 file with (default) name “server.pfx”, containing the certificates and the private key.

2. Open the SLNetClientTest tool. See [Opening the SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

3. Connect to the DMA. See [Connecting to a DMA with the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

4. Go to the *Build Message* tab of the main window of the tool.

5. In the *Message Type* drop-down list, select *ConfigureTLSMessage*.

6. Configure the following fields of the message:

    | Field           | Description                                                                                                               |
    |-------------------|---------------------------------------------------------------------------------------------------------------------------|
    | DataMinerID       | ID of the DataMiner Agent ID.                                                                                             |
    | EncryptedPassword | Encrypted password (encrypted using the public key of the connection) that will be used with the certificate in question. |
    | Certificate       | Name of the certificate for which the password is set.<br> Default: server.pfx                                            |
    | ID                | ID of the certificate for which the password is set.<br> Currently, DataMiner will always use the certificate with ID 0.  |

7. Click *Send message*.

> [!NOTE]
> - DataMiner currently supports all TLS versions up to TLS 1.3 (i.e. all TLS versions supported by OpenSSL 1.1.1). It will negotiate the highest supported TLS version with the client. If the client supports TLS up to version 1.2, DataMiner will use version 1.2.
> - PFX files are not synchronized among the DMAs in a cluster.
> - If you replace a PKCS12 file on a DataMiner Agent, all elements using the TCP/IP port in question must be stopped and restarted for the changes to take effect.
> - TLS elements and non-TLS elements sharing the same TCP/IP port is not supported.
