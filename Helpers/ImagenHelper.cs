using System.Globalization;
using System.Text;

namespace VentaAccesorioss.Helpers;

public static class ImagenHelper
{
    public static string Para(string? categoria)
    {
        var c = Normalizar(categoria);
        var archivo =
            c.Contains("funda") ? "funda.jpg" :
            c.Contains("cargador") ? "cargador.jpg" :
            c.Contains("cable") ? "cable.jpg" :
            c.Contains("audifono") ? "audifonos.jpg" :
            c.Contains("bateria") || c.Contains("power") ? "bateria.jpg" :
            c.Contains("mica") ? "mica.jpg" : "default.svg";
        return $"/img/productos/{archivo}";
    }

    private static string Normalizar(string? t)
    {
        if (string.IsNullOrWhiteSpace(t)) return "";
        var d = t.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);
        return new string(d.Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark).ToArray());
    }
}