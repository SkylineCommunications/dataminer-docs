---
uid: HTTPS_Connection
---

# HTTP(S) connections

For HTTP(S) connections, you can specify the following connection settings while creating or editing an element:

- **IP address/host**: The polling IP or URL of the destination.

- **IP port**: The IP port of the destination. This is not always required. The default port for HTTPS communication is 443. If you specify a different port, also add the *https://* prefix in the IP address field.

- **Bus address**: The bus address of the device. This is not always required. If the proxy server has to be bypassed, specify *bypassproxy*.

- **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

- **Insecure HTTPS**: From DataMiner 10.4.12/10.5.0 onwards<!--RN 40877-->, SSL/TLS certificates are validated by default for all newly created HTTP elements.

  - To disable certificate validation for an element created after a 10.4.12/10.5.0 upgrade, enable the *Insecure HTTPS* option.

  - To enable certificate validation for an HTTP element created before a 10.4.12/10.5.0 upgrade, disable the *Insecure HTTPS* option.

  When the *Insecure HTTPS* setting is enabled, in case an HTTP connector polls an HTTPS endpoint:

  - DataMiner will ignore invalid certificates in the following cases:

    - The server certificate is expired.

    - The server certificate is revoked.

    - The common name of the server certificate does not match the server name to which DataMiner is sending the request.

    - The certificate is issued by a Certificate Authority that is not trusted by the DataMiner Agent.

  - DataMiner will block communication in the following cases:

    - The server is offering a non-server certificate.

    - The server certificate is signed by a weak signature.

  > [!NOTE]
  >
  > - To skip SSL/TLS certificate validation for all elements that share the same *protocol.xml* file, set the `InsecureHttps` element to true in the `PortSettings` element of the *protocol.xml* file.
  > - To skip SSL/TLS certificate validation when using multi-threaded HTTP communication, set `requestSettings[6]` to true when building the HTTP request in a QAction. For more information, see [Setting up multi-threaded HTTP communication in a QAction](xref:AdvancedMultiThreadedTimersHttp).
  > - For backward compatibility, the SSL/TLS certificate validation is skipped by default for all elements created before version 10.5.0/10.4.12.
