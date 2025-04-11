---
uid: IDP_1.5.2
---

# IDP 1.5.2

## Changes

### Enhancements

#### Enhanced performance when validating element properties [ID 42290]

When validating element properties, IDP will now bypass Class Library and call SLNet directly. This will enhance overall performance and reduce logging.

### Fixes

#### Connectivity: Multiple copies of the same connection could incorrectly get created [ID 42614]

Up to now, when multiple connectivity discoveries were run, in some cases, multiple copies of the same connection could incorrectly get created.
