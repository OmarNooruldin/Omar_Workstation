namespace MyFinalProject.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RoleCreateDto
    {
        public string Name { get; set; }
    }

    public class RoleUpdateDto : RoleCreateDto
    {
        public int Id { get; set; }
    }

    public class RoleWithPermissionDto : RoleDto
    {
        public string PermissionName { get; set; }
    }
}
