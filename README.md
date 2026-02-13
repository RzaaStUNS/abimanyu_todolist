# Todo List API - Technical Test Backend (.NET)
## A.Cara Menjalankan Project
1. Pastikan database MySQL sudah berjalan (misalnya melalui XAMPP).
2. Clone repository ini:
```bash
   git clone [https://github.com/RzaaStUNS/abimanyu_todolist.git]
```

## B.Versi .NET yang Digunakan
- .NET 8.0 (x64)

## C.Cara Setup Database Migration
- Saya menggunakan MySQL dengan Entity Framework Core yang dimana Code-First Approach
- Langkah-langkah yang perlu dilakukan adalah
1. Buka file appsettings.json dan pastikan konfigurasi ConnectionStrings sudah sesuai dengan environment lokal yang digunakan (saya menggunakan localhosst dan dengan nama database di mysql todolistabim_db):
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=todolistabim_db;User=root;Password=;"
}
```
2. Buka terminal di root project, lalu jalankan perintah berikut untuk mengaplikasikan migration dan membuat database + tabel secara otomatis:
```bash
dotnet ef database update
```
3. Database todolistabim_db (nama database kalian, saya menggunakan todolistabim_db) dan tabel Todos akan otomatis terbuat di MySQL.