namespace OmarOnlineStore.Security
{
    public class PermissionsNames
    {
        public const string ClaimType = "Permission";

        public const string CustomerView = "Customers.View";
        public const string CustomerCreate = "Customers.Create";
        public const string CustomerEdit = "Customers.Edit";
        public const string CustomerDelete = "Customers.Delete";
        public const string CustomerDetails = "Customers.Details";

        public const string CategoryView = "Categories.View";
        public const string CategoryCreate = "Categories.Create";
        public const string CategoryEdit = "Categories.Edit";
        public const string CategoryDelete = "Categories.Delete";
        public const string CategoryDetails = "Categories.Details";

        public const string CardItemView = "CardItems.View";
        public const string CardItemCreate = "CardItems.Create";
        public const string CardItemEdit = "CardItems.Edit";
        public const string CardItemDelete = "CardItems.Delete";
        public const string CardItemDetails = "CardItems.Details";

        public const string ProductView = "Products.View";
        public const string ProductCreate = "Products.Create";
        public const string ProductEdit = "Products.Edit";
        public const string ProductDelete = "Products.Delete";
        public const string ProductDetails = "Products.Details";

        public const string UserView = "Users.View";
        public const string UserCreate = "Users.Create";
        public const string UserEdit = "Users.Edit";
        public const string UserDelete = "Users.Delete";
        public const string UserDetails = "Users.Details";
        public const string UserAssignRole = "Users.AssignRole";

        public const string PermissionView = "Permissions.View";
        public const string PermissionCreate = "Permissions.Create";
        public const string PermissionEdit = "Permissions.Edit";
        public const string PermissionDelete = "Permissions.Delete";
        public const string PermissionDetails = "Permissions.Details";

        public const string RoleView = "Roles.View";
        public const string RoleCreate = "Roles.Create";
        public const string RoleEdit = "Roles.Edit";
        public const string RoleDelete = "Roles.Delete";
        public const string RoleDetails = "Roles.Details";
        public const string RoleAssignPermission = "Roles.AssignPermission";

        public static readonly string[] AllPermissions =
            {
               CustomerView,
               CustomerCreate,
               CustomerEdit, 
               CustomerDelete,  
               CustomerDetails,
               CategoryView,
               CategoryCreate,
               CategoryEdit,
               CategoryDelete,
               CategoryDetails,
               CardItemView, 
               CardItemCreate,
               CardItemEdit, 
               CardItemDelete, 
               CardItemDetails,
               ProductView, 
               ProductCreate, 
               ProductEdit, 
               ProductDelete,
               ProductDetails, 
               UserView,
               UserCreate, 
               UserEdit,
               UserDelete, 
               UserDetails,
               UserAssignRole,
               PermissionView, 
               PermissionCreate,
               PermissionEdit, 
               PermissionDelete,
               PermissionDetails,
               RoleView, 
               RoleCreate,
               RoleEdit,
               RoleDelete,
               RoleDetails,
               RoleAssignPermission
            };
    }
}
