using System.ComponentModel.DataAnnotations;

namespace Factory
{
    public class Usuario : Persona
    {
        public override int Id { get; set; }
        public override TipoIdentificacion TipoIdentificacion { get; set; }
        public override string Identificacion { get; set; }
        public override string Nombre { get; set; }
        public override string Apellido { get; set; }
        public override string Direccion { get; set; }
        public override string Telefono { get; set; }
        public override string Email { get; set; }

        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        public string Contraseña { get; set; }
        public Perfil Perfil { get; set; }
        
        [Display(Name = "Nombre completo")]
        public string NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }
        
    }
}
