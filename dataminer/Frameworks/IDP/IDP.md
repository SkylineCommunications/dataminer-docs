---
uid: SolIDP
---

# DataMiner IDP app

DataMiner Infrastructure Discovery and Provisioning (IDP) is an out-of-the-box application to **manage network inventory in a highly automated yet secure manner**. Today's infrastructure deployments are highly dynamic. This is the result of many continuous evolutions.

For example, there is a continuous need to add capacity to networks at the optimal cost point. In some cases, additional compute, storage, or networking capacity is deployed at the edges of the network, even at the end-customer site — think of B2B terminals (IP routers, VSAT terminals, etc.), edge computing in the network such as 5G, HFC DOCSIS remote DAA Digital Nodes, etc. In other cases, additional capacity is deployed in a few geographically spread data centers. Scale and elasticity may lead to public cloud deployment of functions as well. Most often, networks grow and adapt in all dimensions: on-premises edges, on-premises centralized, and public cloud.

DataMiner IDP will among others provide the following advantages:

- A **single source of truth**: a single overview of inventory documentation, wiring, addresses, etc.
- **Dynamics**: Integration of full inventory, including VNI.
- **Security**: controlled onboarding of inventory and software.

## Far-reaching automation

More than ever, it is crucial to keep track of the network implementation and network change management processes and activities. There is a real need for a single source of truth when it comes to inventory. All too often, people have to conclude that their offline inventory database does not match with their actual network. DataMiner IDP ensures that the inventory database does reflect reality, and it can even do much more than that. In an automated manner, it does all the things a good operations team should constantly take care of but often does not get the time to do consistently and securely:

- **Discover new network inventory** at user-defined time intervals, and compare this with the already managed network elements and network functions. DataMiner scans any API, and therefore discovers hardware inventory (PNI), virtualized inventory (VNI), and cloud functions from any manufacturer. In addition, DataMiner IDP Discovery also extracts connectivity from the network whenever this can be done remotely (e.g. by reading LLDP info).

- Once the inventory is discovered or imported, DataMiner provisions the elements on the platform so that the inventory can instantly be managed. The **DataMiner zero-touch provisioning** intelligence will automatically select the connector matching the detected API from the data source. Without a single click, operators can monitor the newly added inventory, receive alarms, and control and trend metrics and counters.

- SecOps is top of mind for CSO and operations teams. Therefore, DataMiner IDP Configuration Manager can **automatically verify whether a particular configuration is allowed** in the network. If needed, DataMiner IDP can even upload a golden configuration to the newly discovered inventory, a configuration that is safe in terms of user access policies, IP flow policies (ACL), etc.

- Similarly, DataMiner will detect any non-approved software images in the network and provide alarm notifications. And similar to DataMiner IDP Configuration Manager, the DataMiner IDP Software Update Manager can **upload validated builds** on the network elements or image repositories.

- Even if every network function has become software today, there is still a lot of legacy on-premises hardware mounted in racks, and every virtualized or containerized cluster eventually runs on nodes mounted in racks as well. As such, DataMiner IDP Rack Manager allows the **automatic creation of highly graphical views of all your facilities, buildings, floor plans, aisles, and racks**. The required information to create the visuals can easily be imported from any API, database, or file.

![DataMiner IDP user interface](~/dataminer/images/IDP_Dojo_screenshot.jpg)

> [!TIP]
> For more information:
>
> - [Introduction video](https://www.youtube.com/watch?v=DdrSfUBzfOI)

## IDP components

DataMiner IDP consists of several interacting components, each responsible for a specific task.

![IDP component overview](~/dataminer/images/IDP_overview.jpg)

- The **Discovery Manager** automatically discovers inventory in the network as well as the network topology. Using highly user-configurable profiles and discovery mechanisms, such as SNMP, HTTP(S) and serial, the Discovery Manager can be tailored to detect not only new inventory, but it also identifies what type of inventory is in the network.

- The **Provisioning Manager** can automate the provisioning workflow completely. As soon as DataMiner IDP discovers new inventory, the IDP Provisioning Manager will provision the inventory in DataMiner fully automatically or semi-automatically.

- The **Configuration Manager**, introduced in IDP version 1.1.5, is responsible for storing configuration backups of the inventory and can be used to easily restore the default configuration of specific elements.

- The **Software Update Manager** allows users to upload an approved software image to elements and to signal elements that do not run the expected software version.

- The **Rack & Facility Manager** automatically creates the hierarchy of DataMiner rack views without any operator intervention. Using the element properties, the system understands how to represent an element in DataMiner Visual Overview, where to map the element in the DataMiner Surveyor hierarchy, and how to position it in the physical rack layouts in DataMiner.
