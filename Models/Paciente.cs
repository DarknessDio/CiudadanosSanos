namespace CiudadanosSanos.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string genero { get; set; }
        public string TipoDocumento { get; set; }
        public int NroDocumento {  get; set; }
        public int Contacto { get; set; }
        public int edad { get; set; } 
        public ICollection<Consulta> Consultas { get; set; } //Propiedad de Navegacion
    }
}
