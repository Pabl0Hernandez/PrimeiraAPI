namespace PrimeiraAPI.Models
{
    public class AlunoCurso
    {
        // Identificador único para do registro para a associação entre Aluno e Curso
        public Guid AlunoCursoId { get; set; }

        // Chave estrangeira para o Aluno
        public Guid AlunoId { get; set; }

        // Propriedade de navegação para o Aluno
        public Aluno? Aluno { get; set; }

        // Chave estrangeira para o Curso
        public Guid CursoId { get; set; }

        // Propriedade de navegação para o Curso
        public Curso? Curso { get; set; }
    }
}
