---
uid: Connector_help_UPC_Nederland_ProdIS
---

# UPC Nederland ProdIS

This connector will communicate to the UPC Nederland ADI Importer.

## About

The connector will read the different messages placed in the providers folder by the Spider device and move them to another folder.
These messages will be placed in a table and can be requested by the UPC Nederland ADI Importer.

## Installation and configuration

This a virtual connector so there aren't any settings when you create an element.

## Usage

### General

On the general page you can set the settings for the credentials.
You can also set the path to the *ContentStore* folder,
the number of days the messages should be stored in the table and the **Dma and Element ID** from the ADI Importer.

### Assets Overview

This page is the table which holds all the important information of the messages placed in the folders *Loaded, Rejected* and *Failed*.

### Offers Overview

This page is the table which holds the important information for the messages placed in the folder *Loaded\offering*.

### Communication with the other element.

The ADI Importer will request some assets or offers. Then the ProdIS will check if those are in the table and will send the information back to the ADI Importer.
