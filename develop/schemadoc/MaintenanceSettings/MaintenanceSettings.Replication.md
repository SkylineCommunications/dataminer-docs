---
uid: MaintenanceSettings.Replication
---

# Replication element

Configures replication-related settings.

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[AuthenticateMessageTimeout](xref:MaintenanceSettings.Replication.AuthenticateMessageTimeout) | [0, 1] | Specifies the timeout time for authentication messages (in seconds). |
| &#160;&#160;[ConnectionCheckingInterval](xref:MaintenanceSettings.Replication.ConnectionCheckingInterval) | [0, 1] | Specifies the interval, in seconds, used to potentially send out connection checking messages. |
| &#160;&#160;[ConnectionCheckingMaxIdleTime](xref:MaintenanceSettings.Replication.ConnectionCheckingMaxIdleTime) | [0, 1] | Specifies the number of seconds that the replication connection must be idle before a connection checking message can be sent. |
| &#160;&#160;[ConnectionMinDelayBeforeRetry](xref:MaintenanceSettings.Replication.ConnectionMinDelayBeforeRetry) | [0, 1] | When a DataMiner Agent fails to set up a connection to another DataMiner Agent for replication purposes, further attempts to set up a connection are blocked during a fixed time interval (in seconds). |
| &#160;&#160;[ConnectionRetryInterval](xref:MaintenanceSettings.Replication.ConnectionRetryInterval) | [0, 1] | Specifies the connection retry interval (in seconds). |
| &#160;&#160;[ConnectionTimeoutTime](xref:MaintenanceSettings.Replication.ConnectionTimeoutTime) | [0, 1] | Specifies the connection timeout time (in seconds). |
| &#160;&#160;[HttpExpect100Continue](xref:MaintenanceSettings.Replication.HttpExpect100Continue) | [0, 1] | Specifies whether to await a non-final "100 Continue" response from the destination before actually sending data. |
| &#160;&#160;[UseZipping](xref:MaintenanceSettings.Replication.UseZipping) | [0, 1] | Specifies whether messages on the connection need to be zipped. |
