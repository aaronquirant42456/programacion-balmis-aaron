namespace Ejercicio4;
public class SierraElectrica : Herramienta
{
    public int PotenciaW {get;}
    public int DiametroHojaMn {get;}
    public SierraElectrica(Guid id, string nombre, string marca, double peso, double precio, int potenciaW, int diametroHojaMm) : base(id, nombre, marca, peso, precio)
    {
        PotenciaW = potenciaW;
        DiametroHojaMn = diametroHojaMm;
    }

    public string Corta(string material, int grosorMm)
    {
        return $"""
                Cortar("{material}", {grosorMm}mm) OK
                """;
    }
    public override double Precio => PotenciaW > 1300 ? PrecioBase * 1.10 : PrecioBase;
    // {
    //     if(PotenciaW > 1300)
    //         return PrecioBase += 0.10;
    //     else
    //         return PrecioBase;
    // }
    public override string Usa()
    {
        return "Realiza cortes rectos en madera y tableros.";
    }
    public override string ToString()
    {
        return $"{base.ToString()}, Potencia: {PotenciaW}, Hoja: {DiametroHojaMn}mm";
    }
}