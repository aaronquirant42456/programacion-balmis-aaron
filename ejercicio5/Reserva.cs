public class Reservas
{
    public int Plazas {get;}
    public bool EsTemporadaAlta {get;}
    public Reservas(int plazas, bool esTemporadaAlta)
    {
        Plazas = plazas;
        EsTemporadaAlta = esTemporadaAlta;
    }
}