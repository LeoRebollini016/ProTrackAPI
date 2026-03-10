namespace ProTrack.DOMAIN.Constants.Constants;

public static class AppConstants
{
    public static class SwaggerDocs
    {
        public const string DocName = "v1";
    }
    public static class EndpointsGroupName
    {
        public const string AuthGroupName = "auth";
        public const string ProjectsGroupName = "projects";
    }
    public static class AssembliesConstants
    {
        public const string Application = "ProTrack.APPLICATION";
    }
    public static class  SwaggerDocumentation
    {
        public const string RegisterAuthSummary = "Registrar nuevo usuario";
        public const string RegisterAuthDescription = "Crea una cuenta de usuario en el sistema. Retorna 201 si es exitoso.";
        public const string LoginAuthSummary = "Iniciar sesión de usuario";
        public const string LoginAuthDescription = "Autentica a un usuario y retorna un token JWT. Retorna 201 si es exitoso.";
        public const string CreateProjectSummary = "Crea un nuevo proyecto";
        public const string CreateProjectDescription = "Este endpoint permite a un usuario autorizado crear un nuevo proyecto. Retorna 201 si es exitoso.";
        public const string AddMembersSummary = "Agregar miembros a un proyecto";
        public const string AddMembersDescription = "Permite agregar uno o más miembros a un proyecto existente. Retorna 200 si es exitoso.";
        public const string UpdateRoleMemberSummary = "Actualizar el rol de un miembro";
        public const string UpdateRoleMemberDescription = "Permite actualizar el rol de un miembro en un proyecto. Retorna 204 si es exitoso";
        public const string RemoveMemberSummary = "Eliminar a un miembro del proyecto.";
        public const string RemoveMemberDescription = "Permite eliminar a un miembro del proyecto. Retorna 204 si es exitoso.";
        public const string CreateTaskSummary = "Crear una nueva tarea en un proyecto";
        public const string CreateTaskDescription = "Permite crear una nueva tarea en un proyecto. Retorna 201 si es exitoso.";
    }
    public static class ResultMessages
    {
        public const string MetadataName = "Errors";
        public const string InvalidMessage = "Validation failed.";
        public const string UnauthorizedAction = "No tienes permisos para realizar esta acción.";
        public const string AlreadyExists = "Ya existe un registro: '{0}'.";
        public const string DuplicateInList = "Se detectaron elementos duplicados en la lista {0}.";
        public const string NotFound = "El registro '{0}' no fue encontrado.";
    }
    public static class ExceptionMessages
    {
        public const string UnexpectedError = "Ocurrió un error inesperado. Por favor, inténtalo de nuevo más tarde.";
        public const string UnexpectedErrorDetail = "Error inesperado: {0}. Inténtalo de nuevo más tarde.";
    }
    public static class ValidationMessages
    {
        public const string RequiredField = "El campo es requerido.";
        public const string MaxLength = "El campo no puede superar los {1} caracteres.";
        public const string InvalidFormat = "El campo tiene un formato inválido.";
    }
    public static class AuthConstants
    {
        public const string UserTable = "users";
        public const string UserCreationFailed = "No se pudo crear el usuario.";
        public const string InvalidCredentials = "Credenciales inválidas.";
    }
    public static class ProjectConstants
    {
        public const string ProjectTable = "projects";
        public const string TitleColumn = "title";
        public const string UserNotExist = "Uno de los usuarios no existe.";
        public const string ProjectNonTransferable = "No esta permitido transferir la propiedad del proyecto.";
    }
    public static class DomainConstants
    {
        public const string EntityNotFound = "NotFound";
        public const string CompletedProject = "No se puede modificar un proyecto completado.";
        public const string UserNotMember = "El usuario no es miembro activo del proyecto.";
    }
}
