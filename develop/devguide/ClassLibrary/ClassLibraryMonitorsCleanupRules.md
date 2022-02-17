---
uid: ClassLibraryMonitorsCleanupRules
---

# Cleanup rules

Any monitor will be automatically stopped in the following cases:

- When the source element (i.e. the element that starts the monitors) is stopped or restarted.

  This means that all monitors must be manually restarted when the element is restarted.
- When the destination element (i.e. the element that is being monitored) is deleted.
