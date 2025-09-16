# RemindMe API

Backend service cho ứng dụng **RemindMe**, được xây dựng bằng **ASP.NET Core Web API** + **Entity Framework Core**.

---

## 🚀 Công nghệ sử dụng
- .NET 8 / ASP.NET Core Web API
- Entity Framework Core
- Postgre SQL (cấu hình qua `appsettings.json`)
- JWT Authentication

---

## 📂 Cấu trúc thư mục
```
RemindMeApi/
│── Controllers/     # Chứa API controllers
│── Models/          # Chứa các model
│── Data/            # DbContext + Migrations
│── Program.cs       # Entry point
│── appsettings.json # Config 
```

---

## ⚙️ Cài đặt & Chạy project
### 1. Clone repo
```bash
git clone https://github.com/nvnhat04/remindme-backend.git
cd remindme-backend
```

### 2. Cấu hình Database
Chỉnh chuỗi kết nối trong `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=RemindMeDb;User Id=sa;Password=your_password;"
}
```

### 3. Apply migrations
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run API
```bash
dotnet run
```
API mặc định chạy tại: **http://localhost:5110**

---

## 📝 API chính
### Auth
- `POST /api/auth/register` → đăng ký
- `POST /api/auth/login` → đăng nhập (trả về JWT fake)

### Documents
- `GET /api/documents` → lấy danh sách
- `GET /api/documents/{id}` → chi tiết
- `POST /api/documents` → tạo mới
- `PUT /api/documents/{id}` → cập nhật
- `DELETE /api/documents/{id}` → xóa

### User
- `GET /api/user` → lấy danh sách
- `GET /api/user/profile` → chi tiết
- `POST /api/user` → tạo mới
- `PUT /api/user/{id}` → cập nhật
- `DELETE /api/user/{id}` → xóa
---

## 🔑 Authentication
- Dùng **JWT fake** để xác thực.
- Client gửi request kèm header:
```
Authorization: Bearer <jwt_token>
```

---

## 🧪 Test nhanh bằng JSON
Ví dụ body request:
```json
{
  "title": "Tài liệu thử",
  "content": "Đây là nội dung test",
  "userId": 1
}
```


