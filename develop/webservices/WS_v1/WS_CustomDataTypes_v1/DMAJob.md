---
uid: DMAJob
---

# DMAJob

| Item         | Format                 | Description                                                                                |
|--------------|------------------------|--------------------------------------------------------------------------------------------|
| ID           | String                 | The ID of the job.                                                                         |
| DomainID     | String                 | The domain of the job. Added from DataMiner 10.0.9 onwards.                                |
| Name         | String                 | The name of the job.                                                                       |
| TimeStartUTC | Long integer           | The start time of the job in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| TimeEndUTC   | Long integer           | The end time of the job in UTC format (milliseconds since midnight January 1, 1970 GMT).   |
| Sections     | Array of [DMAJobSection](xref:DMAJobSection) | The sections of the job.                                             |
