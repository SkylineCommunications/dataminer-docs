---
uid: BPA_Security_Advisory
---

# Security Advisory

## Best Practice

This BPA will run a collection of checks to see if the system is configured as secure a possible.
Currently The following parts of the system are covered:

- DMA
  - gRPC: Verifies if the system is configured to use gRPC for the cube <--> dma and inter-dma communication (only from 10.3.2/10.3.0 onwards).
  - Legacy components: Verifies if the v0 web api, the legacy reporter and dashboards module and the legacy annotations module are disabled.
  - Nats: Verifies if NATS is configured to use TLS (only from 10.4.3 onwards).
- IIS
  - HTTP: Verifies if http is disabled, restricted to localhost or configured to redirect to https.
  - HTTPS: Verifies if https is enabled and if the certificate is valid.
  - HTTP Headers: Verifies if http headers that leak information are removed and if http headers that increase security are set.
- Operating System
  - Firewall configuration: Verifies if the firewall is active and if the port configuration is correct. Note: only the ports used by DataMiner and the databases are checked, a list of the checked ports can be found in the DataMiner hardening guide.
  - Local Admin hygiene: Verifies if the local admin account is disabled and if there are not to many local administrator accounts.
  - TLS configuration: Verifies if legacy TLS protocol versions are disabled and if the recommended TLS protocol versions are enabled.
- Database
  - Authentication: Verifies if authentication is enabled and if a secure password is used.
  - Authorization: Verifies if the database user isn't a super-user.
  - TLS: Verifies if the connection towards the database is using TLS.

> [!NOTE]
> This BPA is available from 10.4.5 onwards.

## Metadata

- Name: Security Advisory
- Description: Runs a collection of checks to see if the system is configured as secure as possible.
- Author: Skyline Communications
- Default Schedule: Weekly

## Results

### Success

The DataMiner Agent is set up and configured according to the DataMiner hardening guide.

### Error

One or more of the parts of the system covered by this BPA is not in it's most secure configuration.
The PBA will indicate what can be improved.

## Mitigation

The BPA will indicate which parts of the system are not in it's most secure configuration.
The [DataMiner Hardening guide](xref:DataMiner_hardening_guide) provides or points to a step-by-step guide on how to fix the indicated issues.
