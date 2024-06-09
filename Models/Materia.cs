namespace Inscripciones.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int anioCarreraId { get; set; }
        public anioCarrera? AnioCarrera { get; set; }
    }
}
