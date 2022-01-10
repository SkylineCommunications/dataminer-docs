## Configuring LDAP settings

DataMiner supports any LDAP compatible directory (e.g. OpenLDAP) as an alternative to Active Directory for importing users and groups into a DMA.

This section contains the following information on the configuration of LDAP settings:

- [Configuring LDAP settings in DataMiner Cube](#configuring-ldap-settings-in-dataminer-cube)

- [LDAP section in DataMiner.xml](#ldap-section-in-dataminerxml)

- [Remarks regarding LDAP settings](#remarks-regarding-ldap-settings)

- [Automatic refresh of group membership and user information](#automatic-refresh-of-group-membership-and-user-information)

### Configuring LDAP settings in DataMiner Cube

From DataMiner 9.5.5 onwards, most custom LDAP settings can be configured in DataMiner Cube.

To do so:

1. Go to *System Center* > *System settings* > *LDAP*.

2. Select the checkbox *Use custom configuration.*

3. Configure the following settings as required to connect to the LDAP server:

    In the *general* tab:

    | Setting                              | Description                                                                                                                                                                                                                                                                                                                                                             |
    |----------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Host                                   | The name or IP of the LDAP server.                                                                                                                                                                                                                                                                                                                                      |
    | Port                                   | The port to connect to the LDAP server.                                                                                                                                                                                                                                                                                                                                 |
    | Authentication type                    | The authentication method to access the LDAP server. The following authentication types are available: *Anonymous*, *Max*, *Member System*, *Password*, *SASL*, and *Simple*. |
    | Naming context                         | A suffix that identifies the top entry of the LDAP hierarchy.                                                                                                                                                                                                                                                                                                           |
    | Use fully qualified domain name (FQDN) | When selected, the full user names will be retrieved by means of LDAP. Otherwise, full user names will be retrieved by means of NetAPI instead.                                                                                                                                                                                                                         |
    | User name                              | The user name to connect to the LDAP server, if necessary.                                                                                                                                                                                                                                                                                                              |
    | Password                               | The password to connect to the LDAP server, if necessary.                                                                                                                                                                                                                                                                                                               |

    In the *User* tab:

    | Setting    | Description                                                                                                 |
    |--------------|-------------------------------------------------------------------------------------------------------------|
    | Class name   | The object class(es) that identify users.<br> Multiple values can be separated with pipe characters (“\|”). |
    | Account name | The user’s account name.                                                                                    |
    | Display name | The user name that will be displayed.                                                                       |
    | Description  | The user’s description.                                                                                     |
    | Email        | The user’s email address.                                                                                   |
    | Phone        | The user’s fixed phone number.                                                                              |
    | Mobile       | The user’s mobile phone number.                                                                             |
    | Pager        | The user’s pager number.                                                                                    |
    | Filter       | The LDAP search filter to find all users.<br> Note that in XML ampersands must be encoded as “&amp;”.       |

    In the *Group* tab:

    | Setting   | Description                                                                                                  |
    |-------------|--------------------------------------------------------------------------------------------------------------|
    | Class name  | The object class(es) that identify groups.<br> Multiple values can be separated with pipe characters (“\|”). |
    | Name        | The name of the group.                                                                                       |
    | Alias       | The alias of the group.                                                                                      |
    | Description | The description of the group.                                                                                |
    | Filter      | The LDAP search filter to find all groups.<br> Note that in XML ampersands must be encoded as “&amp;”.       |

    > [!NOTE]
    > If a setting is left empty, the default setting will be applied.

4. Click the *Apply* button in the lower right corner.

### LDAP section in DataMiner.xml

To establish a link between a DMA and an LDAP other than Active Directory, open the *DataMiner.xml* file and add or modify the *\<LDAP>* tag (which should contain all necessary LDAP server settings).

> [!NOTE]
> To apply the changes in *DataMiner.xml* in DataMiner, the DMA needs to be restarted. As such, from DataMiner 9.5.5 onwards, it is best to configure these settings in DataMiner Cube instead. See [Configuring LDAP settings in DataMiner Cube](#configuring-ldap-settings-in-dataminer-cube).

> [!TIP]
> See also:
> [DataMiner.xml](../../part_7/SkylineDataminerFolder/DataMiner_xml.md#dataminerxml)

#### OpenLDAP

The following example shows how Global Telecom Company (“GTC”) has configured the LDAP tag for OpenLDAP:

```xml
<LDAP nonDomainLDAP="true" host="10.0.0.207"
    username="" password="" auth=""
    namingContext="DC=gtc,DC=local" useForFullName="true">
  <Group>
    <Filter>(objectClass=groupOfNames)</Filter>
    <Classname>groupOfNames|posixGroup</Classname>
    <NameField>cn</NameField>
    <DescriptionField>description</DescriptionField>
  </Group>
  <User>
    <Filter>(objectClass=inetOrgPerson)</Filter>
    <Classname>inetOrgPerson|person</Classname>
    <AccountNameField>uid</AccountNameField>
    <DisplayNameField>displayName</DisplayNameField>
    <DescriptionField>title</DescriptionField>
    <EmailField>mail</EmailField>
    <PhoneField>homePhone</PhoneField>
    <PagerField>pager</PagerField>
  </User>
</LDAP>
```

#### Active Directory

The following example shows how Global Telecom Company (“GTC”) has configured the LDAP tag for Active Directory:

```xml
<LDAP nonDomainLDAP="true" host="dc.gtc.be"
    port="389" username="" password="" auth=""
    namingContext="DC=gtc,DC=local" useForFullName="true">
  <Group>
    <Filter>(&amp;(objectClass=group)
    (groupType:1.2.840.113556.1.4.803:=2147483648))</Filter>
    <Classname>group|foreignSecurityPrincipal</Classname>
    <NameField>name</NameField>
    <DescriptionField>description</DescriptionField>
  </Group>
  <User>
    <Filter>(|(&amp;(objectCategory=person)(objectClass=user)(objectSid=*)
    (!samAccountType:1.2.840.113556.1.4.804:=3))
    (&amp;(objectCategory=person)(objectClass=user)(!objectSid=*)))</Filter>
    <Classname>person</Classname>
    <AccountNameField>sAMAccountName</AccountNameField>
    <DisplayNameField>name</DisplayNameField>
    <DescriptionField>description</DescriptionField>
    <EmailField>mail</EmailField>
    <PhoneField>telephoneNumber</PhoneField>
    <PagerField>pager</PagerField>
  </User>
</LDAP>
```

> [!NOTE]
> Normally, when using Active Directory, you do not have to add an \<LDAP> tag. However, if you have to specify non-default settings (e.g. when you want to link to a secondary domain controller), add an \<LDAP> tag and specify all necessary settings.

### Remarks regarding LDAP settings

- If no naming context is specified, in case of Active Directory, it will be auto-discovered. When OpenLDAP is used, a naming context should be specified. In *DataMiner.xml*, this is done using the *namingContext* attribute.

- In *DataMiner.xml*, the hostname can be specified either in the host attribute of the *\<LDAP>* tag or in the *namingContext* attribute of that same tag.

    If you specify it in the *namingContext* attribute, be sure to put it in front of the actual naming context data, separated by means of a forward slash.     Examples:

    ```xml
    <LDAP host="dc.gtc.local" namingContext="dc=GTC,dc=local">
    ```

    ```xml
    <LDAP namingContext="dc.gtc.local/dc=GTC,dc=local">
    ```

- If the LDAP server requires authentication, enter both the user name and the password, and set the authentication type to “simple” (using the *auth* attribute in *DataMiner.xml*).

- The *\<Filter>* tags contain the LDAP search filters to find all groups and users. Note that in XML ampersands must be encoded as “&”.

- The *\<Classname>* tags indicate the object class(es) that identify groups and users. Multiple values can be separated with pipe characters (“\|”).

- If you set the *useForFullName* attribute to “true” (i.e. the default setting), the full usernames will be retrieved by means of LDAP. If you set this attribute to “false”, full usernames will be retrieved by means of NetAPI instead. This attribute corresponds to the *Use fully qualified domain name (FQDN)* setting in Cube.

- DataMiner can only connect to one LDAP server, so only one LDAP tag can be specified.

- When a user group in the DataMiner domain contains users from another domain, by default, referrals are used to retrieve these users. This means that when information is asked from the DataMiner domain about a different domain, the request is automatically forwarded. However, if referrals are not configured, this will not work, so that it can appear that a domain group does not contain any users. In that case, the attribute *referralConfigured="false"* should be added to the LDAP tag in *DataMiner.xml*, so that a connection is made with the other Domain Controller and the latter is queried directly.

    ```xml
    <LDAP referralConfigured="false" />
    ```

- To connect to the LDAP server with SSL, from DataMiner 9.5.6 onwards, specify the attribute *useSSL=true* in the LDAP tag. The password is encrypted after the first usage. (Default SSL port: 636.)

- From DataMiner 10.0.6 onwards, an individual LDAP query will time out after 5 minutes. This timeout interval can be customized in the *\<QueryTimeout>* subtag of the *\<LDAP>* tag.

    ```xml
    <DataMiner>
      <LDAP>
        <QueryTimeout>300</QueryTimeout>
      </LDAP>
    </DataMiner>
    ```

    > [!NOTE]
    > This timeout applies to every individual LDAP query. As a result, a request to refresh all groups (which consists of multiple requests) could have a total timeout that is much larger than the configured value.

### Automatic refresh of group membership and user information

When using Active Directory, group and user data are refreshed automatically. However, for versions of DataMiner prior to DataMiner 7.5, if you are using an LDAP-compatible directory other than Active Directory and you want to have group and user data refreshed automatically, you should create a scheduled task that executes a JavaScript file containing the following code:

```txt
var localDMS = new ActiveXObject("SLDMS.DMS");
var localReturn;
localDMS.Notify(92 /*DMS_REFRESH_LDAP*/, 0, "", "", localReturn);
```

> [!NOTE]
> -  The frequency with which the scheduled task should be executed depends on the number of users and groups in your domain. You could e.g. set the task to be executed once a day.
> -  From DataMiner 7.5 onwards, an automatic hourly refresh has been implemented, so it is no longer necessary to create this scheduled task.
> -  From DataMiner 9.5.0/9.0.3 onwards, when Active Directory is used, by default DataMiner automatically receives updates whenever changes occur in the domain. You can disable this by setting the *notifications* attribute of the LDAP tag to false (*\<LDAP notifications="false" />*) in the *DataMiner.xml* file.
> -  From DataMiner 10.1.9/10.2.0 onwards, LDAP notification behavior is disabled by default, and instead the LDAP system is polled on an hourly basis. Set the *notifications* attribute of the LDAP tag to true to enable this behavior again.
>
