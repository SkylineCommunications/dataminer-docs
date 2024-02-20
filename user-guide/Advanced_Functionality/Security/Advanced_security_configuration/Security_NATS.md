---
uid: Security_NATS
---

# Securing NATS

## Enable TLS in cluster

By default, NATS does **not** implement TLS encryption, which means anyone can eavesdrop the communication passing over the wire. We therefore **highly recommend that you enable TLS encryption** on your NATS cluster.

> [!NOTE]
> This applies solely to instances involving a DMS cluster or external DxMs. In the scenario of a single-agent setup, all communication is confined to the localhost, given the presence of only one NATS node.

To enable authentication, please apply the following procedure to all the NATS nodes in the cluster: 

1. Request or generate a TLS certificate (the certificates should be in the PEM format). When generating self-signed certificates, we recommend that you **use our [scripts for generating TLS certificates](https://github.com/SkylineCommunications/generate-tls-certificates)**, available on GitHub. There is a version of the script for Linux and Windows machines. The script requires two tools: *openssl* and the *Java keytool*. Both of these can run on Linux and Windows.
   
1. Update the **nats-server.config** file, to incorporate the TLS section within the cluster segment. This adjustment is necessary to accommodate the specified location of the PEM files, as exemplified below:
    
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
> The `ca_file` property is only required when using self-signed certificates.
   
1. Stop your NATS service.

1. Stop your NAS service.

1. Start your NATS service, which should automatically start the NAS service.

Please ensure the TLS encryption is enabled by accessing the **[NATS monitoring](http://localhost:8222/varz)** and validating that the `urls` property encompasses all the IP addresses of the NATS nodes configured with TLS. Additionally, confirm that the `tls_required` and `tls_verify` properties are appropriately configured to **true**, as demonstrated below:

   ```json
     "cluster": {
       "urls": [
         "[NATS_NODE_IP_ADDRESS]:6222",
       ],
       "tls_required": true,
       "tls_verify": true
     }
  ```
