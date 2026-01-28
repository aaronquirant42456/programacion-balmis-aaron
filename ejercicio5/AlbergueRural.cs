public class AlbergueRural : Albergue
{
    public AlbergueRural(string nombre, int capacidad, double precio, Direccion direccion, int plazasOcupadas, int porcentajeOcupacion): base(nombre, capacidad, precio, direccion, plazasOcupadas, porcentajeOcupacion)
    {
        AgregaServicio("Desayuno");
        AgregaServicio("Cena");
    }
    protected override bool AdmiteReserva(int plazas, bool esTemporadaAlta)
    {
        if (!base.AdmiteReserva(plazas, esTemporadaAlta)) 
            return false;
        // hay que rehcazar si la reserva es > 50% capacidad
        return plazas <= Capacidad * 0.5;
    }
    public override double CalculaPrecioActual()
    {
        double precio = Precio * 1.15; // incluye desayuno y cena
        bool tempAlta = false;

        foreach(var r in Reserva)
        {
            if(r.EsTemporadaAlta)
                tempAlta = true;
        }
        if (tempAlta && PorcentajeOcupacion >= 20)
            precio *= 2.15;

        return precio;
    }

    public override string InformacionComplementaria()
    {
        return $"""
                Clima previsto: Nieve ligera
                """;
    }
}