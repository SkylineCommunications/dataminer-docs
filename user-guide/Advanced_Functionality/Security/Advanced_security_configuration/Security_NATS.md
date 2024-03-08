---
uid: Security_NATS
---

# Securing NATS

By default, NATS does **not** employ TLS encryption, leaving communication susceptible to eavesdropping. Consequently, we **strongly recommend enabling TLS encryption** for enhanced security within your NATS cluster.

## Enabling NATS inter-node TLS communication

> [!NOTE]
> This applies solely to instances involving a DMS cluster or external DxMs. If you have a single-Agent setup, all communication is confined to the local host, as there is only one NATS node.

1. Request or generate TLS certificates (in PEM format).

   To generate self-signed certificates, we recommend that you **use our [scripts for generating TLS certificates](https://github.com/SkylineCommunications/generate-tls-certificates)**, available on GitHub. There is a version of the script for Linux and for Windows machines. The script requires two tools: *openssl* and the *Java keytool*. Both of these can run on Linux and Windows.

1. Follow the steps below **for each of the NATS nodes** in the cluster to enable TLS encryption:

   1. Update the **nats-server.config** file to incorporate the TLS section within the cluster segment.

      This adjustment is necessary to accommodate the specified location of the PEM files. For example:

      ```
      cluster {
        tls {
          cert_file: "absolute\\path\\to\\certificate_file\\certificate.pem"
          key_file:  "absolute\\path\\to\\private-key_file\\private-key.pem"
          ca_file:   "absolute\\path\\to\\rootCA_file\\rootCA.pem"
        }
      }
      ```

      > [!NOTE]
      > The `ca_file` property is only required when self-signed certificates are used.

   1. In the *Services* tab in the Windows Task Manager, stop the NATS service.

   1. In the *Services* tab in the Windows Task Manager, stop the NAS services.

   1. In the *Services* tab in the Windows Task Manager, start the NATS service.

      This should automatically trigger the start of the NAS service as well.

   1. Verify whether TLS encryption is enabled for inter-node communication:

      1. Go to `http://localhost:8222/varz` in a browser.

      1. Check whether the `urls` property encompasses all the IP addresses of the NATS nodes configured with TLS.

      1. Check whether the `tls_required` and `tls_verify` properties are appropriately configured to **true**.

      For example:

      ```json
        "cluster": {
          "urls": [
            "[NATS_NODE_IP_ADDRESS]:6222",
          ],
          "tls_required": true,
          "tls_verify": true
        }
      ```

## Enabling DataMiner-to-NATS node TLS communication

> [!IMPORTANT]
> TLS encryption for communication between software and NATS nodes is available starting from DataMiner 10.4.3 [CU0]/10.5.0<!-- RN 38302 --> with support for CA-signed certificates (Certificate Authority-Signed Certificates). While support for self-signed certificates will be introduced later, keep in mind that for now only CA-signed certificates are supported and attempting to use self-signed certificates will result in DataMiner startup failures.

1. Install the certificate in the Windows Trusted Root Certification Authorities Certificate Store, which **requires administrator privileges**.

   1. Double-click the certificate file.

      This will open the *Certificate* dialog.

   1. Click *Install Certificate*.

   1. Select to store the certificate on the "Local Machine"

      > [!NOTE]
      > This requires administrative privileges.

   1. Select *Place all certificates in the following store*.

   1. Click *Browse* and select *Trusted Root Certification Authorities*.

1. Update the **nats-server.config** file to incorporate the TLS section.

   This adjustment is necessary to accommodate the specified location of the PEM files. For example:

   ```
     tls {
       cert_file: "absolute\\path\\to\\certificate_file\\certificate.pem"
       key_file:  "absolute\\path\\to\\private-key_file\\private-key.pem"
     }
   ```

1. In the *Services* tab in the Windows Task Manager, stop the NATS service.

1. In the *Services* tab in the Windows Task Manager, stop the NAS services.

1. In the *Services* tab in the Windows Task Manager, start the NATS service.

   This should automatically trigger the start of the NAS service as well.

1. Verify whether TLS encryption is enabled for DataMiner-to-NATS communication:

   1. Go to `http://localhost:8222/connz` in a browser.

   1. Check whether the `tls_version` and `tls_cipher_suite` properties are present for each connection.

   For example:

   ```json
    "connections": [
        {
            "cid": 1,
            "kind": "Client",
            "type": "nats",
            "ip": "127.0.0.1",
            "port": 56100,
            "start": "2024-02-23T16:17:34.0336834Z",
            "last_activity": "2024-02-23T16:17:34.0699403Z",
            "rtt": "1ns",
            "uptime": "4s",
            "idle": "4s",
            "pending_bytes": 0,
            "in_msgs": 0,
            "out_msgs": 0,
            "in_bytes": 0,
            "out_bytes": 0,
            "subscriptions": 0,
            "name": "_NSS-test-cluster-send",
            "lang": "go",
            "version": "1.27.0",
            "tls_version": "1.3",
            "tls_cipher_suite": "TLS_AES_128_GCM_SHA256"
        }]
   ```
