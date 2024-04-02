---
uid: Configuring_RADIUS_settings
---

# Configuring RADIUS settings

DataMiner users can be authenticated using a RADIUS server.

If a RADIUS server has been configured, the DataMiner Agent acts as a RADIUS client and passes the user credentials along to the RADIUS server, which will then authenticate the user. DataMiner also supports RADIUS challenges (see below).

In the file *DataMiner.xml*, a RADIUS server can be configured in the following way.

```xml
<DataMiner>
  <ExternalAuthentication type="RADIUS"
    host="IP address of RADIUS server" port="IP port of RADIUS server"
    sharedSecret="RADIUS server shared secret" />
</DataMiner>
```

When you have configured a RADIUS server:

- All users will be authenticated through that RADIUS server.

- The RADIUS server will respond to each logon attempt with an Accept, Reject or Challenge response. In case of a Challenge response, additional user input must be sent in order to complete the authentication.

> [!IMPORTANT]
> RADIUS users first need to be imported via LDAP. See [Configuring LDAP settings](xref:Configuring_LDAP_settings) on how to do this.
>
