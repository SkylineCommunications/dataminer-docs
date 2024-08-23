---
uid: WiresharkDecrypt
---

# Wireshark stream decryption

## SNMPv3

Wireshark allows decrypting an encrypted SNMPv3 stream.

Go to *Edit* > *Preferences...*. From the Preferences window, expand *Protocols* and select *SNMP*. Press the *Edit...* button for Users Table.

This opens the SNMP Users window. Press the *+* icon and provide the necessary details for:

- Engine ID
- Username
- Authentication model
- Authentication password
- Privacy protocol
- Privacy password

If the provided info is correct, the package stream now shows the decryped data.
