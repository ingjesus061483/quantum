namespace Factory
{
   public abstract class Persona
    {
        public abstract  int Id { get; set; }
        public abstract  TipoIdentificacion TipoIdentificacion { get; set; } 
        public abstract  string Identificacion { get; set; }
        public abstract  string Nombre { get; set; }
        public abstract  string Apellido { get; set; }
        public abstract  string Direccion { get; set; }
        public abstract  string Telefono { get; set; }
        public abstract string Email { get; set; }
    }
    
}
