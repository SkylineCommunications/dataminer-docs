---
uid: KI_DataMiner_Cube_freeze_on_startup
---

# DataMiner Cube freeze on startup

## Affected versions

All versions of the DataMiner Cube desktop application (DataMinerCube.exe).

## Issue description

- On a machine without internet connectivity, the DataMiner Cube desktop application will freeze for 20 seconds on startup. Once you have logged in, Cube works fine.
- When you go to the file properties of *DataMinerCube.exe > Digital Signatures > Details*, the same freeze occurs. After 20 seconds, the *Digital Signature Details* window is displayed.

    ![Digital Signature Details](~/user-guide/images/CRL-Freeze-Signature-Details.png)

## Root cause

.NET Framework/Windows attempts to check the Certificate Revocation List (CRL) associated with the certificate that Skyline uses to sign its applications.

- For binaries signed before 2021-07-01, this is with a certificate from COMODO that will attempt to access the following URLs:

  - <http://ocsp.comodoca.com/>
  - <http://crl.comodoca.com/>

- For binaries signed after 2021-07-01, this is with a certificate from Sectigo that will attempt to access the following URLs as well:

  - <http://ocsp.sectigo.com/>
  - <http://crl.sectigo.com/>

Terminology:

- CRL: [Certificate Revocation List](https://en.wikipedia.org/wiki/Certificate_revocation_list)
- CTL: [Certificate Trust List](https://docs.microsoft.com/en-us/windows/win32/seccrypto/certificate-trust-list-overview)
- OCSP: [Online Certificate Status Protocol](https://en.wikipedia.org/wiki/Online_Certificate_Status_Protocol)

Background articles:

- [Understanding Certificate Revocation Checks](https://docs.microsoft.com/en-us/archive/blogs/ieinternals/understanding-certificate-revocation-checks)
- [How Certificate Revocation Works](https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/ee619754(v=ws.10))

## Workarounds

### Compliance – ensure Windows can correctly check the CRL

- Allow Windows to periodically update all CTLs through Windows Update. This requires HTTP access to *ctldl.windowsupdate.com*.
- Allow Windows to periodically update these specific CRLs. This requires HTTP access to the 4 hostnames listed above in the [Root cause](#root-cause) section.
- Manage the periodic delivery of CTLs to disconnected client machines through any other mechanism.

### Avoidance – prevent Windows from checking the CRL

- Instruct .NET Framework to not check the CRL for this application (see [Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/runtime/generatepublisherevidence-element)). Place a file named *DataMinerCube.exe.config* alongside *DataMinerCube.exe* with the following content:

  ```xml
  <configuration>
    <runtime>
      <generatePublisherEvidence enabled="false"/>
    </runtime>
  </configuration>
  ```

  > [!NOTE]
  > This workaround will be applied automatically when Cube is deployed via the launcher MSI.

- Instruct Windows to not check the CRL for any application, by disabling the setting *Internet Options > Advanced > Security > Check for publisher's certificate revocation*.

  ![Advanced settings](~/user-guide/images/CRL-Freeze-IE-Advanced-Settings.png)

  This setting can also be disabled via its registry key:

  `HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\WinTrust\Trust Providers\Software Publishing`

  Set value *State* to `146944` (decimal) or `0x00023e00` (hex).

  > [!NOTE]
  > There is no built-in group policy available in Windows for this setting.

### Mitigation – allow Windows to attempt to check the CRL, but ensure this attempt fails quickly instead of waiting for a timeout

- On the local machine: Redirect the affected hostnames in the `C:\Windows\system32\drivers\etc\hosts` file.

  ```txt
  127.0.0.1   ocsp.comodoca.com
  127.0.0.1   crl.comodoca.com
  127.0.0.1   ocsp.sectigo.com
  127.0.0.1   crl.sectigo.com
  ```

- On the network firewall: Do not silently drop packets to these hostnames on TCP port 80. Instead, reject the connection so the client is immediately informed that no connection can be made and does not wait for a timeout.
