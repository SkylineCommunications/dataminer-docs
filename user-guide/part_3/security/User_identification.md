## User identification

Users have to identify themselves by means of

- a unique username, and

- a password.

    > [!NOTE]
    > To avoid login problems, the password policy for all servers within a DataMiner System must be the same. 

DataMiner supports two methods for user identification:

- **Autonomous User Identification**: Users are defined in the DataMiner System itself by a DMS Administrator.

- **Domain**: Users are defined in the corporate network domain and are transparently integrated into the DMS after the latter is added to the domain.

i

> [!NOTE]
> -  When the DataMiner System is configured to integrate domain users, the DataMiner client applications will automatically log on to the DMS with the user’s current Windows user account.
> -  DMS Security is tightly integrated with Microsoft Windows security. Even when the DMS uses Autonomous User Identification, the users you create in DataMiner will automatically be created in the Windows operating system. This means that users who are authorized to access the DMS will automatically be allowed to access the DMS via the Windows operating system.

> [!TIP]
> See also:
> [Adding a user](Adding_a_user.md)
