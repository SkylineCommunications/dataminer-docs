---
uid: Adding_a_user
---

# Adding a user

There are two ways to add a new user to a DataMiner System, depending on whether it is a [local user](xref:Types_of_users#local-users) or a [domain user](xref:Types_of_users#manually-added-domain-users).

## Adding a local user

1. In the *Users / Groups* section of the System Center module, go to the *users* tab.

1. At the bottom of the list of users, click *Add new user*.

1. In the *Add new user* window, add the user’s information:

   - You must fill in at least the fields *Name*, *Password* and *Confirm password* in order to be able to continue.

     > [!NOTE]
     >
     > - User names cannot start or end with a backslash “\\” character. They may also not contain more than one percentage “%” character.
     > - The maximum length of a user name is 20 characters.
     > - User name validation is not case sensitive. This means that if, for instance, a user named “John” has already been added, it will not be possible to add another user named “john” or “JOHN”.

   - The *Telephone* field must be filled in for the user to be able to receive text messages.

     > [!NOTE]
     > It is advisable to always add telephone numbers in international format (starting with a “+” sign).

   - The *Email* must be filled in for the user to be able to receive email notifications or automated email messages.

   - The *Level* field determines the user’s security level, in case this is different from the user’s group security level. Access levels range from 1 (highest level) to 100 (lowest level).

   - To force the user to change the password the next time they log on to the DMS, select *User must change password at next login*.

   - If you want to prevent the password from being changed, select *User cannot change password*.

   - To ensure that the password does not expire, select *Password never expires*.

1. If you want to add another user, click *Add another*. Otherwise, click *Add*.

   The new users will be added to the list of *Local* users.

## Adding an existing domain user

1. In the *Users / Groups* section of the System Center module, go to the *users* tab.

1. At the bottom of the list of users, click *Add existing user*.

1. In the *Add existing user* window, select the user(s) you want to add and click *OK*.

   The new users will be added to the list of *Domain* users.

> [!NOTE]
> Domain users can also be added automatically, in case they get added to a domain group that has been added to the DMS. See [Adding a user group](xref:Adding_a_user_group).
