---
uid: Managing_predefined_sets_of_credentials_for_SNMP_authentication
keywords: authentication, auth, SNMP credentials
---

# Managing predefined sets of credentials for SNMP authentication

In the DataMiner Cube Credentials Library, you can add and manage sets of predefined credentials. These credentials can then for example be selected when SNMP elements are created or edited, so that credentials do not need to be specified manually.

In System Center, go to *System settings* > *Credentials library*. You can then:

- Add credentials with the *Add credentials* button.

- Delete credentials by selecting them in the list and clicking the *Delete* button.

- Edit credentials by selecting them in the list and specifying the necessary information in the pane on the right:

  - Each set of credentials must have a unique name, specified in the *Name* box at the top.

  - Each set of credentials must have a specific type assigned. The following types of credentials are available, and can be selected in the *Type* dropdown box:

    - Community credentials

    - SNMPv3 credentials

    - Username and password credentials (available from DataMiner 10.3.11 onwards<!-- RN 37416 -->)

    - For each set of credentials, the user groups that can use them must be specified. To do so, add or remove the relevant groups in the *Included in groups* box using the *ADD \>\>* and *\<\< REMOVE* buttons.

When you have applied changes to a set of credentials, do not forget to click the *Apply* button in the lower-right corner to save the changes.

> [!NOTE]
>
> - Credentials are synchronized throughout the DMS.
> - If a set of credentials is deleted or edited while it is in use by an active element, that element will be restarted automatically.
> - For credentials that include a password (e.g. SNMPv3 credentials), the password can be up to 43 characters long. From DataMiner 10.4.0 [CU18]/10.5.0 [CU6]/10.5.9 onwards<!--RN 43422-->, credentials of type *Username and password* allow passwords of any length.
