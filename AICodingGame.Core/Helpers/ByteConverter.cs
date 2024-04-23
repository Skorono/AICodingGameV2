using System.Text;
using System.Text.RegularExpressions;

namespace AICodingGame.Core.Helpers;

public static class ByteConverter
{
    public static byte[] StringToByteArray(this String hex)
    {
        var regex = new Regex(@"\\x([0-9a-fA-F]{2})");
        var matches = regex.Matches(hex);
        byte[] byteArray = new byte[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            byteArray[i] = Convert.ToByte(matches[i].Groups[1].Value, 16);
        }

        return byteArray;
    }
    
    public static string ByteArrayToString(this byte[] ba)
    {
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte b in ba)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();
    }
}