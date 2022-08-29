---
uid: Configuring_Atlassian_Crowd_settings
---

# Configuring Atlassian Crowd settings

DataMiner can import users and groups from an Atlassian Crowd server and can also rely on this type of server for user authentication.

This section contains the following information on Atlassian Crowd settings:

- [Importing users and groups from a Crowd server into DataMiner](#importing-users-and-groups-from-a-crowd-server-into-dataminer)

- [Authenticating DataMiner users against an Atlassian Crowd server](#authenticating-dataminer-users-against-an-atlassian-crowd-server)

## Importing users and groups from a Crowd server into DataMiner

DataMiner can import users and groups from an Atlassian Crowd server.

In the file *DataMiner.xml*, enter a *\<Crowd>* tag like the one in the example below.

```xml
<DataMiner>
  <Crowd host="myDma" application="dataminer" password="…"/>
</DataMiner>
```

In the Atlassian Crowd server, make sure there is an application named “dataminer” (as specified in the *DataMiner.xml* file), that it can be accessed using the password specified in the *DataMiner.xml* file, and that it contains the necessary users and user groups. Also make sure to add the IP address of the DataMiner Agent to the list of remote addresses.

## Authenticating DataMiner users against an Atlassian Crowd server

DataMiner users can be authenticated against an Atlassian Crowd server.

To configure this, open the *DataMiner.xml* file, add an *\<ExternalAuthentication>* tag as shown in the example below, and restart the DataMiner Agent. Users added to the Crowd server and imported into DataMiner should then be able to log on.

```xml
<DataMiner>
  <ExternalAuthentication type="CROWD"
    host="hostname" port="port"
    username="application_name" password="application_password">
  </ExternalAuthentication>
</DataMiner>
```

> [!NOTE]
> DataMiner Cube also supports domain-specific single sign-on (SSO) using third-party authentication via an Atlassian Crowd server.
>
> In case Crowd single sign-on is used, as soon as the DataMiner Agent receives the SSO configuration from the Crowd server it authenticates against, it will pass this configuration on to the DataMiner Cube client in the form of a cookie.

### autoproxy setting

When configuring an Atlassian Crowd server in *DataMiner.xml*, you can use the autoproxy setting to override automatic detection of proxy server settings.

By default, the SLDataMiner process will attempt to automatically detect the proxy server settings.

Example:

```xml
<DataMiner>
  <ExternalAuthentication type="CROWD"
    host="hostname" port="port"
    username="application_name" password="application_password"
    autoproxy="false">
  </ExternalAuthentication>
</DataMiner>
```
