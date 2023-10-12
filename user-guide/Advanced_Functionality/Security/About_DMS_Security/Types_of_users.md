---
uid: Types_of_users
---

# Types of users

DataMiner distinguishes the following types of users:

- [Local users](#local-users)

- [Manually added domain users](#manually-added-domain-users)

- [Automatically added domain users](#automatically-added-domain-users)

- [dataminer.services users](#dataminerservices-users)

## Local users

These are proprietary users, only known to the local operating system of the DataMiner Agents.

These users are entirely managed by DataMiner.

This type of user will mostly be used in situations where the DMAs have not been added to a domain.

![Local users](~/user-guide/images/Security_local_users.png)<br>
*Local users in DataMiner 10.3.6*

## Manually added domain users

These are domain users of which the username and the password are managed by the domain, while all other properties (e.g. telephone number, email address, etc.) are managed by DataMiner.

This type of user will mostly be used in situations where the DMAs have been added to a domain on which the DataMiner administrators do not have permission to change domain group memberships or update domain user properties (phone numbers, email addresses, etc.).

![Manually added domain users](~/user-guide/images/Security_manually_added_domain_users.png)<br>
*Manually added domain users in DataMiner 10.3.6*

## Automatically added domain users

These are domain users that have been automatically added when a domain group was added to DataMiner.

These users are entirely managed by the domain.

This type of user will mostly be used in situations where the DMAs have been added to a domain on which the DataMiner administrators have permission to change domain group memberships and update domain user properties (phone numbers, email addresses, etc.).

![Automatically added domain users](~/user-guide/images/Security_automatically_added_domain_users.png)<br>
*Automatically added domain users in DataMiner 10.3.6*

> [!NOTE]
>
> - When a [domain group is added](xref:Adding_a_user_group) to DataMiner, the email address, the mobile number and the pager number of existing, manually added domain users will be overruled by their counterparts on domain level.
> - When a [domain group is deleted](xref:Deleting_a_user_group) from DataMiner, all users within that domain group will be deleted from DataMiner as well, even if they are a member of one or more proprietary DataMiner groups. If, however, they are a member of one or more other domain groups, they will not be deleted.

## dataminer.services users

These users are automatically added when content is shared via dataminer.services. They only have the permissions needed to view the shared content. They are entirely managed by DataMiner, which means that you cannot modify them on the *Users/Groups* page.

![dataminer.services users](~/user-guide/images/Security_cloud_users.png)<br>
*dataminer.services users in DataMiner 10.3.6*

> [!TIP]
> See also:
>
> - [DataMiner Sharing](xref:Sharing#dataminer-sharing)
> - [Cloud connectivity and security](xref:Cloud_connectivity_and_security)
