---
uid: IDP_1.1.7
---

# IDP 1.1.7

## New features

#### IDP now supports WMI discovery \[ID_25559\]

IDP has now been extended with WMI discovery, so that Windows servers can be discovered.

WMI discovery actions have the following fields:

- **Name**: The name of the action in this discovery profile. The name has to be unique in the profile and can be referenced by the CI types.

- **ProtocolType**: This defines the discovery mechanism and is set to *WMI*.

- **Method**: The namespace, e.g. *root\\\\cimv2*.

- **Parameter**: The class and the name, e.g. *Win32_Service\\\\Name*.

- **Port**: The destination port on the device to send the request to, by default 135. However, this needs to be checked as WMI has a fixed port and the port cannot be specified when doing WMI queries.

- **Options**: Contains the WQL syntax for instances filtering. Wildcards are supported.

Credentials can be specified by adding username and password under *GenericSettings*.

> [!NOTE]
> When fields contain a backslash (“\\”), an additional backslash must be placed before it. For example, when the namespace is *root\\cimv2*, the discovery profile should contain *root\\\\cimv2*.

For example:

```json
{
   "Actions": [
      {
         "Name": "System Name",
         "Method": "root\\cimv2",
         "Parameter": "Win32_OperatingSystem\\Name",
         "Port": 135,
         "ProtocolType": "WMI"

      }
   ],
   "Credentials": {
      "GenericSettings": {
         "Username": "JohnD",
         "Password": "ThisIsMyPa$$w0rd"
      }
   }
}
```

#### Customizable rack slot position numbering \[ID_25561\]

It is now possible to configure how rack slot positions are numbered, by using the *Rack Position* setting. You can find this setting in the IDP app under *Admin* > *Facilities* > *View Settings*.

The rack position can either be set to "bottom-up", in which case position 1 will be at the bottom of the rack, or to "top-down", in which case position 1 will be at the top of the rack.

#### New 'Identify Unknown Devices' option in IDP app \[ID_25593\]

A new option, *Identify Unknown Devices*, is now available in the IDP app, via *Admin* > *Discovery* > *Settings*. This option determines whether the app shows devices that have been discovered but for which no matching CI type is found.

#### IDP app: Inventory tab enhancements \[ID_25638\]

In the *Inventory* tab of the IDP app, you can now delete an element from the *Discovered Elements* table by selecting the element and clicking the *Delete* button above the table.

In addition, the filter options for the *Discovered Elements* table have been changed, so that it can now show either only managed elements or all elements.

Finally, the new *Identify Unknown Devices* option is now also available on this tab, allowing you to determine whether discovered devices should be displayed in the table if no matching CI type was found for them.

#### Discovery of SNMPv3 devices \[ID_25706\]

Discovery of SNMPv3 devices is now supported. For this purpose, you can import discovery profiles with SNMPv3 actions and credentials. You can do so by going to *Admin* > *Discovery* in the IDP app and clicking the upload icon.

The uploaded file should be in JSON format and should use the following structure:

```json
{
"Actions": [{
                "Method": "GetRequest",
                "Name": "sysDescr",
                "Parameter": "1.3.6.1.2.1.1.1.0",
                "Port": 16102,
                "ProtocolType": "SNMPv3"
            }
],
"Credentials": {
               "SnmpV3Settings": {
                                    "Username": "user",
                                   "SecurityLevel":"AuthPriv",
                                    "AuthenticationPassword": "public",
                                    "EncryptionPassword" : "private",
                                    "AuthenticationAlgorithm" : "HMAC_MD5",
                                    "EncryptionAlgorithm" : "AES128"
                                 }
                }

}
```

The following values are supported for “SecurityLevel”:

- "None" or "1": No authentication and no privacy.
- "AuthNoPriv" or "2": Authentication without privacy. This means that authentication is required, but data are not encrypted. An encryption password is not necessary in this case.
- "AuthPriv" or "3": Authentication with privacy. This means that authentication is required and data are encrypted, so that both an authentication password and an encryption password must be specified.

The following values are supported for “AuthenticationAlgorithm”:

- "None" or "1"
- "HMAC_MD5" or "2"
- "HMAC_SHA" or "3"
- "HMAC128_SHA224" or "4"
- "HMAC192_SHA256" or "5"
- "HMAC256_SHA384" or "6"
- "HMAC384_SHA512" or "7"

The following values are supported for “EncryptionAlgorithm”:

- "None" or "1"
- "DES" or "2"
- "AES128" or "4"
- "AES192" or "20"
- "AES256" or "21"

Finally, the following restrictions apply:

- It is not possible to assign an authentication algorithm when the security level is set to "None".
- It is not possible to assign an encryption algorithm when the security level is set to "None" or "AuthNoPriv".
- Up to DataMiner 9.6.11, only "HMAC-SHA" or "HMAC-MD5" are supported for authentication, and only "DES" and "AES128" are supported for encryption.
- The following combinations of authentication and encryption algorithm are not supported:

  - MD5/SHA-1 and AES192
  - MD5/SHA-1/SHA-224 and AES256

#### Configuration comparison \[ID_25773\]

A new *Compare* subtab has been added to the *Configuration* tab in the IDP app. On this tab, you can compare two configuration files.

To do so:

1. Click the *Search* button and specify the necessary search criteria in the pop-up window.
2. Click *Search* in the pop-up window. The configuration files matching your search criteria will be displayed in the table below *Select configs*.
3. Select the first configuration file to include in the comparison and click the *Left* button.
4. Select the configuration file to compare it with and click the *Right* button.
5. Click the *Compare* button. The configuration files will now be displayed side by side. The differences between the files will be highlighted.
6. To close the side-by-side comparison, click the x in the top-right corner. To clear the selection of files to compare, click the *Clear* button.

You can also quickly launch the configuration comparison from the *Summary* and *Backups* subtabs of the *Configuration* tab. To do so, select an entry in the table on these pages and click the *Compare* button above the table. The app will then display the *Compare* tab with the selected configuration as the configuration file selected on the left. You will then only need to select the configuration file to compare it with and start the comparison.

## Changes

### Enhancements

#### IDP app toggle buttons now use Cube accent color \[ID_25617\]

The toggle buttons in the IDP app have been adjusted so that they now use the Cube accent color.

#### Rack Layout Manager: Support for larger rack-mountable devices \[ID_25663\]

The Rack Layout Manager now supports larger rack-mountable devices. The maximum size has been increased from 6 rack units to 20 rack units.

#### Improved performance when synchronizing element names \[ID_25709\]

Performance has improved when element names are synchronized between the DataMiner System and the IDP app.

#### Base protocols no longer available as protocol for element creation in CI types \[ID_25765\]

When you create or edit a CI type, you can no longer use a base protocol (also known as a mediation protocol) as the protocol for element creation, as it is not possible to create elements with these kinds of protocols. As such, base protocols are no longer listed in the Solution when CI types are generated, created or edited.

### Fixes

#### Element creation failed if multiple proposed element names for discovered elements were set to 'N/A' \[ID_25596\]

If the *Discovered Elements* table contained multiple entries where the proposed element name was "N/A", it could occur that element creation failed.

#### Skyline IDP Discovery: IP address range calculation issue \[ID_25681\]

In some cases, it could occur that IP address ranges were not calculated correctly.

#### Not possible to delete discovery profile \[ID_25706\]

In some cases, it could occur that it was not possible to delete discovery profiles using the context menu of the *Discovery Profiles* table.

#### Element state configuration in CI type not applied \[ID_25757\]

When a particular element state other than active was defined in a CI type configuration, this was not taken into account. Instead, elements were always created in the active state.
