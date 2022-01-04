## Configuring Mobile Gateway to communicate with an SMSEagle device via HTTPS

From DataMiner 9.6.10 onwards, it is possible to set up communication with an SMSEagle device via HTTPS. To do so:

1. Open *C:\\Skyline DataMiner\\Mobile Gateway\\Config.xml*.

2. In the *\<HttpGsm>* tag, add the following subtags:

    | Tag           | Description                                                                                                                                                                                                             |
    |-----------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | UseHttps        | Set to “true” to enable HTTPS.                                                                                                                                                                                          |
    | RequireValidSsl | Set to “true” to require a valid certificate on the SMSEagle device (recommended). In that case, the *HttpGSM.Location* tag must contain “smseagle” instead of the IP address of the device. |

3. Make sure the port attribute of the *\<Location>* tag is set to the port on which the SMSEagle device is listening. This will most likely be port 443.

    Example of the *\<HttpGsm>* configuration in *Config.xml*:

    ```xml
    <HttpGsm>                                
      <Location port="443">smseagle</Location>
      <Schedule>3</Schedule>                  
      <UseHttps>true</UseHttps>               
      <RequireValidSsl>true</RequireValidSsl> 
      <SMSEagle user="user" pass="pass"/>      
    </HttpGsm>                               
    ```

    > [!NOTE]
    > From DataMiner 10.2.0/10.1.5 onwards, you can also add the *unicode="true"* attribute to the *SMSEagle* element to make the SMSEagle device use Unicode characters when sending text messages.

If \<*RequireValidSsl>* is set to *false*, no further configuration is required. If this is set to *true*, follow the procedure below:

1. Make sure the DataMiner Agent trusts the default server certificate of the SMSEagle device:

    1. In your internet browser, go to *https://\<IP address of the SMSEagle device>*.

        If an error message appears, telling you that the site is not secure, ignore it.

    2. Click the warning triangle to the left of the URL bar, and click *certificate*. A window will open.

    3. Go to the *Details* tab, and click *Copy to File.*

    4. Click *Next*, specify a random folder and a file name, and click *Save*.

    5. Open the Microsoft Management Console. To do so, press WINDOWS+R, type “mmc”, and press ENTER.

    6. In the Microsoft Management Console, press CTRL+M.

    7. In the *Add or Remove Snap-ins* window, select “Certificate” from the *Available snap-ins* list, and click *Add*.

    8. Select the following options:

        - *Computer Account*

        - *Local Computer*

    9. Click *OK* to close the *Add or Remove Snap-ins* window.

    10. Under the *Console Root*, go to *Certificates (Local Computer) \> Trusted Root Certification Authorities \> Certificates*.

    11. Right-click the *Certificates* folder, and select *All tasks \> Import.*

    12. Select the file where you saved the certificate details. This will load the certificate into the certificate store.

2. Update the Windows hosts file:

    1. Open *C:\\Windows\\System32\\Drivers\\etc\\hosts*.

    2. At the bottom, add a line with the IP address of the SMSEagle device, followed by a space and the word “smseagle”

        Example: *10.3.1.41 smseagle*

    3. Save and close the hosts file.

3. To check if the certificate was correctly installed, open an internet browser, and go to *https://smseagle/login*. If no “invalid certificate” errors appear, the certificate was correctly installed.

> [!NOTE]
> -  In production environments, it is recommended to use the domain certificate of the network (e.g. smseagle.skyline.be) and to generate a server certificate for the SMSEagle device that is trusted by the root skyline.be certificate.
> -  The SMSEagle firmware supports HTTPS as from version 2.7.
> -  When an SMSEagle device with firmware version 3.32 is used, because of an issue with this firmware version, it is not possible to retrieve the signal strength. 
>
