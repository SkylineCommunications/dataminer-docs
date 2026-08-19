---
uid: EPM_xPON_Create_OLT
description: Learn how to create xPON OLT elements, either individually through the interactive user interface or in bulk from a CSV file.
---

# Creating a new xPON OLT

## About the CreateOLTs automation script

The **CreateOLTs** automation script allows operators to create xPON OLT elements in an EPM xPON deployment.

You can either:

- Create a single OLT through an interactive wizard.
- Create multiple OLTs in bulk from a CSV file.

The script supports the following OLT vendors:

- Huawei
- ZTE
- Nokia

After the OLT is created, the script automatically configures the required EPM xPON integration settings, updates the frontend and backend components, assigns the appropriate view structure, and applies the configured element properties.

## Creating a single OLT

1. In DataMiner Cube, go to **Apps** > **Automation**.

1. In the pane on the left, select the script **CreateOLTs**.

1. In the lower-right corner, click **Execute**.

   This will open a pop-up window.

1. Click **Create Single**.

1. In the **General** section:

   1. Define the **Element Name**.

      > [!IMPORTANT]
      > Make sure the element name does not contain any forbidden characters:
      >
      > ```text
      > / : * ? < > | [ ] $ º ª
      > ```

   1. Select the **Host** where the OLT element will be created.

      > [!NOTE]
      > Only DMA Agents containing a **Skyline EPM Platform GPON** backend element are available for selection.

1. In the **Element Details** section:

   1. Select the desired **protocol**.

      Currently supported protocols are:

      - Huawei 5600
      - ZTE ZXA10 C600 GPON Platform
      - Nokia ISAM 7300

   1. Enter the necessary information:

      - **IP Address**: The IP address of the OLT.
      - **Get Community String**
      - **Set Community String** (optional)
      - **System Username**
      - **System Password**

1. In the **View Details** section, select the **Network**, **Market**, and **Hub**.

   > [!NOTE]
   > If the selected Network, Market, or Hub view does not exist, the script automatically creates the required view hierarchy.

1. Click **Create**.

The script will perform the following actions:

1. Validate the supplied information.
1. Create the OLT element on the selected DMA.
1. Create missing views if required.
1. Assign the element to the selected view hierarchy.
1. Configure SNMP connectivity.
1. Copy export and import paths from the corresponding EPM xPON backend.
1. Configure Kafka stream paths.
1. Configure vendor-specific parameters.
1. Register the OLT in the EPM xPON frontend.
1. Register the OLT in the EPM xPON backend.
1. Apply the Network, Market, and Hub element properties.
1. Restart the element.

### Created element configuration

The element will be created with the following specifications:

- **Element name**: The specified element name.
- **Protocol**: The selected protocol.
- **Protocol version**: Production.
- **IP address**: The specified IP address.
- **SNMP Get community**: The specified Get community string.
- **SNMP Set community**: The specified Set community string (if any).
- **Export path**: Automatically inherited from the xPON backend.
- **Import path**: Automatically inherited from the xPON backend.
- **Kafka path**: Automatically inherited from the xPON backend.
- **System username**: The specified system username.
- **System password**: The specified system password.
- **Network property**: The selected Network.
- **Market property**: The selected Market.
- **Hub property**: The selected Hub.

> [!NOTE]
> It may take several seconds before the element becomes fully available, as the script performs additional configuration and registration steps after element creation.

## Creating OLTs in bulk from a CSV file

1. In DataMiner Cube, go to **Apps** > **Automation**.

1. In the pane on the left, select the script **CreateOLTs**.

1. In the lower-right corner, click **Execute**.

   This will open a pop-up window.

1. Click **Create Bulk**.

1. Enter the full path to a CSV file with the correct [CSV structure](#csv-structure).

1. Click **Create**.

The script will validate the CSV file and create the OLT elements found in the file.

### CSV structure

The CSV file must contain the following headers:

| Column | Description |
|----------|----------|
| ElementName | Name of the OLT element |
| Host | DMA ID where the element will be created |
| Protocol | Protocol name |
| IpAddress | OLT IP address |
| GetCommunityString | SNMP Get community |
| SetCommunityString | SNMP Set community |
| Network | Network view |
| Market | Market view |
| Hub | Hub view |
| SystemUser | System username |
| SystemPass | System password |

### Example CSV file

```csv
ElementName,Host,Protocol,IpAddress,GetCommunityString,SetCommunityString,Network,Market,Hub,SystemUser,SystemPass
OLT-HUAWEI-001,101,Huawei 5600,10.10.10.1,public,private,North,MarketA,Hub01,admin,password
OLT-ZTE-001,101,ZTE ZXA10 C600 GPON Platform,10.10.10.2,public,private,North,MarketA,Hub01,admin,password
OLT-NOKIA-001,102,Nokia ISAM 7300,10.10.10.3,public,private,South,MarketB,Hub02,admin,password
```

> [!NOTE]
>
> - The CSV file must be accessible from the DataMiner Agent executing the script.
> - The file extension must be `.csv`.
> - CSV files must use commas (`,`) as separators.
> - The first row must contain the required headers.

### Bulk processing behavior

The script automatically:

- Loads all records from the CSV file.
- Detects elements that already exist.
- Skips existing elements.
- Creates only elements that are not yet present in the DataMiner System.
- Processes up to five OLTs per execution.

> [!NOTE]
>
> - If more than five OLTs still need to be created, execute the script again using the same CSV file.
> - Previously created elements are automatically ignored.
> - If all elements already exist, the script reports that no elements remain to be created.

## Validation rules

The script validates all supplied information before creating an element.

- The **element name**:

  - Cannot be empty.
  - Must be unique.
  - Cannot contain forbidden characters.

- The **host**:

  - Cannot be empty.
  - Must contain a valid DMA ID.
  - Must correspond to an existing DMA Agent.

- The **protocol**:

  - Cannot be empty.
  - Must be installed in DataMiner.
  - Must be available in the Production branch.

- The **IP address**:

  - Cannot be empty.
  - Must be a valid IPv4 address.
  - Must not already be used by another DataMiner element.

- The following fields **cannot be empty**:

  - GetCommunityString
  - Network
  - Market
  - Hub

## Automatic view creation

If the specified hierarchy does not exist, the script automatically creates the required views:

```text
Network
└── Market
    └── Hub
```

The newly created OLT is then assigned to the corresponding Hub view.

## Automatic property creation

If the following element properties do not exist in the DataMiner System, the script creates them automatically:

- Network
- Market
- Hub

## Troubleshooting

### EPM frontend not found

Verify that an element named `EPM FE - GPON` exists and is active.

### Host not found

Verify that the selected DMA exists and is operational.

### Protocol not found

Verify that the protocol is installed and available as the Production version.

### Duplicated IP address

Verify whether the configured IP address is not already used by another element.

### Invalid CSV file

Verify that:

- The file exists.
- The file extension is `.csv`.
- The CSV structure matches the required format.
- The file is accessible by the executing DMA.

### No elements left to be created

This indicates that all OLTs defined in the CSV file already exist in the DataMiner System. See [Bulk processing behavior](#bulk-processing-behavior).
