namespace Inscripciones.Models
{
    public class anioCarrera
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int carreraId { get; set; }
        public Carrera? Carrera { get; set; }
    }
}
