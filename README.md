# Web bán hàng thời trang TShop sử dụng công nghệ Asp.Net MVC
# Giao diện người dùng
- Giao diện trang chủ
![Screenshot 2024-05-17 133521](https://github.com/trantuyet762/Fashion-Website-ASP.Net-MVC/assets/119680198/9117361f-c534-4a3a-82aa-a9c08665e481)

- Giao diện đăng nhập , đăng ký

  ![Screenshot 2024-05-17 151114](https://github.com/trantuyet762/Fashion-Website-ASP.Net-MVC/assets/119680198/3c1bc362-33a7-41ef-9277-71677486f145)

  ![Screenshot 2024-05-17 151150](https://github.com/trantuyet762/Fashion-Website-ASP.Net-MVC/assets/119680198/0aba69a6-f7ce-4767-9bee-e5436e563177)

- Giao diện xem chi tiết sản phẩm như hình và bên dưới gồm 2 tab(chi tiết sản phẩm, đánh giá)

  ![Screenshot 2024-05-17 151250](https://github.com/trantuyet762/Fashion-Website-ASP.Net-MVC/assets/119680198/8f12755a-ac91-4852-a984-e13ed233a563)

#Phần đánh giá sẽ hiển thị danh sách các đánh giá, form đánh giá chỉ hiển thị khi bạn đã mua sản phẩm này(đã đăng nhập// chưa đăng nhập khi nhập đánh giá sẽ hiển thị message phải login)

  ![Screenshot 2024-05-17 151352](https://github.com/trantuyet762/Fashion-Website-ASP.Net-MVC/assets/119680198/65ffd529-e652-4586-b91b-adcfa750d399)

- Giao diện giỏ hàng

  ![Screenshot 2024-05-17 145243](https://github.com/trantuyet762/Fashion-Website-ASP.Net-MVC/assets/119680198/8cd520fe-2a6d-4f7a-9d0c-43e0173f069f)

- Giao diện thanh toán (chưa login sẽ chuyển về trang login)

  ![Screenshot 2024-05-17 145453](https://github.com/trantuyet762/Fashion-Website-ASP.Net-MVC/assets/119680198/ad0edcdc-e1ec-43a9-8a85-198fe65e5ac2)

- Giao diện xem lịch sử mua hàng
#Có thể hủy đơn hàng nếu bạn đặt hàng dưới 2 ngày, đã giao khi đơn hàng được giao đến bạn, còn lại đang giao

  ![Screenshot 2024-05-17 150930](https://github.com/trantuyet762/Fashion-Website-ASP.Net-MVC/assets/119680198/f1daba56-b234-404d-ab2b-a7cea47b3790)

# Giao diện Admin ( không chụp những trang nhỏ lẻ khác)
- Giao diện trang danh sách sản phẩm (số lượng, màu, size ở bảng khác liên kết với bảng sản phẩm)
   
  ![Screenshot 2024-05-17 151517](https://github.com/trantuyet762/Fashion-Website-ASP.Net-MVC/assets/119680198/23ffb77e-2d4f-40fc-beee-ef3eeb8db641)

- Giao diện trang đơn hàng

#Kích vào chi tiết sẽ hiển thị trang chi tiết đơn hàng, nút cập nhật sẽ cập nhật trạng thái gồm chưa giao hàng, đã giao, hoàn thành

##Option Hoàn thành khi kích vào lựa chọn này mặc định đơn hàng đã giao =>> phía giao diện người dùng đơn hàng này sẽ chuyển về đã giao

#Còn 1 nút Hủy bên cạnh nút cập nhật (chỉ admin mới hủy được, nhân viên không có quyền hủy)
  ![Screenshot 2024-05-17 151616](https://github.com/trantuyet762/Fashion-Website-ASP.Net-MVC/assets/119680198/ad724507-0a96-4eb9-a6c3-7bedee37bb99)

- Giao diện trang thống kê

  ![Screenshot 2024-05-17 151817](https://github.com/trantuyet762/Fashion-Website-ASP.Net-MVC/assets/119680198/954d71d3-abe6-4738-90b7-c1c824db8f53)

# Những hạn chế của trang web
- Phía người dùng
  + Trang chi tiết sản phẩm khi thêm sản phẩm vào giỏ hàng đã giới hạn số lượng đặt của sản phẩm, bên trang giỏ hàng vẫn chưa làm giới hạn số lượng (khi kích nút + số lượng vẫn tăng lên tùy chọn)
  + Khi đặt hàng thành công số lượng của sản phẩm không bị trừ đi
  + Phần thanh toán bằng thẻ ngân hàng dù thanh toán thành công hay thất bại vẫn sẽ tạo ra đơn hàng mới

- Phía admin
  + Trang đơn hàng chưa được tối ưu, khi kích vào trạng thái hoàn thành chưa ẩn nút cập nhật lại
  + Phần thống kê chỉ thống kê theo ngày
# sẽ dần update lại trang web, sửa lại các lỗi..
