---
uid: User_management
---

# User management

## User directories

DataMiner supports the following types of directories for user management:

- [Active Directory](xref:Adding_a_user#adding-an-existing-domain-user) (default)
- [Azure Active Directory](xref:Setting_up_Azure_Active_Directory_Domain_Services)
- [Atlassian Crowd](xref:Configuring_Atlassian_Crowd_settings)
- [LDAP-compatible directories](xref:Configuring_LDAP_settings) (e.g., OpenLDAP)

By default, DataMiner will import users from its local Active Directory.

> [!NOTE]
> Importing users via these methods does not necessarily allow these users to sign in. See [User authentication](#user-authentication).

## Local users

Apart from directory users, DataMiner also has a notion of local users, i.e., users created within the DataMiner System. Behind the scenes, when a new local user is created, DataMiner will create a new Windows user. Local users are completely managed by the Windows Server hosting your DataMiner System. This means Windows is responsible for password storage, complexity, and audit trail requirements.

For more information see [Types of users](xref:Types_of_users).

## Default Users

DataMiner has one built-in user, named "Administrator". This user is also the local administrator on the Windows server hosting DataMiner. This user is intended for recovery and initial configuration purposes. We highly recommend that you avoid using this account for routine and day-to-day operations and securely manage access to this account, for example via LAPS.

> [!NOTE]
> If you use self-managed storage nodes instead of the recommended [Storage as a Service](xref:STaaS), you will need to make sure that the default users of the DataMiner **databases** are also secured. For more information, see [Securing self-managed DataMiner storage](xref:Cassandra_authentication).

## User authentication

To actually sign in users in DataMiner, several authentication methods are supported:

- [SSPI](https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-r2-and-2008/dn169026(v=ws.10)) (default)
- [SAML](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML) (Entra ID, Okta, etc.)
- [RADIUS](xref:Configuring_RADIUS_settings)

## Multifactor Authentication (MFA)

Both RADIUS and SAML authentication have support for enabling multifactor authentication on your DataMiner System.

## Groups and permissions

Once your users are imported into the DataMiner System, it is possible to assign them to a group. All permissions are configured on group level. See [DataMiner user permissions](xref:DataMiner_user_permissions) for more information about the different permissions.

> [!TIP]
> See also:
>
> - [User rights](xref:User_rights)
> - [User groups](xref:User_groups)
