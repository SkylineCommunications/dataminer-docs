---
uid: Security_NATS
---

# Securing NATS

## Enable TLS in cluster

By default, NATS does **not** implement TLS encryption, which means anyone can eavesdrop the communication passing over the wire. We therefore **highly recommend that you enable TLS encryption** on your NATS cluster.

> [!NOTE]
> This only applicable if you have a DMS cluster or external DxMs. In case of a single agent setup, all communication occurs within the localhost, since there is only a singular NATS node.

To enable authentication, the following procedure 

1. Request or generate a TLS certificate (the certificates should be in the PEM format). When generating self-signed certificates, we recommend that you **use our [scripts for generating TLS certificates](https://github.com/SkylineCommunications/generate-tls-certificates)**, available on GitHub. There is a version of the script for Linux and Windows machines. The script requires two tools: *openssl* and the *Java keytool*. Both of these can run on Linux and Windows.
   
1. Update the **nats-server.config** file, in order to add the TLS section within the cluster section as demonstrated below:
    
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

1. Stop the NAS service.

1. Start your NATS service, which should automatically start the NAS service.


Confirm that the TLS encryption is enabled by accessing the **[NATS monitoring](http://localhost:8222/varz)** and vefying whether the `urls` property contains all the IP addresses of the NATS nodes configured with TLS. In addition, the `tls_required` and `tls_verify` properties should be set to **true**, as presented below:

   ```json
     "cluster": {
       "urls": [
         "[NATS_NODE_IP_ADDRESS]:6222",
       ],
       "tls_required": true,
       "tls_verify": true
     }
  ```
