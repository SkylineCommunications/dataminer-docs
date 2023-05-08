---
uid: Configuring_LDAP_settings
---

# Configuring LDAP settings

DataMiner supports any LDAP-compatible directory (e.g. OpenLDAP) as an alternative to Active Directory for importing users and groups into a DMA.

> [!TIP]
> See also: [Lightweight Directory Access Protocol](https://docs.microsoft.com/en-us/previous-versions/windows/desktop/ldap/lightweight-directory-access-protocol-ldap-api)

## Configuring LDAP settings in DataMiner Cube

From DataMiner 9.5.5 onwards, most custom LDAP settings can be configured in DataMiner Cube.

To do so:

1. Go to *System Center* > *System settings* > *LDAP*.

1. In DataMiner versions prior to DataMiner 10.1.0 [CU11]/10.2.2, select the checkbox *Use custom configuration*.

1. Configure the following settings as required to connect to the LDAP server:

   In the *general* tab:

   - **Host**: The name or IP of the LDAP server.
   - **Port**: The port to connect to the LDAP server.
   - **Authentication type**: The authentication method to access the LDAP server. The following authentication types are supported: *Anonymous* and *Simple*.
   - **Naming context**: A suffix that identifies the top entry of the LDAP hierarchy.
   - **Non-domain LDAP**: Available from DataMiner 10.2.0 [CU16]/10.3.0 [CU4]/10.3.6<!--  RN 35782 -->. An LDAP server that is not Windows Active Directory. This will be used to determine if DataMiner can subscribe to change notifications of the LDAP server, a feature that is only supported by Active Directory. DataMiner will only sync changes with a non-domain LDAP server through the *ReloadLDAP.js* script, which runs on an hourly basis through the *Skyline DataMiner LDAP Resync* scheduled task in Windows.
   - **Referral configured**: Available from DataMiner 10.1.0 [CU11]/10.2.2 onwards. To use referrals to retrieve users from another domain in case these are part of a user group in the DataMiner domain, select this option. This means that when information is asked from the DataMiner domain about a different domain, the request is automatically forwarded. If you do not select this option, instead a connection is made with the other Domain Controller and the latter is queried directly.
   - **SSL/TLS**: Available from DataMiner 10.1.0 [CU11]/10.2.2 onwards. Select this option if you want DataMiner to use SSL/TLS when connecting to the LDAP server. When using SSL/TLS, make sure that the name or IP configured in **Host** matches the **Common Name** or an entry from the **Subject Alternative Names** in the certificate presented by the LDAP server.
   - **Use fully qualified domain name (FQDN)**: When this option is selected, the full user names will be retrieved by means of LDAP. Otherwise, full user names will be retrieved by means of NetAPI instead.
   - **User name**: The user name to connect to the LDAP server, if necessary.
   - **Password**: The password to connect to the LDAP server, if necessary.

   In the *User* tab:

   - **Class name**: The object class(es) that identify users. Multiple values can be separated with pipe characters (“\|”).
   - **Account name**: The user’s account name.
   - **Display name**: The user name that will be displayed.
   - **Description**: The user’s description.
   - **Email**: The user’s email address.
   - **Phone**: The user’s fixed phone number.
   - **Mobile**: The user’s mobile phone number.
   - **Pager**: The user’s pager number.
   - **Filter**: The LDAP search filter to find all users. Note that in XML ampersands must be encoded as “&amp;”.

   In the *Group* tab:

   - **Class name**: The object class(es) that identify groups. Multiple values can be separated with pipe characters (“\|”).
   - **Name**: The name of the group.
   - **Alias**: The alias of the group.
   - **Description**: The description of the group.
   - **Filter**: The LDAP search filter to find all groups. Note that in XML ampersands must be encoded as “&amp;”.

   > [!NOTE]
   >
   > - If a setting is left empty, the default setting will be applied.
   > - If you change any of these settings, this change will only be applied to the DataMiner Agent you are connected to. The change is not synced with the rest of the cluster.

1. Click the *Apply* button in the lower right corner.

## LDAP section in DataMiner.xml

To establish a link between a DMA and an LDAP other than Active Directory, open the *DataMiner.xml* file and add or modify the *\<LDAP>* tag (which should contain all necessary LDAP server settings).

> [!NOTE]
> To apply the changes in *DataMiner.xml* in DataMiner, the DMA needs to be restarted. As such, from DataMiner 9.5.5 onwards, it is best to configure these settings in DataMiner Cube instead. See [Configuring LDAP settings in DataMiner Cube](#configuring-ldap-settings-in-dataminer-cube).

> [!TIP]
> See also: [DataMiner.xml](xref:DataMiner_xml#dataminerxml)

### OpenLDAP

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

### Active Directory

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

## Remarks regarding LDAP settings

- If no naming context is specified, in case of Active Directory, it will be auto-discovered. When OpenLDAP is used, a naming context should be specified. In *DataMiner.xml*, this is done using the *namingContext* attribute.

- In *DataMiner.xml*, the hostname can be specified either in the host attribute of the *\<LDAP>* tag or in the *namingContext* attribute of that same tag.

  If you specify it in the *namingContext* attribute, be sure to put it in front of the actual naming context data, separated by means of a forward slash.

  Examples:

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

## Automatic updates of group membership and user information

Prior to DataMiner DataMiner 10.1.9/10.2.0, when Active Directory is used, DataMiner automatically receives updates to group and user data whenever changes occur in the domain. You can disable this by setting the *notifications* attribute of the LDAP tag to false (*\<LDAP notifications="false" />*) in the *DataMiner.xml* file.

From DataMiner 10.1.9/10.2.0 onwards, LDAP notification behavior is disabled by default. Instead, the LDAP system is polled on an hourly basis. Set the *notifications* attribute of the LDAP tag to "true" to enable this behavior again.

## Active Directory Forest with multiple domains

When you have an Active Directory Forest with multiple domains, you need to create a custom configuration.

In Active Directory, do the following:

- Use universal security groups.

  > [!IMPORTANT]
  > If you do not use universal security groups, DataMiner will only have access to the users that are in the same domain as the DataMiner agent.

- Specify the necessary trusts between the different domains.

  > [!IMPORTANT]
  > If you do not specify trusts between domains, users from one domain will not be able to log in to another domain. 

  > [!NOTE]
  > Parent-child trusts are created automatically.

In DataMiner, do the following:

- Set the naming context to the top entry of the forest hierarchy.

  > [!IMPORTANT]
  > Directory traversal happens top to bottom. If you start somewhere else, any parent or sibling domains will not be included.

- Query the Global Catalog on port 3268.

  > [!IMPORTANT]
  > Querying the Global Catalog is required to get information from other domains than the one you are querying against.

- Use a user account that has permission to query the top entry of the forest hierarchy.

  > [!IMPORTANT]
  > Directory traversal happens top to bottom. If you do not have access to query against the top level of the forest, any parent or sibling domains of the child domain you are querying against will not be included.

> [!IMPORTANT]
> When adding existing groups in DataMiner, all domain groups will appear to be in the same domain as the DataMiner agent. However, this is only a visualization issue. Functionality is not affected.
