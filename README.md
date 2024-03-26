## Getting Stared
Hướng dẫn để khởi chạy dự án 

## Prerequisites
- .Net core 8.0.203
- IDE (Visual Studio bản Enterprise)
    (API.NET and web development and .Netdesktop development -> install while download -> install -> launch) 
- My SQL Server 2022

## Setup
- clone repository (https://github.com/lunacaoz/Project_netcore)
- Cấu hình lại chuỗi kết nối dữ liệu ( mở SQL server cài đặt sa và mật khẩu: 123456 , sau đó tạo database tên "DataNet" rồi thay đổi link ở file appsettings.json thành "Web_MVCContext": "Data Source=Tên server;Initial Catalog=DataNet;User ID=sa;Password=123456;Multiple Active Result Sets=True;Trust Server Certificate=True")
sau đó chạy 