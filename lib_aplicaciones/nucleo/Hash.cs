using System.Security.Cryptography;
using System.Text;

namespace lib_aplicaciones.nucleo;

public static class Hash
{
    public static string Sha256(string texto)
        => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(texto))).ToLowerInvariant();
}
