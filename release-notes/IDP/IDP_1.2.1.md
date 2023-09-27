---
uid: IDP_1.2.1
---

# IDP 1.2.1

### Enhancements

#### Improved performance when provisioning DCF connections and interface properties [ID_35916]

IDP connectivity has been updated to improve performance when a large number of DCF connections and interface properties are provisioned:

- To reduce the number of calls, existing DCF interfaces and connections are now cached.
- Multi-threading is now used to allow the algorithm to run faster.
- SLNet calls are now used instead of the DCFHelper to create connections and properties.

#### Bus address support for all connection types [ID_36046]

You can now configure the bus address for any type of connection in the CI Type Management wizard, so that it is configured when a newly discovered element is provisioned or a CI Type is reapplied or reassigned.

### Fixes

#### IP address of element not updated when IP address of corresponding IS-04 node changed [ID_35391]

When a user created a new PA process using the existing [IDP IS-04 Update Existing Nodes](xref:Using_your_IS04_registry_to_provision_DataMiner_with_IDP#idp-is-04-update-existing-nodes) process, it could occur that the IP address of the element was not updated when the IP address of the IS-04 node changed.

To prevent this issue, the *IPAddress* metadata is now added to the token.

#### Username casing mismatch caused exception when searching for backup configuration files [ID_35567]

If the casing of a username in DataMiner was different from the casing in Windows (e.g. the DataMiner username was *user* while the Windows username was *User* or *USER*), this could cause an exception when searching for backup configuration files. More specifically, the *IDP_ApplySearchCriteria* script would throw an exception stating that it could not find an active session for the current user.

#### Exception thrown when updating a device [ID_35666]

If IDP could not resolve the CMDB element when a device was updated, it could occur that the update progress could not be updated and the following exception was thrown:

```txt
System.ArgumentException: Source array was not long enough. Check srcIndex and length, and the array's lower bounds.
```
