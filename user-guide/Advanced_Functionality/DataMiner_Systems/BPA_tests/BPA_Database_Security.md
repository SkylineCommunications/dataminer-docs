---
uid: BPA_Database_Security
---

# Database Security

At the core of DataMiner is its capability to collect data from different sources. These days, preventing data breaches is more important than ever. Attackers will not only steal your data but even try to keep you from accessing it. Ensuring that the databases are correctly secured is therefore of crucial importance.

The main steps in securing the databases are:

- Enabling authentication
- Enabling TLS encryption
- Limiting the permissions of the database user

This BPA test will check that authentication and TLS encryption are enabled on the Cassandra and Elasticsearch databases. It will also verify that the database superuser is not used by DataMiner.

> [!NOTE]
> This BPA is available from DataMiner version 10.2.12 and 10.3.0 onwards.

## Metadata

- Name: Database Security
- Description: Verifies that the Cassandra and Elasticsearch databases are configured securely
- Author: Skyline Communications
- Default Schedule: Weekly

## Results

### Success

Authentication and encryption are enabled on all databases.

### Warning

- Authentication is not configured.
- TLS encryption is not configured.
- The database user is a default superuser, e.g. *root*.

### Error

This BPA does not create errors.

## Mitigation

Enable authentication and TLS encryption.

Ensure that the DataMiner database user is not a default superuser. You can for example create a dedicated "dataminer" database user and configure it in DataMiner.

For more information, see [Securing the DataMiner databases](https://aka.dataminer.services/DatabaseSecurity).

## Limitations

- The BPA cannot verify if authorization has been enabled in Cassandra.
- The BPA cannot not verify the validity or chain of trust for the TLS certificates.
- The BPA cannot not verify the TLS version in use by DataMiner.
