namespace ProtectInf3;

public static class ByteUintConverter
{
    public static byte[] ConvertToBytes(IReadOnlyList<uint> data)
    {
        var result = new byte[data.Count * 4];
        for (var i = 0; i < data.Count; i++)
        {
            result[i * 4 + 3] = (byte)(data[i] & 0xff);
            result[i * 4 + 2] = (byte)((data[i] >> 8) & 0xff);
            result[i * 4 + 1] = (byte)((data[i] >> 16) & 0xff);
            result[i * 4] = (byte)((data[i] >> 24) & 0xff);
        }

        return result;
    }

    public static uint[] ConvertToUint(IReadOnlyList<byte> inputData)
    {
        var length = inputData.Count / 4 + ((inputData.Count & 3) == 0 ? 0 : 1);
        if ((length & 3) != 0)
        {
            length += 4 - length % 4;
        }

        var inputLength = inputData.Count;
        var result = new uint[length];
        for (var i = 0; i < result.Length; i ++)
        {
            result[i] = i * 4 < inputLength ? inputData[i * 4] : (byte)0;
            result[i] = (result[i] << 8) | (i * 4 + 1 < inputLength ? inputData[i * 4 + 1] : (byte)0);
            result[i] = (result[i] << 8) | (i * 4 + 2 < inputLength ? inputData[i * 4 + 2] : (byte)0);
            result[i] = (result[i] << 8) | (i * 4 + 3 < inputLength ? inputData[i * 4 + 3] : (byte)0);
        }

        return result;
    }
}