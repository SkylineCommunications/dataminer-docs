---
uid: Encryption_in_DataMiner
---

# Encryption in DataMiner

## Passwords

In the context of a DataMiner System, we can distinguish between two types of passwords:

- User passwords
- Device passwords

### User passwords

Passwords for external users in the DataMiner System are always managed by the User Directory (Active Directory, OpenLDAP, etc.). To verify password security requirements, we recommend that users consult their respective User Directory documentation.

For local DataMiner users, [Windows will store the (hashed) password](https://docs.microsoft.com/en-us/windows-server/security/kerberos/passwords-technical-overview). The complexity and renewal policies in Windows apply to local DataMiner users.

The only exception to this is dataminer.services users (see [Types of users](xref:Types_of_users)). These users are fully managed by DataMiner. The passwords for these users are randomly generated (17 characters) and encrypted using the Blowfish algorithm (ECB mode, 308-bit key) before being stored.

### Device passwords (tokens)

All password encryption in DataMiner is done through the Blowfish algorithm (ECB mode). A 308-bit key is used for the encryption.

DataMiner encrypts the following secrets using this technique:

- Password parameters
- [Credential libraries](xref:Managing_predefined_sets_of_credentials_for_SNMP_authentication)
- Database passwords
- Element passwords
- Replication passwords

## In-Transit Encryption

Here we can distinguish several communication flows:

- DataMiner Cube
- DataMiner Web Apps & API
- Inter-DataMiner
- Data acquisition
- Cassandra
- Elasticsearch
- NATS

### DataMiner Cube

DataMiner Cube will communicate with the DataMiner back end over .NET Remoting. By default, this is encrypted using the Rijndael (256-bit key, CBC mode) algorithm. The encryption key is negotiated over a 2048-bit RSA-secured communication channel.

### DataMiner Web Apps & API

By default, the DataMiner Web Apps (Reports, Dashboards, Monitoring, etc.) are served over HTTP, which is unencrypted. We recommend that you [enable HTTPS and disabling HTTP](xref:Setting_up_HTTPS_on_a_DMA) to ensure all traffic is encrypted.

### Inter-DataMiner

When a DataMiner System consists of multiple DataMiner nodes, inter-node communication flows through a .NET Remoting channel. By default, this is encrypted using the Rijndael algorithm (256-bit key, CBC mode). The encryption key is negotiated over a 2048-bit RSA-secured communication channel.

### Data acquisition

Depending on the type of device, DataMiner supports different communication protocols:

| Protocol | Description |
| -------- | ----------- |
| SSH | DataMiner supports a broad list of SSH cipher, host key algorithms and key exchange algorithms. For more information, see [SSH support in DataMiner](xref:ConnectionsSerialSecureShell#ssh-support-in-dataminer). |
| SNMP | We recommend interfacing with SNMP devices by using SNMPv3, which provides authentication and privacy. |
| HTTP(S) | We recommend interfacing with devices or APIs over [HTTPS](xref:ConnectionsHttpHttps), which uses TLS encryption. |
| TCP/IP | DataMiner can poll devices over a TLS-encrypted TCP/IP channel. See [Enabling TLS encryption](xref:Enabling_TLS_encryption). |

### Cassandra

For DataMiner Systems configured to use a Cassandra database, it is possible to [enable TLS encryption between DataMiner and the Cassandra cluster](xref:DB_xml#enabling-tls-on-the-cassandra-database-connection). Please refer to the official Cassandra documentation on [enabling TLS encryption](https://docs.datastax.com/en/cassandra-oss/3.x/cassandra/configuration/secureSSLClientToNode.html).

We recommend changing the default Cassandra credentials.

> [!NOTE]
> For more information, see [Securing the Cassandra general database](xref:Security_Cassandra_general).

### Elasticsearch

For DataMiner Systems configured to use an Elasticsearch database, we recommend enabling HTTPS. Please refer to the official Elasticsearch documentation on [enabling TLS encryption](https://www.elastic.co/blog/configuring-ssl-tls-and-https-to-secure-elasticsearch-kibana-beats-and-logstash).

> [!NOTE]
> For more information, see [Securing the Elasticsearch database](xref:Security_Elasticsearch).

### NATS

From version 10.1.0/10.1.1 onwards, DataMiner relies on NATS for some inter-process communication. By default, this NATS traffic is not yet encrypted.

Please refer to the official NATS documentation on [enabling TLS encryption](https://docs.nats.io/running-a-nats-service/configuration/securing_nats/tls).

## Encryption at rest

DataMiner only encrypts passwords at rest, all other data is not encrypted by default. This behavior is not configurable in DataMiner. Note that it is possible to [enable Windows BitLocker](https://docs.microsoft.com/en-us/windows/security/information-protection/bitlocker/bitlocker-group-policy-settings) to encrypt all data on disk.

When your DataMiner System is configured to use a Cassandra database, we recommend enabling the [transparent_encryption_options](https://docs.datastax.com/en/security/6.7/security/secEncryptTDE.html), effectively encrypting all your database data at rest.
