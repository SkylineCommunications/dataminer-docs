---
uid: Types_of_users
---

# Types of users

DataMiner distinguishes the following types of users:

- **Local users**: Proprietary users, only known to the local operating system of the DataMiner Agents.

  These users are entirely managed by DataMiner.

  > [!NOTE]
  > This type of user will mostly be used in situations where the DMAs have not been added to a domain.

- **Manually added domain users**: Domain users of which the username and the password are managed by the domain, while all other properties (e.g. telephone number, email address, etc.) are managed by DataMiner.

  > [!NOTE]
  > This type of user will mostly be used in situations where the DMAs have been added to a domain on which the DataMiner administrators do not have permission to change domain group memberships or update domain user properties (phone numbers, email addresses, etc.).

- **Automatically added domain users**: Domain users added automatically as a result of adding a domain group to DataMiner.

  These users are entirely managed by the domain.

  > [!NOTE]
  > This type of user will mostly be used in situations where the DMAs have been added to a domain on which the DataMiner administrators have permission to change domain group memberships and update domain user properties (phone numbers, email addresses, etc.).

- **dataminer.services users**: These users are automatically added when content is shared via dataminer.services. They only have the permissions needed to view the shared content. They are entirely managed by DataMiner, which means that you cannot modify them in the Users/Groups module.

  > [!TIP]
  > See also:
  >
  > - [DataMiner Sharing](xref:Sharing#dataminer-sharing)
  > - [Cloud connectivity and security](xref:Cloud_connectivity_and_security)

> [!NOTE]
>
> - When a domain group is added to DataMiner, the email address, the mobile number and the pager number of existing, manually added domain users will be overruled by their counterparts on domain level.
> - When a domain group is deleted from DataMiner, all users within that domain group will be deleted from DataMiner as well, even if they are a member of one or more proprietary DataMiner groups. If, however, they are a member of one or more other domain groups, they will not be deleted.
