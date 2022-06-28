namespace WebApplicationAdminLTE.Constants;

public class Permissions
{
    public static List<string> GeneratePermissionsForModule(string module)
    {
        return new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.View",
            $"Permissions.{module}.Edit",
            $"Permissions.{module}.Delete",
        };
    }
    public static class Thesis
    {
        public const string View = "Permissions.Thesis.View";
        public const string Create = "Permissions.Thesis.Create";
        public const string Edit = "Permissions.Thesis.Edit";
        public const string Delete = "Permissions.Thesis.Delete";
    }
}