---
uid: ClassLibraryMonitorsStartingAStartedMonitor
---

# Starting a started monitor

From a single source, you should only start a specific monitor on a destination element or parameter once. If you start a second monitor on the same destination and with the same trigger it will remove and overwrite the previously started monitor.

To clarify, you can imagine every monitor to be unique through the following string:

- Source + Monitor Type + Destination

If you start a monitor that has already been started, you will clean up the previous action and assign your new action to the event.
