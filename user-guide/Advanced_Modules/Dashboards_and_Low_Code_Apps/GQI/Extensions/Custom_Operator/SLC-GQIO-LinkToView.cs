using Skyline.DataMiner.Analytics.GenericInterface;
using Skyline.DataMiner.Net;

[GQIMetaData(Name = "Link to view")]
public sealed class LinkToViewOperator : IGQIRowOperator, IGQIInputArguments
{
    private readonly GQIColumnDropdownArgument _viewIDColumnArgument;

    private GQIColumn<int> _viewIDColumn;

    public LinkToViewOperator()
    {
        _viewIDColumnArgument = new GQIColumnDropdownArgument("View id column")
        {
            IsRequired = true,
            Types = new[] { GQIColumnType.Int },
        };
    }

    public GQIArgument[] GetInputArguments() => new[] { _viewIDColumnArgument };

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _viewIDColumn = (GQIColumn<int>)args.GetArgumentValue(_viewIDColumnArgument);
        return default;
    }

    public void HandleRow(GQIEditableRow row)
    {
        // Retrieve the view id from this row
        if (!row.TryGetValue(_viewIDColumn, out int viewID))
            return;

        // Wrap it in a ViewID object ref
        var objectRef = new ViewID(viewID);

        // Create a new metadata instance for the object
        var objectRefMetadata = new ObjectRefMetadata { Object = objectRef };

        // Link it to the row
        row.Metadata = new GenIfRowMetadata(new[] { objectRefMetadata });
    }
}