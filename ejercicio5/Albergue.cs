public class Albergue
{
    private string Nombre { get; }
    public int Capacidad { get; }
    private Direccion Direccion { get; }
    // con protected da error
    protected List<string> Servicios { get; } = new();
    protected List<Reservas> Reserva { get; } = new();
    public double Precio { get; set; }
    // no son propiedades?
    // protected int PlazasOcupadas {get;}
    // public int PorcentajeOcupacion {get;}
    public Albergue(string nombre, int capacidad, double precio, Direccion direccion, int plazasOcupadas, int porcentajeOcupacion)
    {
        Nombre = nombre;
        Capacidad = capacidad;
        Precio = precio;
        Direccion = direccion;
    }
    // así?????????
    public int PlazasOcupadas
    {
        get
        {
            int total = 0;
            foreach(var r in Reserva)
                total += r.Plazas;
            return total;
        }
    }
    public int PorcentajeOcupacion
        {
            get
            {
                if (Capacidad == 0) return 0;
                return (int)Math.Round((double)PlazasOcupadas / Capacidad * 100);
            }
        }

    public void AgregaServicio(string servicio)
    {
        if(!Servicios.Contains(servicio))
            Servicios.Add(servicio);
    }
    protected virtual bool AdmiteReserva(int plazas, bool esTemporadaAlta) => plazas > 0 && PlazasOcupadas + plazas <= Capacidad;
    // {
    //     return plazas > 0 && PlazasOcupadas + plazas <= Capacidad;
    // }
    private void AñadeReservaInterna(Reservas r) => Reserva.Add(r);
    public bool RegistraReserva(int plazas, bool esTemporadaAlta)
    {
        if(AdmiteReserva(plazas, esTemporadaAlta))
        {
            AñadeReservaInterna(new Reservas(plazas, esTemporadaAlta));
            return true;
        }

        return false;
    }
    public virtual double CalculaPrecioActual() => Precio;
    public virtual string InformacionComplementaria() => "Sin información complementaria";
    // Surf Point (AlbergueCostero) - Capacidad: 55, Ocupación: 18%, Servicios: [Clases de surf, Parking]
    // Precio base: 20 ,Precio actual: 20
    public override string ToString()
    {
        return $"""
                {Nombre} ({this.GetType().Name}) - Capacidad: {Capacidad}, Ocupación: {PorcentajeOcupacion}%, Servicios: {Servicios}
                Precio base: {Precio} ,Precio actual: {CalculaPrecioActual():F1}
                """;
    }
}