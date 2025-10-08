---
uid: Configuring_RADIUS_settings
---

# Configuring RADIUS settings

DataMiner users can be authenticated using a RADIUS server. However, note that this is no longer recommended (see [Software support lifecycles](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)).

If a RADIUS server has been configured, the DataMiner Agent acts as a RADIUS client and passes the user credentials along to the RADIUS server, which will then authenticate the user. DataMiner also supports RADIUS challenges (see below).

To configure a RADIUS server:

1. Go to the folder `C:\Skyline DataMiner` and open the - file.

1. In *DataMiner.xml*, configure the [ExternalAuthentication](xref:DataMiner.ExternalAuthentication) tag as illustrated in the example below:

   ```xml
   <DataMiner>
     <ExternalAuthentication type="RADIUS"
       host="IP address of RADIUS server" port="IP port of RADIUS server"
       sharedSecret="RADIUS server shared secret" />
   </DataMiner>
   ```

1. Save and close the file, and restart the DMA.

1. Import the RADIUS users in DataMiner via LDAP. See [Configuring LDAP settings](xref:Configuring_LDAP_settings).

When you have configured a RADIUS server:

- All users will be authenticated through that RADIUS server.

- The RADIUS server will respond to each logon attempt with an Accept, Reject, or Challenge response. In case of a Challenge response, additional user input must be sent in order to complete the authentication.
