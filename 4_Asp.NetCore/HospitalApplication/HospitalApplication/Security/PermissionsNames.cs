namespace HospitalApplication.Security
{
    public class PermissionsNames
    {
        public const string ClaimType = "Permission";

        //ADD your Permission Names Here
        public const string AppointmentView = "Appointments.View";
        public const string AppointmentCreate = "Appointments.Create";
        public const string AppointmentUpdate = "Appointments.Update";
        public const string AppointmentDelete = "Appointments.Delete";
        public const string AppointmentDetails = "Appointments.Details";

        public const string BillingView = "Billings.View";
        public const string BillingCreate = "Billings.Create";
        public const string BillingUpdate = "Billings.Update";
        public const string BillingDetails = "Billings.Details";
        public const string BillingDelete = "Billings.Delete";
        

        public const string DepartmentView = "Departments.View";
        public const string DepartmentCreate = "Departments.Create";
        public const string DepartmentUpdate = "Departments.Update";
        public const string DepartmentDetails = "Departments.Details";
        public const string DepartmentDelete = "Departments.Delete";
        

        public const string DoctorView = "Doctors.View";
        public const string DoctorCreate = "Doctors.Create";
        public const string DoctorUpdate = "Doctors.Update";
        public const string DoctorDetails = "Doctors.Details";
        public const string DoctorDelete = "Doctors.Delete";

        public const string ElectronicHealthRecordView = "ElectronicHealthRecords.View";
        public const string ElectronicHealthRecordCreate = "ElectronicHealthRecords.Create";
        public const string ElectronicHealthRecordUpdate = "ElectronicHealthRecords.Update";
        public const string ElectronicHealthRecordDetails = "ElectronicHealthRecords.Details";
        public const string ElectronicHealthRecordDelete = "ElectronicHealthRecords.Delete";

        public const string PatientView = "Patients.View";
        public const string PatientCreate = "Patients.Create";
        public const string PatientUpdate = "Patients.Update";
        public const string PatientDetails = "Patients.Details";
        public const string PatientDelete = "Patients.Delete";

        public const string PrescriptionView = "Prescriptions.View";
        public const string PrescriptionCreate = "Prescriptions.Create";
        public const string PrescriptionUpdate = "Prescriptions.Update";
        public const string PrescriptionDetails = "Prescriptions.Details";
        public const string PrescriptionDelete = "Prescriptions.Delete";


        public const string UserManagement = "Users.Management";

        public const string PermissionManagement = "Permissions.Management";

        public const string RoleManagement = "Roles.Management";
        

        public static string[] AllPermissions =
        {
            AppointmentView,
            AppointmentCreate,
            AppointmentUpdate,
            AppointmentDetails,
            AppointmentDelete,
            BillingView,
            BillingCreate, 
            BillingUpdate,
            BillingDetails,
            BillingDelete,
            DepartmentView, 
            DepartmentCreate,
            DepartmentUpdate, 
            DepartmentDetails,
            DepartmentDelete,
            DoctorView,
            DoctorCreate, 
            DoctorUpdate,
            DoctorDetails, 
            DoctorDelete,
            ElectronicHealthRecordView, 
            ElectronicHealthRecordCreate,
            ElectronicHealthRecordUpdate, 
            ElectronicHealthRecordDetails,
            ElectronicHealthRecordDelete,
            PatientView, 
            PatientCreate,
            PatientUpdate, 
            PatientDetails,
            PatientDelete,
            PrescriptionView, 
            PrescriptionCreate,
            PrescriptionUpdate,
            PrescriptionDetails,
            PrescriptionDelete,
            UserManagement,
            PermissionManagement,
            RoleManagement
        };

    }
}
