namespace MyFinalProject.Security
{
    public class PermissionsNames
    {
        public const string ClaimType = "Permission";
        // Add your permission names here
        //Employee Permissions
        public const string EmployeeView = "Employees.View";
        public const string EmployeeCreate = "Employees.Create";
        public const string EmployeeUpdate = "Employees.Update";
        public const string EmployeeDelete = "Employees.Delete";
        public const string EmployeeDetails = "Employees.Details";

        //Category Permissions
        public const string CategoryView = "Categories.View";
        public const string CategoryCreate = "Categories.Create";
        public const string CategoryUpdate = "Categories.Update";
        public const string CategoryDelete = "Categories.Delete";
        public const string CategoryDetails = "Categories.Details";

        //Department Permissions
        public const string DepartmentView = "Departments.View";
        public const string DepartmentCreate = "Departments.Create";
        public const string DepartmentEdit = "Departments.Edit";
        public const string DepartmentDelete = "Departments.Delete";
        public const string DepartmentDetails = "Departments.Details";
        //Products Permissions
        public const string ProductView = "Products.View";
        public const string ProductCreate = "Products.Create";
        public const string ProductEdit = "Products.Edit";
        public const string ProductDelete = "Products.Delete";
        public const string ProductDetails = "Products.Details";
        //Roles Permissions
        public const string RoleMangment = "Roles.Mangment";
        public const string PermissionMangment = "Permissions.Mangment";
        public const string UserMangment = "Users.Mangment";

        public static readonly string[] AllPermissions =
        {
            EmployeeView,
            EmployeeCreate,
            EmployeeUpdate,
            EmployeeDelete,
            EmployeeDetails,
            CategoryView,
            CategoryCreate, 
            CategoryUpdate,
            CategoryDelete,
            CategoryDetails,
            DepartmentView,
            DepartmentCreate,
            DepartmentEdit,
            DepartmentDelete,
            DepartmentDetails,
            ProductView,
            ProductCreate,
            ProductEdit,
            ProductDelete,
            ProductDetails,
            RoleMangment,
            PermissionMangment,
            UserMangment
        };

    }
}
