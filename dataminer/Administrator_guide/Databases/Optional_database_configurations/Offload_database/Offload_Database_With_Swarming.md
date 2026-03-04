---
uid: Offload_Database_With_Swarming
keywords: central database, swarming
---

# Offload database configuration with Swarming enabled

When [Swarming](xref:Swarming) is enabled, some offload features are disabled.

Starting from DataMiner 10.6.4/10.7.0<!-- RN 44751/44767 -->, provided the `info` and `alarm` tables have a compatible primary key definition, all offloads are supported except for the `alarm_property`, `brainlink`, `interface_alarm`, and `service_alarm` tables.

In earlier DataMiner versions, all offload configuration features are disabled when Swarming is enabled.

## Updating info and alarm tables for compatibility with Swarming

To enable swarming, the `info` and `alarm` tables in the offload database need to have a primary key definition that is compatible with Swarming. Enabling Swarming will be blocked if the primary key is not compatible.

If the offload database has been set up in DataMiner 10.6.4/10.7.0 or later, these primary key definitions are automatically created when the database is created, and no further action is needed.

> [!TIP]
> If you are unsure whether your offload database is compatible with Swarming, you can run a [Swarming prerequisites check](xref:EnableSwarming#running-a-prerequisites-check) to verify this.

To update the primary key definition of the `info` and `alarm` tables, you can run the queries mentioned below on the offload database. Choose the queries that match your database type.

However, when you do so, keep the following in mind:

- Before running these scripts, ensure you have a **backup** of your database.

- These operations may **lock the tables** temporarily during execution.

- These actions might take a **long time** to complete, especially if the tables contain a large amount of data.

- If you have **external applications or scripts** that interact with the offload database and rely on the primary key structure, make sure to **update them** to accommodate the new primary key structure after you have run these scripts. Examples include querying by DMA ID and ID, which might now return multiple results instead of at most one.

### MySQL

```sql
-- Update ALARM table primary key to include EId
ALTER TABLE `alarm` DROP PRIMARY KEY, ADD PRIMARY KEY(`Id`, `DmaId`, `EId`);

-- Update INFO table primary key to include EId
ALTER TABLE `info` DROP PRIMARY KEY, ADD PRIMARY KEY(`Id`, `DmaId`, `EId`);
```

### MSSQL

These scripts assume the existing primary key constraint names match those in the original table definitions (`[PK_Alarm]` and `[PK_info_1]`). If your database has different constraint names, you will need to adjust the `ALTER TABLE` statements accordingly.

```sql
-- Update ALARM table primary key to include EId
ALTER TABLE [dbo].[alarm] DROP CONSTRAINT [PK_Alarm];
ALTER TABLE [dbo].[alarm] ADD CONSTRAINT [PK_Alarm] PRIMARY KEY CLUSTERED ([Id] ASC, [DmaId] ASC, [EId] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];

-- Update INFO table primary key to include EId
ALTER TABLE [dbo].[info] DROP CONSTRAINT [PK_info_1];
ALTER TABLE [dbo].[info] ADD CONSTRAINT [PK_info_1] PRIMARY KEY CLUSTERED ([id] ASC, [DmaId] ASC, [EId] ASC) WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY];
```

> [!NOTE]
> If you downgrade to a DataMiner version prior to 10.6.4/10.7.0 after running these scripts, the downgrade will report these two errors:
>
> - `Exception during unicode conversion for table alarm : Violation of PRIMARY KEY constraint 'PK_alarm_temp_1'. Cannot insert duplicate key in object 'dbo.alarm_temp'. The duplicate key value is (xxx, xxx).`
> - `Exception during unicode conversion for table info : Violation of PRIMARY KEY constraint 'PK_info_temp_1'. Cannot insert duplicate key in object 'dbo.info_temp'. The duplicate key value is (xxx, xxx).`
>
> These errors are expected and can be ignored, as the primary key definitions will no longer be compatible with the older version. There will be no further impact.

### Oracle

These scripts assume the existing primary key constraint names match those in the original table definitions (`[ALARM_PK]` and `[INFO_PK]`). If your database has different constraint names, you will need to adjust the `ALTER TABLE` statements accordingly.

```sql
-- Update ALARM table primary key to include EId
ALTER TABLE "ALARM" DROP CONSTRAINT "ALARM_PK";
ALTER TABLE "ALARM" ADD CONSTRAINT "ALARM_PK" PRIMARY KEY ("ID", "DMAID", "EID");

-- Update INFO table primary key to include EId
ALTER TABLE "INFO" DROP CONSTRAINT "INFO_PK";
ALTER TABLE "INFO" ADD CONSTRAINT "INFO_PK" PRIMARY KEY ("ID", "DMAID", "EID");
```
