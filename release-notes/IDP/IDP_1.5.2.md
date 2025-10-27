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

#### IDP connectivity discovery failed when connected element was stopped [ID 43086]

When a connection was detected between two elements but one of the elements was stopped, this could cause the IDP connectivity discovery to fail and throw an exception. This situation will now be handled more gracefully, allowing discovery and provisioning to continue for other elements, and leaving the affected connection to be provisioned once the stopped element becomes active.
