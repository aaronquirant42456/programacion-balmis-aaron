public class AlbergueUrbano : Albergue
{
    public AlbergueUrbano(string nombre, int capacidad, double precioBase, Direccion direccion, int plazasOcupadas, int porcentajeOcupacion) : base(nombre, capacidad, precioBase, direccion, plazasOcupadas, porcentajeOcupacion)
    {
        AgregaServicio("WiFi");
        AgregaServicio("Lavandería");
    }

    protected override bool AdmiteReserva(int plazas, bool esTemporadaAlta) => base.AdmiteReserva(plazas, esTemporadaAlta);
    
    public override double CalculaPrecioActual()
    {
        double precio = Precio;

        if (PorcentajeOcupacion >= 60)
            precio *= 1.10;
            
        return precio;
    }
}