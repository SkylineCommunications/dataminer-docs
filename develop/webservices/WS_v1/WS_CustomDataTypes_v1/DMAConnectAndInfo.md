---
uid: DMAConnectAndInfo
---

# DMAConnectAndInfo

| Item | Format | Description |
|--|--|--|
| Connection | String | The connection string. |
| Message | String | If the connection attempt failed, *Message* will contain an error message. |
| MessageType | String | If the connection attempt failed, *MessageType* will indicate the type of error that occurred. |
| DMAVersion | String | The version of the DataMiner software. |
| AlarmColors | [DMAAlarmColors](xref:DMAAlarmColors) | The alarm colors used on the DataMiner Agent. |
| time | String | The DMS time. |
| TimeUTC | Long integer | The DMS time in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| LastChangeUTC | Long integer | The time when the object was last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| Security | [DMASecurity](xref:DMASecurity) | The user permissions of the specified user account. |
| Licenses | [DMALicenses](xref:DMALicenses) | Array indicating which licenses are or are not available on the DMA. |
| User | [DMAUser](xref:DMAUser) | The user login, full name and email address of each user. |
| UserGroups | [DMAUserGroup](xref:DMAUserGroup) | The IDs and names of the user groups. |
| SLNetConnectionID | String | The SLNet connection ID. |
| Cookie | String | The encoded timestamp, client info hash, username and password |
| ClusterInfo.IsCassandraActive | Boolean | Indicates whether the DMA uses a Cassandra database. |
| ClusterInfo.IsSearchActive | Boolean | Indicates whether the DMA uses an indexing database. |
| HasDelegatedAuthentication | Boolean | Indicates whether authentication is delegated to a third-party system. |
