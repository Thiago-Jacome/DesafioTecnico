namespace DesafioTecnico.DTOs.Responses
{
    public class RetornoProfessorDto
    {
        public int Id { get; set; }
        public string NomeProfessor { get; set; } = string.Empty;
        public int CursoId { get; set; }
        public string NomeCurso { get; set; } = string.Empty;
    }
}
