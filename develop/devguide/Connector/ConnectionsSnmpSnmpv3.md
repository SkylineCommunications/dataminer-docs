---
uid: ConnectionsSnmpSnmpv3
---

# SNMPv3

The following RFCs provide more information about SNMPv3:

| RFC                                                       | Description                                                                                                   |
|-----------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|
| [RFC 3410](https://datatracker.ietf.org/doc/html/rfc3410) | Introduction and Applicability Statements for Internet-Standard Management Framework                          |
| [RFC 3411](https://datatracker.ietf.org/doc/html/rfc3411) | An Architecture for Describing Simple Network Management Protocol (SNMP) Management Frameworks                |
| [RFC 3412](https://datatracker.ietf.org/doc/html/rfc3412) | Message Processing and Dispatching for the Simple Network Management Protocol (SNMP)                          |
| [RFC 3413](https://datatracker.ietf.org/doc/html/rfc3413) | Simple Network Management Protocol (SNMP) Applications                                                        |
| [RFC 3414](https://datatracker.ietf.org/doc/html/rfc3414) | User-based Security Model (USM) for version 3 of the Simple Network Management Protocol (SNMPv3)              |
| [RFC 3415](https://datatracker.ietf.org/doc/html/rfc3415) | View-based Access Control Model (VACM) for the Simple Network Management Protocol (SNMP)                      |
| [RFC 3416](https://datatracker.ietf.org/doc/html/rfc3416) | Version 2 of the Protocol Operations for the Simple Network Management Protocol (SNMP)                        |
| [RFC 3417](https://datatracker.ietf.org/doc/html/rfc3417) | Transport Mappings for the Simple Network Management Protocol (SNMP)                                          |
| [RFC 3418](https://datatracker.ietf.org/doc/html/rfc3418) | Management Information Base (MIB) for the Simple Network Management Protocol (SNMP)                           |
| [RFC 3584](https://datatracker.ietf.org/doc/html/rfc3584) | Coexistence between Version 1, Version 2, and Version 3 of the Internet-standard Network Management Framework |

## User-based Security Model (USM)

SNMPv3 applies a User-based Security Model (USM) which provides support for authentication and encryption. For more information about USM in SNMPv3, refer to [RFC 3414](https://datatracker.ietf.org/doc/html/rfc2574).

> [!NOTE]
> Always verify that the correct security settings are filled in (username, authentication and privacy settings). A user is considered unique based on the following set of properties:<!-- RN 21458 -->
>
> - User name
> - Authentication protocol
> - Authentication password
> - Privacy protocol
> - Privacy password

### Supported authentication and encryption protocols

The following SNMPv3 authentication and encryption (privacy) protocols are supported in DataMiner:

- Encryption algorithms:
  - DES
  - AES128
  - AES192<!-- RN 23586 -->
  - AES256<!-- RN 23586 -->
- Authentication algorithms:
  - MD5
  - SHA128
  - SHA224<!-- RN 23586 -->
  - SHA256<!-- RN 23586 -->
  - SHA384<!-- RN 23586 -->
  - SHA512<!-- RN 23586 -->

> [!NOTE]
> When an encryption algorithm is used with more bits than the authentication type, this can cause issues. The following combinations are therefore not possible:
>
> - MD5 & AES192
> - MD5 & AES256
> - SHA128 & AES192
> - SHA128 & AES256
> - SHA224 & AES256

### About snmpEngineID, snmpEngineBoots, snmpEngineTime and timeliness

[RFC 3411](https://datatracker.ietf.org/doc/html/rfc3411#section-3.1.1.1) states the following: *Within an administrative domain, an snmpEngineID is the unique and unambiguous identifier of an SNMP engine. Since there is a one-to-one association between SNMP engines and SNMP entities, it also uniquely and unambiguously identifies the SNMP entity within that administrative domain. Note that it is possible for SNMP entities in different administrative domains to have the same value for snmpEngineID. Federation of administrative domains may necessitate assignment of new values.*

Therefore, if DataMiner manages multiple SNMP entities, it is important that these are all configured with a different value for *snmpEngineID*. If this is not the case, this can lead to communication issues.

Every SNMP engine maintains two values:

- *snmpEngineBoots*: A count of the number of times the SNMP engine has rebooted/reinitialized since *snmpEngineID* was last configured.
- *snmpEngineTime*: The number of seconds since the *snmpEngineBoots* counter was last incremented.

Together, these provide an indication of time at that specific SNMP engine.

These values are included in an authenticated message sent to or received from that SNMP engine (a non-authoritative SNMP engine retrieves these values from an authoritative SNMP engine by a [discovery process](https://datatracker.ietf.org/doc/html/rfc3414#section-4)). This is because when an SNMP engine receives an authenticated message, it verifies whether the time indication in the message falls within a specific time window compared to its current time. This acts as a message replay protection mechanism. (For more information, refer to [RFC3414](https://datatracker.ietf.org/doc/html/rfc3414#section-1.5.2)).

[RFC 3414](https://datatracker.ietf.org/doc/html/rfc3414#section-2.3) also states the following: *A non-authoritative SNMP engine must keep local notions of these values (snmpEngineBoots, snmpEngineTime and latestReceivedEngineTime) for each authoritative SNMP engine with which it wishes to communicate. Since each authoritative SNMP engine is uniquely and unambiguously identified by its value of snmpEngineID, the non-authoritative SNMP engine may use this value as a key in order to cache its local notions of these values.*

If you were to have multiple devices with the same *snmpEngineID*, this could result in the non-authoritative SNMP engine only being able to keep track of the notion of time of one authoritative SNMP engine (which could lead to communication issues with all SNMP engines that have the same value for *snmpEngineID*).
