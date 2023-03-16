---
uid: UD_APIs_UserDefinableApiEndpoint
---

# DataMiner UserDefinableApiEndpoint

> [!WARNING]
> The current feature is in preview and is not fully released yet. This feature should not be used in any staging or production environment.

UserDefinableApiEndpoint is an extension module that runs an ASP.NET Core 5 web API. It handles the incoming API triggers over HTTP or HTTPS and sends the requests to the DataMiner agent(s) in a round robin-way.

## Install

Even though this is an extension module, it follows the release cycle of DataMiner. Meaning that the module will be installed and updated by a DataMiner upgrade package. Note that uninstalling the extension module will result in the feature being unusable.

If the installation would be corrupted or the extension module is unintentionally uninstalled, you can install the extension module using the msi installer located in `C:\Skyline DataMiner\ModuleInstallers\DataMiner UserDefinableApiEndpoint <VERSION>.msi`. Admin rights are required.

When downgrading the UserDefinableApiEndpoint, don't just run the installer of the lower version, but first uninstall the installed version. There is a known issue in MSI installers that corrupts the installation when downgrading. First uninstalling and then installing the lower version prevents this issue from happening.

> [!IMPORTANT]
> Downgrading DataMiner will not automatically downgrade the UserDefinableApiEndpoint extension module. So downgrading from a recent version to an old version could result in incompatibility between DataMiner and the extension module.

## Logging

The logging of the extension module can be found at the following location:

`%ProgramData%\Skyline Communications\DataMiner UserDefinableApiEndpoint\Logs`

Only core functionality errors will be logged. User errors like an empty route will not be logged as the exception passed to the user should give enough info. ASP.NET logging is managed by the Microsoft loglevel in the appsettings.

Also the logging of the installation will be placed in this folder under following name: `UserDefinableApiEndpointInstaller.txt`. Only the logging of the last install is kept.

## NATS

The UserDefinableAPIEndpoint uses NATS to communicate with DataMiner. If there are issues and the logging contains errors related to NATS, please consult the following page to investigate what is going wrong: [Investigating NATS issues](xref:Investigating_NATS_Issues).

## Configuration

The extension module has a configuration file with some settings that can be filled in. They contain default values, but it is important to change them to match your API needs. The file can be found at the following location:

`%programfiles%\Skyline Communications\DataMiner UserDefinableApiEndpoint\appsettings.json`

If you want to make changes to the settings, it is advised to follow the recommendation at the top of the config file to not have your settings overwritten when a new update is installed.

The config file with default values looks like this:

```json
{
  // ======================================================================================================== //
  // When updating UserDefinableApiEndpoint, this file will be overriden, 
  //      meaning that any change made to this file will be gone.
  // 
  // If you want to customize any of the below settings you can create a new file named 
  //      "appsettings.custom.json" in the same directory as this appsettings.json file.
  //
  // This custom appsettings file can override and/or extend any JSON property defined in this settings file.
  // ======================================================================================================== //
  "Kestrel": {
    "Endpoints": {
      "Http": {
        "Url": "http://localhost:5002"
      }
    }
  },

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

  "UserDefinableAPIs": {
    "NatsSubject": "Skyline.DataMiner.Protobuf.Apps.UserDefinableApis.Api.v1.UserDefinableApiTriggerRequest",
    "SessionConfigPath": "C:\\Skyline DataMiner\\SLCloud.xml",
    "CredentialsConfigPath": "C:\\Skyline DataMiner\\NATS\\nsc\\.nkeys\\creds\\DataMinerOperator\\DataMinerAccount\\DataMinerUser.creds",
    "MessageBrokerTimeOutSeconds": 300
  }
}
```

### Changing a configuration

If you want to change a configuration, create an appsettings.custom.json file, this will prevent your settings from being overwritten by an upgrade as explained earlier. You add the setting that you want to override, and change the value. In the example below, we are going to change the `MessageBrokertimeOutSeconds` to a higher value:

`appsettings.custom.json`

```json
{
  "UserDefinableAPIs": {
    "MessageBrokerTimeOutSeconds": 500
  }
}
```

> [!NOTE]
> For some of the configurations, a restart of the service is required when doing a change.

### Kestrel

Contains the endpoint on which UserDefinableApiEndpoint will be run, you can change the port here.

IIS also has a rewrite rule (Reroute User Definable APIs) that forwards API requests to the port used by UserDefinableApiEndpoint (5002). When changing the port configured in appsettings(.custom).json, this rule also has to be updated.

To update the rewrite rule, open `Internet Information Services (IIS) Manager` and follow the steps below:

1. Open the 'Default Web Site' on the left;
2. Click 'URL Rewrite';
3. Click the 'Reroute User Definable APIs' rewrite rule;
4. Click 'Edit' in the bar on the right;
5. Change the default port (5002) in the 'Rewrite URL' under 'Action' to the port you want to use;
6. Click 'Apply'

![IIS Manager 1](~/user-guide/images/UDAPIS_IIS1.jpg)

![IIS Manager 2](~/user-guide/images/UDAPIS_IIS2.jpg)

![IIS Manager 3](~/user-guide/images/UDAPIS_IIS3.jpg)

### Serilog

Serilog is the logging service being used for UserDefinableApiEndpoint. Here you can change where the logfiles should be located, how big they can get and how many files should be kept. You can also change the default loglevels.

> [!NOTE]
> The default settings are to roll a file after it reaches a size of 5 MB. It will keep a maximum of 3 files. After reaching 3 files, the oldest file will be deleted to make place for the new file.

### UserDefinableAPIs

Specific options for User Definable APIs.

#### NatsSubject

The subject used for internal NATS messaging. This should not be changed.

#### SessionConfigPath

This is the path of the SLCLoud.xml file.

#### CredentialsConfigPath

This contains the path to the credentials used to connect to DataMiner over NATS.

#### MessageBrokerTimeOutSeconds

Default is set to 5 minutes (300 seconds). The MessageBroker sending the NATS trigger to SLNet will wait for this long on a response until it will time out.

## HTTP(S) support

> [!NOTE]
> Because API triggers contain a secret token, we strongly recommend to only allow HTTPS communication. Using HTTP could expose these tokens.

In order to allow requests over HTTP or HTTPS. Bindings have to be configured in IIS, and the firewall needs to allow incoming requests on port 80 (HTTP) and/or 443 (HTTPS). The following page explains how to [set up HTTPs on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

In the IIS binding, you can choose the IP address to listen to. This can be used to only have requests coming from one network interface, or select 'All Unassigned' to allow requests from all interfaces.
You can also specify a specific hostname here.
