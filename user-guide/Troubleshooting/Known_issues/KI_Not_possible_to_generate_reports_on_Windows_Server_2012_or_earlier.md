---
uid: KI_Not_possible_to_generate_reports_on_Windows_Server_2012_or_earlier
---

# Not possible to generate reports on Windows Server 2012 or earlier

## Description of the issue

On Windows Server 2012 or earlier versions of Windows, it can occur that it is not possible to generate legacy reports when you use HTTPS.

![Failing to create report](~/user-guide/images/Failing-to-create-report-1024x392.png)

## Cause

The TLS settings are at the root of this issue. By default, Windows 2012 servers use TLSv1.0 (also for winHTTP). So if you have disabled the use of TLSv1.0 in server mode, it could be that DataMiner is trying to request the report through TLSv1.0 (instead of first trying TLSv1.2, then TLSv1.1, etc.).

## Resolution

KB3140245 resolves this issue, but merely installing it on your machine does not change the behavior.

You also need to adjust the settings in the registry keys to resolve the issue:

- HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings\WinHttp
- HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Internet Settings\WinHttp

The registry value is a DWORD bitmap. DefaultSecureProtocols => 0x00000800

> [!TIP]
> For more information, see [Microsoft Support](https://support.microsoft.com/en-us/help/3140245/update-to-enable-tls-1-1-and-tls-1-2-as-default-secure-protocols-in-wi).
