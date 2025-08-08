---
uid: BPA_Security_Advisory
---

# Security Advisory

This BPA will run a collection of checks to see if the system is configured as securely as possible.

Currently, the following parts of the system are covered:

- DMA

  - gRPC: Verifies if the system is configured to use gRPC for the communication between Cube and the DMA and for inter-DMA communication (only from DataMiner 10.3.2/10.3.0 onwards).
  - Legacy components: Verifies if the v0 web API, the legacy Reporter and Dashboards module, and the legacy Annotations module are disabled.
  - NATS: Verifies if NATS is configured to use TLS (only from DataMiner 10.4.3 onwards).

    > [!NOTE]
    > Prior to DataMiner 10.4.0 CU5/10.3.0 CU17/10.4.8, the BPA also checks if NATS is configured to use TLS if the DMS consists of only one Agent. However, as this is not necessary in such case, this is no longer checked in later DataMiner versions.<!-- RN 39792 -->

- IIS

  - HTTP: Verifies if HTTP is disabled, restricted to localhost, or configured to redirect to HTTPS.
  - HTTPS: Verifies if HTTPS is enabled and if the certificate is valid.
  - HTTP Headers: Verifies if HTTP headers that leak information are removed and if HTTP headers that increase security are set.

- Operating system

  - Firewall configuration: Verifies if the firewall is active and if the port configuration is correct. Note that only the ports used by DataMiner and the databases are checked. For a list of the checked ports, refer to the [DataMiner hardening guide](xref:DataMiner_hardening_guide#configure-the-firewall).
  - Local admin hygiene: Verifies if the local admin account is disabled and if there are not too many local administrator accounts.
  - TLS configuration: Verifies if legacy TLS protocol versions are disabled and if the recommended TLS protocol versions are enabled.

- Database

  - Authentication: Verifies if authentication is enabled and if a secure password is used.
  - Authorization: Verifies if the database user is not a superuser.
  - TLS: Verifies if the connection towards the database is using TLS.
  - Database software: Verifies whether the database software is still supported. This check is included from DataMiner 10.4.0 [CU16]/10.5.0 [CU4]/10.5.7 onwards.<!-- RN 42914 -->

> [!NOTE]
> This BPA test is available from DataMiner 10.3.0 [CU15]/10.4.0 [CU3]/10.4.5 onwards.<!-- RN 38632 -->

## Metadata

- Name: Security Advisory
- Description: Runs a collection of checks to see if the system is configured as securely as possible.
- Author: Skyline Communications
- Default Schedule: Weekly

## Results

### Success

The DataMiner Agent is set up and configured according to the DataMiner hardening guide.

### Error

One or more of the parts of the system covered by this BPA do not have the most secure configuration.

The BPA will indicate what can be improved.

## Mitigation

The BPA will indicate which parts of the system do not have the most secure configuration.

To fix the indicated issues, refer to the [DataMiner Hardening guide](xref:DataMiner_hardening_guide).
