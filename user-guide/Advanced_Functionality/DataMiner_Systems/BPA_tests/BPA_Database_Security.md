---
uid: BPA_Database_Security
---

# Database Security

## Best Practice

The core of DataMiner lies in its capability to collect data from different sources.
Data breaches are only increasing and attackers will not only steal your data but even try to deny you from accessing it.
For these reasons, it is important to ensure the databases are correctly secured.

The most important steps in securing the databases are:
- Enabling authentication
- Enabling TLS encryption
- Limiting the permissions of the database user.

This BPA will check that authentication &amp; TLS encryption are enabled on the Cassandra &amp; Elasticsearch database.
It will also verify the database superuser is not used by DataMiner.

## Metadata

- Name: Database Security
- Description: Verifies the Cassandra &amp; Elasticsearch databases are configured securely.
- Author: Skyline Communications
- Default Schedule: Weekly

## Results

### Success

All databases have enabled authentication and encryption.

### Warning

- Authentication is not configured
- TLS encryption is not configured
- The database user is a default superuser, e.g. *root*

### Error

This BPA does not create errors.

## Mitigation

Enable authentication and TLS encryption.
Ensure the DataMiner database user is not a default superuser, e.g. create a dedicated 'dataminer' database user and configure it in DataMiner.

For more information, see [Securing the DataMiner databases](https://aka.dataminer.services/DatabaseSecurity).

## Limitations

- The BPA cannot verify if authorization has been enabled in Cassandra.
- The BPA cannot not verify the validity or chain of trust for the TLS certificates.
- The BPA cannot not verify the TLS version in-use by DataMiner.