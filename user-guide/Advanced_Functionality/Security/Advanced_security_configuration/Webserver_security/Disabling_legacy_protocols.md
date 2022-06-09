---
uid: Disabling_legacy_protocols
---

# Disabling legacy protocols

Secure Socket Layer (SSL) is an internet security protocol that provides encryption, authentication and data integrity.
SSL is the predecessor of Transport Layer Security (TLS), which is widely used across the internet.
SSL/TLS provides the security for HTTPS communication.

SSL was last updated in 1996 and is now considered deprecated. There are several known vulnerabilities in the SSL protocol, and security experts recommend discontinuing its use. In fact, most modern web browsers no longer support SSL at all.

Since 2021, TLS 1.0 and 1.1 are oficially considered **deprecated**.
We recommend users disable these legacy versions and migrate to the more modern TLS 1.2 and 1.3.

To **disable** the legacy SSL/TLS protocols, execute the Disable-LegacyProtocols PowerShell script  [available on our GitHub](https://github.com/SkylineCommunications/windows-hardening/blob/main/Disable-LegacyProtocols.ps1).

Make sure to **reboot** the Windows Server for the changes to take effect.