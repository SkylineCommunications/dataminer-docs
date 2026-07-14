---
uid: Credentials_Library
keywords: authentication, auth, SNMP credentials
---

# Credentials Library

The DataMiner Credentials Library is a built-in key vault feature that centralizes the management of authentication data used across the system. It provides a single place to define and maintain credentials, streamlining administration, ensuring consistency, and enabling reuse without embedding sensitive data in multiple locations.

The library supports multiple credential types, including SNMPv2 community strings, SNMPv3 configurations, username/password pairs, and token-based credentials.

> [!NOTE]
> Password and secret values stored in the Credentials Library are limited to a maximum size of **5120 bytes (5 KB)**.

> [!NOTE]
> From DataMiner 10.6.9/10.7.0 onwards<!--RN 44352-->, credential secrets in the Credentials Library are stored as authenticated ciphertext (AES-256-CBC with HMAC-SHA-256) and never appear in plain text on disk. For more information, see [Encryption in DataMiner](xref:Encryption_in_DataMiner#credentials-at-rest).

## Configuring credentials in DataMiner Cube

To configure a set of credentials in DataMiner Cube:

1. Go to *System Center* > *System settings* > *Credentials library*.

1. Click *Add credentials* at the bottom of the screen.

1. In the *General* section:

   - Specify a *Name* for the credentials.
   - Select the appropriate *Type*:
     - *Community credentials*
     - *Token credentials*
     - *SNMPv3 credentials*
     - *Username and password credentials* (available from DataMiner 10.3.11 onwards)

1. In the *Credentials* section, provide the information required for the selected credentials type.

   The available options adapt automatically based on the chosen type.

1. In the *Groups* section, configure access control by adding or removing the relevant groups in the *Included in groups* box using the *ADD >>* and *<< REMOVE* buttons.

   > [!NOTE]
   > Credentials are **only available to users who belong to the included groups**.

1. Click *Apply* to save the credentials.

Once saved, the credentials can be reused across the DataMiner System, ensuring secure, consistent, and access-controlled authentication handling.

> [!NOTE]
>
> - Credentials are synchronized throughout the DMS.
> - If a set of credentials is deleted or edited while it is in use by an active element, that element will be restarted automatically.
> - For credentials that include a password (e.g., SNMPv3 credentials), the password can be up to 43 characters long. From DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43422-->, credentials of type *Username and password* allow passwords of any length.
