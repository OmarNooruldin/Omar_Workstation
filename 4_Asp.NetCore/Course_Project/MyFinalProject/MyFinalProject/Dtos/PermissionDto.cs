using System.ComponentModel.DataAnnotations;

namespace MyFinalProject.Dtos
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PermissionCreateDto
    {
        public string Name { get; set; }
    }

    public class PermissionUpdateDto : PermissionCreateDto
    {
        public int Id { get; set; }
    }
}
