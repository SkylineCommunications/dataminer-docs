---
uid: DataMiner.LDAP
---

# LDAP element

Contains the LDAP configuration.

See [Configuring LDAP settings](xref:Configuring_LDAP_settings).

## Parents

[DataMiner](xref:DataMiner)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [auth](xref:DataMiner.LDAP-auth) | string |  | The authentication method to access the LDAP server. |
| [host](xref:DataMiner.LDAP-host) | string |  | The name or IP address of the LDAP server.<br>Alternatively, the hostname can be specified in the [namingContext](xref:DataMiner.LDAP-namingContext) attribute, in which case it should precede the actual naming context data and be separated from it by a forward slash. |
| [namingContext](xref:DataMiner.LDAP-namingContext) | string |  | A suffix that identifies the top entry of the LDAP hierarchy.<br>If no naming context is specified when Active Directory is used, it will be auto-discovered.<br>When OpenLDAP is used, a naming context must be specified. |
| [nonDomainLDAP](xref:DataMiner.LDAP-nonDomainLDAP) | string |  | Should be set to "true" to make sure that DataMiner Agents that are not connected to a domain can use Active Directory or OpenLDAP.<br>If this is specified on a DataMiner Agent that is in a domain, this attribute is not used. |
| [notifications](xref:DataMiner.LDAP-notifications) | boolean |  | When Active Directory is used, by default, DataMiner also automatically receives updates whenever changes occur in the domain.<br>Set this attribute to "false" to disable these automatic updates. |
| [password](xref:DataMiner.LDAP-password) | string |  | The password to connect to the LDAP server, in case it requires authentication. |
| [port](xref:DataMiner.LDAP-port) | int |  | The port to connect to the LDAP server. |
| [referralConfigured](xref:DataMiner.LDAP-referralConfigured) | boolean |  | If referrals are not configured, this attribute should be set to "false" in order to make a connection with the other Domain Controller and query it directly.<br>See [Remarks regarding LDAP settings](xref:Configuring_LDAP_settings#remarks-regarding-ldap-settings). |
| [useForFullName](xref:DataMiner.LDAP-useForFullName) | boolean |  | Determines whether the full user names will be retrieved by means of LDAP ("true") or NetAPI ("false"). |
| [username](xref:DataMiner.LDAP-username) | string |  | The user name to connect to the LDAP server, in case it requires authentication. |
| [useSSL](xref:DataMiner.LDAP-useSSL) | boolean |  | To connect to the LDAP server with SSL, set this attribute to "true". |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[Group](xref:DataMiner.LDAP.Group) | [0, 1] | Configures a group. |
| &#160;&#160;[QueryTimeout](xref:DataMiner.LDAP.QueryTimeout) | [0, 1] | Specifies the number of seconds after which an individual LDAP request will time out.<br>Default: 300. |
| &#160;&#160;[User](xref:DataMiner.LDAP.User) | [0, 1] | Configures a user. |
