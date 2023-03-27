---
uid: UD_APIs_UserDefinableApiEndpoint
---

# DataMiner UserDefinableApiEndpoint DxM

> [!WARNING]
> This feature is in preview and is not fully released yet. For now, it should only be used on a staging platform. It should not be used in a production environment.

*DataMiner UserDefinableApiEndpoint* is an extension module that runs an ASP.NET Core 5 web API. It handles the incoming API triggers over HTTP or HTTPS and sends the requests to the DataMiner Agent(s) in a round-robin way.

## Installing the DxM

Even though this is an extension module, it follows the release cycle of DataMiner. This means that when you install a **general DataMiner upgrade package**, this module will also be installed and updated.

If for some reason this extension module is uninstalled, the User-Defined APIs feature will become unavailable. If this happens, or if the installation somehow becomes corrupted, you can install the extension module using the **MSI installer** located in `C:\Skyline DataMiner\ModuleInstallers\DataMiner UserDefinableApiEndpoint <VERSION>.msi`. You will need Administrator rights for this.

> [!IMPORTANT]
> Downgrading DataMiner will not automatically downgrade the *UserDefinableApiEndpoint* DxM. This means that a **downgrade could result in incompatibility** between DataMiner and the extension module. To downgrade the *UserDefinableApiEndpoint* DxM, first uninstall the installed version, and then install the lower version. Do not just run the installer of the lower version without uninstalling first, as this may corrupt your installation.

## Consulting logging for the DxM

For logging of **core functionality errors** of the extension module, consult the logging in the following location:

`%ProgramData%\Skyline Communications\DataMiner UserDefinableApiEndpoint\Logs`

User errors, such as an empty route, are not included in this, as the exception passed to the user should give enough info. ASP.NET logging is managed by the Microsoft loglevel in the appsettings.

Logging related to the **installation** is placed in that same folder in the file `UserDefinableApiEndpointInstaller.txt`.  Only the logging of the last installation is kept.

The *UserDefinableAPIEndpoint* DxM uses **NATS** to communicate with DataMiner. If there are issues and the logging contains errors related to NATS, refer to [Investigating NATS issues](xref:Investigating_NATS_Issues).

## Configuring HTTPS

Because API triggers contain a secret token, we **strongly recommend that you only allow HTTPS communication**. Using HTTP could expose these tokens.

You will need to configure bindings in IIS, and the firewall needs to allow incoming requests on port 443 (HTTPS). In the IIS binding, you can choose the IP address to listen to. This can be used to only have requests coming from one network interface. Select *All Unassigned* to allow requests from all interfaces. You can also specify a specific hostname here.

For more information on how to set this up, see [Setting up HTTPs on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

## Configuring the DxM

The extension module has a configuration file with some settings that are set to default values. It is important that you customize this configuration to match the needs for your API, by creating a custom configuration file of your own.

The default configuration file can be found in the following location: `%programfiles%\Skyline Communications\DataMiner UserDefinableApiEndpoint\appsettings.json`

If you want to make changes to the configuration, create an *appsettings.custom.json* file within the same folder. This will prevent your settings from being overwritten by an upgrade.

In this file, add the setting or settings that you want to override, with your custom value. The following main blocks of settings are available:

- [Kestrel](#kestrel)
- [Serilog](#serilog)
- [UserDefinableAPIs](#userdefinableapis)

> [!IMPORTANT]
> When you have customized the settings, you will need to restart the *DataMiner UserDefinableAPIEndpoint* service.

For example, to change the setting *MessageBrokerTimeOutSeconds* to a higher value, create an *appsettings.custom.json* file with the following content and then restart the service:

```json
{
  "UserDefinableAPIs": {
    "MessageBrokerTimeOutSeconds": 500
  }
}
```

### Kestrel

This contains the endpoint where the *UserDefinableApiEndpoint* DxM will be run. You can change the port here.

For example, this is the default configuration:

```json
{
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:5002"
      }
    }
  }
  ...
}
```

IIS also has a rewrite rule (Reroute User Definable APIs) that forwards API requests to the port used by *UserDefinableApiEndpoint* (5002). **When you specify a custom port in *appsettings.custom.json*, you will also have to update this rule**:

1. Open `Internet Information Services (IIS) Manager`.

1. In the *Connections* pane on the left, expand the top node and *Sites* node until you see *Default Web Site*.

1. Select *Default Web Site* and then double-click *URL Rewrite* on the right.

   ![IIS Manager 1](~/user-guide/images/UDAPIS_IIS1.jpg)

1. Select the *Reroute User Definable APIs* rewrite rule and click *Edit* in the pane on the right.

   ![IIS Manager 2](~/user-guide/images/UDAPIS_IIS2.jpg)

1. Under *Action*, in the *Rewrite URL* box, change the default port (5002) to the port you want to use.

   ![IIS Manager 3](~/user-guide/images/UDAPIS_IIS3.jpg)

1. Click *Apply*.

### Serilog

Serilog is the logging service used for *UserDefinableApiEndpoint*. Here you can change where the log files should be located, how big they can get, and how many files should be kept. You can also change the default log levels.

By default, a log file has a maximum size of 5 MB, and at most 3 files will be kept. When there are 3 files already and a new file needs to be created, the oldest file will be removed.

For example, this is the default configuration:

```json
{
  ...
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "Default": "Debug",
        "System": "Information",
        "Microsoft": "Information"
      }
    },
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "%ProgramData%\\Skyline Communications\\DataMiner UserDefinableApiEndpoint\\Logs\\UserDefinableApiEndpoint.txt",
          "fileSizeLimitBytes": 5000000,
          "rollOnFileSizeLimit": true,
          "retainedFileCountLimit": 3
        }
      }
    ],
    "Enrich": [ "FromLogContext" ]
  },
  ...
}
```

### UserDefinableAPIs

This section contains options specific to the DataMiner User-Definable APIs module:

- **NatsSubject**: The subject used for internal NATS messaging. This should not be changed.

- **SessionConfigPath**: *Optional.* The path to the NATS config file. This will by default point to the `SLCloud.xml` file if not filled in.

- **CredentialsConfigPath**: The path to the credentials used to connect to DataMiner over NATS.

- **MessageBrokerTimeOutSeconds**: The time the message broker sending the NATS trigger to SLNet will wait for a response before it times out. By default, this is set to 300 seconds (i.e. 5 minutes).

For example, this is the default configuration:

```json
{
  ...
  "UserDefinableAPIs": {
    "NatsSubject": "Skyline.DataMiner.Protobuf.Apps.UserDefinableApis.Api.v1.UserDefinableApiTriggerRequest",
    "CredentialsConfigPath": "C:\\Skyline DataMiner\\NATS\\nsc\\.nkeys\\creds\\DataMinerOperator\\DataMinerAccount\\DataMinerUser.creds",
    "MessageBrokerTimeOutSeconds": 300
  }
}
```
