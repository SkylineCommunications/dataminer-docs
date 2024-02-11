# Getting Started with Node Edge

This tutorial will show you how to start using Node Edge by implementing a basic example. More information about Node Edge can be found here.
The content and screenshots of this tutorial were created in DataMiner version 10.4.1

Expected duration: 20 minutes

## Prerequisites

- A DataMiner system running at least version 10.1.5/10.2

## Overview

- Step 1: Deploy the package from the catalog
- Step 2: Create a node edge diagram between switch and router
- Step 3: Enhance the node edge diagram with PCs

## Step 1: Deploy the tutorial package from the catalog

1. Go to the catalog and deploy the package [Kata Node Edge](https://catalog.dataminer.services/details/package/5838)
The package contains the following components:

- Automation script *JSON Reader* (available in the Automation module, folder Automation Scripts/GQI/Data sources)
- Files (available in the Documents Module, folder GQI data sources)
  - list_pc.json
  - list_network_devices.json
  - list_connection_single.json
  - list_connection_bidirectional.json
  - list_interface.json
  - list_router.json
  - list_switch.json
- Dashboards:
  - Node_Edge
  - Node_Edge_Extra

## Step 2: Create a node edge diagram between switch and router
