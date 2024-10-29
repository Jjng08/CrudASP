namespace CrudASP.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateOnly FechaContrato { get; set; }
        public bool Estado { get; set; }

    }
}
