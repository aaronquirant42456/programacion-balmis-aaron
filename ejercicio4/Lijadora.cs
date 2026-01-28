public class Lijadora : Herramienta
{
    public int Rpm {get;}
    public int DiametroDiscoMm {get;}
    public Lijadora(Guid id, string nombre, string marca, double peso, double precioBase, int rpm, int diametroDiscoMm) : base(id, nombre, marca, peso, precioBase)
    {
        Rpm = rpm;
        DiametroDiscoMm = diametroDiscoMm;
    }
    public double Pule(double superficieM2) => (superficieM2 * 60) / (Rpm * 0.012);
    // {
    //     return (superficieM2 * 60) / (Rpm * 0.012);
    // }
    public new double Precio => Rpm > 10000 ? Math.Round(PrecioBase * 0.90, 2) : PrecioBase;
    // {
    //     if(Rpm < 1000)
    //         return PrecioBase += 0.10;
    //     else
    //         return PrecioBase;
    // }
    public override string Usa()
    {
        return "Lija y suaviza superficies de madera.";
    }
    public override string ToString()
    {
        return $"{base.ToString()}, RPM: {Rpm}, Disco: {DiametroDiscoMm}mm";
    }

}