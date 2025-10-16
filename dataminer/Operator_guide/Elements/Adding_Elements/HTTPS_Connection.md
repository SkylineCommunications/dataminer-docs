---
uid: HTTPS_Connection
---

# HTTP(S) connections

For HTTP(S) connections, you can specify the following connection settings while creating or editing an element:

- **Site**: The remote site. Set to `<None>` if a direct connection needs to be set up instead of a tunnel. This dropdown is only visible if the Site Manager DxM is installed and remote sites are configured. For more information, refer to [Site Manager](xref:SiteManagerOverview).

- **IP address/host**: The polling IP or URL of the destination.

- **IP port**: The IP port of the destination. This is not always required. The default port for HTTPS communication is 443. If you specify a different port, also add the `https://` prefix in the IP address field.

- **Bus address**: The bus address of the device. This is not always required. If the proxy server has to be bypassed, specify *bypassproxy*.

- **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

- **Skip SSL/TLS certificate verification (insecure)**: From DataMiner 10.4.12/10.5.0 onwards<!--RN 40877 + 41285-->, SSL/TLS certificates are validated by default for all newly created HTTP elements. When this setting is enabled, SSL/TLS certificates will not be automatically validated.

  > [!NOTE]
  > For HTTP elements created before the upgrade to 10.4.12/10.5.0, disable this option to enable automatic certificate verification.

  When the *Skip SSL/TLS certificate verification (insecure)* setting is enabled, in case an HTTP connector polls an HTTPS endpoint:

  - DataMiner will ignore invalid certificates in the following cases:

    - The server certificate is expired.

    - The server certificate is revoked.

    - The common name of the server certificate does not match the server name to which DataMiner is sending the request.

    - The certificate is issued by a Certificate Authority that is not trusted by the DataMiner Agent.

    - The server certificate is signed by a weak signature.

  - DataMiner will block communication when the server is offering a non-server certificate.

  > [!NOTE]
  >
  > - To skip SSL/TLS certificate validation for all elements that share the same *protocol.xml* file, set the `SkipCertificateVerification` element to true in the `PortSettings` element of the *protocol.xml* file.
  > - To enable SSL/TLS certificate validation when using multithreaded HTTP communication, set `requestSettings[6]` to false when building the HTTP request in a QAction. For more information, see [Setting up multithreaded HTTP communication in a QAction](xref:AdvancedMultiThreadedTimersHttp).
  > - For backward compatibility, the SSL/TLS certificate validation is skipped by default for all elements created before version 10.5.0/10.4.12.
