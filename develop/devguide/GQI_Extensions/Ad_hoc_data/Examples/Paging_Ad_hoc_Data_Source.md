---
uid: Paging_Ad_hoc_Data_Source
---

# Paging data from the server

This example demonstrates how a GQI ad hoc data source can efficiently return a large set of DOM instances by requesting them from the server in smaller, consecutive pages. Instead of loading the full result set into memory, a paging session is created once and then advanced as the GQI engine requests additional data. This improves perceived responsiveness (initial rows appear sooner) and reduces peak memory usage.

The PagingHelper used here is a generic concept that is reused across several APIs. Besides DOM instances, similar paging helpers exist for other objects such as SRM Resources, ReservationInstances (Bookings), and Profiles-related data. The usage pattern is the same: prepare a paging session with a query, keep the helper instance alive for the duration of the GQI session, and advance it only when the next page is explicitly requested.

Selecting an appropriate page size is a balance between transfer overhead and unused data. Smaller pages mean more round trips but less unused data in scenarios where only a small subset is ever displayed (e.g. a Low-Code App grid that typically shows 20 rows and is seldom scrolled). Larger pages reduce the number of server calls but increase the chance that a sizeable portion of the returned rows is never rendered. As a starting point:

- Components that expose only a few tens of rows at a time: consider lowering below the default 500 (e.g. 50–150).
- Scenarios with predictable full traversal (e.g. timeline component): larger sizes (500 or higher) can reduce overhead.
Adjust based on observed user interaction patterns and network latency.

In summary, use a single paging helper per logical query, advance it only when asked for the next page, and tune the page size to the consumption pattern of the client to achieve an optimal balance between responsiveness and efficiency.

```csharp
using System;
using System.Linq;
using Skyline.DataMiner.Analytics.GenericInterface;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel;
using Skyline.DataMiner.Net.ManagerStore;
using Skyline.DataMiner.Net.Messages.SLDataGateway;
using Skyline.DataMiner.Net.Sections;

namespace GQI_DataSource_PagingExample
{
    [GQIMetaData(Name = "DOM Jobs")]
    public class MyDataSource : IGQIDataSource, IGQIOnInit
    {
        private GQIDMS _dms;
        private PagingHelper<DomInstance> _pagingHelper;

        public OnInitOutputArgs OnInit(OnInitInputArgs args)
        {
            _dms = args.DMS;
            return null;
        }

        public GQIColumn[] GetColumns()
        {
            return new GQIColumn[]
            {
                new GQIStringColumn("Event Name"),
                new GQIDateTimeColumn("Start"),
                new GQIDateTimeColumn("End")
            };
        }

        public GQIPage GetNextPage(GetNextPageInputArgs args)
        {
            if (_pagingHelper == null)
            {
                // This is the first call, create the paging helper
                _pagingHelper = GetNewPagingHelper();
            }

            if (!_pagingHelper.HasNextPage())
            {
                // There are no pages anymore
                return new GQIPage(Array.Empty<GQIRow>()) { HasNextPage = false };
            }

            // Request the next page from the DB
            _pagingHelper.MoveToNextPage();

            // Convert the page of DOM instances to GQI rows
            var instances = _pagingHelper.GetCurrentPage();
            var rows = instances.Select(ConvertToGqiRow).ToArray();

            return new GQIPage(rows)
            {
                HasNextPage = _pagingHelper.HasNextPage()
            };
        }

        private PagingHelper<DomInstance> GetNewPagingHelper()
        {
            var domHelper = new DomHelper(_dms.SendMessages, JobIds.ModuleId);
            var query = DomInstanceExposers.DomDefinitionId.Equal(JobIds.DomDefinitionId.Id);

            // Default page size is 500, but can be lowered depending on the expected amount of data
            // and how it is displayed. It is important to find the right balance between small pages
            // and not too many requests.
            return domHelper.DomInstances.PreparePaging(query, 500); 
        }

        public static GQIRow ConvertToGqiRow(DomInstance instance)
        {
            var cells = new[]
            {
                new GQICell { Value = instance.GetFieldValue<string>(JobIds.JobInfoSectionDefinitionId, JobIds.NameFieldDescriptorId).Value },
                new GQICell { Value = instance.GetFieldValue<DateTime>(JobIds.JobInfoSectionDefinitionId, JobIds.StartFieldDescriptorId).Value.ToUniversalTime() },
                new GQICell { Value = instance.GetFieldValue<DateTime>(JobIds.JobInfoSectionDefinitionId, JobIds.EndFieldDescriptorId).Value.ToUniversalTime() }
            };

            var reference = new ObjectRefMetadata
            {
                Object = new DomInstanceId(instance.ID.Id) { ModuleId = JobIds.ModuleId }
            };

            return new GQIRow(cells) { Metadata = new GenIfRowMetadata(new[] { reference }) };
        }

        public class JobIds
        {
            public const string ModuleId = "dom_jobs";
            public static readonly DomDefinitionId DomDefinitionId = new DomDefinitionId(Guid.Parse("e37fa9ba-1d6a-4789-b85d-8190213f5be2"));
            public static readonly SectionDefinitionID JobInfoSectionDefinitionId = new SectionDefinitionID(Guid.Parse("0db4c52a-cbe1-46e4-8e0f-f76adde86819"));
            public static readonly FieldDescriptorID NameFieldDescriptorId = new FieldDescriptorID(Guid.Parse("01917961-b626-47df-887e-b5527da6c20a"));
            public static readonly FieldDescriptorID StartFieldDescriptorId = new FieldDescriptorID(Guid.Parse("a2cf5218-e595-464d-8700-141c3ef2ddfe"));
            public static readonly FieldDescriptorID EndFieldDescriptorId = new FieldDescriptorID(Guid.Parse("5a05e858-64c6-4101-b6b3-8527e68234d5"));
        }
    }
}
```
