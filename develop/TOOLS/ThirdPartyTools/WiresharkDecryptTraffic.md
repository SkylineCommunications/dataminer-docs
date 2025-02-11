---
uid: WiresharkDecrypt
---

# Wireshark stream decryption

## SNMPv3

Wireshark allows the decrypting of an encrypted SNMPv3 stream.

1. Go to *Edit* > *Preferences*.

1. In the *Preferences* window, expand *Protocols* and select *SNMP*.

1. Click the *Edit* button next to *Users Table*.

   This will open the *SNMP Users* window.

1. Click the *+* button and provide the necessary details for:

   - Engine ID
   - Username
   - Authentication model
   - Authentication password
   - Privacy protocol
   - Privacy password

If the provided info is correct, the package stream will now show the decrypted data.
