---
uid: Exchanging_Process_Data_With_External_Applications
---

# Exchanging process data with external applications

For each process run, a new process DOM instance needs to be generated. This DOM instance functions as a container of data that each activity can read or update. This should also be the main interface for external applications to access details of a process instance.

The responsibility of the PA framework stops at the update of the DOM instance. It is up to the team implementing the process to code custom logic to access and process relevant data from the process DOM instance .

### Example

For a process where a *Scan IP Range* activity is present, it might be interesting to access the list of IPs that have been detected and show it using a custom front end.

In that case, the process DOM definition would require a “Detected IPs” field descriptor that is used to store a serialized list of IPs.

Custom code would then need to access that field descriptor to bring it to the user.
