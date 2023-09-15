---
uid: Connector_help_Teracom_Service_Overview_Manager
---

# Teracom Service Overview Manager

The **Teracom Service Overview Manager** provides an overview of the states of the different services.

## About

This connector provides an overview of all the alarms on services. Services are added by importing an .xls, .xlsx or .csv file.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | No                      |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not need any user input during creation.

### Configuration

To import services, define a file path on the **Import** **File** pop-up page and then click the **Import** button. (This works for both CSV and XLS files.)

## Usage

### General page

On this page, one large table is available, the **Service** **table**. To enter services into this table, you must import an .xls or .xlsx file. To do so, click the **Import** **File** button to go to the **Import** **File** page. To remove services from the table, click the **Remove** button.

There are two other page buttons available that are used to automatically add a **Tx** or **Headend**. When you add a **Tx** or **Headend** here, these will be added to all the necessary tables. For a Tx, this will be the following tables: Tx, Tx Input, Tx Output, Probe/TxIn and Probe/TxOut.

### Headend page

On this page, you can add **Headend** **In** and **Out** by clicking the respective page button and filling in the required information on the pop-up page. There you can select a probe and an RHE.

### Tx page

On this page, you can add a **Tx** by clicking the page button and filling in the required information on the pop-up page.

### Tx Input/Output page

On these pages, you can find the **Tx Input** and **Tx Output** table. To add new rows, click the page button in question, fill in the required fields, and then click the **Add** **TxIn** or **Add** **TxOut** button.

### Probe/Tx Input/Output

On this page, you can find the **Probe/Tx In** and **Probe/Tx Out** table. To add new rows, click the page button in question, fill in the required fields, and then click the **Probe/Tx In** or **Probe/Tx Out** button.

### Headend Input/Output page

On these pages, you can find the **Headend** **Input** and **Headend** **Output** table. To add new rows, click the page button in question, fill in the required fields, and then click the **Add** **HeIn** or **Add** **HeOut** button.

### Probe/Headend Input/Output

On this page, you can find the **Probe/HeIn** and **Probe/HeOut** table. To add new rows, click the page button in question, fill in the required fields, and then click the **Add** **Probe/HeIn** or **Add** **Probe/HeOut** button.

### Service/Tx , Service/Headends , Services/Tx/InOut , Services/Headends/InOut , Services/Probe/Tx and Services/Probe/Headends page

On these pages, you can find tables that are automatically filled in and that are used to link the other tables to each other.

### Element page

On this page, you can find two tables. The upper table displays all the elements on the DMA with their **Name**, **Protocol** **Version**, **Protocol** **Name**, **Element** **ID** and **Severity**.

The lower table displays a selection of elements that are probes. The information displayed in this table is similar to that in the table above.
