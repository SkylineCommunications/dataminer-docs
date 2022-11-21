---
uid: Amazon_Keyspaces_Service
---

# Amazon Keyspaces Service

From DataMiner 10.3(CU0)/10.3.1 onwards, it is possible to use the Amazon Keyspaces Service on AWS.

## Configuring TLS

Amazon keyspaces requires the Starfield certificate to be present on the local Windows machine DataMiner is running on.
To install the certificate:

1. Download the sf-class2-root.crt certificate file from [here](https://certs.secureserver.net/repository/sf-class2-root.crt).
1. Add the downloaded file to the Trusted Root Certification Authorities section of the Windows certificate store:
1. Run the 'mmc' command on the machine you want to import the certificate on. (Windows + R -> 'mmc')
1. File -> Add/Remove snap-in
1. Select 'Certificates from the available snap-ins list and click the 'Add >' button
1. Select 'Computer account' and click the 'Next' button
1. Select 'Local computer' (should be selected by default) and click the 'Finish' button
1. Click the 'Ok' button at the bottom
1. In the Console Root tree view on the left, select the following folder: Certificates (Local Computer) > Trusted Root Certification Authorities -> Certificates
1. Right click the Certificates folder you just selected and choose All Tasks -> Import...
1. Click Next until you need can browse to the location of the certificate file. After that keep selecting Next or Finish until the certificate is sucessfully imported.
1. You should now see the certificate listed as indicated in the screenshot below.
   
![Add Certificate](~/user-guide/images/aks_add_certificate.png)

## Connecting your DMS to your Amazon Keyspaces database

> [!IMPORTANT]
> An amazon keyspaces database requires a separate search database.
>
> Information on how to configure a search database, such as ElasticSearch, can be found [here](xref:Elasticsearch_database).

1. You can configure the connection to your Amazon keyspaces cluster via DataMiner Cube. Head to System Center, Database and select `Database per cluster`.
    - The database should be of type 'Amazon Keyspaces'.
    - The *Keyspace prefix* field contains the name all amazon keyspaces will be prefixed with. This should be identical for all agents in the same cluster.
    - The *DB Server* field should contain the url of the [global endpoint](https://docs.aws.amazon.com/keyspaces/latest/devguide/programmatic.endpoints.html) of the region your amazon keyspaces cluster is in. (e.g. 'cassandra.eu-north-1.amazonaws.com')
    - The *User* field contains the username of your AWS user account.
    - The *Password* field contains the password of your AWS user account.
    
1. Restart the DMS. This can take multiple minutes the first time since the keyspaces and tables will be created. Relevant logging in case of any trouble can be found in the *sldbconnection.txt* file.

![Cube Database Configuration](~/user-guide/images/aks_cube_config.png)

