namespace ProTrack.DOMAIN.Constants;

public static class AppConstants
{
    public static class SwaggerDocs
    {
        public const string DocName = "v1";
    }
    public static class EndpointsGroupName
    {
        public const string AuthGroupName = "auth";
    }
    public static class  SwaggerDocumentation
    {
        public const string RegisterAuthSummary = "Registrar nuevo usuario";
        public const string RegisterAuthDescription = "Crea una cuenta de usuario en el sistema. Retorna 201 si es exitoso.";
        public const string LoginAuthSummary = "Iniciar sesión de usuario";
        public const string LoginAuthDescription = "Autentica a un usuario y retorna un token JWT. Retorna 201 si es exitoso.";
    }
    public static class ResultMessages
    {
        public const string MetadataName = "Errors";
        public const string InvalidMessage = "Validation failed.";
        public const string InvalidCredentials = "Credenciales inválidas.";
        public const string LoginSuccessful = "Login exitoso.";
        public const string UserCreationFailed = "No se pudo crear el usuario.";
    }
}
