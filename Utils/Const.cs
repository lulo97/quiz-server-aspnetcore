namespace Backend.Utils
{
    public static class Const
    {
        public static string BACKEND_PORT = Environment.GetEnvironmentVariable("BACKEND_PORT") ?? throw new Exception("BACKEND_PORT is null!");
        public static string FRONTEND_PORT = Environment.GetEnvironmentVariable("FRONTEND_PORT") ?? throw new Exception("FRONTEND_PORT is null!");

        public const string READ_FAIL = "Lấy bản ghi thất bại"; //Unknown reason
        public const string ADD_FAIL = "Thêm bản ghi thất bại"; //Unknown reason
        public const string EDIT_FAIL = "Sửa bản ghi thất bại"; //Unknown reason
        public const string DELETE_FAIL = "Xóa bản ghi thất bại"; //Unknown reason

        public const string ID_NULL = "Mã rỗng!"; //id in request is null
        public const string ID_PARAM_NOT_MATCH = "id không trùng mã bản ghi!"; //id in param not match record in body of request

        public const string NAME_NULL = "Tên trống!"; //Column Name is null
        public const string NAME_EXISTED = "Tên đã tồn tại"; //Other record already have same name
        public const string SUBJECT_ID_NULL = "Mã môn học trống"; //SubjectId is null
        public const string EDUCATION_LEVEL_ID_NULL = "Mã trình độ trống"; //EducationLevelId is null

        public const string RECORD_NOT_FOUND = "Không tìm thấy bản ghi!"; //Id is not null but find by id return null
        public const string RECORD_CONTENT_EXISTED = "Nội dung bản ghi đã tồn tại"; //Same record with same content is exist, not need to create more
    }
}
