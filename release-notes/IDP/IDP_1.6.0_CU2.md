---
uid: IDP_1.6.0_CU2
---

# IDP 1.6.0 CU2

## Fixes

#### Enabling extended logging could abort discovery [ID 44331]

When extended logging was enabled on the IDP Discovery element, this could cause a discovery action to be aborted.

#### Shared folder for configuration archive incorrectly reported as unavailable [ID 44436]

In some cases, it could occur that the configuration archive reported a disconnected or unavailable status for the configured shared folders even though the connection was fine. This especially occurred when the shared folder had not been accessed for a while. To prevent this, the connection check has now been replaced with a more accurate implementation.

#### Credential conflicts for configuration archive shared folders caused unnecessary account lockouts [ID 44450]

When credential conflicts for session-global SMB connections occurred with the credentials used for the configuration archive shared folders, these conflicts were incorrectly treated as authentication failures, leading to unnecessary account lockouts. To prevent this, IDP will now attempt to resolve these conflicts by disconnecting the existing session before retrying. If a conflict persists, IDP will use the existing session but log a warning regarding potential file permission issues.

#### Pending discovery requests from interrupted run not cleared from memory [ID 44462]

When the IDP Discovery element was restarted while a discovery run was still in progress, pending requests from that interrupted run could remain in memory and interfere with new network discovery operations. To prevent this, IDP Discovery now clears the remaining requests from memory on startup before beginning new processing.

#### Serial discovery incorrectly handled command parameters as ASCII string [ID 44769]

For serial discovery actions, the discovery profile *Parameter* field contains the command to send to the device and must be specified in hexadecimal format. Previously, this value was incorrectly handled as an ASCII string and then encoded to bytes, which could change the intended byte sequence and prevented sending non-printable command bytes. This has been fixed so the hexadecimal string is parsed into the corresponding binary bytes, and those bytes are sent to the device without an ASCII conversion step.

> [!IMPORTANT]
> This is a behavioral change. If existing discovery profiles were configured with ASCII text (instead of a base16/hex representation of the intended bytes), the bytes sent to the device will now differ. Verify and, if necessary, update the configured serial discovery command values so they represent the intended command bytes in hexadecimal format.

#### Rack Layout Manager became unresponsive when duplicate views were created [ID 44810]

The Rack Layout Manager component could become unresponsive and fail when you attempted to create a view with a name that already existed. This issue has been resolved by detecting and reusing existing views, preventing attempts to create duplicates.
