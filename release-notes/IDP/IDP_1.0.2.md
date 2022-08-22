---
uid: IDP_1.0.2
---

# IDP 1.0.2

## New features

#### Skyline IDP CMDB: New app component to store CI types \[ID_21925\]

The element using the protocol *Skyline IDP CMDB* will now serve as the centralized location where all information regarding CI types is stored.

This element contains a page similar to the *Provisioning Templates* page of the IDP Discovery element. Like the *Provisioning Templates* page, this page allows you to specify a file path and load the CI type files. It also includes a table with the CI types and a table with the provisioning conditions.

#### Redesigned IDP app visual overview \[ID_21959\]

The main visual overview of the IDP app has been redesigned.

It now consists of the following tabs:

- *Overview*: Consists of a summary of the actions of the app, KPIs, alarms, statistics per DMA and a general map overview.

- *Inventory*: Consists of the following subtabs:

  - *Managed*: Displays an overview of the elements managed by the IDP Solution.
  - *Discovered*: Allows you to start a device discovery and manage the discovered elements. The *Discovered Elements* table lists all discovered elements with detailed information.
  - *Imported*: Displays an overview of imported elements.

- *Facilities*: Displays an overview of the levels in the infrastructure, with KPIs and a table that allows you to manage the location of managed devices.

- *Workflows*: Displays a timeline with all scheduled activities and a *New...* button, which allows you to schedule a new discovery activity.

- *Admin*: Consists of the following subtabs:

  - *Discovery*: Allows you to verify and configure the IP ranges for device discovery.
  - *Provisioning*: Allows you verify and configure the IP ranges for provisioning, and to set the fallback Agent.
  - *Facilities*: Allows you to configure the rack view structure and to set prefixes for each level in the structure.
  - *Settings*: Allows you to run the setup wizard again.

- *Info*: Consists of the following subtabs:

  - *About*: Displays version information for the IDP Solution.
  - *Provisioning API*: Displays documentation on the provisioning API.
  - *Help*: Displays the IDP Solution section of the DataMiner Help.

#### DataMiner IDP Discovery: New button to load CI type conditions \[ID_22007\]

In the DataMiner IDP Discovery element, you can now retrieve CI type conditions. On the *Provisioning Templates* page of the element, a new button *Load From CMDB* is available, which will load this information.

#### Provisioning API: CreateElementWithTemplate method \[ID_22153\]

The provisioning API now contains a *CreateElementWithTemplate* method, which creates an element based on a CI type reference. This makes it possible to always create elements with the latest template.

The following example illustrates the structure that should be used:

```json
{
    "CITypes": [{
            "Keywords": [{
                    "Keyword": "IPAddress",
                    "KeywordReplacement": "192.168.123.230"
                }, {
                    "Keyword": "$.Provisioning.Configuration.Description",
                    "KeywordReplacement": "test"
                }
            ],
            "NameCIType": "Cisco Manager"
        }
    ]
}
```

In this structure:

- The name of the CI type must be specified in *NameCIType*.

- The keywords are optional and used to tweak the element that is created:

  - Several normal keywords can be specified (e.g. *IPAddress*). If the CI type mentions such a keyword within square brackets (e.g. *\[IPAddress\]*), it will be replaced by the "KeywordReplacement" specified in the structure.

  - There are also keywords that can be used to override fields in the CI Type. The syntax for these is similar to the syntax to select a token in Json.NET. For example, to refer to the description in the example below, the keyword *$.Provisioning.Configuration.Description* can be used. If a match is found, the field will be overridden with the specified “KeywordReplacement”:

    ```json
    {
        "Provisioning": {
            "Configuration": {
                "Description": "[ProtocolName]-[ProtocolVersion]-[IPAddress]",
            },
        }
    }
    ```

> [!NOTE]
> Before the element is created, basic validation is done, for instance to ensure that no element with the same name already exists.

## Enhancements

#### Automation script summary window no longer displayed \[ID_21964\]

When an Automation script is launched from the IDP Solution, the summary window of the script will no longer be displayed.

#### IDP app refreshes information based on messages sent by IDP Discovery element \[ID_21980\]

The IDP app will now use notifications sent by the IDP Discovery element regarding the status of current discovery tasks in order to trigger a refresh of the information displayed to the user.

#### Improved information on ongoing discovery process \[ID_22013\]

To provide the user with a better view on what is happening during the discovery process, the *Inventory* > *Discovered* tab of the IDP app now displays a list of the six most recent discoveries.

In addition, the IDP Discovery driver now has the following parameters on the Admin data page: *Extended Logging*, *Number of Threads*, *Number of Retries*, *Auto-Create Elements*.
