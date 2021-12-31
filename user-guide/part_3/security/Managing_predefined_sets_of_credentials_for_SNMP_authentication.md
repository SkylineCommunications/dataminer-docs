## Managing predefined sets of credentials for SNMP authentication

From DataMiner 9.5.5 onwards, sets of predefined credentials can be added and managed within DataMiner Cube. These credentials can then be selected when SNMP elements are created or edited, so that credentials do not need to be specified manually.

In System Center, go to *System settings* > *Credentials library*. You can then:

- Add credentials with the *Add credentials* button.

- Delete credentials by selecting them in the list and clicking the *Delete* button.

- Edit credentials by selecting them in the list and specifying the necessary information in the pane on the right:

    - Each set of credentials must have a unique name, specified in the *Name* box at the top.

    - Each set of credentials must have a specific type assigned. The following types of credentials are available, and can be selected in the *Type* drop-down box:

        - Community credentials

        - SNMPv3 credentials

        > [!NOTE]
        > Prior to DataMiner 9.5.13, you can also select the *Password* or *Username and password* type of credentials. However, these are not used in Cube.

    - For each set of credentials, the user groups that can use them must be specified. To do so, add or remove the relevant groups in the *Included in groups* box using the *ADD \>\>* and *\<\< REMOVE* buttons.

When you have applied changes to a set of credentials, do not forget to click the *Apply* button in the lower right corner to save the changes.

> [!NOTE]
> -  Credentials are synchronized throughout the DMS.
> -  If a set of credentials is deleted or edited while it is in use by an active element, that element will be restarted automatically.
>
