---
uid: Value_update_verification
---

# Value update verification

- In case a protocol enables performing sets on a device (e.g., changing a configuration parameter), the protocol must verify that the set succeeded by retrieving the value again (e.g., when using SNMP, a get should always be performed after the set to ensure the set succeeded).
