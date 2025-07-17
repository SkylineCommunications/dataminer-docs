---
uid: Manually_removing_old_alarms_from_ES
---

# Manually removing old alarms from an Elasticsearch cluster

In some cases, it may be necessary to manually remove old alarms from an Elasticsearch cluster, for example because exceptional alarm storms have flooded the cluster with alarm data, and the cluster is likely to run out of disk space in the near future as a consequence.

To do so, you can use queries similar to the examples below, which you can execute through [Postman](xref:Postman) on the Elasticsearch cluster.

- Search query for all alarms older than April 15th, 2022:

  - Endpoint: `GET http://[Elasticsearch node IP]:9200/dms-alarms/_search`

  - Body:

    ```json
    {
      "query": {
        "bool" : {
          "must" : [
            {
            "range": {
                  "CreationTime": {"lte" : "2022-04-15" }}
             }
          ]}
       }
    }
    ```

- Delete query for all alarms older than April 15th, 2022:

  - Endpoint: `POST http://[Elasticsearch node IP]:9200/dms-alarms/_delete_by_query`

  - Body:

    ```json
    {
      "query": {
        "bool" : {
          "must" : [
            {
            "range": {
                  "CreationTime": {"lte" : "2022-04-15" }}
             }
          ]}
       }
    }
    ```

> [!NOTE]
> To execute the same queries for information events, replace "dms-alarms" with "dms-info".
