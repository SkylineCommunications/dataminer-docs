---
uid: Connector_help_TDF_Conducteur_Application
---

# TDF Conducteur Application

This virtual connector allows you to create SRM bookings by importing a CSV file with the booking information. The connector is intended to be used exclusively by TDF.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

The element consists of two pages:

- **General**: The **Input Files** table allows you to import the CSV input files. When you have selected the input file and Start Date in the **Input Files** table, click the **Process Files** button to process the file. The **File Data State** table will have information about the parsed files and a Validation State indicating the result of the validation checks of each entry.
- **Bookings**: Displays information about the **Scheduled** and **Non Scheduled Bookings**. You can also configure the **booking windows** here.

The **input files** should be placed in the folder *C:\Skyline DataMiner\Documents\TDF Conducteur Application\Input Files*.

The CSV files need to have the following **header**: *Num_Emission,Client,Activation,Emetteur,Jour Debut,Expiration,Heure Envoi Parametre,Recurs_Interval,Recurs_Jour,Recurs_Ordinal,Recurs_JourSemaine,Frequence,Azimut,Config,Puissance Demandee,Type de Modulation,Mode DACM,Heure Debut Cde Etat Emt,Cde Etat Emt,Heure Circuit,Circuit,Secours Audio 1,Secours Audio 2,Heure d'arret Circuit,Heure fin Etat Emt,,Mise a l'Heure,Mode Adptation,Mode Clipping,Comblage,Editeur,Zone Cible,Langue,Puissance contractuelle,Type Contenu Audio,,Commentaires.*

The connector will create the bookings in the system based on the information in the input files. If the bookings are in the **Scheduled Bookings Window**, the connector will trigger the Automation script "TDF SRM Ingestion" and create the bookings in the system. If the Bookings are in the **Non** **Scheduled Bookings Window**, this information will be added in the **Non Scheduled Bookings** table.
