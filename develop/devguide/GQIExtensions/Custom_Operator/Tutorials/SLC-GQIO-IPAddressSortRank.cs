using Skyline.DataMiner.Analytics.GenericInterface;
using System.Net;

[GQIMetaData(Name = "Rank IP address")]
public sealed class IPAddressRanker : IGQIColumnOperator, IGQIRowOperator, IGQIInputArguments
{
    private readonly GQIColumnDropdownArgument _ipAddressColumnArg;
    private readonly GQIColumn<int> _ipAddressRankColumn;

    private GQIColumn<string> _ipAddressColumn;

    public IPAddressRanker()
    {
        _ipAddressColumnArg = new GQIColumnDropdownArgument("IP address")
        {
            Types = new[] { GQIColumnType.String },
            IsRequired = true,
        };
        _ipAddressRankColumn = new GQIIntColumn("IP address rank");
    }

    public GQIArgument[] GetInputArguments()
    {
        return new GQIArgument[] { _ipAddressColumnArg };
    }

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _ipAddressColumn = (GQIColumn<string>)args.GetArgumentValue(_ipAddressColumnArg);
        return default;
    }

    public void HandleColumns(GQIEditableHeader header)
    {
        // Add the new IP address rank column
        header.AddColumns(_ipAddressRankColumn);
    }

    public void HandleRow(GQIEditableRow row)
    {
        // Retrieve the IP address in the current row
        string ipAddress = row.GetValue(_ipAddressColumn);

        // Calculate its ranking
        int ranking = GetRanking(ipAddress);

        // Save it in the new IP address rank column
        row.SetValue(_ipAddressRankColumn, ranking);
    }

    private int GetRanking(string ipAddress)
    {
        // Parse the IP address into its constituent octets
        byte[] bytes = IPAddress.Parse(ipAddress).GetAddressBytes();

        // Combine the octects bitwise to achieve the desired sort order
        uint ranking = (uint)bytes[0] << 24 | (uint)bytes[1] << 16 | (uint)bytes[2] << 8 | bytes[3];
        return UnsignedToSigned(ranking);
    }

    private int UnsignedToSigned(uint ranking)
    {
        if (ranking > int.MaxValue)
            return (int)(ranking - int.MaxValue);
        else
            return (int)ranking - int.MaxValue;
    }
}