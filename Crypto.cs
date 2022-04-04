using System.Text;
using Org.BouncyCastle;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System.Security.Cryptography;


/// <summary>
/// Всё в одном классе т. к. возможно вы имели в виду класс program.cs когда говорили, что их должно быть 4.
/// В любом случае, вынести функцию несложно.
/// </summary>
public class Crypto{

    public string key;
    public string text;
    public string HMAC;

    public Crypto(string _text){
        text = _text;

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            byte[] tokenData = new byte[64];
            rng.GetBytes(tokenData);

            key = GenerateKey(Convert.ToBase64String(tokenData));
            HMAC = GenerateHMAC(text, key);
        }

        

    }

    public string GenerateKey(string input){
        var hashAlgorithm = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(256);
        byte[] byte_array = System.Text.Encoding.UTF8.GetBytes(input);
        hashAlgorithm.BlockUpdate(byte_array, 0, byte_array.Length);
        byte[] result = new byte[32]; // 512 / 8 = 64
        hashAlgorithm.DoFinal(result, 0);
        string hashString = BitConverter.ToString(result);
        hashString = hashString.Replace("-", "").ToUpperInvariant();
        return hashString;
    }

    public string GenerateHMAC(string text, string key)
    {
        var hmac = new HMac(new Sha3Digest(256));
        hmac.Init(new KeyParameter(Encoding.UTF8.GetBytes(key)));
        byte[] result = new byte[hmac.GetMacSize()];
        byte[] bytes = Encoding.UTF8.GetBytes(text);

        hmac.BlockUpdate(bytes, 0, bytes.Length);
        hmac.DoFinal(result, 0);

        string hashString = BitConverter.ToString(result);
        hashString = hashString.Replace("-", "").ToUpperInvariant();
        return hashString;
    }

}