---
uid: I-DOCSIS_Create_CCAP/CM_pair
---

# Create a new CCAP/CM pair

To create a new CCAP/CM pair:

1. Open the Automation module (via apps > Automation).

1. On the left pane select the **EPM_I_DOCSIS_AddNewCcapCmPair**.

1. In the lower right corner, click *Execute*.

1. UI steps:

    **General**
    1. Define the element name.
    The name of the collector element is going to be: *[defined element name]* +"_COLLECTOR".

    1. Select on of the BE DMA.

    **CCAP Details**
    1. Select the desired CCAP protocol.

    1. Select the desired protocol version. We recomment to be the production version.

    1. Enter the IP Address.

    1. Define the desired community string.

    **View Details**

    1. Choose the location where the the CCAP/CM pair will be added according to the EPM view structure.

    **Interface Setting**

    Define the Username and password with an account that can access the **FE DMA**.


The elements are going to be created with the following specifications:
- **CCAP:**
     - **element name:** *[defined element name]*.
     - **protocol:** *[selected protocol]*.
     - **protocol version:** *[selected version]*.
     - **ip address:** *[defined ip address]*.
     - **alarm template:** default alarm template.
     - **trend template:** default trend template.
     - **get community string:** *[defined community string]*.
     - **entity export directory:** "\\\FE DMA Name\DataMiner EPM\DOCSIS".
     - **entity import directory:** "\\\FE DMA Name\DataMiner EPM\DOCSIS".
     - **entity import directory type:** Remote.
     - **system username:** *[system username]*.
     - **system password:** *[system password]*.

- **Collector:** 
    - **element name:** *[defined element name]* +"_COLLECTOR". 
    - **protocol:** [Generic DOCSIS CM Collector](https://catalog.dataminer.services/result/driver/4207) protocol.
    - **protocol version:** production version.
    - **ip address:**  127.0.0.1.
    - **alarm template:** public.
    - **trend template:** private.
    - **get community string:** *[defined community string]*.
    - **entity import directory:** "\\\FE DMA Name\DataMiner EPM\DOCSIS".
    - **entity import directory type:** Remote.
    - **system username:** *[system username]*.
    - **system password:** *[system password]*.








