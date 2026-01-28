using System.Resources;

public class AlbergueCostero : Albergue
{
    public AlbergueCostero(string nombre, int capacidad, double precioBase, Direccion direccion, int plazasOcupadas, int porcentajeOcupacion) : base(nombre, capacidad, precioBase, direccion, plazasOcupadas, porcentajeOcupacion)
    {
        AgregaServicio("Clases de surf");
        AgregaServicio("Parking");
    }
    protected override bool AdmiteReserva(int plazas, bool esTemporadaAlta)
    {
        if (!base.AdmiteReserva(plazas, esTemporadaAlta))
            return false;

        if (esTemporadaAlta && plazas > (Capacidad - PlazasOcupadas) * 0.6)
            return false;

        return true;
    }
    public override double CalculaPrecioActual()
    {
        double precio = Precio;

        // contar si es temporada alta en la última reserva registrada => Precio + 3
        if(Reserva.Count() > 0 && Reserva.Last().EsTemporadaAlta)
            precio += 3;

        if (PorcentajeOcupacion >= 40)
            precio += 2;

        return precio;
    }

    public override string InformacionComplementaria() => "Oleaje estimado: Moderado";
}