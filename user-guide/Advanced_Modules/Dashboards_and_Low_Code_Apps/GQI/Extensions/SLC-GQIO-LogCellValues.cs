using Skyline.DataMiner.Analytics.GenericInterface;

[GQIMetaData(Name = "Log cell values")]
public sealed class LogOperator : IGQIRowOperator, IGQIOnInit, IGQIInputArguments
{
    private readonly GQIColumnDropdownArgument _columnToLogArgument = new GQIColumnDropdownArgument("Column to log") { IsRequired = true };

    private IGQILogger _logger;
    private GQIColumn _columnToLog;

    public OnInitOutputArgs OnInit(OnInitInputArgs args)
    {
        _logger = args.Logger;

        // Configure the logger to include logs for the 'Debug' level
        _logger.MinimumLogLevel = GQILogLevel.Debug;

        return default;
    }

    public GQIArgument[] GetInputArguments()
    {
        return new[] { _columnToLogArgument };
    }

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _columnToLog = args.GetArgumentValue(_columnToLogArgument);

        // Log the name of the selected column
        _logger.Information($"Column to log: {_columnToLog.Name}");

        return default;
    }

    public void HandleRow(GQIEditableRow row)
    {
        var rowKey = row.Key;
        var cellValue = row.GetValue(_columnToLog.Name);

        // Log the cell value with the 'Debug' log level
        _logger.Debug($"Value for '{rowKey}' is '{cellValue}'");
    }
}