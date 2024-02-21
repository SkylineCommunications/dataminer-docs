---
uid: Security_NATS
---

# Securing NATS

## Enabling TLS in a NATS cluster

By default, NATS does **not** employ TLS encryption, leaving communication susceptible to eavesdropping. Consequently, we **strongly recommend enabling TLS encryption** for enhanced security within your NATS cluster.

> [!NOTE]
> This applies solely to instances involving a DMS cluster or external DxMs. If you have a single-Agent setup, all communication is confined to the local host, as there is only one NATS node.

Before proceeding with the configuration of each node in the cluster, you should request or generate TLS certificates (in PEM format).

To generate self-signed certificates, we recommend that you **use our [scripts for generating TLS certificates](https://github.com/SkylineCommunications/generate-tls-certificates)**, available on GitHub. There is a version of the script for Linux and for Windows machines. The script requires two tools: *openssl* and the *Java keytool*. Both of these can run on Linux and Windows.

**To enable TLS encryption, please apply the following procedure to all the NATS nodes in the cluster:**

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

1. Stop your NATS service, by navigating to the Services tab within your Task Manager.

1. Stop your NAS service, through the same Services tab in your Task Manager.

1. Start your NATS service, which should automatically trigger the start of the NAS service. Access the Services tab within your Task Manager for seamless execution.

1. Verify whether TLS encryption is enabled:

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
