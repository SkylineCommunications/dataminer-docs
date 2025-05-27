using System.Collections.Generic;
using System.Linq;
using Skyline.DataMiner.Analytics.GenericInterface;
using Skyline.DataMiner.Core.DataMinerSystem.Common;
using Skyline.DataMiner.Net;

[GQIMetaData(Name = "Get elements in view")]
public sealed class ViewElementsDataSource : IGQIDataSource, IGQIOnInit, IGQIInputArguments
{
    private readonly GQIIntArgument _viewArgument = new GQIIntArgument("View id") { IsRequired = true };
    private readonly GQIStringColumn _nameColumn = new GQIStringColumn("Name");

    private GQIDMS _dms;
    private int _viewID;

    public OnInitOutputArgs OnInit(OnInitInputArgs args)
    {
        _dms = args.DMS;
        return default;
    }

    public GQIArgument[] GetInputArguments() => new[] { _viewArgument };

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _viewID = args.GetArgumentValue(_viewArgument);
        return default;
    }

    public GQIColumn[] GetColumns() => new[] { _nameColumn };

    public GQIPage GetNextPage(GetNextPageInputArgs args)
    {
        var rows = GetElements()
            .Select(CreateElementRow)
            .ToArray();
        return new GQIPage(rows);
    }

    private IList<IDmsElement> GetElements()
    {
        var connection = _dms.GetConnection();
        var dms = connection.GetDms();

        var view = dms.GetViewReference(_viewID);
        return view.Elements;
    }

    private GQIRow CreateElementRow(IDmsElement element)
    {
        // Create a new row with:

        // 1. A unique key
        var elementID = new ElementID(element.AgentId, element.Id);
        var key = elementID.GetKey();

        // 2. Cells containing element data
        var nameCell = new GQICell { Value = element.Name };
        var cells = new[] { nameCell };

        // 3. Metadata to link the row to the element
        var elementMetadata = new ObjectRefMetadata { Object = elementID };
        var rowMetadata = new GenIfRowMetadata(new[] { elementMetadata });

        return new GQIRow(key, cells) { Metadata = rowMetadata };
    }
}