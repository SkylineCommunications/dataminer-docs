---
uid: Credentials_Library
---

# Credentials Library

The DataMiner Credentials Library is a built-in key vault feature that centralizes the management of authentication data used across the system. It provides a single place to define and maintain credentials, streamlining administration, ensuring consistency, and enabling reuse without embedding sensitive data in multiple locations.

The library supports multiple credential types, including SNMPv2 community strings, SNMPv3 configurations, username/password pairs, and token-based credentials.

> [!NOTE]
> Password and secret values stored in the Credentials Library are limited to a maximum size of **5120 bytes (5 KB)**.

> [!NOTE]
> From DataMiner 10.6.9 onwards<!--RN 44075-->, credential secrets in the Credentials Library are stored as authenticated ciphertext (AES-256-CBC with HMAC-SHA-256) and never appear in plain text on disk. For more information, see [Encryption in DataMiner](xref:Encryption_in_DataMiner#credentials-at-rest).

## Configuring credentials in DataMiner Cube

To configure a credential in DataMiner Cube:

1. Go to **System Center** > **System Settings** > **Credentials Library**.

1. Click **Add credentials** at the bottom of the screen.

1. In the **General** section:
   - Specify a **Name** for the credential.
   - Select the appropriate **Type**:
     - **Community credentials**
     - **Token credentials**
     - **SNMPv3 credentials**
     - **Username and password credentials**

1. In the **Credentials** section, provide the information required for the selected credential type. The available options adapt automatically based on the chosen type.

1. In the **Groups** section, configure access control:
   - Select one or more groups from **Available groups**.
   - Click **Add >>** to move them to **Included in groups**.

   > [!NOTE]
   > Credentials are **only available to users who belong to the included groups**.

1. Click **Apply** to save the credential, or **Discard** to cancel your changes.

Once saved, the credential can be reused across the DataMiner platform, ensuring secure, consistent, and access-controlled authentication handling.