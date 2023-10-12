---
uid: SNMPv3_Connection
---

# SNMPv3 connections

For SNMPv3 connections, you can specify the following connection settings while creating or editing an element:

- **SNMP version**: Allows you to select a different SNMP version than the version configured in the protocol. With an SNMPv3 type protocol, you can select SNMPv2 or SNMPv3.

- **IP address/host**: The polling IP or URL of the destination.

- **Network**: The network interface (NIC). If only one network interface is available on the DMA, it is automatically selected.

- **Port number**: By default 161.

- **Use credentials**: If predefined credentials have been made available for your user account, you can select this checkbox to select a set of predefined SNMP credentials. See also: [Managing predefined sets of credentials for SNMP authentication](xref:Managing_predefined_sets_of_credentials_for_SNMP_authentication).

- **Security level and protocol**: Select one of the following three levels in the drop-down list:

  - *noAuthNoPriv*: No authentication and no privacy, which is essentially the same as SNMPv2.

  - *authNoPriv*: Authentication without privacy. This means that authentication is required, but data is not encrypted. If this value is chosen, an encryption password is not necessary.

  - *authPriv*: Authentication with privacy. This means that both authentication is required and data is encrypted, so that both the authentication password and the encryption password must be filled in.

- **User name**: Always needs to be specified, regardless of the selected security level and protocol.

- **Authentication password**: Not required if *noAuthNoPriv* is selected.

- **Encryption password**: Only required if *authPriv* is selected.

- **Authentication algorithm**: Not available if *NoAuth_NoPriv* is selected. You can choose between *MD5*, *SHA-1*, *SHA-224*, *SHA-256*, *SHA-384*, and *SHA-512*.

- **Encryption algorithm**: Only available if *Auth_Priv* is selected. You can choose between *AES-128*, *AES-192*, *AES-256*, and *DES*.

> [!NOTE]
> The following combinations of authentication and encryption algorithm are not supported:
>
> - MD5/SHA-1 and AES192
> - MD5/SHA-1/SHA-224 and AES256
>
> We recommend that you use SHA-512 and AES-256, since this is the most secure combination. As such, this is the combination that is selected by default.
