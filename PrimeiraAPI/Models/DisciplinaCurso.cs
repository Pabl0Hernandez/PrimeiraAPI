namespace PrimeiraAPI.Models
{
    public class DisciplinaCurso
    {
     public Guid DisciplinaCursoId { get; set; }
     public Guid DisciplinaId { get; set; }
     public Disciplina? Disciplina { get; set; }
     public Guid CursoId { get; set; }
     public Curso? Curso { get; set; }

    }
}
