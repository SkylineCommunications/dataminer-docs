---
uid: CloudConnectionSecurity
---

# Cloud connection security

To connect your DataMiner System to the DataMiner Cloud Platform, a secure connect flow needs to be completed. The administrator needs to authenticate on the DataMiner System and then needs to authenticate towards the DataMiner Cloud Platform. 

At the end of this flow, a secure  JSON Web Token is delivered directly from the DataMiner Cloud Platform to the DataMiner System, which is used by the DataMiner System to authenticate towards the DataMiner Cloud Platform.

- The signature of these JSON Web Tokens is created using the HMAC SHA256 algorithm. The secret is kept in a Key Vault, which is only accessed using Managed Identities.

- Every JSON web token is only valid for 1 week, after which it is automatically renewed using a single-use refresh key.

All communication between the DataMiner System and the DataMiner Cloud Platform happens using HTTPS and WSS protocols, both using encrypted TLS connections.

Only outgoing traffic needs to be allowed through for the domain *.dataminer.services.

> [!NOTE]
> Technical details of this implementation may be subject to change as we regularly review our security implementations.
