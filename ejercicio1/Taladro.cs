public class Taladro : Herramienta
{
    // cuando pone readonly, es solo get
    public int Potencia { get; }
    public int VelocidadMaxima { get; }

    public Taladro(Guid id, string nombre, string marca, double peso, double precio, int potencia, int velocidadMaxima) : base(id, nombre, marca, peso, precio)
    {
        Potencia = potencia;
        VelocidadMaxima = velocidadMaxima;
    }

    // poner override en el la clase hijo, y llamar a la propiedad con base.propiedad
    public override double Precio => base.Precio * 0.15;
    public override string ToString()
    {
        return base.ToString() + $"""
                Potencia: {Potencia}W, Velocidad: {VelocidadMaxima} RPM
                """;
    }
}