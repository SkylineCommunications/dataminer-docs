---
uid: Running_Cassandra_as_non-SYSTEM_user
---

# Running Cassandra as a non-SYSTEM user (Windows)

By default, DataMiner will run the Cassandra service with SYSTEM privileges. To reduce the impact of a breach through the Cassandra service, we recommend running Cassandra as a restricted user.

> [!TIP]
>
> - A PowerShell script is available to modify the Cassandra service user. You can download this *Modify-CassandraServiceUser* Powershell script from [GitHub](https://github.com/SkylineCommunications/Modify-CassandraServiceUser).
> - If you do not want the hassle of maintaining the DataMiner storage databases yourself, we recommend using [DataMiner Storage as a Service](xref:STaaS) instead.

To run Cassandra as a non-SYSTEM user:

1. Stop the DataMiner Agent.

1. Open a command prompt as Administrator.

1. Execute the *compmgmt.msc* command to open Computer Management.

1. Navigate to *Computer Management (Local)* > *System Tools* > *Local Users and Groups* > *Users*.

1. Right click *Users* and select *New User*.

1. Fill in a *User Name*, for example *cassandra_service*.

1. Configure a strong password.

1. Clear the checkbox the *User must change password at next logon*.

1. Select the checkboxes *User cannot change password* and *Password never expires*.

1. Grant the user *Modify* access to the following folders:

   - *C:\\Program Files\\Cassandra\\data*

   - *C:\\Program Files\\Cassandra\\logs*

   - *C:\\Program Files\\Cassandra\\bin\\daemon\\*

   - *C:\\ProgramData\\Cassandra*

   > [!CAUTION]
   > Do not grant the permissions on the entire *C:\Program Files\Cassandra* folder, as this may introduce vulnerabilities.

1. Go back to the command prompt and execute the *services.msc* command to open the Service Manager.

1. Stop the *Cassandra* service.

1. Right-click the *Cassandra* service and open *Properties*.

1. Open the *Log On* tab and select *This account*.

1. Fill in the credentials for the user you created earlier.

1. Click *Apply* and *OK* to close the properties window.

1. Start the *Cassandra* service.

1. Start the DataMiner Agent.
