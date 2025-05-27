---
uid: IDP_1.5.2
---

# IDP 1.5.2

## Changes

### Enhancements

#### Enhanced performance when validating element properties [ID 42290]

When validating element properties, IDP will now bypass Class Library and call SLNet directly. This will enhance overall performance and reduce logging.

### Fixes

#### Same connection created multiple times [ID 42614]

When connectivity discovery and provisioning was run multiple times, this could lead to multiple copies of the same connection being created. This will now be prevented. IDP will check if a connection exists and update it if needed. The same also applies for connection properties and interface properties.
