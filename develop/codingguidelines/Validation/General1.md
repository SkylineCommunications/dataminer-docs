---
uid: General1
---

# General

- Verify that parameter get and set operations succeed. Verify that each configurable parameter of the device is set correctly.

    Try to verify the parameter value using the web interface of the device or another tool. If this is not possible, try to verify the format of these settings using Stream Viewer for a locally created element.

- In order to verify the communication with the device, you must verify displayed parameters that are not initialized. Parameters should not have exceptions by default to avoid being not initialized.

- No errors or issues must occur when the device is not reachable and communication should still be initiated.
